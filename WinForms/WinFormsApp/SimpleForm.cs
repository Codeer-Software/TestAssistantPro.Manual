using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class SimpleForm : Form
    {
        public SimpleForm()
        {
            InitializeComponent();
            _comboBoxLanguage.SelectedIndex = 0;
        }
    }
}
