using Codeer.TestAssistant.GeneratorToolKit;
using Xceed.Wpf.AvalonDock.Controls;

namespace Driver.InTarget
{
    [CaptureCodeGenerator("Driver.Controls.LayoutDocumentControlDriver")]
    public class LayoutDocumentControlDriverGenerator : CaptureCodeGeneratorBase
    {
        LayoutDocumentControl _control;

        protected override void Attach()
        {
            _control = (LayoutDocumentControl)ControlObject;
            _control.Model.Closed += ModelClosed;
        }

        protected override void Detach()
        {
            _control.Model.Closed -= ModelClosed;
        }

        private void ModelClosed(object sender, System.EventArgs e)
        {
            AddSentence(new TokenName(), ".Close();");
        }
    }
}
