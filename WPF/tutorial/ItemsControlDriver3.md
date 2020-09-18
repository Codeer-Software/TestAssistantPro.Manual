## ItemsControlWindowのドライバ作成
ListBoxとListViewが含まれているItemsControl Windowのドライバを作成します。
ピックアップすると最初はWPFListBox、WPFListViewがタイプとして選択されます。WPFListBox&lt;SampleListBoxItem>、WPFListView&lt;SampleListViewItem>にそれぞれ変更してください。

![ItemsControlDialog.png](../Img/ItemsControlDialog.png)

```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;

namespace Driver.Windows
{
    [WindowDriver(TypeFullName = "WpfDockApp.ItemsControlWindow")]
    public class ItemsControlWindowDriver
    {
        public WindowControl Core { get; }
        public WPFListBox<SampleListBoxItemDriver> _listBox => Core.Dynamic()._listBox; 
        public WPFListView<SampleListViewItemBaseDriver> _listView => Core.Dynamic()._listView; 

        public ItemsControlWindowDriver(WindowControl core)
        {
            Core = core;
        }

        public ItemsControlWindowDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class ItemsControlWindowDriverExtensions
    {
        [WindowDriverIdentify(TypeFullName = "WpfDockApp.ItemsControlWindow")]
        public static ItemsControlWindowDriver AttachItemsControlWindow(this WindowsAppFriend app)
            => app.WaitForIdentifyFromTypeFullName("WpfDockApp.ItemsControlWindow").Dynamic();
    }
}
```
