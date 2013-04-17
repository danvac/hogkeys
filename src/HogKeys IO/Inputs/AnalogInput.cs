
namespace net.willshouse.HogKeys.IO.Inputs
{
    public class AnalogInput : Input<int>
    {
        private double minValue, maxValue, position, spread;
        private int index, calMin, calMax, calRange;

        public AnalogInput()
            : base()
        {
            Type = InputType.Analog;
        }

        public AnalogInput(string name)
            : base()
        {
            Name = name;
            Type = InputType.Analog;
        }

        public double MinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                minValue = value;
                NotifyPropertyChanged("MinValue");
                calibrate();
            }
        }

        public double MaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
                NotifyPropertyChanged("MaxValue");
                calibrate();
            }
        }

        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                NotifyPropertyChanged("Index");

            }
        }

        public int CalMin
        {
            get { return calMin; }
            set
            {
                calMin = value;
                NotifyPropertyChanged("CalMin");
                calibrate();
            }
        }

        public int CalMax
        {
            get { return calMax; }
            set
            {
                calMax = value;
                NotifyPropertyChanged("CalMax");
                calibrate();
            }
        }

        public override string generateState(int[] pokeysValues)
        {
            position = (double)(pokeysValues[index] - calMin) / (double)calRange;
            //return (minValue + (position * spread)).ToString();
            return string.Format("{0:0.00}",(minValue + (position * spread)));
        }

        private void calibrate()
        {
            spread = maxValue - minValue;
            calRange = calMax - calMin;
        }


    }
}
