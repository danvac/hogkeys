using System.ComponentModel;

namespace net.willshouse.HogKeys.IO
{
    public abstract class HogKeysIO : INotifyPropertyChanged
    {
        protected string state, name, description;
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

        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
    }
}
