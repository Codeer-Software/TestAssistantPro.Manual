using Codeer.Friendly;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;

namespace Driver.Controls
{
    [ControlDriver(TypeFullName = "WeifenLuo.WinFormsUI.Docking.DockContent", Priority = 2)]
    public class DockContentDriver : FormsControlBase
    {
        public DockContentDriver(AppVar appVar)
            : base(appVar) { }
    }
}
