using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace ledStripController
{
    class ledEffects
    {
        public static void blank()
        {
            Program.strip.clear();
            Program.strip.update();
        }

        public static void waterfall()
        {
            while (true)
            {
                for (int i = 0; i < 240; i++)
                {
                    for (int j = 0; j < Program.strip.getSize(); j++)
                    {
                        int color = ((i + j) % 60) * 4;
                        Program.strip.setPixel(j, Color.FromArgb(color, color, 255));
                    }
                    Program.strip.update();
                }
            }
        }

        public static void candyCane()
        {
            while(true)
            {
                for (int i = 0; i < Program.strip.getSize(); i++)
                {
                    if (i % 2 == 0)
                    {
                        Program.strip.setPixel(i, Color.FromArgb(255, 255, 150));
                    }
                    else
                    {
                        Program.strip.setPixel(i, Color.Red);
                    }
                }
                Program.strip.update();

                Thread.Sleep(1000);

                for (int i = 0; i < Program.strip.getSize(); i++)
                {
                    if (i % 2 == 0)
                    {
                        Program.strip.setPixel(i, Color.Red);
                    }
                    else
                    {
                        Program.strip.setPixel(i, Color.FromArgb(255, 255, 150));
                    }
                }
                Program.strip.update();

                Thread.Sleep(1000);
            }   
        }

        public static void christmas()
        {

            //Pixels in group
            int GROUPPIXELS = 120;
            int NUMFRAMES = 480;

            //Times
            int DWELL = 5000;
            int WAIT = 33;

            while(true)
            {
                for (int k = 0; k < NUMFRAMES / 4; k++)
                {
                    for (int i = 0; i < Program.strip.getSize() / GROUPPIXELS; i++)
                    {
                        // pixels.Color takes RGB values, from 0,0,0 up to 255,255,255
                        //pixels.setPixelColor(i, pixels.Color(0,150,0)); // Moderately bright green color.

                        for (int j = 0; j < GROUPPIXELS / 2; j++)
                        {
                            //Do math for colour interpolation here
                            Program.strip.setPixel(i * GROUPPIXELS + j, Color.FromArgb(120 - 120 / (NUMFRAMES / 4) * k, 120 / (NUMFRAMES / 4) * k, 0));
                        }

                    }
                    Program.strip.update();
                    Thread.Sleep(WAIT);
                }
                Thread.Sleep(DWELL);

                for (int k = 0; k < NUMFRAMES / 4; k++)
                {
                    for (int i = 0; i < Program.strip.getSize() / GROUPPIXELS; i++)
                    {

                        for (int j = 0; j < GROUPPIXELS / 2; j++)
                        {
                            //Do math for colour interpolation here
                            Program.strip.setPixel(i * GROUPPIXELS + j + GROUPPIXELS / 2, Color.FromArgb(120 / (NUMFRAMES / 4) * k, 120 - 120 / (NUMFRAMES / 4) * k, 0));
                        }
                    }

                    Program.strip.update();
                    Thread.Sleep(WAIT);
                }
                Thread.Sleep(DWELL);

                for (int k = 0; k < NUMFRAMES / 4; k++)
                {
                    for (int i = 0; i < Program.strip.getSize() / GROUPPIXELS; i++)
                    {
                        // pixels.Color takes RGB values, from 0,0,0 up to 255,255,255
                        //pixels.setPixelColor(i, pixels.Color(0,150,0)); // Moderately bright green color.

                        for (int j = 0; j < GROUPPIXELS / 2; j++)
                        {
                            //Do math for colour interpolation here
                            Program.strip.setPixel(i * GROUPPIXELS + j, Color.FromArgb(120 / (NUMFRAMES / 4) * k, 120 - 120 / (NUMFRAMES / 4) * k, 0));
                        }
                    }

                    Program.strip.update();
                    Thread.Sleep(WAIT);
                }
                Thread.Sleep(DWELL);

                for (int k = 0; k < NUMFRAMES / 4; k++)
                {
                    for (int i = 0; i < Program.strip.getSize() / GROUPPIXELS; i++)
                    {
                        // pixels.Color takes RGB values, from 0,0,0 up to 255,255,255
                        //pixels.setPixelColor(i, pixels.Color(0,150,0)); // Moderately bright green color.

                        for (int j = 0; j < GROUPPIXELS / 2; j++)
                        {
                            //Do math for colour interpolation here
                            Program.strip.setPixel(i * GROUPPIXELS + j + GROUPPIXELS / 2, Color.FromArgb(120 - 120 / (NUMFRAMES / 4) * k, 120 / (NUMFRAMES / 4) * k, 0));
                        }
                    }

                    Program.strip.update();
                    Thread.Sleep(WAIT);
                }
                Thread.Sleep(DWELL);
            }
        }

        public static void deskLight()
        {
            for (int i = 0; i < 17; i++)
            {
                Program.strip.setPixel(i, Color.FromArgb(0, 0, 0));
                Program.strip.update();
            }
            for (int i = 17; i < 48; i++)
            {
                Program.strip.setPixel(i, Color.FromArgb(0, 0, 10));
                Program.strip.update();
            }
            for (int i = 48; i < 72; i++)
            {
                Program.strip.setPixel(i, Color.FromArgb(150, 100, 25));
                Program.strip.update();
            }
            for (int i = 72; i < 240; i++)
            {
                Program.strip.setPixel(i, Color.FromArgb(0, 0, 10));
                Program.strip.update();
            }
        }

        public static void readingLight()
        {
            for (int i = 0; i < 17; i++)
            {
                Program.strip.setPixel(i, Color.FromArgb(0, 0, 0));
                Program.strip.update();
            }
            for (int i = 17; i < 96; i++)
            {
                Program.strip.setPixel(i, Color.FromArgb(0, 0, 10));
                Program.strip.update();
            }
            for (int i = 96; i < 120; i++)
            {
                Program.strip.setPixel(i, Color.FromArgb(150, 100, 25));
                Program.strip.update();
            }
            for (int i = 120; i < 240; i++)
            {
                Program.strip.setPixel(i, Color.FromArgb(0, 0, 10));
                Program.strip.update();
            }
        }

        public static void nightight()
        {
            for (int i = 0; i < 17; i++)
            {
                Program.strip.setPixel(i, Color.FromArgb(0, 0, 0));
                Program.strip.update();
            }
            for (int i = 17; i < 240; i++)
            {
                Program.strip.setPixel(i, Color.FromArgb(0, 0, 10));
                Program.strip.update();
            }
        }

        public static void warmAmbient()
        {
            for (int i = 0; i < 240; i++)
            {
                Program.strip.setPixel(i, Color.FromArgb(255, 168, 43));
                Program.strip.update();
            }
        }

        public static void quietDiagnostic()
        {
            while(true)
            {
                Program.strip.setPixel(0, Color.FromArgb(25, 0, 0));
                Program.strip.update();
                Thread.Sleep(500);
                Program.strip.setPixel(0, Color.FromArgb(0, 0, 0));
                Program.strip.update();
                Thread.Sleep(500);
            }
        }
    }
}
