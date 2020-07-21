using System;
using System.Collections.Generic;
using System.IO;
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
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        private string treename;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
            ListView1.SelectionChanged += ListView_SelectionChanged;
            ListView2.SelectionChanged += ListView_SelectionChanged;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                var item = e.AddedItems[0] as string;
                TextBlock1.Text = $"Job = {treename}";
                TextBlock2.Text = $"Item = {item}";
            }
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
            treename = (string)treeViewItem.Header;
            var documents = GetDocuments((string)treeViewItem.Header);
            ListView1.ItemsSource = documents;
            ListView2.ItemsSource = documents;
            e.Handled = true;
        }

        public TreeViewItem[] GetTreeViewItems()
        {
            var treeViewItem = new TreeViewItem[] 
            {
                new TreeViewItem() 
                {
                    Header = "受発注管理",
                    ItemsSource = new TreeViewItem[]
                    {
                        new TreeViewItem() { Header = "受注管理"},
                        new TreeViewItem() { Header = "発注管理"},
                        new TreeViewItem() { Header = "受け入れ管理"},
                        new TreeViewItem() { Header = "支払い管理"},
                        new TreeViewItem() { Header = "納品検収管理"},
                        new TreeViewItem() { Header = "請求管理"},
                        new TreeViewItem() { Header = "売上管理"},
                    },
                },
                new TreeViewItem()
                {
                    Header = "在庫管理",
                    ItemsSource = new TreeViewItem[]
                    {
                        new TreeViewItem() { Header = "出庫計画"},
                        new TreeViewItem() { Header = "補充計画"},
                        new TreeViewItem() { Header = "補充管理"},
                        new TreeViewItem() { Header = "出庫管理"},
                        new TreeViewItem() { Header = "在庫一覧"},
                        new TreeViewItem() { Header = "棚卸"},
                    },
                },
                new TreeViewItem()
                {
                    Header = "工程管理",
                    ItemsSource = new TreeViewItem[]
                    {
                        new TreeViewItem() { Header = "生産計画立案"},
                        new TreeViewItem() { Header = "外注工程管理"},
                        new TreeViewItem() { Header = "進捗管理"},
                        new TreeViewItem() { Header = "品質管理"},
                        new TreeViewItem() { Header = "設備管理"},
                        new TreeViewItem() { Header = "出荷管理"},
                    },
                },
            };
            return treeViewItem;
        }

        public string[] GetDocuments(string header)
        {
            string[] documents = new string[] { };
            switch (header)
            {
                case "受発注管理":
                    documents = new string[] 
                    {
                        "受注管理",
                        "発注管理",
                        "受け入れ管理",
                        "支払い管理",
                        "納品検収管理",
                        "請求管理",
                        "売上管理",
                    };
                    break;
                case "受注管理":
                    documents = new string[]
                    {
                        "受注日",
                        "納品先",
                        "発送日",
                        "商品コード",
                        "商品名",
                        "数量",
                        "単価",
                        "合計金額",
                    };
                    break;
                case "発注管理":
                    documents = new string[]
                    {
                        "発注日",
                        "発注先",
                        "到着日",
                        "商品コード",
                        "商品名",
                        "数量",
                        "単価",
                        "合計金額",
                    };
                    break;
                case "受け入れ管理":
                    documents = new string[]
                    {
                        "発注日",
                        "発注先",
                        "到着日",
                        "商品コード",
                        "商品名",
                        "数量",
                        "単価",
                        "合計金額",
                    };
                    break;
                case "支払い管理":
                    documents = new string[]
                    {
                        "発注日",
                        "発注先",
                        "発注先口座",
                        "支払日",
                        "商品コード",
                        "商品名",
                        "数量",
                        "単価",
                        "合計金額",
                    };
                    break;
                case "納品検収管理":
                    documents = new string[]
                    {
                        "発注日",
                        "発注先",
                        "納品日",
                        "商品コード",
                        "商品名",
                        "数量",
                        "単価",
                        "合計金額",
                        "検収結果",
                    };
                    break;
                case "請求管理":
                    documents = new string[]
                    {
                        "受注日",
                        "納品先",
                        "請求先",
                        "発送日",
                        "商品コード",
                        "商品名",
                        "数量",
                        "単価",
                        "合計金額",
                    };
                    break;
                case "売上管理":
                    documents = new string[]
                    {
                        "入金日",
                        "請求先",
                        "商品コード",
                        "商品名",
                        "数量",
                        "単価",
                        "合計金額",
                    };
                    break;
                case "在庫管理":
                    documents = new string[]
                    {
                        "出庫計画",
                        "補充計画",
                        "補充管理",
                        "出庫管理",
                        "在庫一覧",
                        "棚卸",
                    };
                    break;
                case "出庫計画":
                    documents = new string[]
                    {
                        "発送日",
                        "納品先",
                        "商品コード",
                        "商品名",
                        "数量",
                    };
                    break;
                case "補充計画":
                    documents = new string[]
                    {
                        "商品コード",
                        "商品名",
                        "在庫数量",
                        "出庫数量",
                        "不足数量",
                        "ロット数量",
                    };
                    break;
                case "出庫管理":
                    documents = new string[]
                    {
                        "商品コード",
                        "商品名",
                        "在庫数量",
                        "出庫数量",
                    };
                    break;
                case "補充管理":
                    documents = new string[]
                    {
                        "商品コード",
                        "商品名",
                        "在庫数量",
                        "入庫数量",
                        "入庫日",
                    };
                    break;
                case "在庫一覧":
                    documents = new string[]
                    {
                        "商品コード",
                        "商品名",
                        "在庫数量",
                        "棚番",
                    };
                    break;
                case "棚卸":
                    documents = new string[]
                    {
                        "商品コード",
                        "商品名",
                        "在庫数量",
                        "棚番",
                        "実在数量",
                    };
                    break;
                case "工程管理":
                    documents = new string[]
                    {
                        "生産計画立案",
                        "外注工程管理",
                        "進捗管理",
                        "品質管理",
                        "設備管理",
                        "出荷管理",
                    };
                    break;
                case "生産計画立案":
                    documents = new string[]
                    {
                        "商品コード",
                        "商品名",
                        "生産数量",
                        "完成日",
                    };
                    break;
                case "外注工程管理":
                    documents = new string[]
                    {
                        "商品コード",
                        "商品名",
                        "数量",
                        "発注先",
                        "納品日",
                    };
                    break;
                case "進捗管理":
                    documents = new string[]
                    {
                        "商品コード",
                        "商品名",
                        "数量",
                        "発注先",
                        "納品日",
                        "確認日",
                        "進捗率",
                    };
                    break;
                case "品質管理":
                    documents = new string[]
                    {
                        "商品コード",
                        "商品名",
                        "数量",
                        "発注先",
                        "納品日",
                        "確認日",
                        "検収結果",
                    };
                    break;
                case "設備管理":
                    documents = new string[]
                    {
                        "設備商品コード",
                        "設備名",
                        "数量",
                        "発注先",
                        "確認日",
                        "結果",
                    };
                    break;
                case "出荷管理":
                    documents = new string[]
                    {
                        "商品コード",
                        "商品名",
                        "数量",
                        "納品先",
                        "発送日",
                    };
                    break;
            }
            return documents;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new DialogWindow();
            dialog.ShowDialog();
        }
    }
}
