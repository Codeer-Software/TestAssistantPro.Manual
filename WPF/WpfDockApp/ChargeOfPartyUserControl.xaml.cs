using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDockApp
{
    /// <summary>
    /// ChargeOfPartyUserControl.xaml の相互作用ロジック
    /// </summary>
    public partial class ChargeOfPartyUserControl : UserControl, INotifyPropertyChanged
    {
        public ChargeOfPartyUserControl()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private string userName = string.Empty;

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

        private string tel = string.Empty;

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

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
