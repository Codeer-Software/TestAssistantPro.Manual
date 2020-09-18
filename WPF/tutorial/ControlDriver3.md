## CaptureCodeGeneratorの実装

次にNumericUpDownControlのCaptureCodeGeneratorをコードテンプレートを編集して作成します。
イベントを受ける必要があるので NumericUpDownControl が定義されている WpfDockApp.exe を参照します。
コードテンプレートを次のように変更してください。

```cs
using System;
using Codeer.TestAssistant.GeneratorToolKit;
using WpfDockApp;

namespace Driver.InTarget
{
    [CaptureCodeGenerator("Driver.Controls.NumericUpDownControlDriver")]
    public class NumericUpDownControlDriverGenerator : CaptureCodeGeneratorBase
    {
		NumericUpDownControl _control;
		protected override void Attach()
		{
			_control = (NumericUpDownControl)ControlObject;
			_control.ValueChanged += ValueChanged;
		}

		protected override void Detach()
		{
			_control.ValueChanged -= ValueChanged;
		}

		void ValueChanged(object sender, EventArgs e)
		{
			if (_control.ValueTextBox.IsFocused || _control.UpButton.IsFocused || _control.DownButton.IsFocused)
				AddSentence(new TokenName(), ".EmulateChangeValue(" + _control.Value, new TokenAsync(CommaType.Before), ");");
		}
	}
}
```
## 注意
Driver.InTarget.dllは対象プロセス内部で動作します。そのため対象プロセスにアタッチした後、そのプロセスが起動している間にビルドしようとしてもdllファイルは対象プロセスが握っている状態なのでビルドできません。ビルドする場合は対象プロセスを一度終了させてください。
