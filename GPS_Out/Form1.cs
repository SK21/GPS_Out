using System;
using System.Drawing;
using System.Windows.Forms;

namespace GPS_Out
{
    /*
    $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
       0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
            Time      Lat       Lon     FixSatsOP Alt
    Where:
         GGA          Global Positioning System Fix Data
         123519       Fix taken at 12:35:19 UTC
         4807.038,N   Latitude 48 deg 07.038' N
         01131.000,E  Longitude 11 deg 31.000' E
         1            Fix quality: 0 = invalid
                                   1 = GPS fix (SPS)
                                   2 = DGPS fix
                                   3 = PPS fix
                                   4 = Real Time Kinematic
                                   5 = Float RTK
                                   6 = estimated (dead reckoning) (2.3 feature)
                                   7 = Manual input mode
                                   8 = Simulation mode
         08           Number of satellites being tracked
         0.9          Horizontal dilution of position
         545.4,M      Altitude, Meters, above mean sea level
         46.9,M       Height of geoid (mean sea level) above WGS84
                          ellipsoid
         (empty field) time in seconds since last DGPS update
         (empty field) DGPS station ID number
         *47          the checksum data, always begins with *
     *
     *
    $GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A
     0      1    2   3      4    5      6   7     8     9     10   11
            Time      Lat        Lon       knots  Ang   Date  MagV

    Where:
         RMC          Recommended Minimum sentence C
         123519       Fix taken at 12:35:19 UTC
         A            Status A=active or V=Void.
         4807.038,N   Latitude 48 deg 07.038' N
         01131.000,E  Longitude 11 deg 31.000' E
         022.4        Speed over the ground in knots
         084.4        Track angle in degrees True
         230394       Date - 23rd of March 1994
         003.1,W      Magnetic Variation
         *6A          The checksum data, always begins with *
     *
    $GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48
     *
        VTG          Track made good and ground speed
        054.7,T      True track made good (degrees)
        034.4,M      Magnetic track made good
        005.5,N      Ground speed, knots
        010.2,K      Ground speed, Kilometers per hour
        *48          Checksum
    */

    public partial class frmStart : Form
    {
        public PGN54908 AGIOdata;
        public PGN_GGA GGA;
        public UDPComm PandaComm;
        public SerialComm SER;
        public clsTools Tls;
        public PGN_VTG VTG;

        public frmStart()
        {
            InitializeComponent();
            Tls = new clsTools(this);
            PandaComm = new UDPComm(this, 15555, 8000, 7120, "PandaComm", "127.255.255.255");
            AGIOdata = new PGN54908(this);
            AGIOdata.NewData += AGIOdata_NewData;
            GGA = new PGN_GGA(this);
            SER = new SerialComm(this, 0);
            VTG = new PGN_VTG(this);
        }

        public int CheckSum(string Data)
        {
            int CK = 0;
            int End = Data.IndexOf("*");
            char[] buf = Data.ToCharArray();
            if (buf[0] == '$' && End > -1)
            {
                for (int i = 1; i < End; i++)
                {
                    CK ^= buf[i];
                }
            }
            return CK;
        }

        public string FixQuality(byte Qu)
        {
            String Result = "";
            switch (Qu)
            {
                case 1:
                    Result = "GPS 1";
                    break;

                case 2:
                    Result = "DGPS";
                    break;

                case 3:
                    Result = "PPS";
                    break;

                case 4:
                    Result = "RTK fix";
                    break;

                case 5:
                    Result = "Float";
                    break;

                case 6:
                    Result = "Estimate";
                    break;

                case 7:
                    Result = "Man IP";
                    break;

                case 8:
                    Result = "Sim";
                    break;
            }
            return Result;
        }

        public void StartSerial()
        {
            try
            {
                String ID = "_0_";
                SER.RCportName = Tls.LoadProperty("RCportName" + ID + "0");

                int tmp;
                if (int.TryParse(Tls.LoadProperty("RCportBaud" + ID + "0"), out tmp))
                {
                    SER.RCportBaud = tmp;
                }
                else
                {
                    SER.RCportBaud = 57600;
                }

                bool tmp2;
                bool.TryParse(Tls.LoadProperty("RCportSuccessful" + ID + "0"), out tmp2);
                if (tmp2) SER.OpenRCport();
            }
            catch (Exception ex)
            {
                Tls.WriteErrorLog("frmStart/StartSerial: " + ex.Message);
                Tls.ShowHelp(ex.Message, this.Text, 3000, true);
            }
        }

        public void UpdateForm()
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                lbAge.Text = AGIOdata.Age.ToString("N2");
                lbLon.Text = AGIOdata.Longitude.ToString("N7");
                lbLat.Text = AGIOdata.Latitude.ToString("N7");
                lbSpeed.Text = AGIOdata.Speed.ToString("N1");
                lbQuality.Text = FixQuality(AGIOdata.FixQuality);
                lbHDOP.Text = AGIOdata.HDOP.ToString("N2");
                lbSats.Text = AGIOdata.Satellites.ToString("");
                lbElev.Text = AGIOdata.Altitude.ToString("N1");
                lbAge.Text = AGIOdata.Age.ToString("N1");

                lbYawRate.Text = AGIOdata.IMUyawRate.ToString("N0");
                lbRoll.Text = AGIOdata.IMUroll.ToString("N1");
                lbPitch.Text = AGIOdata.IMUpitch.ToString("N1");
                lbYaw.Text = AGIOdata.IMUheading.ToString("N1");
            }
        }

        private void AGIOdata_NewData(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void btnConnect1_Click(object sender, EventArgs e)
        {
            if (btnConnect1.Text == "Connect")
            {
                SER.OpenRCport();
            }
            else
            {
                SER.CloseRCport();
            }
            SetPortButtons1();
        }

        private void btnGGA_Click(object sender, EventArgs e)
        {
            tbGGA.Text = GGA.Sentence;
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            LoadRCbox();
        }

        private void btnVTG_Click(object sender, EventArgs e)
        {
            tbVTG.Text = VTG.Sentence;
        }

        private void cboBaud1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SER.ArduinoPort.BaudRate = Convert.ToInt32(cboBaud1.Text);
            SER.RCportBaud = Convert.ToInt32(cboBaud1.Text);
        }

        private void cboGGA_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmrGGA.Interval = 1000 / Convert.ToInt16(cboGGA.Text);
            tmrGGA.Enabled = true;
        }

        private void cboPort1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SER.RCportName = cboPort1.Text;
        }

        private void cboVTG_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmrVTG.Interval = 1000 / Convert.ToInt16(cboVTG.Text);
            tmrVTG.Enabled = true;
        }

        private void frmStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            Tls.SaveFormData(this);
            Tls.SaveProperty("cboGGA", cboGGA.SelectedIndex.ToString());
            Tls.SaveProperty("cboVTG", cboVTG.SelectedIndex.ToString());
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            Tls.LoadFormData(this);
            StartSerial();
            PandaComm.StartUDPServer();
            LoadRCbox();
            tmrGGA.Enabled = true;
            UpdateForm();
            SetCombos();
            PortIndicator1.BackColor = Properties.Settings.Default.DayColour;
            this.BackColor = Properties.Settings.Default.DayColour;
        }

        private void frmStart_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                tmrMinimize.Enabled = false;
            }
            else
            {
                tmrMinimize.Enabled = true;
            }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            Tls.DrawGroupBox(box, e.Graphics, this.BackColor, Color.Black, Color.Blue);
        }

        private void LoadRCbox()
        {
            cboPort1.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboPort1.Items.Add(s);
            }
            SetPortButtons1();
        }

        private void SetCombos()
        {
            byte GGAcombo = 1;
            byte VTGcombo = 1;

            if (byte.TryParse(Tls.LoadProperty("cboGGA"), out byte gga)) GGAcombo = gga;
            if (byte.TryParse(Tls.LoadProperty("cboVTG"), out byte vtg)) VTGcombo = vtg;

            cboGGA.SelectedIndex = GGAcombo;
            cboVTG.SelectedIndex = VTGcombo;
        }

        private void SetPortButtons1()
        {
            cboPort1.SelectedIndex = cboPort1.FindStringExact(SER.RCportName);
            cboBaud1.SelectedIndex = cboBaud1.FindStringExact(SER.RCportBaud.ToString());

            if (SER.ArduinoPort.IsOpen)
            {
                cboBaud1.Enabled = false;
                cboPort1.Enabled = false;
                btnConnect1.Text = "Disconnect";
                PortIndicator1.Image = Properties.Resources.On;
            }
            else
            {
                cboBaud1.Enabled = true;
                cboPort1.Enabled = true;
                btnConnect1.Text = "Connect";
                PortIndicator1.Image = Properties.Resources.Off;
            }
        }

        private void tmrGGA_Tick(object sender, EventArgs e)
        {
            GGA.Send();
        }

        private void tmrMinimize_Tick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tmrVTG_Tick(object sender, EventArgs e)
        {
            VTG.Send();
        }
    }
}