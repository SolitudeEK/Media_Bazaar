using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using ZXing;

namespace mediabazaar_s2_cb06_1.Scanner
{
    public partial class ScannerQr : Form
    {
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice;
        public ScannerQr()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        private void bClose_Click(object sender, EventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
            this.Close();
        }
        private void bStart_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbCameras.SelectedIndex].MonikerString);
            //PreSetted resolution or getedfromcam
            videoCaptureDevice.VideoResolution = selectResolution(videoCaptureDevice);
            //videoCaptureDevice.VideoResolution = videoCaptureDevice.VideoCapabilities[cboCamera.SelectedIndex];
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();

            timerCheck.Start();
        }

        private static VideoCapabilities selectResolution(VideoCaptureDevice device)
        {
            foreach (var cap in device.VideoCapabilities)
            {
                if (cap.FrameSize.Height == 480)
                    return cap;
                if (cap.FrameSize.Width == 720)
                    return cap;
            }
            return device.VideoCapabilities.Last();
        }

        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            pbVideo.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pbVideo.Image);
            if (result != null)
            {
                string[] getted = result.ToString().Split(':');
                if (getted.Count() == 3)
                {
                    lOut.Text = getted[0] + " " + getted[1];
                    pbPortret.Image = QRInfo.GetImage(Convert.ToInt32(getted[2]), 200);
                    QRInfo.SetTime(Convert.ToInt32(getted[2]));
                    timerCheck.Start();
                    timerClear.Start();
                }
                else
                    MessageBox.Show("Unknown user");
            }
        }

        private void ScannerQr_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cbCameras.Items.Add(filterInfo.Name);
            cbCameras.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void ScannerQr_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
        }

        private void timerClear_Tick(object sender, EventArgs e)
        {
            lOut.Text = "";
            pbPortret.Image = null;
            timerCheck.Start();
            timerClear.Stop();  
        }
    }
}
