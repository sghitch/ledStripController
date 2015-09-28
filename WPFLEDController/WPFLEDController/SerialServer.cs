using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Media;

namespace WPFLEDController
{
    class SerialServer
    {
        private SerialPort com = new SerialPort();
        private bool running = false;

        private Timer dispatch = new Timer();

        private LedStrip activeStrip = null;
        private LedStrip lastSend = null;
        private Queue<LedStrip> requests = new Queue<LedStrip>();
        private byte luminanceOverride = 255;
        public SerialServer(string portName, int framerate)
        {
            com.PortName = "com3";
            com.BaudRate = 250000;
            Start();

            dispatch.Interval = 1000/(double)framerate;
            dispatch.Elapsed += onDispatch;
            dispatch.Start();
        }

        #region Public Methods
        public bool Start()
        {
            if (!com.IsOpen)
            {
                try
                {
                    com.Open();
                }
                catch (System.UnauthorizedAccessException) { }
                if(com.IsOpen)
                {
                    running = true;
                    return true;
                }
                return false;
            }
            return true;
        }
        public bool Stop()
        {
            if(com.IsOpen)
            {
                com.Close();
                if(!com.IsOpen)
                {
                    running = false;
                    return true;
                }
                return false;    
            }
            return true;

        }

        public void ManualSend(LedStrip strip)
        {
            if (running)
            {
                pruneRequests();
                enqueueRequest(strip);
            }
            List<Color> updateRequest = new List<Color>();
        }

        public void Clear()
        {
            requests = new Queue<LedStrip>();
        }
        
        public LedStrip ActiveStrip
        {
            get
            {
                return activeStrip;
            }
            set
            {
                if(activeStrip == null || !activeStrip.Equals(value))
                { 
                    if (activeStrip != null)
                    {
                        activeStrip.PropertyChanged -= onActiveStripChanged;
                    }
                    activeStrip = value;
                    if(activeStrip != null)
                    {
                        activeStrip.PropertyChanged += onActiveStripChanged;
                    }   
                }
            }
        }
        public byte LuminanceOverride
        {
            get { return luminanceOverride; }
            set
            {
                if(luminanceOverride != value)
                {
                    luminanceOverride = value;
                    if(requests.Count == 0 && lastSend != null)
                    {
                        enqueueRequest(lastSend);
                    }
                }
            }
        }
        #endregion
        private void pruneRequests()
        {
            if (requests.Count >= 1 / dispatch.Interval)
            {
                Queue<LedStrip> temp = new Queue<LedStrip>();
                for (int i = 0; i < requests.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        temp.Enqueue(requests.Dequeue());
                    }
                }
                requests = temp;
            }
        }
        private void enqueueRequest(LedStrip strip)
        {
            LedStrip temp = new LedStrip(strip.LedCount);
            for(int i = 0; i < strip.LedCount; i ++)
            {
                temp.SetPixel(i, strip.GetPixel(i));
            }
            requests.Enqueue(temp);   
        }
        private void onActiveStripChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("Push"))
            {
                pruneRequests();
                enqueueRequest(activeStrip);
            }
        }
        private void onDispatch(object sender, EventArgs e)
        {
            if(requests.Count > 0)
            {
                LedStrip send = requests.Dequeue();

                byte[] buf = new byte[send.LedCount * 3];

                for (int i = 0; i < send.LedCount; i++)
                {
                    Color c = send.GetPixel(i);
                    int r = (int)c.R;
                    int g = (int)c.G;
                    int b = (int)c.B;
                    c = Color.FromArgb(255, (byte)((r * luminanceOverride)/255), (byte)((g * luminanceOverride)/255), (byte)((b * luminanceOverride)/255));

                    //Write Bytes
                    buf[3 * i + 0] = c.G;
                    buf[3 * i + 1] = c.R;
                    buf[3 * i + 2] = c.B;

                    /*_serialPort.Write(BitConverter.GetBytes(c.G), 0, 1);
                    _serialPort.Write(BitConverter.GetBytes(c.R), 0, 1);
                    _serialPort.Write(BitConverter.GetBytes(c.B), 0, 1);*/
                }

                com.Write(buf, 0, send.LedCount * 3);
                lastSend = send;
            }    
        }
        #region Private Methods

        #endregion
    }
}
