namespace WinFormsApp
{
    partial class ReservationInformationUserControl
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this._checkBoxSmoking = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this._radioButtonCourse = new System.Windows.Forms.RadioButton();
            this._radioButtonAlacarte = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // _checkBoxSmoking
            // 
            this._checkBoxSmoking.AutoSize = true;
            this._checkBoxSmoking.Location = new System.Drawing.Point(14, 12);
            this._checkBoxSmoking.Name = "_checkBoxSmoking";
            this._checkBoxSmoking.Size = new System.Drawing.Size(67, 16);
            this._checkBoxSmoking.TabIndex = 0;
            this._checkBoxSmoking.Text = "Smoking";
            this._checkBoxSmoking.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(113, 45);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 19);
            this.numericUpDown1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of people";
            // 
            // _radioButtonCourse
            // 
            this._radioButtonCourse.AutoSize = true;
            this._radioButtonCourse.Location = new System.Drawing.Point(14, 77);
            this._radioButtonCourse.Name = "_radioButtonCourse";
            this._radioButtonCourse.Size = new System.Drawing.Size(59, 16);
            this._radioButtonCourse.TabIndex = 3;
            this._radioButtonCourse.TabStop = true;
            this._radioButtonCourse.Text = "Course";
            this._radioButtonCourse.UseVisualStyleBackColor = true;
            // 
            // _radioButtonAlacarte
            // 
            this._radioButtonAlacarte.AutoSize = true;
            this._radioButtonAlacarte.Location = new System.Drawing.Point(14, 109);
            this._radioButtonAlacarte.Name = "_radioButtonAlacarte";
            this._radioButtonAlacarte.Size = new System.Drawing.Size(74, 16);
            this._radioButtonAlacarte.TabIndex = 4;
            this._radioButtonAlacarte.TabStop = true;
            this._radioButtonAlacarte.Text = "A la carte";
            this._radioButtonAlacarte.UseVisualStyleBackColor = true;
            // 
            // ReservationInformationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._radioButtonAlacarte);
            this.Controls.Add(this._radioButtonCourse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this._checkBoxSmoking);
            this.Name = "ReservationInformationUserControl";
            this.Size = new System.Drawing.Size(268, 161);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox _checkBoxSmoking;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton _radioButtonCourse;
        private System.Windows.Forms.RadioButton _radioButtonAlacarte;
    }
}
