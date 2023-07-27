using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace couse_work_gad
{
    public partial class Staffdash : Form
    {
        public Staffdash()
        {
            InitializeComponent();
        }
        private Form currentChildForm;
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
                currentChildForm.Close();
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelCf.Controls.Add(childForm);
            panelCf.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbl_title.Text = childForm.Text;
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            panel_nav.BringToFront();
            panel_nav.Height = btn_dashboard.Height;
            panel_nav.Top = btn_dashboard.Top;
            panel_nav.Left = btn_dashboard.Left;
            btn_dashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btn_adminpanel_Click(object sender, EventArgs e)
        {
            panel_nav.BringToFront();
            panel_nav.Height = btn_adminpanel.Height;
            panel_nav.Top = btn_adminpanel.Top;
            panel_nav.Left = btn_adminpanel.Left;
            btn_adminpanel.BackColor = Color.FromArgb(24, 30, 54);
            OpenChildForm(new EmployeeREG());
        }

        private void btn_csdetails_Click(object sender, EventArgs e)
        {
            panel_nav.BringToFront();
            panel_nav.Height = btn_csdetails.Height;
            panel_nav.Top = btn_csdetails.Top;
            panel_nav.Left = btn_csdetails.Left;
            btn_csdetails.BackColor = Color.FromArgb(24, 30, 54);
            OpenChildForm(new Customerdetails());
        }

        private void btn_addflight_Click(object sender, EventArgs e)
        {
            panel_nav.BringToFront();
            panel_nav.Height = btn_addflight.Height;
            panel_nav.Top = btn_addflight.Top;
            panel_nav.Left = btn_addflight.Left;
            btn_addflight.BackColor = Color.FromArgb(24, 30, 54);
            OpenChildForm(new Addflight());
        }

        private void btn_bookings_Click(object sender, EventArgs e)
        {
            panel_nav.BringToFront();
            panel_nav.Height = btn_bookings.Height;
            panel_nav.Top = btn_bookings.Top;
            panel_nav.Left = btn_bookings.Left;
            btn_bookings.BackColor = Color.FromArgb(24, 30, 54);
            OpenChildForm(new CS_Bookings());
        }

        private void Staffdash_Load(object sender, EventArgs e)
        {
            lbl_userid.Text = "User ID : " +Logpage.User;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToLongTimeString();
            lbl_date.Text = DateTime.Now.ToLongDateString();
        }

        //Drag FORM DLL

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel_title_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Logpage log = new Logpage();
            log.Show();
        }
    }
}
