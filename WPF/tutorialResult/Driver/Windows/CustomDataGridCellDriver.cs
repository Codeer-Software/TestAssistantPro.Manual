using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Linq;
using System.Windows.Controls;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "System.Windows.Controls.DataGridCell")]
    public class CustomDataGridCellDriver
    {
        public WPFUIElement Core { get; }
        public WPFTextBlock Name => Core.VisualTree().ByBinding("Name").Single().Dynamic();
        public WPFToggleButton AuthMember => Core.VisualTree().ByBinding("AuthMember").Single().Dynamic();

        public CustomDataGridCellDriver(AppVar core)
        {
            Core = new WPFUIElement(core);
        }
    }

    public static class CustomDataGridCellDriverExtensions
    {
        [UserControlDriverIdentify]
        public static CustomDataGridCellDriver AsCustomDataGridCell(this WPFDataGridCell src)
        {
            string columnType = src.Dynamic().Column.GetType().FullName;
            if (typeof(DataGridTemplateColumn).FullName != columnType) return null;
            if (src.VisualTree().ByBinding("AuthMember").FirstOrDefault() == null) return null;
            return src.Dynamic();
        }
    }
}
