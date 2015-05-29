using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;
using System.Threading;

namespace ledStripController
{
    static class Program
    {
        static SerialPort _serialPort;
        public static ledStrip strip;
        public static float FRAMERATE;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Initialize Serial Port
            _serialPort = new SerialPort();
            _serialPort.PortName = "com3";
            _serialPort.BaudRate = 250000;
            _serialPort.Open();

            //Initilize strip
            FRAMERATE = 120;
            strip = new ledStrip(240, _serialPort);

            //Query for reset
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new serialQuery());

            //Begin main app
            Application.Run(new mainUI());

        }
    }
}
