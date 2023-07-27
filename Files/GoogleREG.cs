using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace couse_work_gad
{
    public partial class GoogleREG : Form
    {
        public GoogleREG()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string Gender;

        private void GoogleREG_Load(object sender, EventArgs e)
        {
            txt_name.Text = Logpage.UName;
            txt_email.Text = Logpage.UEmail;
            con = new SqlConnection("Data Source=sql-db-server1.database.windows.net;Initial Catalog=airlinedb;PersistSecurityInfo=True;User ID=adminayesh;Password=Ayesh123456");

            con.Open();
            cmd = new SqlCommand("SELECT country, country_code FROM countrycode", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb_natinality.Items.Add(dr["country"].ToString());
                cmb_Residence_country.Items.Add(dr["country"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_name.Text == "")
                {
                    lbl_Fname.Visible = true;
                    lbl_Fname.ForeColor = Color.Red;
                    lbl_Fname.Text = "Please Enter Your First Name";
                    txt_name.BorderColor = Color.Red;
                    txt_name.Focus();
                }
                else if (txt_name.Text.Any(char.IsDigit))
                {
                    lbl_Fname.Visible = true;
                    lbl_Fname.ForeColor = Color.Red;
                    lbl_Fname.Text = "Please Only use Letter And First Letters Of The Name is Capital";
                    txt_name.BorderColor = Color.Red;
                    txt_name.Focus();
                }
                else if (cmb_natinality.Text == "")
                {
                    lbl_Nationality.Visible = true;
                    lbl_Nationality.ForeColor = Color.Red;
                    lbl_Nationality.Text = "Pllease Select Your Nationality";
                    cmb_natinality.Focus();
                }
                else if (txt_passport.Text != "")
                {
                    if (!Regex.Match(txt_passport.Text, @"^[A-Z]{2}\d{6}$").Success)
                    {
                        lbl_Passport.Visible = true;
                        lbl_Passport.ForeColor = Color.Red;
                        lbl_Passport.Text = "Please Enter Passport Number Correctly";
                        txt_passport.BorderColor = Color.Red;
                        txt_passport.Focus();
                    }
                }
                else if (cmb_Residence_country.Text == "")
                {
                    lbl_Resident_Country.Visible = true;
                    lbl_Resident_Country.ForeColor = Color.Red;
                    lbl_Resident_Country.Text = "Please Select Resident Country";
                    cmb_Residence_country.Focus();
                }
                else if (txt_contact.Text == "")
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Contact Number";
                    txt_contact.Focus();
                }
                else if (lbl_Contact.Visible)
                {
                    MessageBox.Show("Make sure your contact number is correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_contact.BorderColor = Color.Red;
                    txt_contact.Focus();
                }
                else if (txt_email.Text == "")
                {
                    lbl_Email.Visible = true;
                    lbl_Email.ForeColor = Color.Red;
                    lbl_Email.Text = "Please Enter Email";
                    txt_email.BorderColor = Color.Red;
                    txt_email.Focus();
                }
                else if (!Regex.Match(txt_email.Text, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$").Success)
                {
                    lbl_Email.Visible = true;
                    lbl_Email.ForeColor = Color.Red;
                    lbl_Email.Text = "Please Enter Valide Email";
                    txt_email.BorderColor = Color.Red;
                    txt_email.Focus();
                }
                else if (txt_city.Text == "")
                {
                    lbl_City.Visible = true;
                    lbl_City.ForeColor = Color.Red;
                    lbl_City.Text = "Enter City";
                    txt_city.BorderColor = Color.Red;
                    txt_city.Focus();
                }
                else if (!Regex.Match(txt_city.Text, @"^[a-zA-Z\s-]{1,100}$").Success)
                {
                    lbl_City.Visible = true;
                    lbl_City.ForeColor = Color.Red;
                    lbl_City.Text = "Enter Valid City Name";
                    txt_city.BorderColor = Color.Red;
                    txt_city.Focus();
                }
                else if (txt_address.Text == "")
                {
                    lbl_Address.Visible = true;
                    lbl_Address.ForeColor = Color.Red;
                    lbl_Address.Text = "Please Enter Address";
                    txt_address.BorderColor = Color.Red;
                    txt_address.Focus();
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("SELECT * FROM googleregistration WHERE email = '" + txt_email.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        this.Hide();
                        Home hm = new Home();
                        hm.Show();
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("INSERT INTO googleregistration VALUES ('" + txt_name.Text + "','" + txt_email.Text + "','" + Gender + "','" + cmb_natinality.Text + "','" + dob_picker.Value + "'," +
                        "'" + txt_passport.Text + "','" + cmb_Residence_country.Text + "','" + txt_contact.Text + "','" + txt_city.Text + "','" + txt_address.Text + "')", con);
                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                        {
                            MessageBox.Show("Registration Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            Home home = new Home();
                            home.Show();
                        }
                        else
                        {
                            MessageBox.Show("Registration Failed. Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
