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
