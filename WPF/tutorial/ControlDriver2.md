## ControlDriverの実装

NumericUpDownControlはValueを取得または設定するプロパティを公開しています。
また、TextBoxをValueTextBoxで取得できますので操作できます。
生成したControlDriverのコードテンプレートを次のように変更してください。

プロセスを超えたプロパティやメソッドの操作にはFriendlyを使っています。詳細は[Friendly](https://github.com/Codeer-Software/Friendly/blob/master/README.jp.md)を参照してください。
```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;

namespace Driver.Controls
{
    [ControlDriver(TypeFullName = "WpfDockApp.NumericUpDownControl", Priority = 2)]
    public class NumericUpDownControlDriver : WPFUIElement
    {
        public NumericUpDownControlDriver(AppVar appVar)
            : base(appVar) { }

		public int Value => this.Dynamic().Value;

		public void EmulateChangeValue(int value)
		{
			var textBox = this.Dynamic().ValueTextBox;
			if (textBox != null)
			{
				textBox.Focus();
				textBox.Text = value.ToString();
			}
		}
	}
}
```

## 次の手順
[CaptureCodeGeneratorの実装](ControlDriver3.md)
