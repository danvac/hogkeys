using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;



namespace net.willshouse.HogKeys.IO.Inputs
{

    public abstract class Switch : Input<bool>
    {
        //private string state, name, description;
        
        
        private BindingList<int> pins;
        private BindingList<string> values;
        //public event PropertyChangedEventHandler PropertyChanged;



        

        

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


        protected Switch()
            : this("Enter Name", 1, 3001, InputType.None, "Enter Description")
        {

        }

        protected Switch(string switchName)
            : this(switchName, 1, 3001, InputType.None, "Enter Description")
        {

        }

        protected Switch(string switchName, int deviceId, int buttonId, InputType type, string description)
            : base()
        {
            Name = switchName;
            DeviceId = deviceId;
            ButtonId = buttonId;
            Type = type;
            this.Description = description;
            Pins = new BindingList<int>();
            Values = new BindingList<string>();
        }



        public override bool isStateChanged(bool[] pokeysValues)
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






    }
}
