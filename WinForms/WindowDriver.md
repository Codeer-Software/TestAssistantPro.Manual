# WindowDriver/UserControlDriverの作成

ここでは WindowDriver/UserControlDriver の作成方法に関して説明します。
WindowDriver/UserControlDriver に関しては[こちら](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md)を参照お願いします。

# AnalyzeWindow
AnalyzeWindow は対象のアプリを解析して WindowDriver を作成するものです。
ツリーのルートのコントロールに対して WindowDriver を作成します。
Designer タブの設定でコードを作ります。
現在の設定で生成されるコードは Current Code タブでプレビューを見ることができます。

### 起動
Driver/Windowsフォルダで右クリックから Analyze Window を選択してください。

![WindowDriver.Start.png](Img/WindowDriver.Start.png)

これはどこのフォルダでも可能です。ドライバを生成したときに指定のフォルダに生成されます。
対象アプリを選択する画面が出ますので、対象を選択してください。

![WindowDriver.SelectTarget.png](Img/WindowDriver.SelectTarget.png)

ここで選択するとFriendlyの機能によって対象アプリにFriendly系のdllとDriver.InTarget.dllがインジェクションされます。
間違ったアプリを選択するとOSの再起動が必要になる場合がありますので間違えないように選択してください。
二回目以降はこれが表示されずに同一のアプリに対して Analyze Window が実行されます。
途中で対象アプリを変えたい場合は Select Target を実行すると対象を変更することができます。

![WindowDriver.TreeSelect.png](Img/WindowDriver.TreeSelect.png)

### Tree
コントロールを選択します。
ツリーで選択すると対象アプリの対応するコントロールが赤枠で囲まれます。
Ctrlキーを押しながら対象のアプリのコントロールにマウスを持っていくとツリーの対応するノードが選択されます。

* ダブりクリック
    * WindowDriver のプロパティとして登録したいコントロールをダブルクリックすると右側のグリッドに登録されます。

* 右クリックメニュー
    * Pickup<br>
        選択している要素が右側のグリッドに登録されます。<br>
    * Pickup Children <br>
        指定したコントロールの子孫のコントロールでドライバが割り当たっているものを一括でピックアップしてグリッドに登録します。<br>
        子孫をたどるときにUserControlを発見した場合はそれ以下は検索しません。<br>
        それ以下のコントロールもグリッドに登録したい場合はそのUserControlを選択し再度Pickup Childrenを実行してください。<br>
    * Create Control Driver<br>
        コントロールドライバを作成します。<br>
        詳細はこちらで説明します。<br>
    * Show Base Class<br>
        選択したコントロールの親クラスをアウトプットウィンドウに表示します。<br>
    * Expand All<br>
        ツリーを全て開きます。<br>
    * Close All<br>
        ツリーをすべて閉じます。<br>
    ※右クリックメニューはカスタマイズできます。詳しくは[こちら](Customize.md#Treeのコンテキストメニューの拡張)

### メニュー
* Display Mode <br>
    * Control<br>
        表示モードです。Control.Controlsを元にしたツリーを表示します。デフォルトはこちらです。<br>
    * Field<br>
    * Filter Window And UserControl<br>

* Tree Update<br>
    * Auto Update<br>
        Treeを更新するタイミングを設定します。通常はONで使ってください。あまりにも画面の要素が頻繁に更新される場合は動作が重くなるのでチェックをOFFにしてください。<br>
    * Update Now<br>
        Treeを更新します。<br>
    * Sync with Visual Studio<br>

* Tool<br>
    * Compile & update<br>
    * Option<br>

### Designerタブ
* Type<br>
    コントロールのタイプフルネームが表示されます。<br>
* Assigned Driver<br>
    割り当たってるDriverのタイプフルネームが表示されます。<br>
* Class Name<br>
    作成するWindowDriver/UserControlDriverの名前です。<br>
    ネームスペースはAnalyzeWindowを始めたフォルダになります。<br>
* Create Attach Code<br>
    AttachMethodを作るか否かです。<br>
* Extension<br>
    Attachする対象クラスです。<br>
* Method<br>
    特定方法です。<br>
    * Type Full Name
        .NetのTypeFullNameで特定します。<br>
    * Window Text<br>
        Win32のWindowTextで特定します。<br>
    * Variable Window Text<br>
        WindowTextから特定しますが常に同じWindowTextでない場合に使います。<br>
    * Custom<br>
        カスタムの特定手法です。<br>

* Many Exists<br>
    複数存在する場合があるかです。<br>

* Grid<br>
    WindowDriver/UserControlDriverの子要素です。<br>
    Treeから選択します。<br>

### Current Code タブ
Designer タブでの設定によって出力されるコードが表示されます。

### Propertyタブ
選択しているコントロールのプロパティが表示されます。

### Outputタブ
メニューによって実行した結果が表示されます。

# コード
//WindowDriverで説明
UserControlDriverAttribute
UserControlDriverIdentifyAttribute

WindowDriverAttribute
WindowDriverIdentifyAttribute


# デバッグ
Logger
TestAssistantMode

# 演習
先ほどのサンプルアプリのドライバを作ります。
MainFormは少し複雑なので後に回します。
まずはシンプルなダイアログで操作に慣れていきます。

## Simple Dialog
MainFrameのメニュー -> etc -> Simple Dialog を実行してください。
表示されたダイアログを解析します。
これはシンプルな作りのダイアログなのでツリーのルートで右クリックメニューを表示して Pickup Children を実行します。
そうするとグリッドに ControlDriver の割り当たった要素がピックアップされます。
名前はデフォルトでは変数名になっていますが、変更することができます。
ラベルは Pickup Chidlren では無視されますが、必要ならツリーの要素をダブルクリックすることにより追加で登録できます。
必要な要素を登録したら Generate ボタンを押してコードを生成します。
Create Attach Code は下図のようにデフォルトの状態で生成してください。

![WindowDriver.SimpleDialog.png](Img/WindowDriver.SimpleDialog.png)
```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver.Windows
{
    [WindowDriver(TypeFullName = "WinFormsApp.SimpleForm")]
    public class SimpleFormDriver
    {
        public WindowControl Core { get; }
        public FormsButton _buttonCancel => Core.Dynamic()._buttonCancel; 
        public FormsButton _buttonOK => Core.Dynamic()._buttonOK; 
        public FormsRichTextBox _richTextBoxRemarks => Core.Dynamic()._richTextBoxRemarks; 
        public FormsComboBox _comboBoxLanguage => Core.Dynamic()._comboBoxLanguage; 
        public FormsDateTimePicker _dateTimePickerBirthday => Core.Dynamic()._dateTimePickerBirthday; 
        public FormsTextBox _textBoxName => Core.Dynamic()._textBoxName; 

        public SimpleFormDriver(WindowControl core)
        {
            Core = core;
        }

        public SimpleFormDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class SimpleFormDriverExtensions
    {
        [WindowDriverIdentify(TypeFullName = "WinFormsApp.SimpleForm")]
        public static SimpleFormDriver AttachSimpleForm(this WindowsAppFriend app)
            => app.WaitForIdentifyFromTypeFullName("WinFormsApp.SimpleForm").Dynamic();
    }
}
```

生成できたらキャプチャを試してみます。
Analyze Window を閉じて Scenario/Test.csのTestMethod1で右クリックして Capture を実行してください。

![WindowDriver.CaptureStart.png](Img/WindowDriver.CaptureStart.png)

![WindowDriver.Capture.SimpleDialog.png](Img/WindowDriver.Capture.SimpleDialog.png)

## Multi UserControl Dialog
今度は UserContorl の入っている Form のドライバを作成します。
このFormには二つの UserContorl が入っています。

![UserControlDriver.Analyze.png](Img/UserControlDriver.Analyze.png)

UserControl はそれに対して UserControlDriver を作ることができます。
右側の ReservationInformationUserControl のドライバを作ってみます。
ツリー上で ReservationInformationUserControl を選択し右クリックから Change The Analysis Target を選択します。
それによって解析対象が切り替わります。
必要なコントロールを Designer に登録して Generate ボタンでコードを生成します。

![UserControlDriver.ChangeTheAnalysisTarget.png](Img/UserControlDriver.ChangeTheAnalysisTarget.png)

```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "WinFormsApp.ReservationInformationUserControl")]
    public class ReservationInformationUserControlDriver
    {
        public WindowControl Core { get; }
        public FormsRadioButton _radioButtonAlacarte => Core.Dynamic()._radioButtonAlacarte; 
        public FormsRadioButton _radioButtonCourse => Core.Dynamic()._radioButtonCourse; 
        public FormsNumericUpDown numericUpDown1 => Core.Dynamic().numericUpDown1; 
        public FormsCheckBox _checkBoxSmoking => Core.Dynamic()._checkBoxSmoking; 

        public ReservationInformationUserControlDriver(WindowControl core)
        {
            Core = core;
        }

        public ReservationInformationUserControlDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }
}
```
ReservationInformationUserControl のコードを生成したら今度は Form の方に戻ります。
ChargeOfPartyUserControl の方もドライバを作成しても良いのですが、
今回はこちらはドライバは作らずに Form に直接 UserControl の要素を配置するようにします。
（あくまで演習のためで、本来は場合によって使い分けてください）

![UserControlDriver.Form.png](Img/UserControlDriver.Form.png)

```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver.Windows
{
    [WindowDriver(TypeFullName = "WinFormsApp.MultiUserControlForm")]
    public class MultiUserControlFormDriver
    {
        public WindowControl Core { get; }
        public ReservationInformationUserControlDriver reservationInformationUserControl1
             => new ReservationInformationUserControlDriver(Core.Dynamic().reservationInformationUserControl1); 
        public FormsTextBox _textBoxTel => Core.Dynamic().chargeOfPartyUserControl1._textBoxTel; 
        public FormsTextBox _textBoxName => Core.Dynamic().chargeOfPartyUserControl1._textBoxName; 

        public MultiUserControlFormDriver(WindowControl core)
        {
            Core = core;
        }

        public MultiUserControlFormDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class MultiUserControlFormDriverExtensions
    {
        [WindowDriverIdentify(TypeFullName = "WinFormsApp.MultiUserControlForm")]
        public static MultiUserControlFormDriver AttachMultiUserControlForm(this WindowsAppFriend app)
            => app.WaitForIdentifyFromTypeFullName("WinFormsApp.MultiUserControlForm").Dynamic();
    }
}
```
## MainForm
MainForm は複数のドッキングウィンドウが乗っています。
ここでは MainForm はメニューだけを持つウィンドウと考えます。

![WindowDriver.MainFrame.png](Img/WindowDriver.MainFrame.png)

```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver.Windows
{
    [WindowDriver(TypeFullName = "WinFormsApp.MainForm")]
    public class MainFormDriver
    {
        public WindowControl Core { get; }
        public FormsToolStrip _menuStrip => Core.Dynamic()._menuStrip; 

        public MainFormDriver(WindowControl core)
        {
            Core = core;
        }

        public MainFormDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class MainFormDriverExtensions
    {
        [WindowDriverIdentify(TypeFullName = "WinFormsApp.MainForm")]
        public static MainFormDriver AttachMainForm(this WindowsAppFriend app)
            => app.WaitForIdentifyFromTypeFullName("WinFormsApp.MainForm").Dynamic();
    }
}
```

## TreeFormとOutputForm
TreeForm と OutputForm は UserControlDriver として作成します。
これはAttach方式にします。
Attach対象は MainFromDriver ではなく WindowsAppFrined (アプリケーション全体)にします。
これはフローティング状態にするなど様々な状態を作ることができるからです。
まずは TreeForm の UserControlDriver を作ります。
Formの見つけ方ですがCtrlキーを押しながら Tree の上にマウスを持っていきます。
そうすると TreeView が AnalyzeWindow の上で選択状態になります。
Tree の一つ親を見ると TreeForm になっているのでそのノードの上で Change The Analysis Target を実行します。
TreeView を子要素に登録します。
そして Create Attach Code にチェックを付けて Extension を WindowsAppFriend にします。

![WindowDriver.TreeForm.png](Img/WindowDriver.TreeForm.png)

```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "WinFormsApp.TreeForm")]
    public class TreeFormDriver
    {
        public WindowControl Core { get; }
        public FormsTreeView _treeView => Core.Dynamic()._treeView; 

        public TreeFormDriver(WindowControl core)
        {
            Core = core;
        }

        public TreeFormDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class TreeFormDriverExtensions
    {
        [UserControlDriverIdentify()]
        public static TreeFormDriver AttachTreeForm(this WindowsAppFriend app)
            => app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WinFormsApp.TreeForm")).SingleOrDefault()?.Dynamic();
    }
}
```
Output も同様に作成します。
```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "WinFormsApp.OutputForm")]
    public class OutputFormDriver
    {
        public WindowControl Core { get; }
        public FormsTextBox _textBoxResult => Core.Dynamic()._textBoxResult; 
        public FormsToolStrip _toolStrip => Core.Dynamic()._toolStrip; 

        public OutputFormDriver(WindowControl core)
        {
            Core = core;
        }

        public OutputFormDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class OutputFormDriverExtensions
    {
        [UserControlDriverIdentify()]
        public static OutputFormDriver AttachOutputForm(this WindowsAppFriend app)
            => app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WinFormsApp.OutputForm")).SingleOrDefault()?.Dynamic();
    }
}
```

## Document
Document は同じタイプのものが複数存在します。
Many Exists を使うこともできますが、今回は取得方法を VariableWindowText にします。
これも WindowsAppFriend の拡張メソッドにします。

![WindowDriver.Document.png](Img/WindowDriver.Document.png)

```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "WinFormsApp.OrderDocumentForm")]
    public class OrderDocumentFormDriver
    {
        public WindowControl Core { get; }
        public FormsButton _searchButton => Core.Dynamic()._searchButton;
        public FormsTextBox _searchTextBox => Core.Dynamic()._searchTextBox;
        public FormsDataGridView _grid => Core.Dynamic()._grid;

        public OrderDocumentFormDriver(WindowControl core)
        {
            Core = core;
        }

        public OrderDocumentFormDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class OrderDocumentFormDriverExtensions
    {
        [UserControlDriverIdentify(CustomMethod = "TryGet")]
        public static OrderDocumentFormDriver AttachOrderDocumentForm(this WindowsAppFriend app, string text)
            => app.GetTopLevelWindows().SelectMany(e=>e.GetFromTypeFullName("WinFormsApp.OrderDocumentForm")).Where(e=>(string)e.Dynamic().Text == text).SingleOrDefault()?.Dynamic();

        public static void TryGet(this WindowsAppFriend parent, out string[] texts)
            => texts = parent.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WinFormsApp.OrderDocumentForm")).Select(e => (string)e.Dynamic().Text).ToArray();

    }
}
```

## ネイティブのウィンドウに関して
.Netで実装していても以下のウィンドウはネイティブのものが使われます。
これらのドライバは新規作成時に Driver/Windows/Native 以下に作成されています。

|  Window  |  Driver  |
| ---- | ---- |
| MessageBox | MessageBoxDriver |
| OpenFileDialog | OpenFileDialogDriver |
| SaveFileDialog | SaveFileDialogDriver |
| FolderBrowserDialog | FolderDialogDriver |

## 生成済みのドライバのメンテ
生成済みのドライバに関しては基本は手でメンテになります。プロパティの名前変更などもVisualStudioのリファクタリング機能を使って自由にできます。
ただ AnalyzeWindow を使った方が楽な場合もあります。コントロールドライバを付け足したい場合やAttach方法を変更したい場合はAnalyzeWindowで目的の状態にして Current Code から必要なコードをコピーして元のコードに貼り付けてください。

