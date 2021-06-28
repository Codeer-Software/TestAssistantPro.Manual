using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.TestAssistant.GeneratorToolKit;
using Driver.InTarget;
using RM.Friendly.WPFStandardControls;

namespace Driver.Controls
{
    [ControlDriver(TypeFullName = "Xceed.Wpf.Toolkit.CheckListBox", Priority = 2)]
    public class CheckListBoxDriver : WPFUIElement
    {
        public CheckListBoxDriver(AppVar appVar)
            : base(appVar) { }

        [ItemDriverGetter(ActiveItemKeyProperty = "ActiveItemIndex")]
        public CheckListBoxItemDriver GetItem(int index)
        {
            if (index == -1) return null;
            var item = this.Dynamic().ItemContainerGenerator.ContainerFromIndex(index);
            item.BringIntoView();
            return item;
        }

        public int ActiveItemIndex => App.Type<CheckListBoxDriverGenerator>().GetActiveIndex(this);

        public void EmulateActivateItem(int index)
        {
            this.Dynamic().Focus();
            var item = GetItem(index);
            item.Core.Dynamic().Focus();
        }
    }
}
