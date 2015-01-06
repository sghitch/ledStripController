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
        private static Thread currentThread;
        private static Boolean onState;

        public mainUI()
        {
            //Establish Program Threads

            currentThread = new Thread(ledEffects.blank);
            currentThread.Start();

            onState = false;

            InitializeComponent();

            //Initialize Program List
            _items.Add("Candy Cane");
            _items.Add("Christmas");
            _items.Add("Desk Light");
            _items.Add("Night Light");
            _items.Add("Reading Light");
            _items.Add("Waterfall");
            _items.Add("Diagnostics");

            listBox1.DataSource = _items;
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

        private static void threadExecuter(int index)
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
                currentThread = new Thread(ledEffects.nightight);
            }
            if (index == 5)
            {
                currentThread = new Thread(ledEffects.readingLight);
            }
            if (index == 6)
            {
                currentThread = new Thread(ledEffects.waterfall);
            }
            if (index == 7)
            {
                currentThread = new Thread(ledEffects.quietDiagnostic);
            }
            
            currentThread.Start();
        }
    }
}
