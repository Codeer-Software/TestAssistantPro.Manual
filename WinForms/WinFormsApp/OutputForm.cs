﻿using System;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WinFormsApp
{
    public partial class OutputForm : DockContent
    {
        public OutputForm()
            => InitializeComponent();

        internal void SetOutputTexts(string[] searchResult)
            => _textBoxResult.Text = string.Join(Environment.NewLine, searchResult);

        void _toolStripButtonCopy_Click(object sender, System.EventArgs e)
            => Clipboard.SetText(_textBoxResult.Text);

        void _toolStripButtonSaveFile_Click(object sender, System.EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                File.WriteAllText(dlg.FileName, _textBoxResult.Text);
            }
        }

        void _toolStripButtonClear_Click(object sender, EventArgs e)
            => _textBoxResult.Text = string.Empty;
    }
}
