using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Driver.Controls;
using Ong.Friendly.FormsStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [WindowDriver(TypeFullName = "WinFormsApp.CustomControlForm")]
    public class CustomControlFormDriver
    {
        public WindowControl Core { get; }
        public FormsButton _buttonAdd => Core.Dynamic()._buttonAdd; 
        public BlockControlDriver _blockControl => Core.Dynamic()._blockControl; 

        public CustomControlFormDriver(WindowControl core)
        {
            Core = core;
        }

        public CustomControlFormDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class CustomControlFormDriverExtensions
    {
        [WindowDriverIdentify(TypeFullName = "WinFormsApp.CustomControlForm")]
        public static CustomControlFormDriver AttachCustomControlForm(this WindowsAppFriend app)
            => app.WaitForIdentifyFromTypeFullName("WinFormsApp.CustomControlForm").Dynamic();
    }
}