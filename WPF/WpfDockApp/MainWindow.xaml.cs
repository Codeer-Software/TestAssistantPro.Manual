using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.Windows;
using Xceed.Wpf.AvalonDock.Layout;

namespace WpfDockApp
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            _treeUserControl.MakeDocumentEvent += TreeUserControl_MakeDocumentEvent;
        }

        private void TreeUserControl_MakeDocumentEvent(object sender, MakeDocumentEventArgs e)
        {
            var documents = e.Document;
            bool found = false;
            foreach (var document in _documentPane.Children)
            {
                if (document is LayoutDocument layoutDocument)
                {
                    if (layoutDocument.Title == e.Header)
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
                layoutDocument.Title = e.Header;
                var documentControl = new OrderDocumentUserControl();
                documentControl.Title = e.Header;
                documentControl.SearchEvent += DocumentControl_SearchEvent;
                documentControl.SetDocument(documents);
                layoutDocument.Content = documentControl;
                _documentPane.Children.Add(layoutDocument);
                layoutDocument.IsSelected = true;
            }
        }

        private void DocumentControl_SearchEvent(object sender, SearchEventArgs e)
        {
            _outputUserControl.SetOutputTexts(e.SearchResult);
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

        private void ItemsControlDialog_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ItemsControlWindow();
            dialog.ShowDialog();
        }

        private void MessageBoxDialog_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "Message.");
        }
    }
}
