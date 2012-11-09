using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.willshouse.HogKeys.IO.Inputs
{
    public abstract class Input<T> : HogKeysIO
    {
        private int deviceId, buttonId;
        private InputType type;

        protected Input()
            : base()
        {

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

        public abstract string generateState(T [] pokeysValues);
        public abstract bool isStateChanged(T[] pokeysValues);

        public void setState(T [] pokeysValues)
        {
            state = generateState(pokeysValues);
            NotifyPropertyChanged("State");
        }
                
    }
}
