using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [WindowDriver(TypeFullName = "WpfDockApp.DataGridWindow")]
    public class DataGridWindowDriver
    {
        public WindowControl Core { get; }
        public WPFDataGrid dataGrid => Core.Dynamic().dataGrid; 

        public DataGridWindowDriver(WindowControl core)
        {
            Core = core;
        }

        public DataGridWindowDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class DataGridWindowDriverExtensions
    {
        [WindowDriverIdentify(TypeFullName = "WpfDockApp.DataGridWindow")]
        public static DataGridWindowDriver AttachDataGridWindow(this WindowsAppFriend app)
            => app.WaitForIdentifyFromTypeFullName("WpfDockApp.DataGridWindow").Dynamic();
    }
}