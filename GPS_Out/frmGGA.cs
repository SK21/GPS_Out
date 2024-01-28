using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPS_Out
{
    public partial class frmGGA : Form
    {
        frmStart mf;
        public frmGGA(frmStart CalledFrom)
        {
            InitializeComponent();
            mf = CalledFrom;
            mf.AGIOdata.NewData += AGIOdata_NewData;
        }

        private void AGIOdata_NewData(object sender, EventArgs e)
        {
            UpdateForm();
        }

        void UpdateForm()
        {
            mf.GGA.DecodeGGA(mf.GGA.ReceivedGGA);
            lbLon.Text = mf.GGA.Longitude.ToString("N7");
            lbLat.Text = mf.GGA.Latitude.ToString("N7");
            lbAge.Text = mf.GGA.Age.ToString("N1");
            lbHDOP.Text = mf.GGA.HDOP.ToString("N1");
            lbSats.Text = mf.GGA.Satellites.ToString("N0");
            lbElev.Text = mf.GGA.Altitude.ToString("N1");
            lbQuality.Text = mf.FixQuality(mf.GGA.FixQuality);
        }

        private void frmGGA_Load(object sender, EventArgs e)
        {
            mf.Tls.LoadFormData(this);
        }

        private void frmGGA_FormClosed(object sender, FormClosedEventArgs e)
        {
            mf.Tls.SaveFormData(this);
        }
    }
}
