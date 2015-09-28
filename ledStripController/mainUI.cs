using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ledStripController
{
    public partial class mainUI : Form
    {
        List<string> _items = new List<string>();
        private static List<Action> _programs = new List<Action>();
        private static Thread currentThread;
        private static Boolean onState;
        public Color customColor;
        
        public mainUI()
        {
            sync.Interval = (int)(1000 / Program.FRAMERATE);
            sync.Start();

            //Establish Program Threads

            currentThread = new Thread(ledEffects.blank);
            currentThread.Start();

            onState = false;

            InitializeComponent();

            //Initialize Program List
            _items.Add("Candy Cane");
            _items.Add("Christmas");
            _items.Add("Desk Light");
            _items.Add("Fuse");
            _items.Add("Night Light");
            _items.Add("Patriotic");
            _items.Add("Reading Light");
            _items.Add("Warm Ambient");
            _items.Add("Waterfall");
            _items.Add("Diagnostics");

            //Intialize Program Threads
            _programs.Add(ledEffects.blank);
            _programs.Add(ledEffects.candyCane);
            _programs.Add(ledEffects.christmas);
            _programs.Add(ledEffects.deskLight);
            _programs.Add(ledEffects.fuse);
            _programs.Add(ledEffects.nightlight);
            _programs.Add(ledEffects.patriotic);
            _programs.Add(ledEffects.readingLight);
            _programs.Add(ledEffects.warmAmbient);
            _programs.Add(ledEffects.waterfall);
            _programs.Add(ledEffects.diagnostics);


            listBox1.DataSource = _items;

            Program.strip.setOveride(100);
        }


        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(onState)
            {
                threadExecuter(listBox1.SelectedIndex+1);
            }
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            onState = false;
            threadExecuter(0);
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            onState = true;
            threadExecuter(listBox1.SelectedIndex+1);
        }

        /*private static void threadExecuter(int index)
        {
            currentThread.Abort();

            if(index == 0)
            {
                currentThread = new Thread(ledEffects.blank);
            }
            if(index == 1)
            {
                currentThread = new Thread(ledEffects.candyCane);
            }
            if(index == 2)
            {
                currentThread = new Thread(ledEffects.christmas);
            }
            if (index == 3)
            {
                currentThread = new Thread(ledEffects.deskLight);
            }
            if (index == 4)
            {
                currentThread = new Thread(ledEffects.nightlight);
            }
            if (index == 5)
            {
                currentThread = new Thread(ledEffects.readingLight);
            }
            if (index == 6)
            {
                currentThread = new Thread(ledEffects.warmAmbient);
            }
            if (index == 7)
            {
                currentThread = new Thread(ledEffects.waterfall);
            }
            if (index == 8)
            {
                currentThread = new Thread(ledEffects.quietDiagnostic);
            }
            
            currentThread.Start();
        }*/
        private static void threadExecuter(int index)
        {
            currentThread.Abort();
            currentThread = new Thread(new ThreadStart(_programs[index]));
            Program.strip.clearUpdateRequests();
            currentThread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Color stripColor = colorDialog1.Color;

            currentThread.Abort();
            onState = false;

            Program.strip.flood(stripColor);
            Program.strip.update();
        }

        private void trackBar1_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Program.strip.setOveride(trackBar1.Value);
        }

        private void framerateBox_TextChanged(object sender, EventArgs e)
        {
            if (!framerateBox.Text.Equals(""))
            {
                Program.FRAMERATE = int.Parse(framerateBox.Text);
            }     
        }
 
        private void animationButton_Click(object sender, EventArgs e)
        {
           
        }

        private void sync_Tick(object sender, EventArgs e)
        {
            Program.strip.updateStrip();
        }

    }
}
