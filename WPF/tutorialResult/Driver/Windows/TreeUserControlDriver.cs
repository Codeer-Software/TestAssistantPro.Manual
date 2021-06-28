using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "WpfDockApp.TreeUserControl")]
    public class TreeUserControlDriver
    {
        public WPFUIElement Core { get; }
        public WPFTreeView _treeView => Core.Dynamic()._treeView; 
        public WPFContextMenu _treeViewContextMenu => new WPFContextMenu{Target = _treeView.AppVar};

        public TreeUserControlDriver(AppVar core)
        {
            Core = new WPFUIElement(core);
        }
    }

    public static class TreeUserControlDriverExtensions
    {
        [UserControlDriverIdentify]
        public static TreeUserControlDriver AttachTreeUserControl(this WindowsAppFriend app)
            => app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WpfDockApp.TreeUserControl")).FirstOrDefault()?.Dynamic();
    }
}