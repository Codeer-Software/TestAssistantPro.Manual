using System.Linq;
using System.Windows;

namespace WpfDockApp
{
    public partial class CustomItemsControlWindow : Window
    {
        public CustomItemsControlWindow()
        {
            InitializeComponent();

            _listBox.ItemsSource = Enumerable.Range(0, 20).ToArray();
        }
    }
}
