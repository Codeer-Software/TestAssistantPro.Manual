using System.Windows.Forms;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Driver.InTarget
{
    [CaptureCodeGenerator("Driver.Controls.DockContentDriver")]
    public class DockContentDriverGenerator : CaptureCodeGeneratorBase
    {
        Form _control;

        protected override void Attach()
        {
            _control = (Form)ControlObject;
            _control.FormClosed += FormClosed;
        }

        protected override void Detach()
        {
            _control.FormClosed -= FormClosed;
        }

        void FormClosed(object sender, FormClosedEventArgs e)
        {
            AddSentence(new TokenName(), ".Close();");
        }
    }
}
