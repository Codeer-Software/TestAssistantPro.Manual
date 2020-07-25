# WindowDriver/UserControlDriverの作成

ここではWindowDriver/UserControlDriverの作成方法に関して説明します。<br>
WindowDriver/UserControlDriverに関しては[こちら](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md)を参照お願いします。<br>

# AnalyzeWindow
AnalyzeWindowは対象のアプリを解析してWindowDriverを作成するものです。<br>
ツリーのルートのコントロールに対してWindowDriverを作成します。<br>
Designerタブの設定でコードを作ります。<br>
現在の設定で生成されるコードは Current Code タブでプレビューを見ることができます。<br>

### 起動
Driver/Windowsフォルダで右クリックから Analyze Window を選択してください。<br>
![WindowDriver.Start.png](Img/WindowDriver.Start.png)

これはどこのフォルダでも可能です。ドライバを生成したときに指定のフォルダに生成されます。<br>
対象アプリを選択する画面が出ますので、対象を選択してください。<br>
![WindowDriver.SelectTarget.png](Img/WindowDriver.SelectTarget.png)

ここで選択するとFriendlyの機能によって対象アプリにFriendly系のdllとDriver.InTarget.dllがインジェクションされます。<br>
間違ったアプリを選択するとOSの再起動が必要になる場合がありますので間違えないように選択してください。<br>
二回目以降はこれが表示されずに同一のアプリに対して Analyze Window が実行されます。<br>
途中で対象アプリを変えたい場合は Select Target を実行すると対象を変更することができます。<br>

### Tree
![WindowDriver.TreeSelect.png](Img/WindowDriver.TreeSelect.png)
コントロールを選択します。<br>
ツリーで選択すると対象アプリの対応するコントロールが赤枠で囲まれます。<br>
Ctrlキーを押しながら対象のアプリのコントロールにマウスを持っていくとツリーの対応するノードが選択されます。<br>

* ダブりクリック
    * WindowDriverのプロパティとして登録したいコントロールをダブルクリックすると右側のグリッドに登録されます。

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

    ※右クリックメニューはカスタマイズできます。詳しくは[こちら]()

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
Designerタブでの設定によって出力されるコードが表示されます。

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
先ほどのサンプルアプリのドライバを作ります。<br>
MainFormは少し複雑なので後に回します。<br>
まずはシンプルなダイアログで操作に慣れていきます。<br>

## Simple Dialog
MainFrameのメニュー -> etc -> Simple Dialog を実行してください。<br>
表示されたダイアログを解析します。<br>
これはシンプルな作りのダイアログなのでツリーのルートで右クリックメニューを表示して Pickup Children を実行します。<br>
そうするとグリッドにControlDriverの割り当たった要素がピックアップされます。<br>
名前はデフォルトでは変数名になっていますが、変更することができます。<br>
ラベルは Pickup Chidlren では無視されますが、必要ならツリーの要素をダブルクリックすることにより追加で登録できます。<br>
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

生成できたらキャプチャを試してみます。<br>
Analyze Window を閉じて Scenario/Test.csのTestMethod1で右クリックして Capture を実行してください。<br>
![WindowDriver.CaptureStart.png](Img/WindowDriver.CaptureStart.png)
![WindowDriver.Capture.SimpleDialog.png](Img/WindowDriver.Capture.SimpleDialog.png)

## Multi UserControl Dialog
今度はUserContorlの入っているFormのドライバを作成します。<br>
このFormには二つのUserContorlは入っています。<br>
![UserControlDriver.Analyze.png](Img/UserControlDriver.Analyze.png)

UserControlはそれに対してUserControlDriverを作ることができます。<br>
右側のReservationInformationUserControlのドライバを作ります。<br>
ツリー上でReservationInformationUserControlを選択し右クリックから Change The Analysis Target を選択します。<br>
それによって解析対象が切り替わります。<br>
必要なコントロールをDesignerに登録して Generate ボタンでコードを生成します。<br>
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
ReservationInformationUserControl のコードを生成したら今度は Form の方に戻ります。<br>
ChargeOfPartyUserControl の方もドライバを作成しても良いのですが、<br>
今回はこちらはドライバは作らずにFormに直接UserControlの要素を配置するようにします。<br>
（あくまで演習のためで、本来は場合によって使い分けてください）<br>
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
## MainWindow

## TreeとOUtput

## Document
同じタイプのが

## ネイティブのウィンドウに関して
FolderDialogDriver
MessageBoxDriver
OpenFileDialogDriver
SaveFileDialogDriver



メッセージボックス
ファイル保存/開くダイアログ
新規作成時にコードに入ってきます。
もしそれ以外のがあった場合はこちらを参考に作成お願いします。

