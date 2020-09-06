using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfDockApp
{
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
            _dataGrid.ItemsSource = document;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var hits = new List<string>();
            var items = _dataGrid.Items;
            for (int row = 0; row < items.Count; row++)
            {
                var texts = (string[])items[row];
                for (int col = 0; col < texts.Length; col++)
                {
                    string text = texts[col];
                    {
                        if (text.Contains(_searchText.Text))
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
