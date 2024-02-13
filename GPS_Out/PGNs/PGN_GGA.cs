using System;
using System.Diagnostics;
using System.Globalization;

namespace GPS_Out
{
    public class PGN_GGA
    {
        //$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M ,  ,*47
        //   0     1      2      3    4      5 6  7  8   9    10 11  12 13  14
        //        Time Lat       Lon FixSatsOP Alt
        //Where:
        //GGA Global Positioning System Fix Data
        // 123519       Fix taken at 12:35:19 UTC
        // 4807.038,N Latitude 48 deg 07.038' N
        // 01131.000,E Longitude 11 deg 31.000' E
        // 1            Fix quality: 0 = invalid
        //                           1 = GPS fix(SPS)
        //                           2 = DGPS fix
        //                           3 = PPS fix
        //                           4 = Real Time Kinematic
        //                           5 = Float RTK
        //                           6 = estimated(dead reckoning) (2.3 feature)
        //                           7 = Manual input mode
        //                           8 = Simulation mode
        // 08           Number of satellites being tracked
        // 0.9          Horizontal dilution of position
        // 545.4, M      Altitude, Meters, above mean sea level
        // 46.9, M       Height of geoid(mean sea level) above WGS84
        //                  ellipsoid
        // (empty field) time in seconds since last DGPS update
        // (empty field) DGPS station ID number
        // *47          the checksum data, always begins with*

        private ushort cAgeX100;
        private float cAltitude;
        private byte cFixQuality;
        private ushort cHdopX100;
        private double cLatitude;
        private double cLongitude;
        private ushort cSatellites;
        private string cSentence;
        private frmStart mf;

        public PGN_GGA(frmStart CalledFrom)
        {
            mf = CalledFrom;
        }

        public float Age
        { get { return (float)(cAgeX100 / 100.0); } }

        public float Altitude
        { get { return cAltitude; } }

        public byte FixQuality
        { get { return cFixQuality; } }

        public float HDOP
        { get { return (float)(cHdopX100 / 100.0); } }

        public double Latitude
        { get { return cLatitude; } }

        public double Longitude
        { get { return cLongitude; } }

        public string ReceivedGGA
        { get { return cSentence; } }

        public UInt16 Satellites
        { get { return cSatellites; } }

        public string Sentence
        { get { return cSentence; } }

        public void DecodeGGA(string Sentence)
        {
            string[] words = Sentence.Split(',');
            if (!string.IsNullOrEmpty(words[1]) && !string.IsNullOrEmpty(words[2]) && !string.IsNullOrEmpty(words[3])
                && !string.IsNullOrEmpty(words[4]) && !string.IsNullOrEmpty(words[5]))
            {
                //FixQuality
                byte.TryParse(words[6], NumberStyles.Float, CultureInfo.InvariantCulture, out byte fixQuality);
                cFixQuality = fixQuality;

                //satellites tracked
                ushort.TryParse(words[7], NumberStyles.Float, CultureInfo.InvariantCulture, out ushort satellitesTracked);
                cSatellites = satellitesTracked;

                //hdop
                float.TryParse(words[8], NumberStyles.Float, CultureInfo.InvariantCulture, out float hdopData);
                cHdopX100 = (ushort)(hdopData * 100.0);

                //altitude
                float.TryParse(words[9], NumberStyles.Float, CultureInfo.InvariantCulture, out float altitude);
                cAltitude = altitude;

                //age
                float.TryParse(words[13], NumberStyles.Float, CultureInfo.InvariantCulture, out float ageData);
                cAgeX100 = (ushort)(ageData * 100.0);

                //get latitude and convert to decimal degrees
                int decim = words[2].IndexOf(".", StringComparison.Ordinal);
                if (decim == -1)
                {
                    words[2] += ".00";
                    decim = words[2].IndexOf(".", StringComparison.Ordinal);
                }

                decim -= 2;
                double.TryParse(words[2].Substring(0, decim), NumberStyles.Float, CultureInfo.InvariantCulture, out double latitude);
                double.TryParse(words[2].Substring(decim), NumberStyles.Float, CultureInfo.InvariantCulture, out double temp);
                temp *= 0.01666666666667;
                latitude += temp;
                if (words[3] == "S")
                    latitude *= -1;
                cLatitude = latitude;

                //get longitude and convert to decimal degrees
                decim = words[4].IndexOf(".", StringComparison.Ordinal);
                if (decim == -1)
                {
                    words[4] += ".00";
                    decim = words[4].IndexOf(".", StringComparison.Ordinal);
                }
                double.TryParse(words[4].Substring(0, 3), NumberStyles.Float, CultureInfo.InvariantCulture, out double Lng);
                double.TryParse(words[4].Substring(3), NumberStyles.Float, CultureInfo.InvariantCulture, out double Mins);
                Lng += Mins * 0.0166666666667;
                double longitude = Lng;

                //decim -= 2;
                //double.TryParse(words[4].Substring(0, decim), NumberStyles.Float, CultureInfo.InvariantCulture, out double longitude);
                //double.TryParse(words[4].Substring(decim), NumberStyles.Float, CultureInfo.InvariantCulture, out temp);
                //longitude += temp * 0.0166666666667;

                { if (words[5] == "W") longitude *= -1; }
                cLongitude = longitude;
            }
        }

        public string Build()
        {
            cSentence = "$GPGGA";

            string Hour = DateTime.UtcNow.Hour.ToString();
            string Minute = DateTime.UtcNow.Minute.ToString();
            string Second = DateTime.UtcNow.Second.ToString();
            cSentence += "," + Hour + Minute + Second;

            double lat = mf.AGIOdata.Latitude;
            string NS = ",N";
            if (lat < 0) NS = ",S";
            lat = Math.Abs(lat);
            cSentence += "," + ((int)lat).ToString("D2");
            double Mins = (double)(lat - (int)lat) * 60.0;
            cSentence += Mins.ToString("N6");
            cSentence += NS;

            double lon = mf.AGIOdata.Longitude;
            string EW = ",E";
            if (lon < 0) EW = ",W";
            lon = Math.Abs(lon);
            cSentence += "," + ((int)lon).ToString("D3");
            Mins = (double)(lon - (int)lon) * 60.0;
            cSentence += Mins.ToString("N6");
            cSentence += EW;

            cSentence += "," + mf.AGIOdata.FixQuality.ToString();

            cSentence += "," + mf.AGIOdata.Satellites.ToString("00");

            cSentence += "," + mf.AGIOdata.HDOP.ToString("N1");

            cSentence += "," + mf.AGIOdata.Altitude.ToString("N1") + ",M";

            cSentence += ",0.0,M";

            cSentence += "," + mf.AGIOdata.Age.ToString("N1") + ",";

            cSentence += ",*";
            string Hex = mf.CheckSum(cSentence).ToString("X2");
            cSentence += Hex;

            return cSentence;
        }
    }
}