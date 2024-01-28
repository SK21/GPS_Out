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
    public partial class frmVTG : Form
    {
        frmStart mf;
        public frmVTG(frmStart CalledFrom)
        {
            InitializeComponent();
            mf = CalledFrom;
            mf.AGIOdata.NewData += AGIOdata_NewData;
        }

        private void AGIOdata_NewData(object sender, EventArgs e)
        {
            lbHeading.Text = mf.VTG.Heading.ToString("N1");
            lbMagHeading.Text = mf.VTG.MagHeading.ToString("N1");
            lbKnots.Text = mf.VTG.Knots.ToString("N1");
            lbKMH.Text = mf.VTG.KMH.ToString("N1");
        }

        private void frmVTG_FormClosed(object sender, FormClosedEventArgs e)
        {
            mf.Tls.SaveFormData(this);
        }

        private void frmVTG_Load(object sender, EventArgs e)
        {
            mf.Tls.LoadFormData(this);
        }
    }
}
