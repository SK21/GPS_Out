﻿using System;

namespace GPS_Out
{
    public class PGNs_RMC
    {
        #region RMC Message

        //$GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A

        //RMC          Recommended Minimum sentence C
        //123519       Fix taken at 12:35:19 UTC
        //A            Status A=active or V=Void.
        //4807.038,N   Latitude 48 deg 07.038' N
        //01131.000,E  Longitude 11 deg 31.000' E
        //022.4        Speed over the ground in knots
        //084.4        Track angle in degrees True
        //230394       Date - 23rd of March 1994
        //003.1,W      Magnetic Variation
        //*6A          * Checksum

        #endregion RMC Message

        private string cSentence;
        private frmStart mf;

        public PGNs_RMC(frmStart CalledFrom)
        {
            mf = CalledFrom;
        }

        public string Sentence
        { get { return cSentence; } }

        public string Build()
        {
            double lat;
            double lon;
            cSentence = "$GPRMC";

            cSentence += "," + DateTime.UtcNow.ToString("HHmmss.f0");

            cSentence += ",A";

            if (mf.UseRollCorrected)
            {
                lat = mf.RollCorrected.Latitude;
            }
            else
            {
                lat = mf.AGIOdata.Latitude;
            }
            string NS = ",N";
            if (lat < 0) NS = ",S";
            lat = Math.Abs(lat);
            cSentence += "," + ((int)lat).ToString("D2");
            double Mins = (double)(lat - (int)lat) * 60.0;
            cSentence += Mins.ToString("N7");
            cSentence += NS;

            if (mf.UseRollCorrected)
            {
                lon = mf.RollCorrected.Longitude;
            }
            else
            {
                lon = mf.AGIOdata.Longitude;
            }
            string EW = ",E";
            if (lon < 0) EW = ",W";
            lon = Math.Abs(lon);
            cSentence += "," + ((int)lon).ToString("D3");
            Mins = (double)(lon - (int)lon) * 60.0;
            cSentence += Mins.ToString("N7");
            cSentence += EW;

            double knots = mf.AGIOdata.Speed * 0.5399568;
            cSentence += "," + knots.ToString("N1");

            cSentence += "," + mf.AGIOdata.IMUheading.ToString("N1");

            cSentence += "," + DateTime.Now.ToString("ddMMyy");

            cSentence += ",0.0,W";

            cSentence += "*";
            string Hex = mf.CheckSum(cSentence).ToString("X2");
            cSentence += Hex;

            return cSentence;
        }
    }
}