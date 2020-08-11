# WindowDriver/UserControlDriverのコード

<!--TODO:UserContorlDriverとはなにか？ControlDriverとの違いは？
この文章でいきなり登場している。AnalyzeWindowの説明ではControlDriverを作成するとなっているが、
ここではUserControlDriverとControlDriverと違うもののように説明されている。
コード例もUserControlDriver側が示されており、いったいAnalyzeWindowはどちらのコードを生成するものなのか分からない -->

WindowDriverとUserControlDriverの役割はほとんど同じでコントロールドライバを特定して取得することです。
それ自体を取得するためにAttachMethodを作ります。<!--TODO:「それ自体を取得するために・・」のそれ自体がなにをさしているか分からない-->
UserControlDriverの場合はControlDriver同様に親のWindowDriverの子要素として普通にPropertyで取得することもあります。

## WindowDriverのコード例

```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver.Windows
{
    //WindowDriverであることを明示します。
    //対応するWindowのタイプフルネームを指定します。
    //WindowDriverAttributeを付けることでTestAssistantProが
    //AnalyzeWindowでコントロールに対してすでにドライバが割り当てられていることを検知します。
    [WindowDriver(TypeFullName = "XXX.YForm")]
    public class YFormDriver
    {
        //Fromに対応する変数
        public WindowControl Core { get; }

        //ControlDriverを並べる
        //ControlDriverを特定するのが責務
        public FormsButton _buttonCancel => Core.Dynamic()._buttonCancel; 
        public FormsButton _buttonOK => Core.Dynamic()._buttonOK; 
        public FormsRichTextBox _richTextBoxRemarks => Core.Dynamic()._richTextBoxRemarks; 

        public YFormDriver(WindowControl core)
        {
            Core = core;
        }

        public YFormDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class YFormDriverExtensions
    {
        //アプリケーションからYFormを特定して取得します。
        //WindowDriverIdentifyAttributeを付けることでTestAssistantProがこのメソッドを使えるようになります。
        //Attachについては後述します。
        [WindowDriverIdentify(TypeFullName = "XXX.YForm")]
        public static YFormDriver AttachYForm(this WindowsAppFriend app)
            => app.WaitForIdentifyFromTypeFullName("XXX.YForm").Dynamic();
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
        public FormsRadioButton _radioA => Core.Dynamic()._radioButtonAlacarte; 
        public FormsRadioButton _radioB => Core.Dynamic()._radioButtonCourse; 

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
