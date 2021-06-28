using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using RM.Friendly.WPFStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "WpfDockApp.ReservationInformationUserControl")]
    public class ReservationInformationUserControlDriver
    {
        public WPFUIElement Core { get; }
        public WPFToggleButton _smoking => Core.Dynamic()._smoking; 
        public WPFTextBox _numberOfPeople => Core.Dynamic()._numberOfPeople; 
        public WPFContextMenu _numberOfPeopleContextMenu => new WPFContextMenu{Target = _numberOfPeople.AppVar};
        public WPFToggleButton _course => Core.Dynamic()._course; 
        public WPFToggleButton _alacarte => Core.Dynamic()._alacarte; 

        public ReservationInformationUserControlDriver(AppVar core)
        {
            Core = new WPFUIElement(core);
        }
    }
}