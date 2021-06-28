using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "WpfDockApp.OutputUserControl")]
    public class OutputUserControlDriver
    {
        public WPFUIElement Core { get; }
        public WPFButtonBase _buttonCopy => Core.Dynamic()._buttonCopy;
        public WPFButtonBase _buttonSaveFile => Core.Dynamic()._buttonSaveFile;
        public WPFButtonBase _buttonClear => Core.Dynamic()._buttonClear;
        public WPFTextBox _textBox => Core.Dynamic()._textBox;
        public WPFContextMenu _textBoxContextMenu => new WPFContextMenu { Target = _textBox.AppVar };

        public OutputUserControlDriver(AppVar core)
        {
            Core = new WPFUIElement(core);
        }
    }

    public static class OutputUserControlDriverExtensions
    {
        [UserControlDriverIdentify]
        public static OutputUserControlDriver AttachOutputUserControl(this WindowsAppFriend app)
            => app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WpfDockApp.OutputUserControl")).FirstOrDefault()?.Dynamic();
    }
}
