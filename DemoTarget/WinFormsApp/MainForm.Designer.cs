namespace WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItemEtc = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItemSimpleDialog = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItemMultiUserControlDialog = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItemCustomControlDialog = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItemMessageBox = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItemFile,
            this._toolStripMenuItemEtc});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this._menuStrip.Size = new System.Drawing.Size(807, 24);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _toolStripMenuItemFile
            // 
            this._toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItemOpen,
            this._toolStripMenuItemSave});
            this._toolStripMenuItemFile.Name = "_toolStripMenuItemFile";
            this._toolStripMenuItemFile.ShortcutKeyDisplayString = "(F)";
            this._toolStripMenuItemFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this._toolStripMenuItemFile.Size = new System.Drawing.Size(37, 22);
            this._toolStripMenuItemFile.Text = "File";
            // 
            // _toolStripMenuItemOpen
            // 
            this._toolStripMenuItemOpen.Name = "_toolStripMenuItemOpen";
            this._toolStripMenuItemOpen.ShortcutKeyDisplayString = "";
            this._toolStripMenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._toolStripMenuItemOpen.Size = new System.Drawing.Size(145, 22);
            this._toolStripMenuItemOpen.Text = "Open";
            this._toolStripMenuItemOpen.Click += new System.EventHandler(this._toolStripMenuItemOpen_Click);
            // 
            // _toolStripMenuItemSave
            // 
            this._toolStripMenuItemSave.Name = "_toolStripMenuItemSave";
            this._toolStripMenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._toolStripMenuItemSave.Size = new System.Drawing.Size(145, 22);
            this._toolStripMenuItemSave.Text = "Save";
            this._toolStripMenuItemSave.Click += new System.EventHandler(this._toolStripMenuItemSave_Click);
            // 
            // _toolStripMenuItemEtc
            // 
            this._toolStripMenuItemEtc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItemSimpleDialog,
            this._toolStripMenuItemMultiUserControlDialog,
            this._toolStripMenuItemCustomControlDialog,
            this._toolStripMenuItemMessageBox});
            this._toolStripMenuItemEtc.Name = "_toolStripMenuItemEtc";
            this._toolStripMenuItemEtc.Size = new System.Drawing.Size(38, 22);
            this._toolStripMenuItemEtc.Text = "etc.";
            // 
            // _toolStripMenuItemSimpleDialog
            // 
            this._toolStripMenuItemSimpleDialog.Name = "_toolStripMenuItemSimpleDialog";
            this._toolStripMenuItemSimpleDialog.Size = new System.Drawing.Size(204, 22);
            this._toolStripMenuItemSimpleDialog.Text = "Simple Dialog";
            this._toolStripMenuItemSimpleDialog.Click += new System.EventHandler(this._toolStripMenuItemSimpleDialog_Click);
            // 
            // _toolStripMenuItemMultiUserControlDialog
            // 
            this._toolStripMenuItemMultiUserControlDialog.Name = "_toolStripMenuItemMultiUserControlDialog";
            this._toolStripMenuItemMultiUserControlDialog.Size = new System.Drawing.Size(204, 22);
            this._toolStripMenuItemMultiUserControlDialog.Text = "Multi UserControl Dialog";
            this._toolStripMenuItemMultiUserControlDialog.Click += new System.EventHandler(this._toolStripMenuItemMultiUserControlDialog_Click);
            // 
            // _toolStripMenuItemCustomControlDialog
            // 
            this._toolStripMenuItemCustomControlDialog.Name = "_toolStripMenuItemCustomControlDialog";
            this._toolStripMenuItemCustomControlDialog.Size = new System.Drawing.Size(204, 22);
            this._toolStripMenuItemCustomControlDialog.Text = "Custom Control Dialog";
            this._toolStripMenuItemCustomControlDialog.Click += new System.EventHandler(this._toolStripMenuItemCustomControlDialog_Click);
            // 
            // _toolStripMenuItemMessageBox
            // 
            this._toolStripMenuItemMessageBox.Name = "_toolStripMenuItemMessageBox";
            this._toolStripMenuItemMessageBox.Size = new System.Drawing.Size(204, 22);
            this._toolStripMenuItemMessageBox.Text = "MessageBox";
            this._toolStripMenuItemMessageBox.Click += new System.EventHandler(this._toolStripMenuItemMessageBox_Click);
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Location = new System.Drawing.Point(0, 24);
            this.dockPanel.Margin = new System.Windows.Forms.Padding(2);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(807, 491);
            this.dockPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 515);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "WinFormsApp";
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemSave;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemEtc;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemSimpleDialog;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemMessageBox;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemMultiUserControlDialog;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemCustomControlDialog;
    }
}

