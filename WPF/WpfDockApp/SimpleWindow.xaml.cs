using MahApps.Metro.Controls;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfDockApp
{
    public partial class SimpleWindow : MetroWindow, INotifyPropertyChanged
    {
        public SimpleWindow()
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

        DateTime? birthday ;

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

        string userLanguage;

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

        string remarks;

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

        void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void OK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
