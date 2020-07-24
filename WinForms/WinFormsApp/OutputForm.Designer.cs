namespace WinFormsApp
{
    partial class OutputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputForm));
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this._toolStripButtonSaveFile = new System.Windows.Forms.ToolStripButton();
            this._textBoxResult = new System.Windows.Forms.TextBox();
            this._toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButtonCopy,
            this._toolStripButtonSaveFile,
            this._toolStripButtonClear});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(800, 25);
            this._toolStrip.TabIndex = 0;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _toolStripButtonCopy
            // 
            this._toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButtonCopy.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonCopy.Image")));
            this._toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonCopy.Name = "_toolStripButtonCopy";
            this._toolStripButtonCopy.Size = new System.Drawing.Size(38, 22);
            this._toolStripButtonCopy.Text = "Copy";
            this._toolStripButtonCopy.Click += new System.EventHandler(this._toolStripButtonCopy_Click);
            // 
            // _toolStripButtonSaveFile
            // 
            this._toolStripButtonSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButtonSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonSaveFile.Image")));
            this._toolStripButtonSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonSaveFile.Name = "_toolStripButtonSaveFile";
            this._toolStripButtonSaveFile.Size = new System.Drawing.Size(56, 22);
            this._toolStripButtonSaveFile.Text = "Save File";
            this._toolStripButtonSaveFile.Click += new System.EventHandler(this._toolStripButtonSaveFile_Click);
            // 
            // _textBoxResult
            // 
            this._textBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBoxResult.Location = new System.Drawing.Point(0, 25);
            this._textBoxResult.Multiline = true;
            this._textBoxResult.Name = "_textBoxResult";
            this._textBoxResult.ReadOnly = true;
            this._textBoxResult.Size = new System.Drawing.Size(800, 425);
            this._textBoxResult.TabIndex = 1;
            this._textBoxResult.WordWrap = false;
            // 
            // _toolStripButtonClear
            // 
            this._toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButtonClear.Image")));
            this._toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButtonClear.Name = "_toolStripButtonClear";
            this._toolStripButtonClear.Size = new System.Drawing.Size(37, 22);
            this._toolStripButtonClear.Text = "Clear";
            this._toolStripButtonClear.Click += new System.EventHandler(this._toolStripButtonClear_Click);
            // 
            // OutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._textBoxResult);
            this.Controls.Add(this._toolStrip);
            this.Name = "OutputForm";
            this.Text = "OutputForm";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton _toolStripButtonSaveFile;
        private System.Windows.Forms.TextBox _textBoxResult;
        private System.Windows.Forms.ToolStripButton _toolStripButtonClear;
    }
}