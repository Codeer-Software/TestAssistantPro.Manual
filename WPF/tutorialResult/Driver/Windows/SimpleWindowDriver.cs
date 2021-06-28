using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Linq;

namespace Driver.Windows
{
    static class IUIObjectExtensions
    {
        public static void IUIObjectTest(this IUIObject self, int test)
        {

        }
    }

    public class WPFTextBoxTest : WPFTextBox
    {
        public WPFTextBoxTest(AppVar appVar)
            : base(appVar)
        {

        }
    }

    static class WPFTextBoxExtensions
    {
        public static void ExTestFunc(this WPFTextBoxTest self, int test)
        {

        }
    }

    [WindowDriver(TypeFullName = "WpfDockApp.SimpleWindow")]
    public class SimpleWindowDriver
    {
        public WindowControl Core { get; }
        public WPFTextBoxTest UserName => Core.LogicalTree().ByBinding("UserName").Single().Dynamic(); 
        public WPFContextMenu UserNameContextMenu => new WPFContextMenu{Target = UserName.AppVar};
        public WPFDatePicker Birthday => Core.LogicalTree().ByBinding("Birthday").Single().Dynamic(); 
        public WPFContextMenu BirthdayContextMenu => new WPFContextMenu{Target = Birthday.AppVar};
        public WPFComboBox UserLanguage => Core.LogicalTree().ByBinding("UserLanguage").Single().Dynamic(); 
        public WPFTextBox Remarks => Core.LogicalTree().ByBinding("Remarks").Single().Dynamic(); 
        public WPFContextMenu RemarksContextMenu => new WPFContextMenu{Target = Remarks.AppVar};
        public WPFButtonBase _oK => Core.Dynamic()._oK; 
        public WPFButtonBase _cancel => Core.Dynamic()._cancel; 
        public WPFToggleButton ToggleButton => Core.VisualTree().ByType("System.Windows.Controls.Primitives.ToggleButton")[0].Dynamic(); // TODO It is not the best way to identify. Please change to a better method.
        public WPFToggleButton ToggleButton0 => Core.VisualTree().ByType("System.Windows.Controls.Primitives.ToggleButton")[1].Dynamic(); // TODO It is not the best way to identify. Please change to a better method.
        public WPFButtonBase LightMinButtonStyle => Core.VisualTree().ByBinding("LightMinButtonStyle").Single().Dynamic(); 
        public WPFButtonBase LightMaxButtonStyle => Core.VisualTree().ByBinding("LightMaxButtonStyle").Single().Dynamic(); 
        public WPFButtonBase LightCloseButtonStyle => Core.VisualTree().ByBinding("LightCloseButtonStyle").Single().Dynamic(); 

        public SimpleWindowDriver(WindowControl core)
        {
            Core = core;
        }

        public void AAA()
        {

        }

        public SimpleWindowDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }

        public void テスト1(bool x) { }
        public void テスト2(XXX x) { }

        public enum XXX 
        {
        A,B
        }
    }

    public static class SimpleWindowDriverExtensions
    {
        [WindowDriverIdentify(TypeFullName = "WpfDockApp.SimpleWindow")]
        public static SimpleWindowDriver AttachSimpleWindow(this WindowsAppFriend app)
            => app.WaitForIdentifyFromTypeFullName("WpfDockApp.SimpleWindow").Dynamic();
    }
}