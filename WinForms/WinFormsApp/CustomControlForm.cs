using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class CustomControlForm : Form
    {
        public CustomControlForm()
        {
            InitializeComponent();
        }

        void _buttonAdd_Click(object sender, EventArgs e)
            => _blockControl.AddBlock(new Rectangle(10, 10, 100, 100));
    }
}
