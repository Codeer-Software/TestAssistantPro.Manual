namespace WinFormsApp
{
    partial class MultiUserControlForm
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
            this.reservationInformationUserControl1 = new WinFormsApp.ReservationInformationUserControl();
            this.chargeOfPartyUserControl1 = new WinFormsApp.ChargeOfPartyUserControl();
            this.SuspendLayout();
            // 
            // reservationInformationUserControl1
            // 
            this.reservationInformationUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reservationInformationUserControl1.Location = new System.Drawing.Point(236, 12);
            this.reservationInformationUserControl1.Name = "reservationInformationUserControl1";
            this.reservationInformationUserControl1.Size = new System.Drawing.Size(268, 150);
            this.reservationInformationUserControl1.TabIndex = 1;
            // 
            // chargeOfPartyUserControl1
            // 
            this.chargeOfPartyUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chargeOfPartyUserControl1.Location = new System.Drawing.Point(12, 12);
            this.chargeOfPartyUserControl1.Name = "chargeOfPartyUserControl1";
            this.chargeOfPartyUserControl1.Size = new System.Drawing.Size(205, 150);
            this.chargeOfPartyUserControl1.TabIndex = 0;
            // 
            // MultiUserControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 181);
            this.Controls.Add(this.reservationInformationUserControl1);
            this.Controls.Add(this.chargeOfPartyUserControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MultiUserControlForm";
            this.Text = "MultiUserControlForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ChargeOfPartyUserControl chargeOfPartyUserControl1;
        private ReservationInformationUserControl reservationInformationUserControl1;
    }
}