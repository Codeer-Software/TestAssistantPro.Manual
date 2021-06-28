using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Linq;
//追加
using Driver.Controls;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "WpfDockApp.OrderDocumentUserControl")]
    public class OrderDocumentUserControlDriver
    {
        public WPFUIElement Core { get; }
        public WPFTextBox _searchText => Core.Dynamic()._searchText; 
        public WPFContextMenu _searchTextContextMenu => new WPFContextMenu{Target = _searchText.AppVar};
        public WPFButtonBase _searchButton => Core.Dynamic()._searchButton; 
        public WPFDataGrid _dataGrid => Core.Dynamic()._dataGrid;
        //追加
        public LayoutDocumentControlDriver LayoutDocumentControl
            //親方向に検索して最初に見つかったLayoutDocumentControl
            => Core.VisualTree(TreeRunDirection.Ancestors).ByType("Xceed.Wpf.AvalonDock.Controls.LayoutDocumentControl").First().Dynamic();

        public OrderDocumentUserControlDriver(AppVar core)
        {
            Core = new WPFUIElement(core);
        }
    }

    public static class OrderDocumentUserControlDriverExtensions
    {
        //ここに特定のためのカスタムコードを入れる
        //キャプチャ時にTestAssistantProが使うCustomMethod名を指定します。
        [UserControlDriverIdentify(CustomMethod = "TryGet")]
        public static OrderDocumentUserControlDriver AttachOrderDocumentUserControl(this WindowsAppFriend app, string identifier)
            //アプリの全てのウィンドウからTypeが一致するものを取得
            => app.GetTopLevelWindows().
                    SelectMany(e => e.GetFromTypeFullName("WpfDockApp.OrderDocumentUserControl")).
                    //その中でタイトルが一致するものを取得
                    Where(e => GetTitle(e) == identifier).
                    FirstOrDefault()?.Dynamic();

        //キャプチャ時にTestAssisatntProが使います。
        //発見した目的のUserControlの識別子を配列で戻します。
        public static string[] TryGet(this WindowsAppFriend app)
             //アプリの全てのウィンドウからTypeが一致するものを取得
             => app.GetTopLevelWindows().
                    SelectMany(e => e.GetFromTypeFullName("WpfDockApp.OrderDocumentUserControl")).
                    //識別子にタイトルを使う
                    Select(e => GetTitle(e)).
                    Where(e => e != null).
                    ToArray();

        static string GetTitle(AppVar e)
        {
            //タイトルを取得します。
            //UserContorlから親方向にたどって見つかるLayoutDocumentControlが持っています。
            //これは利用しているライブラリ(今回はXceed)の知識が必要です。
            var layoutDocumentControl = e.VisualTree(TreeRunDirection.Ancestors).ByType("Xceed.Wpf.AvalonDock.Controls.LayoutDocumentControl").FirstOrDefault();
            if (layoutDocumentControl == null) return null;
            return layoutDocumentControl.Dynamic().Model.Title;
        }
    }
}
