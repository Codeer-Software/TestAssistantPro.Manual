using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Driver.Controls;
using RM.Friendly.WPFStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [WindowDriver(TypeFullName = "WpfDockApp.CustomControlWindow")]
    public class CustomControlWindowDriver
    {
        public WindowControl Core { get; }
        public NumericUpDownControlDriver _numericUpDown => Core.Dynamic()._numericUpDown; 

        public CustomControlWindowDriver(WindowControl core)
        {
            Core = core;
        }

        public CustomControlWindowDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class CustomControlWindowDriverExtensions
    {
        [WindowDriverIdentify(TypeFullName = "WpfDockApp.CustomControlWindow")]
        public static CustomControlWindowDriver AttachCustomControlWindow(this WindowsAppFriend app)
            => app.WaitForIdentifyFromTypeFullName("WpfDockApp.CustomControlWindow").Dynamic();
    }
}