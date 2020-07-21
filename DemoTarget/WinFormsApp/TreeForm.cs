using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WinFormsApp
{
    public partial class TreeForm : DockContent
    {
        public delegate void ShowDocumentHandler(object sender, ShowDocumentEventArgs e);
        public event ShowDocumentHandler OpenDocumentEvent;
        
        public TreeForm()
        {
            InitializeComponent();
            ShowDrives();
        }

        void ShowDrives()
        {
            TreeNode treeNode;
            foreach (var drive in GetTreeNodes())
            {
                treeNode = drive;
                _treeView.Nodes.Add(treeNode);
            }
            _treeView.ExpandAll();
        }

        public TreeNode[] GetTreeNodes()
        {
            var treeViewItem = new TreeNode[]
            {
                new TreeNode("Order management",
                    new TreeNode[]
                    {
                        new TreeNode("Accepted"){ Tag = new string [][]{
                            new []{ "Company", "Flower", "Person in charge", "money" },
                            new []{ "ABC, LTD.", "cherry blossom", "Chris", "100" },
                            new []{ "ABC, LTD.", "ume  blossom", "Chris", "300" },
                            new []{ "DEF, LTD.", "tulipm", "Pat", "300" },
                            new []{ "DEF, LTD.", "dandelion", "Pat", "700" },
                            new []{ "DEF, LTD.", "peach blossom", "Pat", "800" },
                            new []{ "GHI, LTD.", "flowering dogwood", "Alex", "900" },
                        } },
                        new TreeNode("Sended"){ Tag = new string [][]{
                            new []{ "Company", "Flower", "Person in charge", "money" },
                            new []{ "JKL, LTD.", "dianthus pink", "Dana", "800" },
                            new []{ "JKL, LTD.", "marigold", "Dana", "600" },
                            new []{ "JKL, LTD.", "azalea", "Dana", "700" },
                            new []{ "JKL, LTD.", "phalaenopsis orchid", "Dana", "900" },
                            new []{ "OPQ, LTD.", "daphne", "Hunter", "200" },
                            new []{ "STU, LTD.", "lily of the valley", "Jamie", "300" },
                        } }
                    })
            };
            return treeViewItem;
        }

        void _toolStripMenuItemOpen_Click(object sender, EventArgs e)
            => OpenDocumentEvent?.Invoke(this, new ShowDocumentEventArgs 
                { 
                    FileName = _treeView.SelectedNode.Text, 
                    Data = (string[][])_treeView.SelectedNode.Tag
                });

        void _contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
            => e.Cancel = _treeView.SelectedNode == null || _treeView.SelectedNode == _treeView.Nodes[0];

        void _treeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                var mouseNode = _treeView.GetNodeAt(e.X, e.Y);
                if (mouseNode != null)
                {
                    _treeView.SelectedNode = mouseNode;
                }
            }
        }

        void _treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == _treeView.Nodes[0]) return;
            OpenDocumentEvent?.Invoke(this, new ShowDocumentEventArgs 
            { 
                FileName = e.Node.Text,
                Data = (string[][])e.Node.Tag
            });
        }
    }

    public class ShowDocumentEventArgs : EventArgs
    {
        public string[][] Data { get; set; }
        public string FileName { get; set; }
    }
}
