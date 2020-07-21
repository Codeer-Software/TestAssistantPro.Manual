using System.Data;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        TreeForm _tree;
        OutputForm _output;

        public MainForm()
        {
            InitializeComponent();

            dockPanel.DocumentStyle = DocumentStyle.DockingWindow;

            _tree = new TreeForm();
            _tree.Show(dockPanel, DockState.DockLeft);
            _tree.OpenDocumentEvent += TreeWindow_ShowDocumentEvent;
            _output = new OutputForm();
            _output.Show(dockPanel, DockState.DockBottom);
        }

        void TreeWindow_ShowDocumentEvent(object sender, ShowDocumentEventArgs e)
        {
            var form = Application.OpenForms.OfType<OrderDocumentForm>().Where(x => x.Text == e.FileName).FirstOrDefault();
            if (form != null)
            {
                form.Show();
                return;
            }

            var doc = new OrderDocumentForm(e.Data);
            doc.Show(dockPanel, DockState.Document);
            doc.Text = e.FileName;

            doc.Searched += Doc_Searched;
        }

        void Doc_Searched(object sender, SearchEventArgs e)
            => _output.SetOutputTexts(e.SearchResult);

        void _toolStripMenuItemOpen_Click(object sender, System.EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.ShowDialog(this);
            }
        }

        void _toolStripMenuItemSave_Click(object sender, System.EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.ShowDialog(this);
            }
        }

        void _toolStripMenuItemSimpleDialog_Click(object sender, System.EventArgs e)
        {
            using (var dlg = new SimpleForm { StartPosition = FormStartPosition.CenterParent })
            {
                dlg.ShowDialog(this);
            }
        }

        void _toolStripMenuItemMultiUserControlDialog_Click(object sender, System.EventArgs e)
        {
            using (var dlg = new MultiUserControlForm { StartPosition = FormStartPosition.CenterParent })
            {
                dlg.ShowDialog(this);
            }
        }

        void _toolStripMenuItemCustomControlDialog_Click(object sender, System.EventArgs e)
        {
            using (var dlg = new CustomControlForm { StartPosition = FormStartPosition.CenterParent })
            {
                dlg.ShowDialog(this);
            }
        }

        void _toolStripMenuItemMessageBox_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(this, "Message.");
        }
    }
}
