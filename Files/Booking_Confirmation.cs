using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MimeKit;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace couse_work_gad
{
    public partial class Booking_Confirmation : Form
    {
        public Booking_Confirmation()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public static string fnum;
        public static string Fnum
        {
            get { return fnum; }
            set { fnum = value; }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void Booking_Confirmation_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=sql-db-server1.database.windows.net;Initial Catalog=airlinedb;PersistSecurityInfo=True;User ID=adminayesh;Password=Ayesh123456");
                if (Logpage.UEmail == null)
                {
                    txt_email.Text = Logpage.User;
                    con.Open();
                    cmd = new SqlCommand("SELECT name FROM RegistrationsTB WHERE email = '" + txt_email.Text + "'", con);
                    string name = cmd.ExecuteScalar().ToString();
                    txt_name.Text = name;
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("SELECT phone_no FROM RegistrationsTB WHERE email = '" + txt_email.Text + "'", con);
                    string phone = cmd.ExecuteScalar().ToString();
                    txt_contact.Text = phone;
                    con.Close();
                }
                else 
                {
                    txt_email.Text = Logpage.UEmail;
                    con.Open();
                    cmd = new SqlCommand("SELECT name FROM googleregistration WHERE email = '" + txt_email.Text + "'", con);
                    string name = cmd.ExecuteScalar().ToString();
                    txt_name.Text = name;
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("SELECT phone_no FROM googleregistration WHERE email = '" + txt_email.Text + "'", con);
                    string phone = cmd.ExecuteScalar().ToString();
                    txt_contact.Text = phone;
                    con.Close();
                }
                
                if(UserControl1_travel.RETURN == null)
                {
                    txt_t_from.Enabled = false;
                    txt_t_to.Enabled = false;
                    lbl_rfc.Visible = false;
                    lbl_rsc.Visible = false;
                    lbl_rtc.Visible = false;
                    lbl_t_fprice.Visible = false;
                    lbl_t_sprice.Visible = false;
                    lbl_t_tprice.Visible = false;
                    lbl_t_fsheet.Visible = false;
                    lbl_t_ssheet.Visible = false;
                    lbl_t_tsheet.Visible = false;
                    lbl_t_fligtname.Visible = false;
                    lbl_t_airline.Visible = false;
                    txt_t_flightno.Visible = false;
                }
                else
                {
                    pb_qr.Visible = false;
                    lbl_bconfirm.Visible = false;
                    btn_download.Visible = false;

                    lbl_d_fligtno.Text = Fnum;
                    con = new SqlConnection("Data Source=sql-db-server1.database.windows.net;Initial Catalog=airlinedb;User ID=adminayesh;Password=Ayesh123456;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    con.Open();
                    cmd = new SqlCommand("select * from flight_data where flight_no = '" + lbl_d_fligtno.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txt_d_from.Text = (dr["from_location"].ToString());
                        txt_d_to.Text = (dr["to_location"].ToString());
                        lbl_departure_date.Text = (dr["departure_date"].ToString());
                        lbl_d_fligtname.Text = (dr["flight_name"].ToString());
                        lbl_d_airline.Text = (dr["airline"].ToString());
                        lbl_d_fsheet.Text = (dr["first_class"].ToString());
                        lbl_d_ssheet.Text = (dr["second_class"].ToString());
                        lbl_d_ssheet.Text = (dr["third_class"].ToString());
                        lbl_d_fprice.Text = (dr["first_class_price"].ToString());
                        lbl_d_sprice.Text = (dr["second_class_price"].ToString());
                        lbl_d_tprice.Text = (dr["third_class_price"].ToString());
                    }
                    else
                    {
                        dr.Close();
                        this.Close();
                        MessageBox.Show("Flight not found");
                    }
                    dr.Close();
                    con.Close();
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            if(txt_passport.Text == "")
            {
                lbl_passport_error.Visible = true;
                lbl_passport_error.Text = "Please enter passport number";
                lbl_passport_error.ForeColor = Color.Red;
                txt_passport.BorderColor = Color.Red;
                txt_passport.Focus();
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO onewayflightTB(from_location,to_location,departure_date,Flight_id,flight_name,passport_no,seat_price,cus_email) VALUES ('" + txt_d_from.Text + "','" + txt_d_to.Text + "','" + lbl_departure_date.Text + "','" + lbl_d_fligtno.Text + "'," +
                    "'" + lbl_d_fligtname.Text + "','" + txt_passport.Text + "','" + txt_total.Text + "','"+txt_email.Text+"')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                
                
                pb_qr.Visible = true;
                string textToencode = $"Departure : \tFrom : {txt_d_from.Text}\tTo: {txt_d_to.Text}\n Arrival : \tFrom : {txt_t_from.Text}\t To: {txt_t_to.Text}" +
                    $"\nCustomer Details \n\t Name: {txt_name.Text}\n\tEmail : {txt_email.Text}\n\tPassport No : {txt_passport.Text}\n\tContact No : {txt_contact.Text}";
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(textToencode, QRCodeGenerator.ECCLevel.Q))
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);
                    pb_qr.Image = qrCodeImage;
                    pb_qr.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                rdb_fclass.Visible = false;
                rdb_sclass.Visible = false;
                rdb_tclass.Visible = false;
                btn_pay.Visible = false;
                txt_total.Visible = false;
                lbl_totPrice.Visible = false;
                lbl_bconfirm.Visible = true;
                btn_download.Visible = true;
                MessageBox.Show("Payment Successful,Please proceed to Download Details", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Send Email
                string emailAddress = txt_email.Text;

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
                        ApplicationName = "Fly Easy International"
                    });

                    var emailMessage = new MimeMessage();
                    emailMessage.From.Add(new MailboxAddress("FlyEasy International", "hansanathimeth@gmail.com")); //Sender's Name and Email Address
                    emailMessage.To.Add(new MailboxAddress("", emailAddress)); // Recipient's email address
                    emailMessage.Subject = "Your Booking Details";
                    emailMessage.Body = new TextPart("plain")
                    {
                        Text = textToencode
                    };

                    var rawMessage = Base64UrlEncode(emailMessage.ToString());
                    var message = new Google.Apis.Gmail.v1.Data.Message
                    {
                        Raw = rawMessage
                    };

                    gmailService.Users.Messages.Send(message, "me").Execute();

                    MessageBox.Show("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while sending the email: {ex.Message}");
                }
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

        private void btn_download_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.Title = "Save the form as PDF";
            saveFileDialog.FileName = "Booking_Details.pdf"; // Set the default file name

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Create the PDF document and set up the size and margins
                Document doc = new Document(PageSize.A3, 20, 20, 20, 20);

                try
                {
                    // Create a PdfWriter instance to write to the file
                    PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                    // Open the document for writing
                    doc.Open();

                    // Render the form onto the PDF document
                    using (Graphics g = this.CreateGraphics())
                    {
                        using (Bitmap bmp = new Bitmap(this.Width, this.Height, g))
                        {
                            this.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));

                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Bmp);
                            img.ScalePercent(72f / img.DpiX * 100);
                            doc.Add(img);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while creating the PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    doc.Close();
                }

                MessageBox.Show("PDF file created and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rdb_fclass_CheckedChanged(object sender, EventArgs e)
        {
            if(rdb_fclass.Checked == true)
            {
                txt_total.Text = lbl_d_fprice.Text;
                btn_pay.Text = "Pay $" + lbl_d_fprice.Text;
            }
        }

        private void rdb_sclass_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_sclass.Checked == true)
            {
                txt_total.Text = lbl_d_sprice.Text;
                btn_pay.Text = "Pay $" + lbl_d_sprice.Text;
            }
        }

        private void rdb_tclass_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_tclass.Checked == true)
            {
                txt_total.Text = lbl_d_tprice.Text;
                btn_pay.Text = "Pay $" + lbl_d_tprice.Text;
            }
        }

        private void txt_passport_Click(object sender, EventArgs e)
        {
            lbl_passport_error.Visible = false;
        }
    }
}
