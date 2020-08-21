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
    /// OrderDocumentUserControl.xaml の相互作用ロジック
    /// </summary>
    public partial class OrderDocumentUserControl : UserControl
    {
        public delegate void SearchEventHandler(object sender, SearchEventArgs e);
        public event SearchEventHandler SearchEvent;

        public string Title { get; set; }

        public OrderDocumentUserControl()
        {
            InitializeComponent();
        }

        public void SetDocument(string[][] document)
        {
            DataGrid.ItemsSource = document;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var hits = new List<string>();
            var items = DataGrid.Items;
            for (int row = 0; row < items.Count; row++)
            {
                var texts = (string[])items[row];
                for (int col = 0; col < texts.Length; col++)
                {
                    string text = texts[col];
                    {
                        if (text.Contains(SearchText.Text))
                        {
                            hits.Add($"OrderDocument ({row},{col}) : {text}");
                        }
                    }
                }
            }

            string result = string.Empty;
            foreach (var hit in hits)
            {
                result += hit + "\n";
            }
            SearchEvent?.Invoke(this, new SearchEventArgs(result));
        }
    }
}
