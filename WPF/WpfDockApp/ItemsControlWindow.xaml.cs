using System;
using System.Collections.Generic;
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
    /// ItemsControlWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ItemsControlWindow : Window
    {
        public ItemsControlWindow()
        {
            InitializeComponent();

            this.Loaded += ItemsControlWindow_Loaded;
        }

        private void ItemsControlWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.ListBox?.Items?.Count == 0)
            {
                this.ListBox.ItemsSource = GetListBoxItems();
            }
            if (this.ListView?.Items?.Count == 0)
            {
                this.ListView.ItemsSource = GetListViewItems();
            }
        }
        public List<ListBoxViewModel> GetListBoxItems()
        {
            var listBoxViewModels = new List<ListBoxViewModel>
            {
                new ListBoxViewModel()
                {
                    CheckBoxData = true,
                    ComboBoxData = 0,
                    TextData = "Text1",
                },
                new ListBoxViewModel()
                {
                    CheckBoxData = false,
                    ComboBoxData = 2,
                    TextData = "Text2",
                },
                new ListBoxViewModel()
                {
                    CheckBoxData = true,
                    ComboBoxData = 1,
                    TextData = "Text3",
                },
                new ListBoxViewModel()
                {
                    CheckBoxData = false,
                    ComboBoxData = 3,
                    TextData = "Text4",
                },
            };
            return listBoxViewModels;
        }

        public List<object> GetListViewItems()
        {
            var listViewViewModels = new List<object>
            {
                new ListView1ViewModel()
                {
                    CheckBoxData = true,
                    ComboBoxData = 0,
                    TextData = "Text1",
                },
                new ListView2ViewModel()
                {
                    ComboBoxData = 2,
                    TextData = "Text2",
                    DateData = new DateTime(2020,8,1),
                },
                new ListView3ViewModel()
                {
                    TextData = "Text3",
                    DateData = new DateTime(2020,8,14),
                    SliderData = 10,
                },
                new ListView1ViewModel()
                {
                    CheckBoxData = false,
                    ComboBoxData = 3,
                    TextData = "Text4",
                },
            };
            return listViewViewModels;
        }
    }
}
