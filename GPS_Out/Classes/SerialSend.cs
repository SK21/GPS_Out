using System;
using System.IO.Ports;

namespace GPS_Out
{
    public class SerialSend
    {
        private readonly frmStart mf;
        private SerialPort Sport;
        private bool Successfull = false;

        public SerialSend(frmStart CalledFrom)
        {
            this.mf = CalledFrom;
            Sport = new SerialPort("Com1", 57600);
            Sport.WriteTimeout = 500;
            LoadData();

            if (bool.TryParse(mf.Tls.LoadProperty("AutoConnect"), out bool CN))
            {
                if (CN && Successfull) Open();
            }
        }

        public int Baud
        {
            get { return Sport.BaudRate; }
            set
            {
                if (!Sport.IsOpen && value > 0 && value < 115201)
                {
                    Sport.BaudRate = value;
                }
            }
        }

        public string PortNm
        {
            get { return Sport.PortName; }
            set
            {
                if (!Sport.IsOpen && value != "")
                {
                    Sport.PortName = value;
                }
            }
        }

        public void Close()
        {
            try
            {
                if (Sport.IsOpen) Sport.Close();
                SaveData();
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("SerialSend/CloseRCport: " + ex.Message);
            }
        }

        public bool IsOpen()
        {
            return Sport.IsOpen;
        }

        public bool Open()
        {
            bool Result = false;
            try
            {
                if (SerialPortExists(Sport.PortName))
                {
                    if (!Sport.IsOpen) Sport.Open();

                    if (Sport.IsOpen)
                    {
                        Sport.DiscardOutBuffer();
                        Result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("SerialSend/OpenRCport: " + ex.Message);
            }
            Successfull = Result;
            return Result;
        }

        public void SendStringData(String data)
        {
            if (Sport.IsOpen)
            {
                try
                {
                    Sport.WriteLine(data);
                }
                catch (Exception ex)
                {
                    mf.Tls.WriteErrorLog("SerialSend/SendStringData: " + ex.Message);
                }
            }
        }

        private void LoadData()
        {
            PortNm = mf.Tls.LoadProperty("Serial_PortName");
            if (int.TryParse(mf.Tls.LoadProperty("Serial_Baud"), out int PB)) Baud = PB;
            if (bool.TryParse(mf.Tls.LoadProperty("Serial_Successful"), out bool tmp)) Successfull = true;
        }

        private void SaveData()
        {
            mf.Tls.SaveProperty("Serial_PortName", Sport.PortName);
            mf.Tls.SaveProperty("Serial_Baud", Sport.BaudRate.ToString());
            mf.Tls.SaveProperty("Serial_Successful", Successfull.ToString());
        }

        private bool SerialPortExists(string Name)
        {
            bool Result = false;
            foreach (string s in SerialPort.GetPortNames())
            {
                if (s == Name)
                {
                    Result = true;
                    break;
                }
            }
            return Result;
        }
    }
}