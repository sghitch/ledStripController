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
            clear();
            update();
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
                        setPixel(j, Color.FromArgb(color, color, 255));
                    }
                    update();
                }
            }
        }

        public static void fuse()
        {
            while (true)
            {
                for (int i = 0; i < 240; i++)
                {
                    for (int j = 0; j < Program.strip.getSize(); j++)
                    {
                        int color = ((i + j) % 60) ;
                        setPixel(j, Color.FromArgb(240 / (color * 8 + 1) , 96 / (color * 8 + 1), 0));
                    }
                    update();
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
                        setPixel(i, Color.FromArgb(255, 255, 150));
                    }
                    else
                    {
                        setPixel(i, Color.Red);
                    }
                }
                update();

                Thread.Sleep(1000);

                for (int i = 0; i < Program.strip.getSize(); i++)
                {
                    if (i % 2 == 0)
                    {
                        setPixel(i, Color.Red);
                    }
                    else
                    {
                        setPixel(i, Color.FromArgb(255, 255, 150));
                    }
                }
                update();

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
                            setPixel(i * GROUPPIXELS + j, Color.FromArgb(120 - 120 / (NUMFRAMES / 4) * k, 120 / (NUMFRAMES / 4) * k, 0));
                        }

                    }
                    update();
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
                            setPixel(i * GROUPPIXELS + j + GROUPPIXELS / 2, Color.FromArgb(120 / (NUMFRAMES / 4) * k, 120 - 120 / (NUMFRAMES / 4) * k, 0));
                        }
                    }

                    update();
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
                            setPixel(i * GROUPPIXELS + j, Color.FromArgb(120 / (NUMFRAMES / 4) * k, 120 - 120 / (NUMFRAMES / 4) * k, 0));
                        }
                    }

                    update();
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
                            setPixel(i * GROUPPIXELS + j + GROUPPIXELS / 2, Color.FromArgb(120 - 120 / (NUMFRAMES / 4) * k, 120 / (NUMFRAMES / 4) * k, 0));
                        }
                    }

                    update();
                    Thread.Sleep(WAIT);
                }
                Thread.Sleep(DWELL);
            }
        }

        public static void deskLight()
        {
   
            for (int i = 0; i < 17; i++)
            {
                setPixel(i, Color.FromArgb(0, 0, 0));
                update();
            }
            for (int i = 17; i < 48; i++)
            {
                setPixel(i, Color.FromArgb(0, 0, 10));
                update();
            }
            for (int i = 48; i < 72; i++)
            {
                setPixel(i, Color.FromArgb(150, 100, 25));
                update();
            }
            for (int i = 72; i < 240; i++)
            {
                setPixel(i, Color.FromArgb(0, 0, 10));
                update();
            }
        }
            

        public static void readingLight()
        {

            for (int i = 0; i < 17; i++)
            {
                setPixel(i, Color.FromArgb(0, 0, 0));
                update();
            }
            for (int i = 17; i < 96; i++)
            {
                setPixel(i, Color.FromArgb(0, 0, 10));
                update();
            }
            for (int i = 96; i < 120; i++)
            {
                setPixel(i, Color.FromArgb(150, 100, 25));
                update();
            }
            for (int i = 120; i < 240; i++)
            {
                setPixel(i, Color.FromArgb(0, 0, 10));
                update();
            }
            
        }

        public static void nightlight()
        {
            for (int i = 0; i < 17; i++)
            {
                setPixel(i, Color.FromArgb(0, 0, 0));
                update();
            }
            for (int i = 17; i < 240; i++)
            {
                setPixel(i, Color.FromArgb(0, 0, 10));
                update();
            }
            
        }

        public static void warmAmbient()
        {
            for (int i = 0; i < 17; i++)
            {
                setPixel(i, Color.FromArgb(0, 0, 0));
                update();
            }
            for (int i = 17; i < 240; i++)
            {
                setPixel(i, Color.FromArgb(255, 168, 43));
                update();
            }
            
        }
            
        public static void patriotic()
        {
            int i = 0;
            while (i < Program.strip.getSize())
            {
                for(int j = 0; j < 20; j++)
                {
                    setPixel(i, Color.FromArgb(255, 0, 0));
                    update();
                    i++;
                }
                for (int j = 0; j < 20; j++)
                {
                    setPixel(i, Color.FromArgb(255, 168, 43));
                    update();
                    i++;
                }
                for (int j = 0; j < 20; j++)
                {
                    setPixel(i, Color.FromArgb(0, 0, 255));
                    update();
                    i++;
                }
                
            }
        }
        public static void diagnostics()
        {
            while(true)
            {
                flood(Color.FromArgb(255, 255, 255));
                update();
                clear();
                update();
            }
        }

        private static void update()
        {
            Program.strip.update();
            Thread.Sleep((int)(1000 / Program.FRAMERATE));
        }
        private static void setPixel(int index, Color c)
        {
            Program.strip.setPixel(index, c);
        }
        private static void flood(Color c)
        {
            Program.strip.flood(c);
        }
        private static void clear()
        {
            Program.strip.clear();
        }
    }
}
