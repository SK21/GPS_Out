using System;
using System.Diagnostics;

namespace GPS_Out
{
    public class PGN_VTG
    {
        // $GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48
        //*
        //   VTG          Track made good and ground speed
        //   054.7,T True track made good(degrees)
        //   034.4,M Magnetic track made good
        //   005.5,N Ground speed, knots
        //   010.2,K Ground speed, Kilometers per hour
        //   *48          Checksum

        private string Data;
        private frmStart mf;

        public PGN_VTG(frmStart CalledFrom)
        {
            mf = CalledFrom;
            mf.AGIOdata.NewData += AGIOdata_NewData;
        }

        public double Heading
        { get { return mf.AGIOdata.IMUheading; } }

        public double KMH
        { get { return mf.AGIOdata.Speed; } }

        public double Knots
        { get { return mf.AGIOdata.Speed * 0.5399568; } }

        public double MagHeading
        { get { return mf.AGIOdata.IMUheading; } }

        public void Send_VTG()
        {
            Data = "$GPVTG";

            Data += "," + mf.AGIOdata.IMUheading.ToString("N1") + ",T";

            Data += "," + mf.AGIOdata.IMUheading.ToString("N1") + ",M";

            double knots = mf.AGIOdata.Speed * 0.5399568;
            Data += "," + knots.ToString("N1") + ",N";

            Data += "," + mf.AGIOdata.Speed.ToString("N1") + ",K";

            Data += "*";
            string Hex = mf.CheckSum(Data).ToString("X");
            Data += Hex;

            mf.SER.SendStringData(Data);
        }

        private void AGIOdata_NewData(object sender, EventArgs e)
        {
            Send_VTG();
        }
    }
}