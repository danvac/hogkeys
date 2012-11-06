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

        private int offset, busIndex, byteIndex;
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
                CalculateBusData();
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

        public int BusIndex
        {
            get { return busIndex; }
            set { busIndex = value;}

            
        }

        public int ByteIndex
        {
            get { return byteIndex; }
            set { byteIndex = value; }

        }

        public virtual void CalculateBusData() 
        {
            if (Index.Count > 0)
            {
                busIndex = Index[0] / 8;
                NotifyPropertyChanged("BusIndex");
                if (busIndex > 0)
                {

                    byteIndex = Index[0] % 8;
                }
                else byteIndex = Index[0];
                NotifyPropertyChanged("ByteIndex");
            }

        }



        public abstract string generateState(ConcurrentDictionary<int,string> dcsValues);

        public void setState(ConcurrentDictionary<int, string> dcsValues)
        {
            state = generateState(dcsValues);
            NotifyPropertyChanged("State");
        }

        public bool isStateChanged(ConcurrentDictionary<int, string> dcsValues)
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
