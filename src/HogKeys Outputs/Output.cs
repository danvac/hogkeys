using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Concurrent;

namespace net.willshouse.HogKeys.Outputs
{
    public abstract class Output : INotifyPropertyChanged
    {
        private string state, name, description;
        //private BindingList<string> values;
        public event PropertyChangedEventHandler PropertyChanged;
        private int offset;
        private  BindingList<int> index;
        private double logicOnValue;

        protected Output(string outputName, string description)
        {
            Name = outputName;
            Offset = -1;
            Index = new BindingList<int>{-1};
            LogicOnValue = 0.2;
            Description = description;
        }

        protected Output()
            : this("Enter Name", "Enter Description")
        {

        }


        public string Name
        {
            get { return name; }

            set
            {
                name = value;
                NotifyPropertyChanged("Name");
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

        public string Description
        {
            get { return description; }

            set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public string State
        {
            get { return this.state; }
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

        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
