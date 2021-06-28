using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Driver.Controls;

namespace Driver.Windows
{
    [WindowDriver(TypeFullName = "WpfDockApp.CustomItemsControlWindow")]
    public class CustomItemsControlWindowDriver
    {
        public WindowControl Core { get; }
        public CheckListBoxDriver _listBox => Core.Dynamic()._listBox;

        public CustomItemsControlWindowDriver(WindowControl core)
        {
            Core = core;
        }

        public CustomItemsControlWindowDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class CustomItemsControlWindowDriverExtensions
    {
        [WindowDriverIdentify(TypeFullName = "WpfDockApp.CustomItemsControlWindow")]
        public static CustomItemsControlWindowDriver AttachCustomItemsControlWindow(this WindowsAppFriend app)
            => app.WaitForIdentifyFromTypeFullName("WpfDockApp.CustomItemsControlWindow").Dynamic();
    }
}
