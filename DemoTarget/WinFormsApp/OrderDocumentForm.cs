using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WinFormsApp
{
    public partial class OrderDocumentForm : DockContent
    {
        public event EventHandler<SearchEventArgs> Searched;

        public OrderDocumentForm(string[][] data)
        {
            InitializeComponent();

            foreach (var e in data[0])
            {
                _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = e });
            }
            foreach (var e in data.Skip(1))
            {
                var row = _grid.Rows[_grid.Rows.Add()];
                for (int i = 0; i < e.Length; i++)
                {
                    row.Cells[i].Value = e[i];
                }
            }
        }

        void _searchButton_Click(object sender, EventArgs e)
        {
            var hits = new List<string>();
            for (int row = 0; row < _grid.Rows.Count; row++)
            {
                for (int col = 0; col < _grid.Columns.Count; col++)
                {
                    var cellText = _grid[col, row].Value?.ToString();
                    if (cellText != null && cellText.Contains(_searchTextBox.Text))
                    {
                        hits.Add($"{Text}({row},{col}) : {cellText}");
                    }
                }
            }
            Searched?.Invoke(this, new SearchEventArgs { SearchResult = hits.ToArray() });
        }
    }

    public class SearchEventArgs : EventArgs
    {
        public string[] SearchResult { get; set; }
    }
}
