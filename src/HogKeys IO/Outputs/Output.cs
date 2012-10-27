using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Concurrent;

namespace net.willshouse.HogKeys.IO
{
    public enum OutputType
    {
        None = 0,
        ToggleOutput,
        BinaryOutput,
        MultiOutput
    }

    public abstract class Output : HogKeysIO
    {
        
        //private BindingList<string> values;
        
        private int offset;
        private  BindingList<int> index;
        private double logicOnValue;
        private OutputType type;

        protected Output(string outputName, string description) :base()
        {
            Name = outputName;
            Offset = 10000;
            Index = new BindingList<int>();
            LogicOnValue = 0.2;
            Description = description;
        }

        protected Output()
            : this("Enter Name", "Enter Description")
        {

        }


        

        public OutputType Type
        {
            get { return type; }

            set
            {
                type = value;
                NotifyPropertyChanged("Type");
            }
        }

        public int Offset 
        {
            get { return offset; }
            set
            {
                offset = value;
                NotifyPropertyChanged("Offset");
            }
        }

        public BindingList<int> Index 
        {
            get { return index; }
            set
            {
                index = value;
                NotifyPropertyChanged("Index");
            }
        }

        public double LogicOnValue 
        {
            get { return logicOnValue; }
            set
            {
                logicOnValue = value;
                NotifyPropertyChanged("LogicOnValue");
            }
        }

                

        public abstract string generateState(ConcurrentDictionary<int,double> dcsValues);

        public void setState(ConcurrentDictionary<int, double> dcsValues)
        {
            state = generateState(dcsValues);
            NotifyPropertyChanged("State");
        }

        public bool isStateChanged(ConcurrentDictionary<int, double> dcsValues)
        {
            string newState = generateState(dcsValues);
            if (newState == State) { return false; }
            else
            {
                state = newState;
                NotifyPropertyChanged("State");
                return true;
            }
        }

        
    }
}
