# CaptureCodeGeneratorのコード

CaptureCodeGeneratorは TestAssistantPro を利用して画面キャプチャしたコードを生成するための機能を提供するコンポーネントです。
ControlDriver に対応する CaptureCodeGenerator を作っておくと TestAssistantPro でキャプチャ時に操作からコードを作成できます。

CaptureCodeGeneratorBase を継承し、CaptureCodeGeneratorAttributeを利用してControlDriverと紐づけたクラスを作成します。
CaptureCodeGenerator は Capture 時に生成され、最初に Attach() が呼び出されます。
そこでイベントに接続してイベントが発生したときに生成したコードを AddSentense メソッドを通して追加します。
CheckBoxでの実装例を次に記載します。

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
AddSentenceメソッドは引数で渡されたオブジェクトを文字列化したコードを登録します。
通常のオブジェクトは ToString() を利用した文字列になりますが、一部特殊な置換が行わるクラスもあります。

|  Token  |  説明  |
| ---- | ---- |
|  TokenName  |  現在選択されている名前になります。  |
|  TokenSeparator  |  空行になります。複数個連続で登録されている場合は一行にまとめられます。  |
|  TokenAsync  |  その操作によりモーダルダイアログが表示された場合はAsyncのオブジェクトが入ります。引数なのでカンマの挿入に関して前後もしくはなしが引数で設定できます。  |
