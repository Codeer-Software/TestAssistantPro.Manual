using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfDockApp
{
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
            if (this._treeView?.Items?.Count == 0)
            {
                this._treeView.ItemsSource = GetTreeViewItems();
            }
        }

        public List<TreeViewModel> GetTreeViewItems()
        {
            var treeViewModels = new List<TreeViewModel>
            {
                new TreeViewModel()
                {
                    Name = "Oder management",
                    IsExpanded = true,
                    Children = new  List<TreeViewModel>
                    {
                        new TreeViewModel() { Name = "Accepted",IsExpanded = true,},
                        new TreeViewModel() { Name = "Sended",IsExpanded = true,},
                    },
                },
            };
            return treeViewModels;
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                var viewModel = (TreeViewModel)_treeView.SelectedItem;
                MakeDocumentEvent?.Invoke(this, new MakeDocumentEventArgs(viewModel.Name, GetDocuments(viewModel.Name)));
            }
        }

        private void TreeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var viewModel = (TreeViewModel)_treeView.SelectedItem;
            if (viewModel.Children == null)
            {
                string header = viewModel.Name;
                MakeDocumentEvent?.Invoke(this, new MakeDocumentEventArgs(header, GetDocuments(header)));
            }
            e.Handled = true;
        }
    }
}
