using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace WpfDockApp
{
    public partial class ChargeOfPartyUserControl : UserControl, INotifyPropertyChanged
    {
        public ChargeOfPartyUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        string userName = string.Empty;

        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged();
                }
            }
        }

        string tel = string.Empty;

        public string Tel
        {
            get { return tel; }
            set
            {
                if (tel != value)
                {
                    tel = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
