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
    public partial class search_results : UserControl
    {
        public search_results()
        {
            InitializeComponent();
        }

        #region Properties

        private string _from;
        private string _to;
        private string _departure;
        private string _fname;
        private string _fnumber;
        private int _fclass;
        private int _sclass;
        private int _tclass;
        private string _airline;
        private int _fprice;
        private int _sprice;
        private int _tprice;

        public string From
        {
            get { return _from; }
            set { _from = value; lbl_from.Text = value; }
        }

        [Category("Custom promps")]
        public string To
        {
            get { return _to; }
            set { _to = value; lbl_to.Text = value; }
        }

        [Category("Custom promps")]
        public string Departure
        {
            get { return _departure; }
            set { _departure = value; lbl_departure.Text = value; }
        }

        [Category("Custom promps")]
        public string FlightName
        {
            get { return _fname; }
            set { _fname = value; lbl_flight_name.Text = value; }
        }

        [Category("Custom promps")]
        public string FlightNumber
        {
            get { return _fnumber; }
            set { _fnumber = value; lbl_flight_number.Text = value; }
        }

        [Category("Custom promps")]
        public int FirstClass
        {
            get { return _fclass; }
            set { _fclass = value; lbl_first_class.Text = value.ToString(); }
        }

        [Category("Custom promps")]
        public int SecondClass
        {
            get { return _sclass; }
            set { _sclass = value; lbl_second_class.Text = value.ToString(); }
        }

        [Category("Custom promps")]
        public int ThirdClass
        {
            get { return _tclass; }
            set { _tclass = value; lbl_third_class.Text = value.ToString(); }
        }

        [Category("Custom promps")]
        public string Airline
        {
            get { return _airline; }
            set { _airline = value; lbl_air_line.Text = value; }
        }
        public int First_Class_Price
        {
            get { return _fprice; }
            set { _fprice = value; lbl_f_price.Text = value.ToString(); }
        }
        public int Second_Class_Price
        {
            get { return _sprice; }
            set { _sprice = value; lbl_s_price.Text = value.ToString(); }
        }
        public int Third_Class_Price
        {
            get { return _tprice; }
            set { _tprice = value; lbl_t_price.Text = value.ToString(); }
        }

        #endregion

        private void search_results_Click(object sender, EventArgs e)
        {
            Booking_Confirmation.Fnum = FlightNumber;
            lbl_flight_number.Text = FlightNumber;
            Booking_Confirmation bf = new Booking_Confirmation();
            bf.Show();
            this.Hide();
        }
    }
}
