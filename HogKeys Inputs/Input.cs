using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace net.willshouse.HogKeys.Inputs
{

    public abstract class Input : INotifyPropertyChanged
    {
        private string state, name, description;
        private int deviceId, buttonId;
        private InputType type;
        private BindingList<int> pins;
        private BindingList<string> values;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return name; }

            set
            {
                name = value;
                NotifyPropertyChanged("Name");
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

        public int DeviceId
        {
            get { return deviceId; }

            set
            {
                deviceId = value;
                NotifyPropertyChanged("DeviceId");
            }
        }

        public int ButtonId
        {
            get { return buttonId; }

            set
            {
                buttonId = value;
                NotifyPropertyChanged("ButtonId");
            }
        }

        public InputType Type
        {
            get { return type; }

            set
            {
                type = value;
                NotifyPropertyChanged("Type");
            }
        }

        public BindingList<int> Pins
        {
            get { return pins; }

            set
            {
                pins = value;
                NotifyPropertyChanged("Pins");
            }
        }

        public BindingList<string> Values
        {
            get { return values; }

            set
            {
                values = value;
                NotifyPropertyChanged("Values");
            }
        }


        protected Input()
            : this("Enter Name", 1, 3001, InputType.None, "Enter Description")
        {

        }

        protected Input(string switchName)
            : this(switchName, 1, 3001, InputType.None, "Enter Description")
        {

        }

        protected Input(string switchName, int deviceId, int buttonId, InputType type, string description)
        {
            Name = switchName;
            DeviceId = deviceId;
            ButtonId = buttonId;
            Type = type;
            this.Description = description;
            Pins = new BindingList<int>();
            Values = new BindingList<string>();
        }

        public abstract void setSwitchPositionData(List<string> positionsData);


        public void setState(bool[] pokeysValues)
        {
            state = generateState(pokeysValues);
            NotifyPropertyChanged("State");
        }

        public bool isStateChanged(bool[] pokeysValues)
        {
            string newState = generateState(pokeysValues);
            if (newState == State) { return false; }
            else
            {
                state = newState;
                NotifyPropertyChanged("State");
                return true;
            }
        }

        public virtual string generateState(bool[] pokeysValues)
        {
            int valueIndex = 0;
            for (int i = 0; i < Pins.Count(); i++)
            {
                valueIndex = valueIndex + ((pokeysValues[Pins[i]] ? 1 : 0) << i);
            }
            return Values[valueIndex];
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
