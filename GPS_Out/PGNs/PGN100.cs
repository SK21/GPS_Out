using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Out.PGNs
{
    public class PGN100
    {
        // corrected position
        // 0        header Hi       128 0x80
        // 1        header Lo       129 0x81
        // 2        source          127 0x7F
        // 3        AGIO PGN        100 0x64
        // 4        length          16
        // 5-12     longitude       double
        // 13-20    latitude        double
        // 21       CRC

        private const byte HeaderCount = 5;
        private double cLatitude;
        private double cLongitude;
        private frmStart mf;
        private DateTime ReceiveTime;

        public PGN100(frmStart CalledFrom)
        {
            mf = CalledFrom;
        }

        public double Latitude
        {
            get
            {
                if (Connected())
                {
                    return cLatitude;
                }
                else
                {
                    return 0;
                }
            }
        }

        public double Longitude
        {
            get
            {
                if (Connected())
                {
                    return cLongitude;
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool Connected()
        {
            return (DateTime.Now - ReceiveTime).TotalSeconds < 4;
        }

        public void ParseByteData(byte[] Data)
        {
            if ((Data.Length > HeaderCount) && (Data.Length == Data[4] + HeaderCount + 1))
            {
                if (mf.Tls.GoodCRC(Data, 2))
                {
                    cLongitude = BitConverter.ToDouble(Data, 5);
                    cLatitude = BitConverter.ToDouble(Data, 13);
                    ReceiveTime = DateTime.Now;
                }
            }
        }
    }
}
