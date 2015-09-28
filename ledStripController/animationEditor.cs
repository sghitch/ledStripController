using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ledStripController
{
    public partial class animationEditor : Form
    {
        private List<int> active;
        private List<Button> buttons;
        private int currentFrame;
        private animation sequence;
        private bool frameBoxIsActive;
        private int playState;
        private int duration;
        
        public animationEditor()
        {
            InitializeComponent();
            active = new List<int>();
            buttons = new List<Button>();
            sequence = new animation("untitled");

            //Initialize Animation Buttons
            for (int i = 0; i < Program.NUMLEDS; i++)
            {
                buttons.Add(new Button());
                buttons[i].Size = new Size(24,24);
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].FlatAppearance.BorderSize = 2;
                buttons[i].BackColor = Color.Black;
                buttons[i].FlatAppearance.BorderColor = Color.DimGray;
                buttons[i].Name = "led" + i;

                //Adds button to active directory on click
                buttons[i].Click += (sender, e) => 
                {
                    Button led = (Button) sender;
                    int ledID = int.Parse(led.Name.Substring(3));
                    if (active.Contains(ledID))
                    {
                        active.Remove(ledID);
                        buttons[ledID].FlatAppearance.BorderColor = Color.DimGray;
                    }
                    else
                    {
                        active.Add(ledID);
                        buttons[ledID].FlatAppearance.BorderColor = Color.Yellow;
                    }
                };

                panel1.Controls.Add(buttons[i]);
                buttons[i].Location = new Point(i*25,0);
            }

            panel1.VerticalScroll.Visible = false;
            frameBoxIsActive = false;
            currentFrame = 1;
            playState = 1;
            duration = 1;
        }

        private void updateActiveFrame()
        {
            List<Color> currentFrameLED = sequence.getFrame(currentFrame);
            for (int i = 0; i < Program.NUMLEDS; i++)
            {
                buttons[i].BackColor = currentFrameLED[i];
            }
        }

       public void animationPlayer()
        {
            if (playState == 1)
            {
                if (currentFrame == duration)
                {
                    animationSlider.Invoke(new MethodInvoker(delegate { animationSlider.Value = 0; }));
                }
                else animationSlider.Invoke(new MethodInvoker(delegate { animationSlider.Value += 1; }));
            }
            if (playState == -1)
            {
                if (currentFrame == 1)
                {
                    animationSlider.Invoke(new MethodInvoker(delegate { animationSlider.Value = duration - 1; }));
                }
                else animationSlider.Invoke(new MethodInvoker(delegate { animationSlider.Value -= 1; }));
            }
        }

        private void animationSlider_ValueChanged(object sender, EventArgs e)
        {
            if (!frameBoxIsActive)
            {
               if(playState == 0) frameBox.Text = "" + (animationSlider.Value + 1);
                currentFrame = animationSlider.Value + 1;
                updateActiveFrame();
            }
        }

        private void durationBox_TextChanged(object sender, EventArgs e)
        {
            int newDuration;
            if (int.TryParse(durationBox.Text, out newDuration))
            {
                if (newDuration > 0)
                {
                    sequence.resize(newDuration);
                    animationSlider.Maximum = newDuration-1;
                    animationSlider.Value = 0;
                    duration = newDuration;
                }
            }
        }

        private void frameBox_TextChanged(object sender, EventArgs e)
        {
            int newFrame;
            if (int.TryParse(frameBox.Text, out newFrame))
            {
                if (newFrame > 0 && newFrame <= animationSlider.Maximum + 1 && frameBoxIsActive)
                {
                    animationSlider.Value = newFrame -1;
                    currentFrame = newFrame;
                    updateActiveFrame();
                }
            }
        }

        private void frameBox_Enter(object sender, EventArgs e)
        {
            frameBoxIsActive = true;
        }

        private void frameBox_Leave(object sender, EventArgs e)
        {
            frameBoxIsActive = false;
        }
    }
}
