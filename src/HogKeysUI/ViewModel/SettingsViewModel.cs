using GalaSoft.MvvmLight;
using HogKeysUI.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace HogKeysUI.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        Manager _manager;
        /// <summary>
        /// Initializes a new instance of the SettingsViewModel class.
        /// </summary>
        public SettingsViewModel(Manager manager)
        {
            _manager = manager;
            CloseCommand = new RelayCommand(() => Messenger.Default.Send<ViewModelBase>(this), () => true);
        }

        public string DisplayName { get { return "Settings"; } }

        public RelayCommand CloseCommand { get; private set; }

        /// <summary>
        /// The <see cref="HostName" /> property's name.
        /// </summary>
        public const string HostNamePropertyName = "HostName";

        public Manager Model { get {return _manager;}  }

        /// <summary>
        /// Sets and gets the HostName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string HostName
        {
            get
            {
                if (_manager.SimHost == null)
                {
                    return "localhost";
                }
                return _manager.SimHost;

            }

            set
            {
                if (_manager.SimHost == value)
                {
                    return;
                }

                RaisePropertyChanging(HostNamePropertyName);
                _manager.SimHost = value;
                RaisePropertyChanged(HostNamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Interval" /> property's name.
        /// </summary>
        public const string IntervalPropertyName = "Interval";

        

        /// <summary>
        /// Sets and gets the Interval property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double Interval
        {
            get
            {
                return (1000/(Model.PollingTimer.Interval));
            }

            set
            {
                if ((1000 / (Model.PollingTimer.Interval)) == value)
                {
                    return;
                }

                RaisePropertyChanging(IntervalPropertyName);
                
                Model.PollingTimer.Interval = (1000 / value);
                RaisePropertyChanged(IntervalPropertyName);
            }
        }
        

        
    }
}