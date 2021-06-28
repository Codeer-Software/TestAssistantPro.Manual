using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;

namespace Driver.Controls
{
    [UserControlDriver(TypeFullName = "Xceed.Wpf.Toolkit.Primitives.SelectorItem")]
    public class CheckListBoxItemDriver
    {
        public WPFUIElement Core { get; }
        public WPFToggleButton Check => Core.VisualTree().ByBinding("IsSelected").Single().Dynamic();
        public WPFTextBlock Text => Core.VisualTree().ByType("System.Windows.Controls.TextBlock").Single().Dynamic();

        public CheckListBoxItemDriver(AppVar core)
        {
            Core = new WPFUIElement(core);
        }
    }
}
