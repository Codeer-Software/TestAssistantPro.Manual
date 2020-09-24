using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// DataGridWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class DataGridWindow : Window
    {
        public DataGridWindow()
        {
            InitializeComponent();

            var data = new ObservableCollection<Person>(
                Enumerable.Range(1, 10).Select(i => new Person
                {
                    Name = i % 2 == 0 ? "James Smith" + i : "Mary Johnson" + i,
                    Gender = i % 2 == 0 ? Gender.Men : Gender.Women,
                    AuthMember = i % 5 == 0,
                    Link = new Uri("https://github.com/Codeer-Software/TestAssistantPro.Manual"),
                }));
            // DataGridに設定する
            this.dataGrid.ItemsSource = data;
        }
    }
}
