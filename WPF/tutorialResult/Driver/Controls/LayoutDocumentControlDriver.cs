using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;

namespace Driver.Controls
{
    [ControlDriver(TypeFullName = "Xceed.Wpf.AvalonDock.Controls.LayoutDocumentControl", Priority = 2)]
    public class LayoutDocumentControlDriver : WPFUIElement
    {
        public LayoutDocumentControlDriver(AppVar appVar)
            : base(appVar) { }

        public void Close() => this.Dynamic().Model.Close();
    }
}
