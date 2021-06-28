using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "WinFormsApp.TreeForm")]
    public class TreeFormDriver
    {
        public WindowControl Core { get; }
        public FormsTreeView _treeView => Core.Dynamic()._treeView;
        public FormsToolStrip _contextMenu => Core.Dynamic()._contextMenu;

        public TreeFormDriver(WindowControl core)
        {
            Core = core;
        }

        public TreeFormDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class TreeFormDriverExtensions
    {
        [UserControlDriverIdentify()]
        public static TreeFormDriver AttachTreeForm(this WindowsAppFriend app)
            => app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WinFormsApp.TreeForm")).FirstOrDefault()?.Dynamic();
    }
}
