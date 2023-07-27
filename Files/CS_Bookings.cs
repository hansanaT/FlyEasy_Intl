using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace couse_work_gad
{
    public partial class CS_Bookings : Form
    {
        public CS_Bookings()
        {
            InitializeComponent();
        }
        public static string uemail;
        public static string UEmail
        {
            get { return uemail; }
            set { uemail = value; }
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        private void CS_Bookings_Load(object sender, EventArgs e)
        {
            try
            {
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo filterInfo in filterInfoCollection)
                {
                    cmb_camType.Items.Add(filterInfo.Name);
                }
                cmb_camType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            try
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[cmb_camType.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                pb_scan.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CS_Bookings_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (captureDevice.IsRunning)
                    captureDevice.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pb_scan.Image != null)
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    Result result = barcodeReader.Decode((Bitmap)pb_scan.Image);
                    if (result != null)
                    {
                        rtb_qr.Text = result.ToString();
                        timer1.Stop();
                        if (captureDevice.IsRunning)
                            captureDevice.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_generaterpt_Click(object sender, EventArgs e)
        {
            UEmail = txt_csEmail.Text;
            Booking_Rpt booking_Rpt = new Booking_Rpt();
            booking_Rpt.Show();
        }
    }
}
