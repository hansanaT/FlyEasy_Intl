using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace couse_work_gad
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        private void Home_Load(object sender, EventArgs e)
        {
            /*con = new SqlConnection("Data Source=sql-db-server1.database.windows.net;Initial Catalog=airlinedb;PersistSecurityInfo=True;User ID=adminayesh;Password=Ayesh123456");
            con.Open();
            cmd = new SqlCommand("select * from RegistrationTB WHERE email = '"+Logpage.UName+"'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                btn_Login.Visible = false;
            }
            else
            {
                btn_Login.Visible = true;
            }*/



            user_control_promotion1.Hide();
            user_control_about_us1.Hide();
            userControl_cargo1.Hide();
            user_control_Mybooking1.Hide();
            uc_payments1.Hide();

            panel_services.Visible = false;
            user_control_promotion1.BackColor = Color.LightGray;
            userControl_cargo1.BackColor = Color.White;

            user_control_about_us1.BackColor = Color.White;
            user_control_about_us1.AutoScroll = false;

            uc_payments1.BackColor = Color.White;


        }

        private void btn_services_Click(object sender, EventArgs e)
        {
            panel_services.Visible = true;
            panel_services.BringToFront();
        }

       

        private void btn_Home_Click(object sender, EventArgs e)
        {
            user_control_promotion1.Hide();
            user_control_about_us1.Hide();
            userControl_cargo1.Hide();
            uc_payments1.Hide();



            userControl1_Home1.Show();
            userControl1_Home1.BringToFront();


        }

        private void btn_promotions_Click(object sender, EventArgs e)
        {
            userControl1_Home1.Hide();
            user_control_about_us1.Hide();
            userControl_cargo1.Hide();
            user_control_Mybooking1.Hide();
            uc_payments1.Hide();


            user_control_promotion1.Show();
            user_control_promotion1.BringToFront();

        }

        private void btn_about_us_Click(object sender, EventArgs e)
        {
            user_control_promotion1.Hide();
            userControl1_Home1.Hide();
            userControl_cargo1.Hide();
            user_control_Mybooking1.Hide();
            uc_payments1.Hide();

            user_control_about_us1.Show();
            user_control_about_us1.BringToFront();



        }

        private void btn_travel_Click(object sender, EventArgs e)
        {
            user_control_promotion1.Hide();
            userControl1_Home1.Hide();
            userControl_cargo1.Hide();
            user_control_about_us1.Hide();

            userControl1_travel1.Show();
            userControl1_travel1.BringToFront();
        }

        private void btn_cargo_Click(object sender, EventArgs e)
        {
            user_control_promotion1.Hide();
            userControl1_Home1.Hide();
            user_control_about_us1.Hide();

            userControl_cargo1.Show();
            userControl_cargo1.BringToFront();
        }

        private void btn_payment_Click(object sender, EventArgs e)
        {
            user_control_promotion1.Hide();
            userControl1_Home1.Hide();
            user_control_about_us1.Hide();
            userControl_cargo1.Hide();
            user_control_Mybooking1.Hide();

            uc_payments1.Show();
            uc_payments1.BringToFront();

            
        }

        private void btn_booking_Click(object sender, EventArgs e)
        {

            user_control_promotion1.Hide();
            userControl1_Home1.Hide();
            user_control_about_us1.Hide();
            userControl_cargo1.Hide();
            uc_payments1.Hide();

            user_control_Mybooking1.Show();
            user_control_Mybooking1.BringToFront();
        }

        private void uc_payments1_Load(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
