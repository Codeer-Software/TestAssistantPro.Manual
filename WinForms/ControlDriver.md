# ControlDriver

ControlDriverはその名の通り、ButtonやTextBoxなどControlに対応するドライバです。<br>
多くの物は使いまわすことができます。<br>
TestAssistantPro を使ってWinFormsのテストプロジェクトを作成すると以下のパッケージがインストールされ<br>
それぞれに定義されているコントロールドライバとキャプチャジェネレータが使えるようになります。<br>
コントロールドライバの種類はそれぞれのリンクを参照してください。<br>

+ [Ong.Frinedly.FormsStandardControls](https://github.com/ShinichiIshizuka/Ong.Friendly.FormsStandardControls)
+ [Codeer.Friendly.Windows.NativeStandardControls](https://github.com/Codeer-Software/Friendly.Windows.NativeStandardControls)

また、WinFormsのサードパーティ製のコントロールで<br>
GrapeCity社のC1FlexGridとSpreadに対するドライバもOSSで公開しています。<br>
+ [Friendly.C1.Win](https://github.com/Codeer-Software/Friendly.C1.Win)
+ [Friendly.FarPoint](https://github.com/Codeer-Software/Friendly.FarPoint)

しかし、世の中には大量の3rdパーティ製のコントロールがあり、さらには各プロジェクト固有のコントロールも存在します。<br>
TestAssistantPro はそのような場合でもそれぞれに対する ControlDriver と CaptureGenerator を実装することで対応することが可能です<br>
ControlDriverはFriendlyの基本機能を使うことで簡単に実装することができます。<br>
[こちら](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md#controldriver)でも説明していますので参照お願いします。<br>
TestAssistantProでAnalyzeWindowに認識させてWindowDriverを作るときに表示する場合はControlDriverAttribute属性を付けます。
Ong.Friendly.FormsStandardControlsのFormsCheckBoxを例にすると以下のようになっています。
```cs
//対応するコントロールを指定することでTestAssistantProでCheckBoxを選択したときにこのクラスが割り当たります
[ControlDriver(TypeFullName = "System.Windows.Forms.CheckBox")]
public class FormsCheckBox : FormsControlBase
{

```
また同一のコントロールに対して複数の ControlDriver を割り当てることも可能です。その場合 Priority を指定すると高い方が優先的に選択されます。
```cs
[ControlDriver(TypeFullName = "System.Windows.Forms.CheckBox", Priority = 1)]
public class FormsCheckBoxEx : FormsCheckBox
{

```

# Capture Code Generator
ControlDriver は手動で Friendly を使ったテストを書く時にも作成するものですが<br>
キャプチャジェネレータはTestAssistantProを使うときだけ出てくるユーティリティクラスです。<br>
ControlDriver に対応する CaptureCodeGenerator を作っておくと TestAssistantPro でキャプチャ時に操作からコードを作成できます。<br>
ControlDriver との紐づけは CaptureCodeGeneratorAttribute で行います。<br>
また CaptureCodeGeneratorBase を継承しておく必要があります。<br>
CaptureCodeGenerator は Capture 時に対象プロセス内に生成され、最初に Attach() が呼び出されます。<br>
そこでイベントに接続してイベントが発生したときに生成したコードをAddSentenseで追加します。<br>
例えば CheckBox の CaptureCode の実装は以下のようなものです。<br>

```cs
using System;
using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Ong.Friendly.FormsStandardControls.Generator
{
    [CaptureCodeGenerator("Ong.Friendly.FormsStandardControls.FormsCheckBox")]
    public class FormsCheckBoxGenerator : CaptureCodeGeneratorBase
    {
        CheckBox _control;
        
        protected override void Attach()
        {
            _control = (CheckBox)ControlObject;
            _control.CheckStateChanged += CheckStateChanged;
        }
        
        protected override void Detach()
        {
            _control.CheckStateChanged -= CheckStateChanged;
        }
        
        void CheckStateChanged(object sender, EventArgs e)
        {
            //フォーカスがあるときだけコードを生成する
            if (!_control.Focused) return;

            //追加で必要なネームスペースを登録
            AddUsingNamespace(typeof(CheckState).Namespace);
            //コードを追加
            AddSentence(new TokenName(), ".EmulateCheck(CheckState." + _control.CheckState, new TokenAsync(CommaType.Before), ");");
        }
    }
}
```
AddSentence は引数で渡されたオブジェクトを接続したコードを登録します。
通常のオブジェクトは ToString() で文字列にしたものになりますが、
一部特殊な置換が行わるクラスがあります。

|  Token  |  説明  |
| ---- | ---- |
|  TokenName  |  現在選択されている名前になります。  |
|  TokenSeparator  |  空行になります。複数個連続で登録されている場合は一行にまとめられます。  |
|  TokenAsync  |  その操作によりモーダルダイアログが表示された場合はAsyncのオブジェクトが入ります。引数なのでカンマの挿入に関して前後もしくは無しが引数で設定できます。  |

# 演習
## AnalyzeWindow から ControlDriver と CaptureGenerator を作成する
ここではサンプルとしてBlockControlのControlDriverとCaptureGeneratorを作ってみます。<br>
MainFrameのメニュー -> etc -> Custom Control Dialog を実行すると表示されます。<br>
Addボタンを押すとブロックが追加されます。<br>
BlockControlの機能としてはブロックをドラッグで移動させることができます。<br>
![ControlDriver.BlockControl.png](Img/ControlDriver.BlockControl.png)

まずは AnalyzeWindow を使ってテンプレートを作成します。<br>
作らいたいコントロールをツリーで選んで右クリックから Create Control Driver を実行してください。<br>
![ControlDriver.CreateControlDriver.png](Img/ControlDriver.CreateControlDriver.png)

ダイアログからControlDriverを選択しDriverプロジェクトの任意のフォルダにドロップします。<br>
どこでも良いのですが、今回はControlsというフォルダを作ってそこにドロップしました。
次にCaptureGeneratorを選択しDriver.InTargetの任意のフォルダにドロップします。<br>
![ControlDriver.CreateControlDriver.Drop.png](Img/ControlDriver.CreateControlDriver.Drop.png)

### ControlDriver 実装
これは [BlockControl]() と [Frinedly]()の知識があれば簡単に実装できます。<br>
BlockCotrolはプロダクトのコードなのでその開発チームなら知っているはずです。<br>
この実装は基本は開発チームに行ってもらうのが費用対効果が良いでしょう。<br>
BlockControlDriverの公開APIの仕様は自由に決定してかまいません。<br>
Ong.Friendly.FormsStandardControlの設計に合すならば<br>
変更を及ぼす操作はメソッドでつくりEmulateプレフィックスを付けます。<br>
今回はこのようにします。<br>

```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System.Drawing;

namespace Driver.Controls
{
    //実装するにはBlockControlのAPIを知っている必要がある
    [ControlDriver(TypeFullName = "WinFormsApp.BlockControl", Priority = 2)]
    public class BlockControlDriver : FormsControlBase
    {
        public BlockControlDriver(AppVar appVar)
            : base(appVar) { }

        //選択インデックス
        public int SelectedIndex => this.Dynamic().SelectedIndex;

        //選択変更
        public void EmulateChangeSelectedIndex(int index) => this.Dynamic().SelectedIndex = index;

        //移動
        public void EmulateMoveBlock(int index, Point location) => this.Dynamic().MoveBlock(index, location);
    }
}
```

### キャプチャジェネレータの実装
イベントを受ける必要があるのでBlockControlが定義されているアセンブリを参照します。具体的にはWinFormApp.exeを参照します。<br>
リフレクションを駆使すれば参照無しでも可能ですが、難易度があがるので説明を省きます。<br>
必要でしたらFriendly.XamControlsで実装していますので[こちら](https://github.com/Codeer-Software/Friendly.XamControls/blob/master/Project/Friendly.XamControls.Generator/XamComboEditorDriverGenerator.cs)を参照お願いします。<br>

```cs
using System;
using System.Drawing;
using Codeer.TestAssistant.GeneratorToolKit;
using WinFormsApp;

namespace Driver.InTarget
{
    [CaptureCodeGenerator("Driver.Controls.BlockControlDriver")]
    public class BlockControlDriverGenerator : CaptureCodeGeneratorBase
    {
        BlockControl _control;

        protected override void Attach()
        {
            _control = (BlockControl)ControlObject;
            _control.SelectChanged += SelectChanged;
            _control.BlockMoved += BlockMoved;
        }

        protected override void Detach()
        {
            _control.SelectChanged -= SelectChanged;
            _control.BlockMoved -= BlockMoved;
        }

        void SelectChanged(object sender, EventArgs e)
        {
            if (!_control.Focused) return;
            AddSentence(new TokenName(), ".EmulateChangeSelectedIndex(" + _control.SelectedIndex, new TokenAsync(CommaType.Before), ");");
        }

        void BlockMoved(object sender, BlockMoveEventArgs e)
        {
            if (!_control.Focused) return;
            AddUsingNamespace(typeof(Point).Namespace);
            AddSentence(new TokenName(), ".EmulateMoveBlock(" + _control.SelectedIndex, $", new Point({e.MoveLocation.X}, {e.MoveLocation.Y})", new TokenAsync(CommaType.Before), ");");
        }
    }
}
```

### 使ってみる
ウィンドウドライバを作成します。<br>
するとPickupChildrenでコントロールドライバが割り当たります。<br>
![CreateDriver.AssignBlockControlDriver.png](Img/CreateDriver.AssignBlockControlDriver.png)
キャプチャしてみます。<br>
![CreateDriver.BlockControlDriver.Capture.png](Img/CreateDriver.BlockControlDriver.Capture.png)

### デバッグする
上手く動かない場合はデバッグして問題を見つけます。<br>
対象プロセス内で動いているので対象プロセスをデバッグする必要があります。<br>
Attachにブレイクポイントを貼ってShiftキーを押しながらCaptureを実行してみてください。


------------------------------------------
TODO
CaptureSettingAttribute
ドッキングの閉じるに対するドライバ

