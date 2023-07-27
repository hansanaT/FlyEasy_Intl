using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace couse_work_gad
{
    public partial class EmployeeREG : Form
    {
        public EmployeeREG()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        string gender;

        private void EmployeeREG_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=sql-db-server1.database.windows.net;Initial Catalog=airlinedb;User ID=adminayesh;Password=Ayesh123456;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        private void btn_as_employee_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Fname.Text == "")
                {
                    lbl_Fname.Visible = true;
                    lbl_Fname.ForeColor = Color.Red;
                    lbl_Fname.Text = "Enter first name";
                }
                else if (txt_Lname.Text == "")
                {
                    lbl_Lname.Visible = true;
                    lbl_Lname.ForeColor = Color.Red;
                    lbl_Fname.Text = "Enter last name";
                }
                else if (txt_nic.Text == "")
                {
                    lbl_error_nic.Visible = true;
                    lbl_error_nic.ForeColor = Color.Red;
                    lbl_error_nic.Text = "Enter nic";
                }
                else if (txt_contact.Text == "")
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Enter contact number";
                }
                else if (txt_email.Text == "")
                {
                    lbl_Email.Visible = true;
                    lbl_Email.ForeColor = Color.Red;
                    lbl_Email.Text = "Enter email";
                }
                else if (txt_city.Text == "")
                {
                    lbl_City.Visible = true;
                    lbl_City.ForeColor = Color.Red;
                    lbl_City.Text = "Enter city";
                }
                else if (txt_address.Text == "")
                {
                    lbl_Address.Visible = true;
                    lbl_Address.ForeColor = Color.Red;
                    lbl_Address.Text = "Enter address";
                }
                else if (txt_password.Text == "")
                {
                    lbl_Password.Visible = true;
                    lbl_Password.ForeColor = Color.Red;
                    lbl_Password.Text = "Enter password";
                }
                else if (txt_password.Text != txt_password_confirm.Text)
                {
                    lbl_Confirm_Password.Visible = true;
                    lbl_Confirm_Password.ForeColor = Color.Red;
                    lbl_Confirm_Password.Text = "Re Enter password correctly";
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("SELECT * FROM employeeTB WHERE email = '" + txt_email.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("User already registerd as employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("INSERT INTO employeeTB VALUES('" + txt_empID.Text + "', '" + txt_Fname.Text + txt_Lname.Text + "', '" + gender + "', '" + dob_picker.Value + "', '" + txt_contact.Text + "', '" + txt_email.Text + "','" + txt_city.Text + "','" + txt_address.Text + "', '" + txt_password_confirm.Text + "', '" + txt_nic.Text + "')", con);
                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                        {
                            MessageBox.Show("User succesfully add as a employee", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdb_male_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_male.Checked == true)
            {
                gender = "Male";
            }
        }

        private void rdb_female_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_female.Checked == true)
            {
                gender = "Female";
            }
        }

        private void btn_employee_delete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM employeeTB WHERE employee_id = '" + txt_empID.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Employee delete succusfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("something went wrong. Please check EMP ID and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_employee_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_contact.Text == "")
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Enter Contact Number";
                }
                else if (txt_city.Text == "")
                {
                    lbl_City.Visible = true;
                    lbl_City.ForeColor = Color.Red;
                    lbl_City.Text = "Enter city";
                }
                else if (txt_address.Text == "")
                {
                    lbl_Address.Visible = true;
                    lbl_Address.ForeColor = Color.Red;
                    lbl_Address.Text = "Enter address";
                }
                else if (txt_password.Text == "")
                {
                    lbl_Password.Visible = true;
                    lbl_Password.ForeColor = Color.Red;
                    lbl_Password.Text = "Enter password";
                }
                else if (txt_password.Text != txt_password_confirm.Text)
                {
                    lbl_Confirm_Password.Visible = true;
                    lbl_Confirm_Password.ForeColor = Color.Red;
                    lbl_Confirm_Password.Text = "Re Enter password correctly";
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE employeeTB SET phone_no = '" + txt_contact.Text + "', city = '" + txt_city.Text + "', address = '" + txt_address.Text + "', password = '" + txt_password_confirm.Text + "' WHERE employee_id = '" + txt_empID.Text + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("Employee update succfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong. check EMP ID and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_as_admin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Fname.Text == "")
                {
                    lbl_Fname.Visible = true;
                    lbl_Fname.ForeColor = Color.Red;
                    lbl_Fname.Text = "Enter first name";
                }
                else if (txt_Lname.Text == "")
                {
                    lbl_Lname.Visible = true;
                    lbl_Lname.ForeColor = Color.Red;
                    lbl_Fname.Text = "Enter last name";
                }
                else if (txt_nic.Text == "")
                {
                    lbl_error_nic.Visible = true;
                    lbl_error_nic.ForeColor = Color.Red;
                    lbl_error_nic.Text = "Enter nic";
                }
                else if (txt_contact.Text == "")
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Enter contact number";
                }
                else if (txt_email.Text == "")
                {
                    lbl_Email.Visible = true;
                    lbl_Email.ForeColor = Color.Red;
                    lbl_Email.Text = "Enter email";
                }
                else if (txt_city.Text == "")
                {
                    lbl_City.Visible = true;
                    lbl_City.ForeColor = Color.Red;
                    lbl_City.Text = "Enter city";
                }
                else if (txt_address.Text == "")
                {
                    lbl_Address.Visible = true;
                    lbl_Address.ForeColor = Color.Red;
                    lbl_Address.Text = "Enter address";
                }
                else if (txt_password.Text == "")
                {
                    lbl_Password.Visible = true;
                    lbl_Password.ForeColor = Color.Red;
                    lbl_Password.Text = "Enter password";
                }
                else if (txt_password.Text != txt_password_confirm.Text)
                {
                    lbl_Confirm_Password.Visible = true;
                    lbl_Confirm_Password.ForeColor = Color.Red;
                    lbl_Confirm_Password.Text = "Re Enter password correctly";
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("SELECT * FROM adminTB WHERE email = '" + txt_email.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("User already registerd as admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("INSERT INTO adminTB VALUES('" + txt_empID.Text + "', '" + (txt_Fname.Text + txt_Lname.Text) + "', '" + gender + "', '" + dob_picker.Value + "', '" + txt_contact.Text + "', '" + txt_email.Text + "','" + txt_city.Text + "','" + txt_address.Text + "', '" + txt_password_confirm.Text + "')", con);
                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                        {
                            MessageBox.Show("User succesfully add as a admin", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btn_admin_delete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM adminTB WHERE admin_id = '" + txt_empID.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("admin delete succusfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("something went wrong. Please check ADMIN ID and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_admin_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_contact.Text == "")
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Enter Contact Number";
                }
                else if (txt_city.Text == "")
                {
                    lbl_City.Visible = true;
                    lbl_City.ForeColor = Color.Red;
                    lbl_City.Text = "Enter city";
                }
                else if (txt_address.Text == "")
                {
                    lbl_Address.Visible = true;
                    lbl_Address.ForeColor = Color.Red;
                    lbl_Address.Text = "Enter address";
                }
                else if (txt_password.Text == "")
                {
                    lbl_Password.Visible = true;
                    lbl_Password.ForeColor = Color.Red;
                    lbl_Password.Text = "Enter password";
                }
                else if (txt_password.Text != txt_password_confirm.Text)
                {
                    lbl_Confirm_Password.Visible = true;
                    lbl_Confirm_Password.ForeColor = Color.Red;
                    lbl_Confirm_Password.Text = "Re Enter password correctly";
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE adminTB SET phone_no = '" + txt_contact.Text + "', city = '" + txt_city.Text + "', address = '" + txt_address.Text + "', password = '" + txt_password_confirm.Text + "' WHERE admin_id = '" + txt_empID.Text + "'", con);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("Admin update succfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong. check ADMIN ID and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void chb_show_password_CheckedChanged(object sender, EventArgs e)
        {
            if(chb_show_password.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }
    }
}
