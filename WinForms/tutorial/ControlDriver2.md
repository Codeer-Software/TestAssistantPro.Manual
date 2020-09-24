## ControlDriverの実装

BlockControlはSelectIndexという現在選択されているブロックのインデックスを取得または設定するプロパティを公開しています。
また、MoveBlockというメソッドも公開しているため、このドライバではその2つを実装します。

生成したControlDriverのコードテンプレートを次のように変更してください。

プロセスを超えたプロパティやメソッドの操作にはFriendlyを使っています。詳細は[Friendly](https://github.com/Codeer-Software/Friendly/blob/master/README.jp.md)を参照してください。
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

## CaptureCodeGeneratorの実装

次にBlockControlのCaptureCodeGeneratorをコードテンプレートを編集して作成します。
イベントを受ける必要があるので BlockControl が定義されている WinFormApp.exe を参照します。
コードテンプレートを次のように変更してください。

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

## 注意
Driver.InTarget.dllは対象プロセス内部で動作します。そのため対象プロセスにアタッチした後、そのプロセスが起動している間にビルドしようとしてもdllファイルは対象プロセスが握っている状態なのでビルドできません。ビルドする場合は対象プロセスを一度終了させてください。

## ControlDriverとCaptureCodeGeneratorの利用

作成したControlDriverとCaptureCodeGenaratorを利用してコードを生成します。
通常の手順でWindowDriverを作成してください。UI解析ツリーからBlockControlを選択することで、グリッドに作成したBlockControlDriverを利用したプロパティが追加されることを確認できます。

![CreateDriver.AssignBlockControlDriver.png](../Img/CreateDriver.AssignBlockControlDriver.png)

WindowDriverを作成してキャプチャも行ってください。操作を行うことでCaptureCodeGeneratorを利用してコードが生成されることを確認できます。

![CreateDriver.BlockControlDriver.Capture.png](../Img/CreateDriver.BlockControlDriver.Capture.png)

### デバッグ

うまく動かない場合はデバッグして問題を見つけます。
Attach にブレークポイントを貼って Shift キーを押しながら Capture を実行してみてください。

## 次の手順
[[DockContentの閉じるに反応するようにする](ControlDriver3.md)
