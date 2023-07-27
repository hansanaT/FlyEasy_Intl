using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace couse_work_gad
{
    public partial class Booking_Rpt : Form
    {
        public Booking_Rpt()
        {
            InitializeComponent();
        }

        private void Booking_Rpt_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'bookingds.onewayflightTB' table. You can move, or remove it, as needed.
                this.onewayflightTBTableAdapter.Fill(this.bookingds.onewayflightTB, CS_Bookings.UEmail);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
