using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.IO.Ports;
using System.Diagnostics;

namespace ledStripController
{
    public class ledStrip
    {
        private static int NUMLEDS;
        private static List<Color> strip;
        private static SerialPort _serialPort;
        private static double luminanceOveride;
        private static Queue<List< Color>> updateQueue;

        public ledStrip(int ledCount, SerialPort arduino)
        {
            NUMLEDS = ledCount;
            strip = new List<Color>();
            _serialPort = arduino;
            updateQueue = new Queue<List<Color>>();
            Thread updateQueueThread = new Thread(updateQueueManager);
            updateQueueThread.Start();

            //Initialize Blank Arrays
            for(int i = 0; i < ledCount; i++)
            {
                strip.Add(Color.FromArgb(0, 0, 0));
            }
            update();
        }

        public void setOveride(int value)
        {
            luminanceOveride = value/100.0;
            this.update();
        }

        public void setPixel(int index, Color color)
        {
            //check valid pixel index
            if (index >= NUMLEDS || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

           //set pixel value
           strip[index] = color;
        }

        public Color getPixel(int index)
        {
            //check valid pixel index
            if (index >= NUMLEDS || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            //get pixel value
            return (Color) strip[index];
        }

        public int getSize()
        {
            return NUMLEDS;
        }

        public void update()
        {
            List<Color> updateRequest = new List<Color>();
            for (int i = 0; i < NUMLEDS; i++)
            {
                updateRequest.Add(strip[i]);
            }
            updateQueue.Enqueue(updateRequest);
        }

        private void updateQueueManager()
        {
            while(true)
            {
                if(updateQueue.Count != 0)
                {
                    updateStrip(updateQueue.Dequeue());
                    Thread.Sleep(8);
                }
                if (updateQueue.Count > 5000)
                {
                    clearUpdateRequests();
                }
            }
        }

        public void clearUpdateRequests()
        {
            updateQueue.Clear();
        }

        private void updateStrip(List<Color> updateRequest)
        {
            byte[] buf = new byte[NUMLEDS * 3];

            for (int i = 0; i < NUMLEDS; i++)
            {
                Color c = updateRequest[i];
                int r = (int)c.R;
                int g = (int)c.G;
                int b = (int)c.B;
                c = Color.FromArgb((int)(r * luminanceOveride), (int)(g * luminanceOveride), (int)(b * luminanceOveride));

                //Write Bytes
                buf[3 * i + 0] = c.G;
                buf[3 * i + 1] = c.R;
                buf[3 * i + 2] = c.B;
                
                /*_serialPort.Write(BitConverter.GetBytes(c.G), 0, 1);
                _serialPort.Write(BitConverter.GetBytes(c.R), 0, 1);
                _serialPort.Write(BitConverter.GetBytes(c.B), 0, 1);*/
            }

            _serialPort.Write(buf, 0, NUMLEDS * 3);
        }
        

        public void clear()
        {
            for (int i = 0; i < NUMLEDS; i++)
            {
                strip[i] = Color.FromArgb(0, 0, 0);
            }
        }
        public void flood(Color c)
        {
            for (int i = 0; i < NUMLEDS; i++)
            {
                strip[i] = c;
            }
        }
    }
}
