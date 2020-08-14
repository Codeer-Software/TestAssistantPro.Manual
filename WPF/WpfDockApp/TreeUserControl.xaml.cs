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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDockApp
{
    /// <summary>
    /// TreeUserControl.xaml の相互作用ロジック
    /// </summary>
    public partial class TreeUserControl : UserControl
    {
        public delegate void MakeDocumentEventHandler(object sender, MakeDocumentEventArgs e);
        public event MakeDocumentEventHandler MakeDocumentEvent;

        public TreeUserControl()
        {
            InitializeComponent();

            this.Loaded += TreeUserControl_Loaded;
        }

        private void TreeUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var items = GetTreeViewItems();
            foreach (var item in items)
            {
                this.TreeView.Items.Add(item);
            }
            foreach (var data in this.TreeView.Items)
            {
                var treeViewItem = data as TreeViewItem;
                foreach (var data2 in treeViewItem.Items)
                {
                    var treeViewItem2 = data2 as TreeViewItem;
                    treeViewItem2.MouseDoubleClick += TreeViewItem_MouseDoubleClick;
                }
            }
        }

        private void TreeViewItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var treeViewItem = sender as TreeViewItem;
            string header = (string)treeViewItem.Header;
            MakeDocumentEvent?.Invoke(this, new MakeDocumentEventArgs(header, GetDocuments(header)));
            e.Handled = true;
        }

        public TreeViewItem[] GetTreeViewItems()
        {
            var contextMenu1 = new ContextMenu();
            var menuItem1 = new MenuItem();
            menuItem1.Header = "Open";
            menuItem1.Click += Open_Click;
            menuItem1.Name = "Accepted";
            contextMenu1.Items.Add(menuItem1);

            var contextMenu2 = new ContextMenu();
            var menuItem2 = new MenuItem();
            menuItem2.Header = "Open";
            menuItem2.Click += Open_Click;
            menuItem2.Name = "Sended";
            contextMenu2.Items.Add(menuItem2);

            var treeViewItem = new TreeViewItem[]
            {
                new TreeViewItem()
                {
                    Header = "Oder management",
                    IsExpanded = true,
                    ItemsSource = new TreeViewItem[]
                    {
                        new TreeViewItem() { Header = "Accepted", ContextMenu = contextMenu1},
                        new TreeViewItem() { Header = "Sended", ContextMenu = contextMenu2},
                    },
                },
            };
            return treeViewItem;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                MakeDocumentEvent?.Invoke(this, new MakeDocumentEventArgs(menuItem.Name, GetDocuments(menuItem.Name)));
            }
        }

        public string[][] GetDocuments(string header)
        {
            string[][] documents = new string[][] { };
            switch (header)
            {
                case "Accepted":
                    documents = new string[][]{
                            new []{ "ABC, LTD.", "cherry blossom", "Chris", "100" },
                            new []{ "ABC, LTD.", "ume  blossom", "Chris", "300" },
                            new []{ "DEF, LTD.", "tulipm", "Pat", "300" },
                            new []{ "DEF, LTD.", "dandelion", "Pat", "700" },
                            new []{ "DEF, LTD.", "peach blossom", "Pat", "800" },
                            new []{ "GHI, LTD.", "flowering dogwood", "Alex", "900" },
                        };
                    break;
                case "Sended":
                    documents = new string[][]{
                            new []{ "JKL, LTD.", "dianthus pink", "Dana", "800" },
                            new []{ "JKL, LTD.", "marigold", "Dana", "600" },
                            new []{ "JKL, LTD.", "azalea", "Dana", "700" },
                            new []{ "JKL, LTD.", "phalaenopsis orchid", "Dana", "900" },
                            new []{ "OPQ, LTD.", "daphne", "Hunter", "200" },
                            new []{ "STU, LTD.", "lily of the valley", "Jamie", "300" },
                        };
                    break;
            }
            return documents;
        }
    }
}
