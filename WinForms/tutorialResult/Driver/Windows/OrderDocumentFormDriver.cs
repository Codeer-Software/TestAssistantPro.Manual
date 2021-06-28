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
    [UserControlDriver(TypeFullName = "WinFormsApp.OrderDocumentForm")]
    public class OrderDocumentFormDriver
    {
        //WindowControl -> DockContentDriver
        public DockContentDriver Core { get; }

        public FormsButton _searchButton => Core.Dynamic()._searchButton;
        public FormsTextBox _searchTextBox => Core.Dynamic()._searchTextBox;
        public FormsDataGridView _grid => Core.Dynamic()._grid;

        public OrderDocumentFormDriver(WindowControl core)
        {
            Core = new DockContentDriver(core.AppVar);
        }

        public OrderDocumentFormDriver(AppVar core)
        {
            Core = new DockContentDriver(core);
        }
    }

    public static class OrderDocumentFormDriverExtensions
    {
        [UserControlDriverIdentify(CustomMethod = "TryGet")]
        public static OrderDocumentFormDriver AttachOrderDocumentForm(this WindowsAppFriend app, string text)
            => app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WinFormsApp.OrderDocumentForm")).Where(e => (string)e.Dynamic().Text == text).FirstOrDefault()?.Dynamic();

        public static string[] TryGet(this WindowsAppFriend parent)
            => parent.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WinFormsApp.OrderDocumentForm")).Select(e => (string)e.Dynamic().Text).ToArray();

    }
}