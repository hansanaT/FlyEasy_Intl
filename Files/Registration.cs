﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Net.Mail;
using Guna.UI2.WinForms;
using System.Drawing.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;
using System.IO;
using System.Threading;

namespace couse_work_gad
{
    public partial class Registration : Form
    {

        public Registration()
        {
            InitializeComponent();

            lbl_Passport.Visible = true;
            lbl_Passport.ForeColor = Color.Blue;
            lbl_Passport.Text = "Passport Number Is Optional";
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public string Gender;
        private Random random = new Random();
        private int randomNumber;
        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Fname.Text == "")
                {
                    lbl_Fname.Visible = true;
                    lbl_Fname.ForeColor = Color.Red;
                    lbl_Fname.Text = "Please Enter Your First Name";
                    txt_Fname.BorderColor = Color.Red;
                    txt_Fname.Focus();
                }
                else if (!Regex.Match(txt_Fname.Text, "^[A-Z][a-zA-Z]*$").Success)
                {
                    lbl_Fname.Visible = true;
                    lbl_Fname.ForeColor = Color.Red;
                    lbl_Fname.Text = "Please Only use Letter And First Letters Of The Name is Capital";
                    txt_Fname.BorderColor = Color.Red;
                    txt_Fname.Focus();
                }
                else if (txt_Lname.Text == "")
                {
                    lbl_Lname.Visible = true;
                    lbl_Lname.ForeColor = Color.Red;
                    lbl_Lname.Text = "Please Enter Your Last Name";
                    txt_Lname.BorderColor = Color.Red;
                    txt_Lname.Focus();
                }
                else if (!Regex.Match(txt_Lname.Text, "^[A-Z][a-zA-Z]*$").Success)
                {
                    lbl_Lname.Visible = true;
                    lbl_Lname.ForeColor = Color.Red;
                    lbl_Lname.Text = "Please Only use Letter And First Letters Of The Name is Capital";
                    txt_Lname.BorderColor = Color.Red;
                    txt_Lname.Focus();  
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
                else if(txt_contact.Text == "")
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
                else if (txt_email_confirm.Text == "")
                {
                    lbl_Confirm_Email.Visible = true;
                    lbl_Confirm_Email.ForeColor = Color.Red;
                    lbl_Confirm_Email.Text = "Re Enter Email";
                    txt_email_confirm.BorderColor = Color.Red;
                    txt_email_confirm.Focus();
                }
                else if (txt_email_confirm.Text != txt_email.Text)
                {
                    lbl_Confirm_Email.Visible = true;
                    lbl_Confirm_Email.ForeColor = Color.Red;
                    lbl_Confirm_Email.Text = "Re Enter Correct Emaii";
                    txt_email_confirm.BorderColor = Color.Red;
                    txt_email_confirm.Focus();
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
                else if (txt_password.Text == "")
                {
                    lbl_Password.Visible = true;
                    lbl_Password.ForeColor = Color.Red;
                    lbl_Password.Text = "Please Enter Password";
                    txt_password.BorderColor = Color.Red;
                    txt_password.Focus();
                }
                else if (!Regex.Match(txt_password.Text, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{12}$").Success)
                {
                    lbl_Password.Visible = true;
                    lbl_Password.ForeColor = Color.Red;
                    lbl_Password.Text = "Please Enter Valid Password";
                    txt_password.BorderColor = Color.Red;
                    txt_password.Focus();
                }
                else if (txt_password_confirm.Text == "")
                {
                    lbl_Confirm_Password.Visible = true;
                    lbl_Confirm_Password.ForeColor = Color.Red;
                    lbl_Confirm_Password.Text = "Please Re-Enter Password";
                    txt_password_confirm.Focus();
                }
                else if (txt_password_confirm.Text != txt_password.Text)
                {
                    lbl_Confirm_Password.Visible = true;
                    lbl_Confirm_Password.ForeColor = Color.Red;
                    lbl_Confirm_Password.Text = "Re-Enter Correct Password";
                    txt_password_confirm.BorderColor = Color.Red;
                    txt_password_confirm.Focus();
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("SELECT * FROM RegistrationsTB WHERE email = '" + txt_email.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        MessageBox.Show("User Already Registerd. Please Use Login Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        
                        dr.Close();
                        cmd = new SqlCommand("INSERT INTO RegistrationsTB VALUES ('"+txt_Fname.Text +" "+ txt_Lname.Text+"','"+Gender+"','"+cmb_natinality.Text+"','"+dob_picker.Value+"','"+txt_passport.Text+"'," +
                        "'"+cmb_Residence_country.Text+"','"+txt_contact.Text+"','"+txt_email.Text+"','"+txt_city.Text+"','"+txt_address.Text+"','"+txt_password.Text+"')",con);
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
            catch(OutOfMemoryException)
            {
                MessageBox.Show("Out Of Memory Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmb_Residence_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT country_code FROM countrycode WHERE country = '" + cmb_Residence_country.Text + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_country_code.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
            con.Close();

            lbl_Resident_Country.Visible = false;
            if (txt_contact.Text == "")
            {
                lbl_Contact.Visible = true;
                lbl_Contact.ForeColor = Color.Red;
                lbl_Contact.Text = "Please Enter You'r Contact Number";
            }
            else if (txt_country_code.Text == "+94")
            {
                if (!Regex.Match(txt_contact.Text, @"^(0\d{9})$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Sri Lannka Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+91")
            {
                if (!Regex.Match(txt_contact.Text, @"^[6789]\d{9}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid India Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+1")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{10}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid America Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+81")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{10}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Japan Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+82")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{9,10}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Korea(South Korea) Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+7")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{10}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Russia Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+44")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{10}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid United Kindom Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+86")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{11}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid China Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+61")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{9}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Australia Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+65")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{8}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Singapore Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
        }

        private void txt_Fname_Click(object sender, EventArgs e)
        {
            lbl_Fname.Visible=false;    
            txt_Fname.BorderColor= Color.Black;
        }

        private void txt_Lname_Click(object sender, EventArgs e)
        {
            lbl_Lname.Visible=false;
            txt_Lname.BorderColor= Color.Black;
        }

        private void cmb_natinality_Click(object sender, EventArgs e)
        {
            lbl_Nationality.Visible=false;
        }

        private void txt_passport_Click(object sender, EventArgs e)
        {
            lbl_Passport.Visible = false;
            lbl_Passport.ForeColor = Color.Blue;
            lbl_Passport.Text = "Passport Number Is Optional";
            txt_passport.BorderColor= Color.Black;
        }
        private void txt_contact_TextChanged(object sender, EventArgs e)
        {
            if (txt_contact.Text == "")
            {
                lbl_Contact.Visible = true;
                lbl_Contact.ForeColor = Color.Red;
                lbl_Contact.Text = "Please Enter You'r Contact Number";
            }
            else if (txt_country_code.Text == "+94")
            {
                if (!Regex.Match(txt_contact.Text, @"^(0\d{9})$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Sri Lannka Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+91")
            {
                if (!Regex.Match(txt_contact.Text, @"^[6789]\d{9}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid India Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+1")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{10}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid America Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+81")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{10}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Japan Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+82")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{9,10}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Korea(South Korea) Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+7")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{10}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Russia Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+44")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{10}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid United Kindom Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+86")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{11}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid China Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+61")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{9}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Australia Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
            else if (txt_country_code.Text == "+65")
            {
                if (!Regex.Match(txt_contact.Text, @"^\d{8}$").Success)
                {
                    lbl_Contact.Visible = true;
                    lbl_Contact.ForeColor = Color.Red;
                    lbl_Contact.Text = "Please Enter Valid Singapore Contact Number";
                    txt_contact.BorderColor = Color.Red;
                }
                else
                {
                    lbl_Contact.Visible = false;
                    txt_contact.BorderColor = Color.Black;
                }
            }
        }
        private void txt_email_Click(object sender, EventArgs e)
        {
            lbl_Email.Visible = false;
            txt_email.BorderColor = Color.Black;
        }

        private void txt_email_confirm_Click(object sender, EventArgs e)
        {
            lbl_Confirm_Email.Visible = false;
            txt_email_confirm.BorderColor = Color.Black;
        }

        private void txt_city_Click(object sender, EventArgs e)
        {
            lbl_City.Visible = false;
            txt_city.BorderColor = Color.Black;
        }

        private void txt_address_Click(object sender, EventArgs e)
        {
            lbl_Address.Visible = false;   
            txt_address.BorderColor = Color.Black;
        }

        private void txt_password_Click(object sender, EventArgs e)
        {
            lbl_Password.Visible = false;
            txt_passport.BorderColor = Color.Black;
        }

        private void txt_password_confirm_Click(object sender, EventArgs e)
        {
            lbl_Confirm_Password.Visible = false;
            txt_password_confirm.BorderColor = Color.Black;
        }

        private void txt_password_MouseEnter(object sender, EventArgs e)
        {
            txt_Password_Info.Visible = true;
        }

        private void txt_password_MouseLeave(object sender, EventArgs e)
        {
           txt_Password_Info.Visible = false;
        }

        private void btn_register_MouseEnter(object sender, EventArgs e)
        {
            /*btn_register.Size = new Size(200, 50);
            
            btn_register.ForeColor = Color.FromArgb(27, 107, 147);
            btn_register.FillColor = Color.Yellow;*/
        }

        private void btn_register_MouseLeave(object sender, EventArgs e)
        {
            /*btn_register.Size = new Size(195, 45);
            btn_register.FillColor = Color.FromArgb(27, 107, 147);
            btn_register.ForeColor = Color.White;*/
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            txt_email_confirm.ReadOnly = true;
            btn_verifyCode.Visible = false;

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

            rdb_male.Checked = true;

            /*dob_picker.MaxDate = DateTime.Today.AddYears(-16);
            dob_picker.MinDate = DateTime.Today.AddYears(-100);
            dob_picker.Value = DateTime.Now;*/
        }
        private void rdb_male_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void rdb_female_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }

        private void chb_show_password_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_show_password.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
                txt_password_confirm.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
                txt_password_confirm.UseSystemPasswordChar = true;
            }
        }

        private void btn_verifyEmail_Click(object sender, EventArgs e)
        {
            txt_email.ReadOnly = true;
            btn_verifyEmail.Visible = false;
            btn_verifyCode.Visible = true;
            txt_verifyCode.ReadOnly = false;
            randomNumber = random.Next(100000, 999999);
            con.Open();
            cmd = new SqlCommand("INSERT INTO verify_code VALUES('" + txt_email.Text + "','" + randomNumber + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            string emailAddress = txt_email.Text;
            string messageText = $"Your Verification code is {randomNumber}";

            try
            {
                UserCredential credential;

                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        new[] { GmailService.Scope.GmailSend },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                var gmailService = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Your Application Name"
                });

                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("Hansana Adhikari", "hansanathimeth@gmail.com")); //Sender's Name and Email Address
                emailMessage.To.Add(new MailboxAddress("", emailAddress)); // Recipient's email address
                emailMessage.Subject = "Welcome to the Application!";
                emailMessage.Body = new TextPart("plain")
                {
                    Text = messageText
                };

                var rawMessage = Base64UrlEncode(emailMessage.ToString());
                var message = new Google.Apis.Gmail.v1.Data.Message
                {
                    Raw = rawMessage
                };

                gmailService.Users.Messages.Send(message, "me").Execute();

                MessageBox.Show("Email Sent,Check your email for the verification code","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while sending the email: {ex.Message}");
            }
        }
        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return System.Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }

        private void btn_verifyCode_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT email FROM verify_code WHERE verification_code = '" + txt_verifyCode.Text + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                txt_verifyCode.Enabled = false;
                lbl_verifymsg.Text = "Verified";
                lbl_verifymsg.Visible = true;
                lbl_verifymsg.ForeColor = Color.Green;
                txt_email_confirm.ReadOnly = true;
                txt_email_confirm.Text = txt_email.Text;
                btn_verifyCode.Visible = false;
                cmd = new SqlCommand("TRUNCATE TABLE verify_code",con);
                cmd.ExecuteNonQuery();
            }
            else
            {
                dr.Close();
                txt_verifyCode.Enabled = false;
                lbl_verifymsg.Text = "Invalid Verification Code, Try Again!";
                lbl_verifymsg.Visible = true;
                lbl_verifymsg.ForeColor = Color.Red;
                txt_verifyCode.Clear();
                txt_email.Focus();
                txt_email.ReadOnly = false;
                btn_verifyCode.Visible = false;
                btn_verifyEmail.Visible = true;
                cmd = new SqlCommand("TRUNCATE TABLE verify_code", con);
                cmd.ExecuteNonQuery();
            }
            dr.Close();
            con.Close();
        }

        private void txt_verifyCode_Click(object sender, EventArgs e)
        {
            lbl_verifymsg.Visible = false;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            Home hm = new Home();
            hm.Show();
        }
    }
}
