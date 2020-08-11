using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
                treeViewItem.Selected += TreeViewItem_Selected;
                foreach (var data2 in treeViewItem.Items)
                {
                    var treeViewItem2 = data2 as TreeViewItem;
                    treeViewItem2.Selected += TreeViewItem_Selected;
                }
            }
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            var treeViewItem = sender as TreeViewItem;
            var documents = GetDocuments((string)treeViewItem.Header);
            DataGrid1.ItemsSource = documents;
            DataGrid2.ItemsSource = documents;
            e.Handled = true;
        }

        public TreeViewItem[] GetTreeViewItems()
        {
            var treeViewItem = new TreeViewItem[] 
            {
                new TreeViewItem() 
                {
                    Header = "Oder management",
                    IsExpanded = true,
                    ItemsSource = new TreeViewItem[]
                    {
                        new TreeViewItem() { Header = "Accepted"},
                        new TreeViewItem() { Header = "Sended"},
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var hits = new List<string>();
            if (Document1.IsSelected)
            {
                var items = DataGrid1.Items;
                for (int row = 0; row < items.Count; row++)
                {
                    var texts = (string[])items[row];
                    for (int col = 0; col < texts.Length; col++)
                    {
                        string text = texts[col];
                        {
                            if (text.Contains(SearchText1.Text))
                            {
                                hits.Add($"OrderDocumentForm({row},{col}) : {text}");
                            }
                        }
                    }
                }
                foreach (var hit in hits)
                {
                    TextBox1.Text += hit + "\n";
                }
            }
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
    }
}
