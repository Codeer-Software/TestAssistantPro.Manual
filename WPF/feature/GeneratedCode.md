# WindowDriver/UserControlDriverのコード

WindowDriverとUserControlDriverの役割はコントロールドライバを特定して取得することです。
そのためにAttachを行うメソッドも作られます。
Attachを行うメソッドの詳細については[Attach方法ごとのコード](./Attach.md)を参照してください。
UserControlDriverの場合はControlDriver同様に親のWindowDriverの子要素としてPropertyで取得する方法もあります。

## WindowDriverのコード例

```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Linq;

namespace Driver.Windows
{
    //WindowDriverであることを明示します。
    //対応するWindowのタイプフルネームを指定します。
    //WindowDriverAttributeを付けることでTestAssistantProが
    //AnalyzeWindowでコントロールに対してすでにドライバが割り当てられていることを検知します。
    [WindowDriver(TypeFullName = "XXX.YWindow")]
    public class YWindowDriver
    {
        public WindowControl Core { get; }
        public WPFDatePicker Birthday => Core.LogicalTree().ByBinding("Birthday").Single().Dynamic(); 
        public WPFComboBox UserLanguage => Core.LogicalTree().ByBinding("UserLanguage").Single().Dynamic(); 
        public WPFTextBox Remarks => Core.LogicalTree().ByBinding("Remarks").Single().Dynamic(); 

        public YWindowDriver(WindowControl core)
        {
            Core = core;
        }

        public YWindowDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class YWindowDriverExtensions
    {
        //アプリケーションからYWindowを特定して取得します。
        //WindowDriverIdentifyAttributeを付けることでTestAssistantProがこのメソッドを使えるようになります。
        //Attachについては後述します。
        [WindowDriverIdentify(TypeFullName = "XXX.YWindow")]
        public static YWindowDriver AttachYWindow(this WindowsAppFriend app)
            => app.WaitForIdentifyFromTypeFullName("XXX.YWindow").Dynamic();
    }
}
```

## UserControlDriverのコード例

```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver.Windows
{
    //UserControlDriverであることを明示します。
    //対応するUserControlのタイプフルネームを指定します。
    //UserControlDriverAttributeを付けることでTestAssistantProが
    //AnalyzeWindowでコントロールに対してすでにドライバが割り当てられていることを検知します。
    [UserControlDriver(TypeFullName = "XXX.ZUserControl")]
    public class ZUserControlDriver
    {
        //UserControlに対応する変数
        public WindowControl Core { get; }

        //ControlDriverを並べる
        //ControlDriverを特定するのが責務
        public WPFTextBox UserName => Core.LogicalTree().ByBinding("UserName").Single().Dynamic(); 
        public WPFTextBox Remarks => Core.LogicalTree().ByBinding("Remarks").Single().Dynamic(); 

        public ZUserControlDriver(WindowControl core)
        {
            Core = core;
        }

        public ZUserControlDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }
    
    public static class ZUserControlDriverExtensions
    {
        //YFormDriverからZUserControlを特定して取得します。
        //UserControlDriverIdentifyAttributeを付けることでTestAssistantProがこのメソッドを使えるようになります。
        //Attachについては後述します。
        [UserControlDriverIdentify()]
        public static ZUserControlDriver AttachZUserControl(this YFormDriver parent)
            => parent.GetFromTypeFullName("XXX.ZUserControl").FirstOrDefault()?.Dynamic();
    }
}
```
