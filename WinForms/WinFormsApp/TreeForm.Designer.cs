namespace WinFormsApp
{
    partial class TreeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._treeView = new System.Windows.Forms.TreeView();
            this._contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this._contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _treeView
            // 
            this._treeView.ContextMenuStrip = this._contextMenu;
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView.Location = new System.Drawing.Point(0, 0);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(467, 339);
            this._treeView.TabIndex = 0;
            this._treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._treeView_NodeMouseDoubleClick);
            this._treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this._treeView_MouseDown);
            // 
            // _contextMenu
            // 
            this._contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItemOpen});
            this._contextMenu.Name = "_contextMenu";
            this._contextMenu.Size = new System.Drawing.Size(104, 26);
            this._contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this._contextMenu_Opening);
            // 
            // _toolStripMenuItemOpen
            // 
            this._toolStripMenuItemOpen.Name = "_toolStripMenuItemOpen";
            this._toolStripMenuItemOpen.Size = new System.Drawing.Size(103, 22);
            this._toolStripMenuItemOpen.Text = "Open";
            this._toolStripMenuItemOpen.Click += new System.EventHandler(this._toolStripMenuItemOpen_Click);
            // 
            // TreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 339);
            this.Controls.Add(this._treeView);
            this.Name = "TreeForm";
            this.Text = "TreeForm";
            this._contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.ContextMenuStrip _contextMenu;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemOpen;
    }
}