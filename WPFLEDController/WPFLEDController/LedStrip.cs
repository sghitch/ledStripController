using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFLEDController
{
    class LedStrip:INotifyPropertyChanged
    {
        private ObservableCollection<Color> strip;
        private int ledCount;

        public LedStrip(int ledCount)
        {
            strip = new ObservableCollection<Color>(); 
            for(int i = 0; i < ledCount; i++)
            {
                strip.Add(Colors.Black);
            }
            this.ledCount = ledCount;
        }

        #region Public Methods
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        #region Accessors
        public void SetPixel(int index, Color color)
        {
            if (index < strip.Count && index > 0)
            {
                if(!strip[index].Equals(color))
                {
                    strip[index] = color;
                    PropertyChanged(this, new PropertyChangedEventArgs("Strip"));
                }
                
            }
        }

        public Color GetPixel(int index)
        {
            if (index < strip.Count && index > 0)
            {
                return strip[index];
            }
            return Colors.Transparent;
        }

        public void Clear()
        {
            for (int i = 0; i < strip.Count; i++)
            {
                strip[i] = Colors.Black;      
            }
            PropertyChanged(this, new PropertyChangedEventArgs("Strip"));
        }

        public void Flood(Color c)
        {
            for (int i = 0; i < strip.Count; i++)
            {
                strip[i] = c;
            }
            PropertyChanged(this, new PropertyChangedEventArgs("Strip"));
        }
        public void Push()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("Push"));
        }

        public ObservableCollection<Color> Strip
        {
            get { return strip; }
        }

        public int LedCount
        {
            get { return ledCount; }
        }
        #endregion

        #endregion

    }
}
