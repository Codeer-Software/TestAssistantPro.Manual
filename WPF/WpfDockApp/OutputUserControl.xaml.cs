using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfDockApp
{
    public partial class OutputUserControl : UserControl
    {
        public OutputUserControl()
        {
            InitializeComponent();
        }
        internal void SetOutputTexts(string searchResult)
        {
            _textBox.Text = searchResult;
        }

        private void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(_textBox.Text);
        }

        private void ButtonSaveFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, _textBox.Text);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            _textBox.Text = string.Empty;
        }
    }
}
