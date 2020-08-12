using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout;

namespace WpfDockApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
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
            MakeDocument(header);
            e.Handled = true;
        }

        private void MakeDocument(string header)
        {
            var documents = GetDocuments(header);
            bool found = false;
            foreach (var document in DocumentPane.Children)
            {
                if (document is LayoutDocument layoutDocument)
                {
                    if (layoutDocument.Title == header)
                    {
                        var documentControl = (OrderDocumentUserControl)layoutDocument.Content;
                        documentControl.SetDocument(documents);
                        layoutDocument.IsSelected = true;
                        found = true;
                        break;
                    }
                }
            }
            if (!found)
            {
                var layoutDocument = new LayoutDocument();
                layoutDocument.Title = header;
                var documentControl = new OrderDocumentUserControl();
                documentControl.SearchEvent += DocumentControl_SearchEvent;
                documentControl.SetDocument(documents);
                layoutDocument.Content = documentControl;
                DocumentPane.Children.Add(layoutDocument);
                layoutDocument.IsSelected = true;
            }
        }

        private void DocumentControl_SearchEvent(object sender, SearchEventArgs e)
        {
            TextBox1.Text = e.SearchResult;
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

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.ShowDialog();
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.ShowDialog();
        }

        private void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TextBox1.Text);
        }

        private void ButtonSaveFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            if (dlg.ShowDialog(this) == true)
            {
                File.WriteAllText(dlg.FileName, TextBox1.Text);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = string.Empty;
        }

        private void SimpleDialog_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SimpleWindow();
            dialog.ShowDialog();
        }

        private void MultiUserControlDialog_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MultiUserControlWindow();
            dialog.ShowDialog();
        }

        private void CustomControlDialog_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CustomControlWindow();
            dialog.ShowDialog();
        }

        private void MessageBoxDialog_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "Message.");
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                MakeDocument(menuItem.Name);
            }
        }
    }
}
