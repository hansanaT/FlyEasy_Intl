using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace couse_work_gad
{
    public partial class Addflight : Form
    {
        public Addflight()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_fid.Text == "")
                {
                    MessageBox.Show("Please enter flight id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_flightName.Text == "")
                {
                    MessageBox.Show("Please enter flight name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cmb_airline.Text == "")
                {
                    MessageBox.Show("Please select airline", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cmb_from.Text == "")
                {
                    MessageBox.Show("Please select departure city", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cmb_to.Text == "")
                {
                    MessageBox.Show("Please select destination city", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_departure.Text == "")
                {
                    MessageBox.Show("Please select departure date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_fclass.Text == "" || txt_sclass.Text == "" || txt_tclass.Text == "")
                {
                    MessageBox.Show("Please enter fligt availability", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_fprice.Text == "" || txt_sprice.Text == "" || txt_tprice.Text == "")
                {
                    MessageBox.Show("Please enter flight price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO flight_data VALUES ('" + cmb_from.Text + "','" + cmb_to.Text + "','" + txt_departure.Text + "','" + cmb_airline.Text + "','" + txt_flightName.Text + "','" + txt_fid.Text + "','" + txt_fclass.Text + "','" + txt_sclass.Text + "','" + txt_tclass.Text + "','" + txt_fprice.Text + "','" + txt_sprice.Text + "','" + txt_tprice.Text + "')", con);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("Flight added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE flight_data SET from_location = '" + cmb_from.Text + "', to_location = '" + cmb_to.Text + "', departure_date = '" + txt_departure.Text + "', airline = '" + cmb_airline.Text + "', flight_name = '" + txt_flightName.Text + "', first_class = '" + txt_fclass.Text + "', second_class = '" + txt_sclass.Text + "', third_class = '" + txt_tclass.Text + "', first_class_price = '" + txt_fprice.Text + "', second_class_price = '" + txt_sprice.Text + "', third_class_price = '" + txt_tprice.Text + "'WHERE flight_no = '" + txt_fid.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Flight updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM flight_data WHERE flight_no = '" + txt_fid.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Flight deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM flight_data WHERE flight_no = '" + txt_fid.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    txt_flightName.Text = dr["flight_name"].ToString();
                    cmb_airline.Text = dr["airline"].ToString();
                    cmb_from.Text = dr["from_location"].ToString();
                    cmb_to.Text = dr["to_location"].ToString();
                    txt_departure.Text = dr["departure_date"].ToString();
                    txt_fclass.Text = dr["first_class"].ToString();
                    txt_sclass.Text = dr["second_class"].ToString();
                    txt_tclass.Text = dr["third_class"].ToString();
                    txt_fprice.Text = dr["first_class_price"].ToString();
                    txt_sprice.Text = dr["second_class_price"].ToString();
                    txt_tprice.Text = dr["third_class_price"].ToString();

                }
                else
                {
                    MessageBox.Show("Flight not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Addflight_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=sql-db-server1.database.windows.net;Initial Catalog=airlinedb;User ID=adminayesh;Password=Ayesh123456;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                cmd = new SqlCommand("SELECT Airline From airlinecode", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmb_airline.Items.Add(dr["Airline"].ToString());
                }
                dr.Close();
                con.Close();

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
            catch
            {
                MessageBox.Show("Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
