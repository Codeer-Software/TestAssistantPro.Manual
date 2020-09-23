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
            this._reservationInformationUserControl = new WinFormsApp.ReservationInformationUserControl();
            this._chargeOfPartyUserControl = new WinFormsApp.ChargeOfPartyUserControl();
            this.SuspendLayout();
            // 
            // _reservationInformationUserControl
            // 
            this._reservationInformationUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._reservationInformationUserControl.Location = new System.Drawing.Point(236, 12);
            this._reservationInformationUserControl.Name = "_reservationInformationUserControl";
            this._reservationInformationUserControl.Size = new System.Drawing.Size(268, 150);
            this._reservationInformationUserControl.TabIndex = 1;
            // 
            // _chargeOfPartyUserControl
            // 
            this._chargeOfPartyUserControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._chargeOfPartyUserControl.Location = new System.Drawing.Point(12, 12);
            this._chargeOfPartyUserControl.Name = "_chargeOfPartyUserControl";
            this._chargeOfPartyUserControl.Size = new System.Drawing.Size(205, 150);
            this._chargeOfPartyUserControl.TabIndex = 0;
            // 
            // MultiUserControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 181);
            this.Controls.Add(this._reservationInformationUserControl);
            this.Controls.Add(this._chargeOfPartyUserControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MultiUserControlForm";
            this.Text = "MultiUserControlForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ChargeOfPartyUserControl _chargeOfPartyUserControl;
        private ReservationInformationUserControl _reservationInformationUserControl;
    }
}