using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFLEDController
{
    class MainWindowPresenter
    {
        private SerialServer serial;
        Effect fuse = new Effect(240, 30);
        public MainWindowPresenter()
        {
            serial = new SerialServer("com3", 30);
            serial.ManualSend(new LedStrip(240));
            testProgram();

            serial.ActiveStrip = fuse.Strip;
            fuse.Start();
            Thread.Sleep(5000);
            fuse.Stop();
            Thread.Sleep(5000);
            fuse.Start();
        }
        private void testProgram()
        {
            for (int i = 0; i < 240; i++)
            {
                LedStrip frame = new LedStrip(240);
                for (int j = 0; j < 240; j++)
                {
                    int color = ((i + j) % 60);
                    frame.SetPixel(j, Color.FromArgb(255, (byte)(240 / (color * 8 + 1)), (byte)(96 / (color * 8 + 1)), 0));
                }
                fuse.SetFrame(i, frame);
            }
        }

    }
}
