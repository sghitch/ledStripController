using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFLEDController
{
    class Keyframe
    {
        private List<Color> content = new List<Color>();
        private int frame;

        public Keyframe(List<Color> content, int frame)
        {
            this.frame = frame;
            foreach(Color c in content)
            {
                this.content.Add(c);
            }
        }
        public Keyframe(LedStrip content, int frame)
        {
            this.frame = frame;
            foreach (Color c in content.Strip)
            {
                this.content.Add(c);
            }
        }
        public Keyframe(int frame, int ledCount)
        {
            this.frame = frame;
            for(int i = 0; i < ledCount; i++)
            {
                content.Add(Colors.Black);
            }
        }

        #region Public Methods
        public void SetPixel(int index, Color c)
        {
            if(index < content.Count)
            {
                content[index] = c;
            }
        }
        public Color GetPixel(int index)
        {
            if (index < content.Count)
            {
                return content[index];
            }
            return Colors.Transparent;
        }
        #region Accessors
        public int Frame
        {
            get { return frame; }
            set { frame = value; }
        }
        public List<Color> Content
        {
            get { return content; }
        }
        #endregion

        #endregion
    }
}
