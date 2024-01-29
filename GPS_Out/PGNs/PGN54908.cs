using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Out
{
    public class PGN54908
    {
        // NMEA data from AGIO
        // 0        0x80
        // 1        0x81
        // 2        0x7C
        // 3        0xD6
        // 4        0x33    array length - 6
        // 5-12     longitude       double
        // 13-20    latitude        double
        // 21-24    headingDual     float
        // 25-28    heading         float
        // 29-32    speed           float
        // 33-36    roll            float
        // 37-40    altitude        float
        // 41-42    satellites      ushort
        // 43       fixQuality
        // 44-45    hdopX100        ushort
        // 46-47    ageX100         ushort
        // 48-49    imuHeading      ushort
        // 50-51    imuRoll         ushort
        // 52-53    imuPitch        ushort
        // 54-55    imuYaw          ushort
        // 56       CRC

        private const byte cByteCount = 57;
        private ushort cAgeX100;
        private float cAltitude;
        private byte cFixQuality;
        private ushort cHdopX100;
        private float cHeading;
        private float cHeadingDual;
        private float cImuHeading;
        private short cImuPitch;
        private short cImuRoll;
        private ushort cImuYaw;
        private double cLatitude;
        private double cLongitude;
        private float cRoll;
        private ushort cSatellites;
        private float cSpeed;
        private frmStart mf;

        public PGN54908(frmStart CalledFrom)
        {
            mf = CalledFrom;
        }

        public event EventHandler NewData;

        public float Age
        { get { return (float)(cAgeX100 / 100.0); } }

        public float Altitude
        { get { return cAltitude; } }

        public byte FixQuality
        { get { return cFixQuality; } }

        public float HDOP
        { get { return (float)(cHdopX100 / 100.0); } }

        public float Heading
        { get { return cHeading; } }

        public float HeadingDual
        { get { return cHeadingDual; } }

        public float IMUheading
        { get { return cImuHeading; } }

        public float IMUpitch
        { get { return (float)(cImuPitch/10.0); } }

        public float IMUroll
        { get { return (float)(cImuRoll/10.0); } }

        public ushort IMUyawRate
        { get { return cImuYaw; } }

        public double Latitude
        { get { return cLatitude; } }

        public double Longitude
        { get { return cLongitude; } }

        public float Roll
        { get { return cRoll; } }

        public UInt16 Satellites
        { get { return cSatellites; } }

        public float Speed
        { get { return cSpeed; } }

        public bool ParseByteData(byte[] Data)
        {
            bool Result = false;
            if (mf.Tls.GoodCRC(Data, 2))
            {
                cLongitude = BitConverter.ToDouble(Data, 5);
                cLatitude = BitConverter.ToDouble(Data, 13);
                cHeadingDual = BitConverter.ToSingle(Data, 21);
                cHeading = BitConverter.ToSingle(Data, 25);
                cSpeed = BitConverter.ToSingle(Data, 29);
                cRoll = BitConverter.ToSingle(Data, 33);
                cAltitude = BitConverter.ToSingle(Data, 37);
                cSatellites = BitConverter.ToUInt16(Data, 41);
                cFixQuality = Data[43];
                cHdopX100 = BitConverter.ToUInt16(Data, 44);
                cAgeX100 = BitConverter.ToUInt16(Data, 46);
                cImuHeading = (float)(BitConverter.ToUInt16(Data, 48) / 10.0);
                cImuRoll = (short)BitConverter.ToInt16(Data, 50);
                cImuPitch = (short)BitConverter.ToInt16(Data, 52);
                cImuYaw = BitConverter.ToUInt16(Data, 54);

                NewData?.Invoke(this, EventArgs.Empty);
                Result = true;
            }
            return Result;
        }
    }
}