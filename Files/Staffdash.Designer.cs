namespace couse_work_gad
{
    partial class Staffdash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Staffdash));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelCf = new System.Windows.Forms.Panel();
            this.pB_intro = new System.Windows.Forms.PictureBox();
            this.btn_maximize = new System.Windows.Forms.Button();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_userid = new System.Windows.Forms.Label();
            this.panel_datetime = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pB_profile = new System.Windows.Forms.PictureBox();
            this.panel_title = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_logout = new Guna.UI2.WinForms.Guna2Button();
            this.btn_bookings = new Guna.UI2.WinForms.Guna2Button();
            this.btn_addflight = new Guna.UI2.WinForms.Guna2Button();
            this.btn_csdetails = new Guna.UI2.WinForms.Guna2Button();
            this.btn_adminpanel = new Guna.UI2.WinForms.Guna2Button();
            this.btn_dashboard = new Guna.UI2.WinForms.Guna2Button();
            this.panel_nav = new System.Windows.Forms.Panel();
            this.panelCf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_intro)).BeginInit();
            this.panel_datetime.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_profile)).BeginInit();
            this.panel_title.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelCf
            // 
            this.panelCf.Controls.Add(this.pB_intro);
            this.panelCf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCf.Location = new System.Drawing.Point(284, 133);
            this.panelCf.Name = "panelCf";
            this.panelCf.Size = new System.Drawing.Size(1204, 843);
            this.panelCf.TabIndex = 6;
            // 
            // pB_intro
            // 
            this.pB_intro.Location = new System.Drawing.Point(0, -1);
            this.pB_intro.Name = "pB_intro";
            this.pB_intro.Size = new System.Drawing.Size(1204, 797);
            this.pB_intro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_intro.TabIndex = 0;
            this.pB_intro.TabStop = false;
            // 
            // btn_maximize
            // 
            this.btn_maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_maximize.BackColor = System.Drawing.Color.Transparent;
            this.btn_maximize.FlatAppearance.BorderSize = 0;
            this.btn_maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_maximize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_maximize.Location = new System.Drawing.Point(1132, 9);
            this.btn_maximize.Name = "btn_maximize";
            this.btn_maximize.Size = new System.Drawing.Size(25, 25);
            this.btn_maximize.TabIndex = 3;
            this.btn_maximize.UseVisualStyleBackColor = false;
            // 
            // btn_minimize
            // 
            this.btn_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_minimize.Location = new System.Drawing.Point(1094, 9);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(25, 25);
            this.btn_minimize.TabIndex = 2;
            this.btn_minimize.UseVisualStyleBackColor = false;
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_exit.Location = new System.Drawing.Point(1170, 9);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(25, 25);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.UseVisualStyleBackColor = false;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(178)))));
            this.lbl_title.Location = new System.Drawing.Point(40, 49);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(200, 44);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Dashboard";
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(178)))));
            this.lbl_date.Location = new System.Drawing.Point(30, 64);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.Size = new System.Drawing.Size(83, 37);
            this.lbl_date.TabIndex = 0;
            this.lbl_date.Text = "Date";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(178)))));
            this.lbl_time.Location = new System.Drawing.Point(30, 19);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(87, 37);
            this.lbl_time.TabIndex = 0;
            this.lbl_time.Text = "Time";
            // 
            // lbl_userid
            // 
            this.lbl_userid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_userid.AutoSize = true;
            this.lbl_userid.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_userid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(178)))));
            this.lbl_userid.Location = new System.Drawing.Point(14, 160);
            this.lbl_userid.Name = "lbl_userid";
            this.lbl_userid.Size = new System.Drawing.Size(57, 17);
            this.lbl_userid.TabIndex = 2;
            this.lbl_userid.Text = "User ID:";
            // 
            // panel_datetime
            // 
            this.panel_datetime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_datetime.Controls.Add(this.lbl_date);
            this.panel_datetime.Controls.Add(this.lbl_time);
            this.panel_datetime.Location = new System.Drawing.Point(547, 2);
            this.panel_datetime.Name = "panel_datetime";
            this.panel_datetime.Size = new System.Drawing.Size(654, 124);
            this.panel_datetime.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_userid);
            this.panel2.Controls.Add(this.pB_profile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 220);
            this.panel2.TabIndex = 0;
            // 
            // pB_profile
            // 
            this.pB_profile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pB_profile.Image = ((System.Drawing.Image)(resources.GetObject("pB_profile.Image")));
            this.pB_profile.Location = new System.Drawing.Point(92, 22);
            this.pB_profile.Name = "pB_profile";
            this.pB_profile.Size = new System.Drawing.Size(100, 97);
            this.pB_profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pB_profile.TabIndex = 0;
            this.pB_profile.TabStop = false;
            // 
            // panel_title
            // 
            this.panel_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel_title.Controls.Add(this.panel_datetime);
            this.panel_title.Controls.Add(this.btn_maximize);
            this.panel_title.Controls.Add(this.btn_minimize);
            this.panel_title.Controls.Add(this.btn_exit);
            this.panel_title.Controls.Add(this.lbl_title);
            this.panel_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title.Location = new System.Drawing.Point(284, 0);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(1204, 133);
            this.panel_title.TabIndex = 5;
            this.panel_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_title_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(147)))));
            this.panel1.Controls.Add(this.btn_logout);
            this.panel1.Controls.Add(this.btn_bookings);
            this.panel1.Controls.Add(this.btn_addflight);
            this.panel1.Controls.Add(this.btn_csdetails);
            this.panel1.Controls.Add(this.btn_adminpanel);
            this.panel1.Controls.Add(this.btn_dashboard);
            this.panel1.Controls.Add(this.panel_nav);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 976);
            this.panel1.TabIndex = 4;
            // 
            // btn_logout
            // 
            this.btn_logout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_logout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_logout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_logout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_logout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_logout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(147)))));
            this.btn_logout.Font = new System.Drawing.Font("Candara", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.ForeColor = System.Drawing.Color.Black;
            this.btn_logout.Image = global::couse_work_gad.Properties.Resources.exit1;
            this.btn_logout.Location = new System.Drawing.Point(0, 919);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(284, 57);
            this.btn_logout.TabIndex = 14;
            this.btn_logout.Text = "Logout";
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_bookings
            // 
            this.btn_bookings.BackColor = System.Drawing.Color.Transparent;
            this.btn_bookings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_bookings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_bookings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_bookings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_bookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_bookings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(147)))));
            this.btn_bookings.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.btn_bookings.ForeColor = System.Drawing.Color.Black;
            this.btn_bookings.Image = global::couse_work_gad.Properties.Resources._79215291;
            this.btn_bookings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_bookings.ImageSize = new System.Drawing.Size(35, 35);
            this.btn_bookings.Location = new System.Drawing.Point(0, 472);
            this.btn_bookings.Name = "btn_bookings";
            this.btn_bookings.Size = new System.Drawing.Size(284, 63);
            this.btn_bookings.TabIndex = 11;
            this.btn_bookings.Text = "Bookings";
            this.btn_bookings.UseTransparentBackground = true;
            this.btn_bookings.Click += new System.EventHandler(this.btn_bookings_Click);
            // 
            // btn_addflight
            // 
            this.btn_addflight.BackColor = System.Drawing.Color.Transparent;
            this.btn_addflight.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_addflight.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_addflight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_addflight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_addflight.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_addflight.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(147)))));
            this.btn_addflight.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addflight.ForeColor = System.Drawing.Color.Black;
            this.btn_addflight.Image = global::couse_work_gad.Properties.Resources.flight2;
            this.btn_addflight.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_addflight.ImageSize = new System.Drawing.Size(35, 35);
            this.btn_addflight.Location = new System.Drawing.Point(0, 409);
            this.btn_addflight.Name = "btn_addflight";
            this.btn_addflight.Size = new System.Drawing.Size(284, 63);
            this.btn_addflight.TabIndex = 10;
            this.btn_addflight.Text = "Add Flight";
            this.btn_addflight.UseTransparentBackground = true;
            this.btn_addflight.Click += new System.EventHandler(this.btn_addflight_Click);
            // 
            // btn_csdetails
            // 
            this.btn_csdetails.BackColor = System.Drawing.Color.Transparent;
            this.btn_csdetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_csdetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_csdetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_csdetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_csdetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_csdetails.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(147)))));
            this.btn_csdetails.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_csdetails.ForeColor = System.Drawing.Color.Black;
            this.btn_csdetails.Image = global::couse_work_gad.Properties.Resources._216117_card_business_icon;
            this.btn_csdetails.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_csdetails.ImageSize = new System.Drawing.Size(35, 35);
            this.btn_csdetails.Location = new System.Drawing.Point(0, 346);
            this.btn_csdetails.Name = "btn_csdetails";
            this.btn_csdetails.Size = new System.Drawing.Size(284, 63);
            this.btn_csdetails.TabIndex = 9;
            this.btn_csdetails.Text = "Customer Details";
            this.btn_csdetails.UseTransparentBackground = true;
            this.btn_csdetails.Click += new System.EventHandler(this.btn_csdetails_Click);
            // 
            // btn_adminpanel
            // 
            this.btn_adminpanel.BackColor = System.Drawing.Color.Transparent;
            this.btn_adminpanel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_adminpanel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_adminpanel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_adminpanel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_adminpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_adminpanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(147)))));
            this.btn_adminpanel.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.btn_adminpanel.ForeColor = System.Drawing.Color.Black;
            this.btn_adminpanel.Image = global::couse_work_gad.Properties.Resources.admin_panel;
            this.btn_adminpanel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_adminpanel.ImageSize = new System.Drawing.Size(35, 35);
            this.btn_adminpanel.Location = new System.Drawing.Point(0, 283);
            this.btn_adminpanel.Name = "btn_adminpanel";
            this.btn_adminpanel.Size = new System.Drawing.Size(284, 63);
            this.btn_adminpanel.TabIndex = 8;
            this.btn_adminpanel.Text = "Admin Panel";
            this.btn_adminpanel.UseTransparentBackground = true;
            this.btn_adminpanel.Click += new System.EventHandler(this.btn_adminpanel_Click);
            // 
            // btn_dashboard
            // 
            this.btn_dashboard.BackColor = System.Drawing.Color.Transparent;
            this.btn_dashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_dashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_dashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_dashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_dashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(107)))), ((int)(((byte)(147)))));
            this.btn_dashboard.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dashboard.ForeColor = System.Drawing.Color.Black;
            this.btn_dashboard.Image = global::couse_work_gad.Properties.Resources._290102_control_panel_dashboard_gauge_measure_meter_icon;
            this.btn_dashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_dashboard.ImageSize = new System.Drawing.Size(35, 35);
            this.btn_dashboard.Location = new System.Drawing.Point(0, 220);
            this.btn_dashboard.Name = "btn_dashboard";
            this.btn_dashboard.Size = new System.Drawing.Size(284, 63);
            this.btn_dashboard.TabIndex = 7;
            this.btn_dashboard.Text = "Dashboard";
            this.btn_dashboard.UseTransparentBackground = true;
            this.btn_dashboard.Click += new System.EventHandler(this.btn_dashboard_Click);
            // 
            // panel_nav
            // 
            this.panel_nav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel_nav.Location = new System.Drawing.Point(0, 283);
            this.panel_nav.Name = "panel_nav";
            this.panel_nav.Size = new System.Drawing.Size(6, 100);
            this.panel_nav.TabIndex = 3;
            // 
            // Staffdash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 976);
            this.Controls.Add(this.panelCf);
            this.Controls.Add(this.panel_title);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Staffdash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staffdash";
            this.Load += new System.EventHandler(this.Staffdash_Load);
            this.panelCf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pB_intro)).EndInit();
            this.panel_datetime.ResumeLayout(false);
            this.panel_datetime.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_profile)).EndInit();
            this.panel_title.ResumeLayout(false);
            this.panel_title.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelCf;
        private System.Windows.Forms.PictureBox pB_intro;
        private System.Windows.Forms.Button btn_maximize;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_userid;
        private System.Windows.Forms.Panel panel_datetime;
        private System.Windows.Forms.PictureBox pB_profile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_title;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btn_dashboard;
        private Guna.UI2.WinForms.Guna2Button btn_bookings;
        private Guna.UI2.WinForms.Guna2Button btn_addflight;
        private Guna.UI2.WinForms.Guna2Button btn_csdetails;
        private Guna.UI2.WinForms.Guna2Button btn_adminpanel;
        private Guna.UI2.WinForms.Guna2Button btn_logout;
        private System.Windows.Forms.Panel panel_nav;
    }
}