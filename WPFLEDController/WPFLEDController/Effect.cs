using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Media;

namespace WPFLEDController 
{
    class Effect : INotifyPropertyChanged
    {
        private LedStrip strip;
        private Timer timer = new Timer();
        private double framerate;

        List<Keyframe> frames = new List<Keyframe>();
        int currentFrame = 0;

        public Effect(int ledCount, double framerate)
        {
            strip = new LedStrip(ledCount);
            this.framerate = framerate; 
            timer.Interval = 1000 / framerate;
            timer.Elapsed += onTimerTick;
        }

        #region Public Methods
        public event PropertyChangedEventHandler PropertyChanged;
        public void Start()
        {
            timer.Start();
            //onTimerTick(this, new EventArgs());
            //onTimerTick(this, new EventArgs());
            //onTimerTick(this, new EventArgs());
        }
        public void Stop()
        {
            timer.Stop();
        }
        public void Reset()
        {
            currentFrame = 0;
        }
        public void SetFrame(int frameNumber, List<Color> frame)
        {
            if(getFrameIndex(frameNumber) != -1)
            {
                frames[getFrameIndex(frameNumber)] = new Keyframe(frame, frameNumber);
                return;
            }
            for(int i = 0; i < frames.Count; i++)
            {
                if(frames[i].Frame > frameNumber)
                {
                    frames.Insert(i, new Keyframe(frame, frameNumber));
                    return;
                }
            }
            frames.Add(new Keyframe(frame, frameNumber));
        }
        public void SetFrame(int frameNumber, LedStrip frame)
        {
            if (getFrameIndex(frameNumber) != -1)
            {
                frames[getFrameIndex(frameNumber)] = new Keyframe(frame, frameNumber);
                return;
            }
            for (int i = 0; i < frames.Count; i++)
            {
                if (frames[i].Frame > frameNumber)
                {
                    frames.Insert(i, new Keyframe(frame, frameNumber));
                    return;
                }
            }
            frames.Add(new Keyframe(frame, frameNumber));
        }
        public Keyframe GetFrame(int frameNumber)
        {
            if(getFrameIndex(frameNumber) != -1)
            {
                return frames[getFrameIndex(frameNumber)];
            }
            return null;
        }

        #region Accessors
        public LedStrip Strip
        {
            get { return strip; }
        }
        public int CurrentFrame
        {
            get { return currentFrame; }
            set
            {
                if(value < frames.Count)
                {
                    currentFrame = value;
                }
            }
        }
        #endregion
        #endregion

        #region Private Methods
        private void onTimerTick(object sender, EventArgs e)
        {
            //No Keyframes
            if (frames.Count == 0)
            {
                currentFrame = 0;
                return;
            }
            //Single Keyframe
            if (frames.Count == 1)
            {
                for(int i = 0; i < strip.LedCount; i++)
                {
                    strip.SetPixel(i, frames[0].GetPixel(i));
                }
                strip.Push();
                currentFrame = 0;
                return;
            }
            //Reach End of Animation
            if(currentFrame == frames[frames.Count -1].Frame)
            {
                for (int i = 0; i < strip.LedCount; i++)
                {
                    strip.SetPixel(i, frames[frames.Count - 1].GetPixel(i));
                }
                strip.Push();
                currentFrame = 0;
                return;
            }
            //Before First Keyframe
            if (currentFrame < frames[0].Frame)
            {
                for (int i = 0; i < strip.LedCount; i++)
                {
                    strip.SetPixel(i, frames[0].GetPixel(i));
                }
                strip.Push();
                currentFrame++;
                return;
            }
            //Reach Keyframe
            if (getFrameIndex(currentFrame) != -1)
            {
                for (int i = 0; i < strip.LedCount; i++)
                {
                    strip.SetPixel(i, frames[getFrameIndex(currentFrame)].GetPixel(i));
                }
                strip.Push();
                currentFrame++;
                return;
            }
            //Regular Interpolation
            Keyframe upper = getKeyframeAbove(currentFrame);
            Keyframe lower = getKeyframeBelow(currentFrame);
            int step = currentFrame - lower.Frame;
            List<Color> interpolation = interpolate(lower, upper, step);
            for (int i = 0; i < strip.LedCount; i++)
            {
                strip.SetPixel(i, interpolation[i]);
            }
            strip.Push();
            currentFrame++;
        }

        private int getFrameIndex(int frameNumber)
        {
            for(int i = 0; i < frames.Count; i++)
            {
                if(frames[i].Frame == frameNumber)
                {
                    return i;
                }
            }
            return -1;
        }
        private Keyframe getKeyframeAbove(int frameNumber)
        {
            if(frames.Count > 1)
            {
                for (int i = 0; i < frames.Count; i++)
                {
                    if (frames[i].Frame > frameNumber)
                    {
                        return frames[i];
                    }
                }
            }
            return null;
        }
        private Keyframe getKeyframeBelow(int frameNumber)
        {
            if (frames.Count > 1)
            {
                for (int i = frames.Count - 1; i >= 0; i--)
                {
                    if (frames[i].Frame < frameNumber)
                    {
                        return frames[i];
                    }
                }
            }
            return null;
        }
        private List<Color> interpolate(Keyframe a, Keyframe b, int step)
        {
            double frameSpan = b.Frame - a.Frame;
            List<Color> output = new List<Color>();

            for(int i = 0; i < a.Content.Count; i++)
            {
                Color c = a.Content[i];

                int deltaR = (int)(((b.Content[i].R - a.Content[i].R) / frameSpan) * step);
                int deltaG = (int)(((b.Content[i].G - a.Content[i].G) / frameSpan) * step);
                int deltaB = (int)(((b.Content[i].B - a.Content[i].B) / frameSpan) * step);

                c.R += (byte)deltaR;
                c.G += (byte)deltaG;
                c.B += (byte)deltaB;

                output.Add(c);
            }
            return output;
        }
        #endregion
    }
}
