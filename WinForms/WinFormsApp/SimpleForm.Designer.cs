namespace WinFormsApp
{
    partial class SimpleForm
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
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._dateTimePickerBirthday = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this._richTextBoxRemarks = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._buttonOK = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(74, 16);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(100, 19);
            this._textBoxName.TabIndex = 0;
            // 
            // _dateTimePickerBirthday
            // 
            this._dateTimePickerBirthday.Location = new System.Drawing.Point(74, 53);
            this._dateTimePickerBirthday.Name = "_dateTimePickerBirthday";
            this._dateTimePickerBirthday.Size = new System.Drawing.Size(200, 19);
            this._dateTimePickerBirthday.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Birthday";
            // 
            // _comboBoxLanguage
            // 
            this._comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxLanguage.FormattingEnabled = true;
            this._comboBoxLanguage.Items.AddRange(new object[] {
            "C#",
            "C++",
            "Java",
            "JavaScript"});
            this._comboBoxLanguage.Location = new System.Drawing.Point(74, 96);
            this._comboBoxLanguage.Name = "_comboBoxLanguage";
            this._comboBoxLanguage.Size = new System.Drawing.Size(121, 20);
            this._comboBoxLanguage.TabIndex = 6;
            // 
            // _richTextBoxRemarks
            // 
            this._richTextBoxRemarks.Location = new System.Drawing.Point(12, 157);
            this._richTextBoxRemarks.Name = "_richTextBoxRemarks";
            this._richTextBoxRemarks.Size = new System.Drawing.Size(299, 113);
            this._richTextBoxRemarks.TabIndex = 7;
            this._richTextBoxRemarks.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Language";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Remarks";
            // 
            // _buttonOK
            // 
            this._buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOK.Location = new System.Drawing.Point(155, 276);
            this._buttonOK.Name = "_buttonOK";
            this._buttonOK.Size = new System.Drawing.Size(75, 23);
            this._buttonOK.TabIndex = 10;
            this._buttonOK.Text = "OK";
            this._buttonOK.UseVisualStyleBackColor = true;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(236, 276);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 11;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // SimpleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 311);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._richTextBoxRemarks);
            this.Controls.Add(this._comboBoxLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._dateTimePickerBirthday);
            this.Controls.Add(this._textBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SimpleForm";
            this.Text = "Simple";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textBoxName;
        private System.Windows.Forms.DateTimePicker _dateTimePickerBirthday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _comboBoxLanguage;
        private System.Windows.Forms.RichTextBox _richTextBoxRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _buttonOK;
        private System.Windows.Forms.Button _buttonCancel;
    }
}