# CaptureCodeGeneratorのコード

CaptureCodeGeneratorは TestAssistantPro を利用して画面キャプチャしたコードを生成するための機能を提供するコンポーネントです。
ControlDriver に対応する CaptureCodeGenerator を作っておくと TestAssistantPro でキャプチャ時に操作からコードを作成できます。

`CaptureCodeGeneratorBase`を継承し、`CaptureCodeGeneratorAttribute`を利用してControlDriverと紐づけたクラスを作成します。
CaptureCodeGeneratorはCapture時に生成され、最初に`Attach`メソッドが呼び出されます。
そこでイベントに接続してイベントが発生したときに生成したコードを`AddSentense`メソッドを通して追加します。
CheckBoxでの実装例を次に記載します。

```cs
using System.Windows.Controls.Primitives;
using Codeer.TestAssistant.GeneratorToolKit;
using System.Windows;

namespace RM.Friendly.WPFStandardControls.Generator
{
    [CaptureCodeGenerator("RM.Friendly.WPFStandardControls.WPFToggleButton")]
    public class WPFToggleButtonGenerator : CaptureCodeGeneratorBase
    {
        ToggleButton _control;

        protected override void Attach()
        {
            _control = (ToggleButton)ControlObject;
            _control.Checked += ChangeCheck;
            _control.Unchecked += ChangeCheck;
            _control.Indeterminate += ChangeCheck;
        }

        protected override void Detach()
        {
            _control.Checked -= ChangeCheck;
            _control.Unchecked -= ChangeCheck;
            _control.Indeterminate -= ChangeCheck;
        }

        void ChangeCheck(object sender, RoutedEventArgs e)
        {
            //フォーカスがある場合のみコードを生成する
            if (_control.IsFocused)
            {
                string isChecked = "null";
                if (_control.IsChecked.HasValue)
                {
                    isChecked = _control.IsChecked.Value ? "true" : "false";
                }
                AddSentence(new TokenName(), ".EmulateCheck(" + isChecked, new TokenAsync(CommaType.Before), ");");
            }
        }
    }
}
```

`AddSentence`メソッドは引数で渡されたオブジェクトを文字列化したコードを登録します。
通常のオブジェクトは`ToString`メソッドを利用した文字列になりますが、一部特殊な置換が行わるクラスもあります。

|  Token  |  説明  |
| ---- | ---- |
|  TokenName  |  現在選択されている名前になります。  |
|  TokenSeparator  |  空行になります。複数個連続で登録されている場合は一行にまとめられます。  |
|  TokenAsync  |  その操作によりモーダルダイアログが表示された場合はAsyncのオブジェクトが入ります。引数なのでカンマの挿入に関して前後もしくはなしが引数で設定できます。  |
