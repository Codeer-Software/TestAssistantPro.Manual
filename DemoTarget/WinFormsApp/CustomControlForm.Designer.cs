namespace WinFormsApp
{
    partial class CustomControlForm
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
            this._blockControl = new WinFormsApp.BlockControl();
            this._buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _blockControl
            // 
            this._blockControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._blockControl.Location = new System.Drawing.Point(12, 47);
            this._blockControl.Name = "_blockControl";
            this._blockControl.SelectedIndex = -1;
            this._blockControl.Size = new System.Drawing.Size(548, 304);
            this._blockControl.TabIndex = 0;
            this._blockControl.Text = "blockControl1";
            // 
            // _buttonAdd
            // 
            this._buttonAdd.Location = new System.Drawing.Point(12, 12);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(75, 23);
            this._buttonAdd.TabIndex = 1;
            this._buttonAdd.Text = "Add";
            this._buttonAdd.UseVisualStyleBackColor = true;
            this._buttonAdd.Click += new System.EventHandler(this._buttonAdd_Click);
            // 
            // CustomControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 366);
            this.Controls.Add(this._buttonAdd);
            this.Controls.Add(this._blockControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CustomControlForm";
            this.Text = "CustomControlForm";
            this.ResumeLayout(false);

        }

        #endregion

        private BlockControl _blockControl;
        private System.Windows.Forms.Button _buttonAdd;
    }
}