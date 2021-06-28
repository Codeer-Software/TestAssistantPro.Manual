using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "WinFormsApp.OutputForm")]
    public class OutputFormDriver
    {
        public WindowControl Core { get; }
        public FormsTextBox _textBoxResult => Core.Dynamic()._textBoxResult; 
        public FormsToolStrip _toolStrip => Core.Dynamic()._toolStrip; 

        public OutputFormDriver(WindowControl core)
        {
            Core = core;
        }

        public OutputFormDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class OutputFormDriverExtensions
    {
        [UserControlDriverIdentify]
        public static OutputFormDriver AttachOutputForm(this WindowsAppFriend app)
            => app.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WinFormsApp.OutputForm")).FirstOrDefault()?.Dynamic();
    }
}