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
    public partial class Customerdetails : Form
    {
        public Customerdetails()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private void btn_search_Click(object sender, EventArgs e)
        {
            if(txt_search_email.Text == "")
            {
                lbl_search_email.Visible = true;
                lbl_search_email.ForeColor = Color.Red;
                lbl_search_email.Text = "Please Enter Customer Email For Search";
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM registrationTB WHERE email = '" + txt_search_email.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_name.Text = dr["name"].ToString();
                    txt_gender.Text = dr["gender"].ToString();
                    txt_nationality.Text = dr["nationality"].ToString();
                    txt_date_of_birth.Text = dr["date_of_birth"].ToString();
                    txt_passport_no.Text = dr["passport_no"].ToString();
                    txt_country_resident.Text = dr["country_of_residence"].ToString();
                    txt_contact.Text = dr["phone_no"].ToString();
                    txt_city.Text = dr["city"].ToString();
                    txt_address.Text = dr["address"].ToString();
                    dr.Close();
                    con.Close();

                    txt_registration_type.Text = "Normal Registration";
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("SELECT * FROM googleregistration WHERE email = '" + txt_search_email.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txt_name.Text = dr["name"].ToString();
                        txt_gender.Text = dr["gender"].ToString();
                        txt_nationality.Text = dr["nationality"].ToString();
                        txt_date_of_birth.Text = dr["date_of_birth"].ToString();
                        txt_passport_no.Text = dr["passport_no"].ToString();
                        txt_country_resident.Text = dr["country_of_residence"].ToString();
                        txt_contact.Text = dr["phone_no"].ToString();
                        txt_city.Text = dr["city"].ToString();
                        txt_address.Text = dr["address"].ToString();
                        dr.Close();
                        con.Close();

                        txt_registration_type.Text = "Google Registration";
                    }
                    else
                    {
                        MessageBox.Show("Unregisterd User","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Customerdetails_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try 
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM RegistrationsTB WHERE email = '" + txt_search_email.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("User account delete succesfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("DELET FROM googleregistration WHERE email = '" + txt_search_email.Text + "'", con);
                    int ii = cmd.ExecuteNonQuery();
                    if (ii == 1)
                    {
                        MessageBox.Show("User account delete succesfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Unregisterd User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
