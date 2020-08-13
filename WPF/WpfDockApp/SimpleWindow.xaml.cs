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
using System.Windows.Shapes;

namespace WpfDockApp
{
    /// <summary>
    /// SimpleWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SimpleWindow : MahApps.Metro.Controls.MetroWindow, INotifyPropertyChanged
    {
        public SimpleWindow()
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

        private DateTime? birthday ;

        public DateTime? Birthday
        {
            get { return birthday; }
            set
            {
                if (birthday != value)
                {
                    birthday = value;
                    OnPropertyChanged();
                }
            }
        }

        private string userLanguage;

        public string UserLanguage
        {
            get { return userLanguage; }
            set
            {
                if (userLanguage != value)
                {
                    userLanguage = value;
                    OnPropertyChanged();
                }
            }
        }

        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set
            {
                if (remarks != value)
                {
                    remarks = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
