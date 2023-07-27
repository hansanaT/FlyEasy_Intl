namespace couse_work_gad
{
    partial class CS_Bookings
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
            this.label1 = new System.Windows.Forms.Label();
            this.pb_scan = new System.Windows.Forms.PictureBox();
            this.btn_scan = new Guna.UI2.WinForms.Guna2Button();
            this.cmb_camType = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_csEmail = new System.Windows.Forms.TextBox();
            this.btn_generaterpt = new Guna.UI2.WinForms.Guna2Button();
            this.rtb_qr = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_scan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan QR Code";
            // 
            // pb_scan
            // 
            this.pb_scan.Location = new System.Drawing.Point(184, 174);
            this.pb_scan.Name = "pb_scan";
            this.pb_scan.Size = new System.Drawing.Size(346, 247);
            this.pb_scan.TabIndex = 1;
            this.pb_scan.TabStop = false;
            // 
            // btn_scan
            // 
            this.btn_scan.AutoRoundedCorners = true;
            this.btn_scan.BorderRadius = 28;
            this.btn_scan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_scan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_scan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_scan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_scan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_scan.ForeColor = System.Drawing.Color.White;
            this.btn_scan.Location = new System.Drawing.Point(270, 438);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(180, 59);
            this.btn_scan.TabIndex = 2;
            this.btn_scan.Text = "Scan";
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // cmb_camType
            // 
            this.cmb_camType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_camType.FormattingEnabled = true;
            this.cmb_camType.Location = new System.Drawing.Point(811, 102);
            this.cmb_camType.Name = "cmb_camType";
            this.cmb_camType.Size = new System.Drawing.Size(309, 33);
            this.cmb_camType.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(647, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Capture Device :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(696, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Customer Email :";
            // 
            // txt_csEmail
            // 
            this.txt_csEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_csEmail.Location = new System.Drawing.Point(863, 438);
            this.txt_csEmail.Name = "txt_csEmail";
            this.txt_csEmail.Size = new System.Drawing.Size(247, 27);
            this.txt_csEmail.TabIndex = 6;
            // 
            // btn_generaterpt
            // 
            this.btn_generaterpt.AutoRoundedCorners = true;
            this.btn_generaterpt.BorderRadius = 22;
            this.btn_generaterpt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_generaterpt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_generaterpt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_generaterpt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_generaterpt.FillColor = System.Drawing.Color.Green;
            this.btn_generaterpt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generaterpt.ForeColor = System.Drawing.Color.White;
            this.btn_generaterpt.Location = new System.Drawing.Point(884, 497);
            this.btn_generaterpt.Name = "btn_generaterpt";
            this.btn_generaterpt.Size = new System.Drawing.Size(180, 46);
            this.btn_generaterpt.TabIndex = 7;
            this.btn_generaterpt.Text = "Generate Report";
            this.btn_generaterpt.Click += new System.EventHandler(this.btn_generaterpt_Click);
            // 
            // rtb_qr
            // 
            this.rtb_qr.Location = new System.Drawing.Point(691, 195);
            this.rtb_qr.Name = "rtb_qr";
            this.rtb_qr.ReadOnly = true;
            this.rtb_qr.Size = new System.Drawing.Size(429, 226);
            this.rtb_qr.TabIndex = 8;
            this.rtb_qr.Text = "";
            // 
            // CS_Bookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 796);
            this.Controls.Add(this.rtb_qr);
            this.Controls.Add(this.btn_generaterpt);
            this.Controls.Add(this.txt_csEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_camType);
            this.Controls.Add(this.btn_scan);
            this.Controls.Add(this.pb_scan);
            this.Controls.Add(this.label1);
            this.Name = "CS_Bookings";
            this.Text = "Scan Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CS_Bookings_FormClosing);
            this.Load += new System.EventHandler(this.CS_Bookings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_scan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_scan;
        private Guna.UI2.WinForms.Guna2Button btn_scan;
        private System.Windows.Forms.ComboBox cmb_camType;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_csEmail;
        private Guna.UI2.WinForms.Guna2Button btn_generaterpt;
        private System.Windows.Forms.RichTextBox rtb_qr;
    }
}