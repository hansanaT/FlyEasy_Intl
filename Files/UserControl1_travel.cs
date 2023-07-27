using FontAwesome.Sharp;
using MailKit.Search;
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
    public partial class UserControl1_travel : UserControl
    {
        public UserControl1_travel()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        int check;
        int dpt, rtn;
        public static string returnd;
        public static string departured;
        public static string RETURN
        {
            get { return returnd; }
            set { returnd = value; }
        }
        public static string DEPARTURE
        {
            get { return departured; }
            set { departured = value; }
        }

        //int rowcount;

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                DEPARTURE = btn_departure.Text;
                RETURN = btn_return.Text;
                
                if (cmb_from.Text == "" || cmb_to.Text == "")
                {
                    MessageBox.Show("Please select a location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (rdb_one_way.Checked)
                {
                    if (btn_departure.Text == "")
                    {
                        MessageBox.Show("Please select a date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        con.Open();

                        da = new SqlDataAdapter("SELECT from_location, to_location, departure_date, airline, flight_name, flight_no,first_class, second_class, third_class, first_class_price, second_class_price, third_class_price " +
                                                   "FROM flight_data WHERE (from_location = '" + cmb_from.Text + "' AND to_location = '" + cmb_to.Text + "') AND departure_date = '" + btn_departure.Text + "'", con);
                        cmd = new SqlCommand("SELECT from_location, to_location, departure_date, airline, flight_name, flight_no,first_class, second_class, third_class, first_class_price, second_class_price, third_class_price " +
                            "FROM flight_data WHERE (from_location = '" + cmb_from.Text + "' AND to_location = '" + cmb_to.Text + "') AND departure_date = '" + btn_departure.Text + "'", con);
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            dr.Close();
                            dt = new DataTable();
                            da.Fill(dt);
                            //rowcount = dt.Rows.Count; //get the total number of rows
                            search_results[] results = new search_results[dt.Rows.Count]; //populate items in the list as per the row count


                            for (int i = 0; i < dt.Rows.Count; i++) //loop through the rows
                            {

                                DataRow drw = dt.Rows[i];
                                search_results search_Results = new search_results();
                                search_Results.From = drw["from_location"].ToString(); //populate the first column
                                search_Results.To = drw["to_location"].ToString(); //populate the second column
                                search_Results.Departure = drw["departure_date"].ToString(); //populate the third column
                                search_Results.Airline = drw["airline"].ToString(); //populate the fourth column
                                search_Results.FlightName = drw["flight_name"].ToString(); //populate the fifth column
                                search_Results.FlightNumber = drw["flight_no"].ToString(); //populate the sixth colum
                                search_Results.FirstClass = Convert.ToInt32(drw["first_class"]); //populate the seventh column
                                search_Results.SecondClass = Convert.ToInt32(drw["second_class"]); //populate the eighth column
                                search_Results.ThirdClass = Convert.ToInt32(drw["third_class"]); //populate the ninth column
                                search_Results.First_Class_Price = Convert.ToInt32(drw["first_class_price"]); //populate the tenth column
                                search_Results.Second_Class_Price = Convert.ToInt32(drw["second_class_price"]); //populate the eleventh column
                                search_Results.Third_Class_Price = Convert.ToInt32(drw["third_class_price"]); //populate the twelveth column
                                results[i] = search_Results; //add the populated rows to the list


                                if (panel_departure_results.Controls.Count < 0)
                                {
                                    panel_departure_results.Controls.Clear();
                                }
                                else
                                {
                                    panel_departure_results.BackColor = Color.White;
                                    panel_departure_results.Controls.Add(results[i]);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No flight found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        dr.Close();

                        con.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void rdb_one_way_CheckedChanged(object sender, EventArgs e)
        {
            btn_return.Visible = false;
            lbl_Return.Visible = false;
            btn_return.Text = "";
            btn_departure.Width = cmb_from.Width;

            check = 1;
        }

        private void rdb_round_trip_CheckedChanged(object sender, EventArgs e)
        {
            btn_return.Visible = true;
            btn_departure.Width = btn_return.Width;

            check = 2;
        }

        private void UserControl1_travel_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=sql-db-server1.database.windows.net;Initial Catalog=airlinedb;User ID=adminayesh;Password=Ayesh123456;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                rdb_round_trip.Checked = true;
                txt_month.Text = "Jan";

                con.Open();
                cmd = new SqlCommand("SELECT airport FROM airportcode", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmb_from.Items.Add(dr["airport"].ToString());
                    cmb_to.Items.Add(dr["airport"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_month.Text == "Jan")
                {
                    txt_month.Text = "Feb";
                }
                else if (txt_month.Text == "Feb")
                {
                    txt_month.Text = "Mar";
                }
                else if (txt_month.Text == "Mar")
                {
                    txt_month.Text = "Apr";
                }
                else if (txt_month.Text == "Apr")
                {
                    txt_month.Text = "May";
                }
                else if (txt_month.Text == "May")
                {
                    txt_month.Text = "Jun";
                }
                else if (txt_month.Text == "Jun")
                {
                    txt_month.Text = "Jul";
                }
                else if (txt_month.Text == "Jul")
                {
                    txt_month.Text = "Aug";
                }
                else if (txt_month.Text == "Aug")
                {
                    txt_month.Text = "Sep";
                }
                else if (txt_month.Text == "Sep")
                {
                    txt_month.Text = "Oct";
                }
                else if (txt_month.Text == "Oct")
                {
                    txt_month.Text = "Nov";
                }
                else if (txt_month.Text == "Nov")
                {
                    txt_month.Text = "Dec";
                }
                else if (txt_month.Text == "Dec")
                {
                    txt_month.Text = "Jan";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_month.Text == "Dec")
                {
                    txt_month.Text = "Nov";
                }
                else if (txt_month.Text == "Nov")
                {
                    txt_month.Text = "Oct";
                }
                else if (txt_month.Text == "Oct")
                {
                    txt_month.Text = "Sep";
                }
                else if (txt_month.Text == "Sep")
                {
                    txt_month.Text = "Aug";
                }
                else if (txt_month.Text == "Aug")
                {
                    txt_month.Text = "Jul";
                }
                else if (txt_month.Text == "Jul")
                {
                    txt_month.Text = "Jun";
                }
                else if (txt_month.Text == "Jun")
                {
                    txt_month.Text = "May";
                }
                else if (txt_month.Text == "May")
                {
                    txt_month.Text = "Apr";
                }
                else if (txt_month.Text == "Apr")
                {
                    txt_month.Text = "Mar";
                }
                else if (txt_month.Text == "Mar")
                {
                    txt_month.Text = "Feb";
                }
                else if (txt_month.Text == "Feb")
                {
                    txt_month.Text = "Jan";
                }
                else if (txt_month.Text == "Jan")
                {
                    txt_month.Text = "Dec";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txt_year_TextChanged(object sender, EventArgs e)
        {
            txt_get_year.Text = txt_year.Text;
        }

        private void txt_month_TextChanged(object sender, EventArgs e)
        {
            txt_get_month.Text = txt_month.Text;
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            txt_get_date.Text = "1";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            txt_get_date.Text = "1";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            txt_get_date.Text = "1";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            txt_get_date.Text = "1";
        }

        private void btn_24_Click(object sender, EventArgs e)
        {
            txt_get_date.Text = "24";
        }

        private void txt_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            panel_calander.Visible = false;
        }

        private void btn_departure_Click(object sender, EventArgs e)
        {
            panel_calander.Visible = true;
            lbl_de_re.Text = "Choose Your Departure Date";
            dpt = 1;
            rtn = 0;

            panel_calander.BringToFront();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_get_date.Text == "" || txt_get_month.Text == "" || txt_get_year.Text == "")
                {
                    MessageBox.Show("Please select a date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (dpt == 1)
                    {
                        btn_departure.Text = txt_get_date.Text + "/" + txt_get_month.Text + "/" + txt_get_year.Text;
                    }
                    else if (rtn == 1)
                    {
                        btn_return.Text = txt_get_date.Text + "/" + txt_get_month.Text + "/" + txt_get_year.Text;
                    }
                    panel_calander.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
