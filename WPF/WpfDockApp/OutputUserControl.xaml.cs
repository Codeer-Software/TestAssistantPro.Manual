using Microsoft.Win32;
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
    /// OutputUserControl.xaml の相互作用ロジック
    /// </summary>
    public partial class OutputUserControl : UserControl
    {
        public OutputUserControl()
        {
            InitializeComponent();
        }
        internal void SetOutputTexts(string searchResult)
        {
            TextBox.Text = searchResult;
        }

        private void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Clipboard.SetText(TextBox.Text);
        }

        private void ButtonSaveFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, TextBox.Text);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = string.Empty;
        }
    }
}
