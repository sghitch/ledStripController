using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ledStripController
{
    class animation
    {
        private List<List<Color>> sequence;
        private string name;

        public animation(string nameInput)
        {
            name = nameInput;
            sequence = new List<List<Color>>();
            List<Color> currentFrame = new List<Color>();
            for(int j = 0; j < Program.NUMLEDS; j++){
                currentFrame.Add(Color.Black);
            }
            sequence.Add(currentFrame);
        }
        public List<Color> getFrame(int frameNumber)
        {
            try
            {
                return sequence[frameNumber-1];
            }
            catch(IOException e)
            {
                if (sequence.Count < frameNumber)
                    Console.WriteLine("Index out of range", e.Source);
                throw;
            }
        }
        public void setFrame(int frameNumber, List<Color> frame)
        {
            try
            {
                sequence[frameNumber-1] = frame;
            }
            catch (IOException e)
            {
                if (sequence.Count < frameNumber)
                    Console.WriteLine("Frame index out of range", e.Source);
                throw;
            }
        }
        public Color getLED(int frameNumber, int ledIndex)
        {
            try
            {
                return sequence[frameNumber-1][ledIndex];
            }
            catch (IOException e)
            {
                if (sequence.Count < frameNumber)
                    Console.WriteLine("Frame index out of range", e.Source);
                if (Program.NUMLEDS-1 < ledIndex)
                    Console.WriteLine("LED index out of range", e.Source);
                throw;
            }
        }
        public void setLED(int frameNumber, int ledIndex, Color c)
        {
            try
            {
                sequence[frameNumber-1][ledIndex] = c;
            }
            catch (IOException e)
            {
                if (sequence.Count < frameNumber)
                    Console.WriteLine("Frame index out of range", e.Source);
                if (Program.NUMLEDS - 1 < ledIndex)
                    Console.WriteLine("LED index out of range", e.Source);
                throw;
            }
        }
        public string getName()
        {
            return name;
        }
        public void changeName(string newName)
        {
            name = newName;
        }
        public void resize(int frameCount)
        {
            int frameDelta = frameCount - sequence.Count;
            if (frameDelta > 0)
            {
                for (int i = 0; i < frameDelta; i++)
                {
                    List<Color> currentFrame = new List<Color>();
                    for (int j = 0; j < Program.NUMLEDS; j++)
                    {
                        currentFrame.Add(Color.Black);
                    }
                    sequence.Add(currentFrame);
                }
            }
            else if(frameDelta < 0)
            {
                for (int i = 0; i > frameDelta; i--)
                {
                    sequence.RemoveAt(sequence.Count - 1);
                }
            }
        }
    }
}
