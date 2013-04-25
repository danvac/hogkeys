using GalaSoft.MvvmLight;
using net.willshouse.HogKeys.SimulatorAdapter;
using net.willshouse.HogKeys.Boards;
using System.Collections.Generic;
using net.willshouse.HogKeys.IO;
using net.willshouse.HogKeys.IO.Inputs.Switches;
using net.willshouse.HogKeys.IO.Inputs;
using System.Timers;

namespace HogKeysUI.Model
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class Manager : ViewModelBase
    {

        private ISimAdapter _simAdapter;
        

        #region Properties

        public Timer PollingTimer { get; private set; }


        /// <summary>
        /// The <see cref="SimPort" /> property's name.
        /// The port the simulator is listening to
        /// </summary>
        public const string SimPortPropertyName = "SimPort";

        //private int _simPort = 9189;

        /// <summary>
        /// Sets and gets the SimPort property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SimPort
        {
            get
            {
                return _simAdapter.Port;
            }

            set
            {
                if (_simAdapter.Port == value)
                {
                    return;
                }

                //RaisePropertyChanging(SimPortPropertyName);
                _simAdapter.Port = value;
                RaisePropertyChanged(SimPortPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="SimHost" /> property's name.
        /// </summary>
        public const string SimHostPropertyName = "SimHost";

        //private string _simHost = "localhost";

        /// <summary>
        /// Sets and gets the SimHost property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string SimHost
        {
            get
            {
                return _simAdapter.Host;
            }

            set
            {
                if (_simAdapter.Host == value)
                {
                    return;
                }

                //RaisePropertyChanging(SimHostPropertyName);
                _simAdapter.Host = value;
                RaisePropertyChanged(SimHostPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ListenerPort" /> property's name.
        /// </summary>
        public const string ListenerPortPropertyName = "ListenerPort";

        //private int _listenerPort = 9190;

        /// <summary>
        /// Sets and gets the ListenerPort property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ListenerPort
        {
            get
            {
                return _simAdapter.ListenerPort;
            }

            set
            {
                if (_simAdapter.ListenerPort == value)
                {
                    return;
                }

                //RaisePropertyChanging(ListenerPortPropertyName);
                _simAdapter.ListenerPort = value;
                RaisePropertyChanged(ListenerPortPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Boards" /> property's name.
        /// </summary>
        public const string BoardsPropertyName = "Boards";

        private List<Board> _boards = new List<Board>();

        /// <summary>
        /// Sets and gets the Boards property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<Board> Boards
        {
            get
            {
                return _boards;
            }

            private set
            {
                if (_boards == value)
                {
                    return;
                }

                RaisePropertyChanging(BoardsPropertyName);
                _boards = value;
                RaisePropertyChanged(BoardsPropertyName);
            }
        }

        #endregion


        #region Constructors
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public Manager(ISimAdapter simAdapter)
        {
            _simAdapter = simAdapter;
            this.PollingTimer = new Timer();
            PollingTimer.Enabled = false;
            PollingTimer.Interval = 1000;
            PollingTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            GenerateTestData();
            foreach (var board in _boards)
            {
                board.Initialize();
                if (board is IOutputs )
                {
                    _simAdapter.MessageReceived += (board as IOutputs).SimListenerMessageReceived;
                }
            }
        }

        void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Poll();
        }

        #endregion

        public void StartPolling()
        {
            PollingTimer.Enabled = true;
            _simAdapter.StartListening();
        }

        public void StopPolling()
        {
            PollingTimer.Enabled = false;
            _simAdapter.StopListening();
        }

        public void Poll()
        {
            foreach (IInputs board in _boards)
            {
                board.Poll();

            }
        }

        private void GenerateTestData()
        {
            ToggleSwitch sasYR = new ToggleSwitch("SASYawR");
            sasYR.DeviceId = 38;
            sasYR.ButtonId = 3005;
            sasYR.Values.Add("-1");
            sasYR.Values.Add("1");
            sasYR.Pins.Add(1);
            sasYR.Enabled = true;

            ToggleOutput TOTrim = new ToggleOutput();
            TOTrim.Name = "TOTrim";
            TOTrim.Description = "TakeOff Trim";
            TOTrim.Offset = 10003;
            TOTrim.Index.Add(0);
            TOTrim.LogicOnValue = 0.2;
            TOTrim.BusIndex = 0;
            TOTrim.ByteIndex = 0;
            TOTrim.Enabled = true;

            AnalogInput yawtrim = new AnalogInput();
            yawtrim.Name = "Yaw Trim";
            yawtrim.DeviceId = 38;
            yawtrim.ButtonId = 3013;
            yawtrim.MinValue = -1;
            yawtrim.MaxValue = 1;
            yawtrim.Index = 0;
            yawtrim.CalMin = 90;
            yawtrim.CalMax = 4050;
            yawtrim.Enabled = true;

            PokeysBoard pokeysBoard = new PokeysBoard(_simAdapter);
            pokeysBoard.DriverIndex = 0;
            pokeysBoard.Id = 1;
            pokeysBoard.Name = "My Test Board";
            pokeysBoard.Enabled = true;

            pokeysBoard.Outputs.Add((Output)TOTrim);
            pokeysBoard.Inputs.Add((Input)yawtrim);
            pokeysBoard.Inputs.Add((Input)sasYR);

            Boards.Add(pokeysBoard);

          

            AnalogInput analog01 = new AnalogInput("StallVol");
            analog01.CalMin = 0;
            analog01.CalMax = 1023;
            analog01.Index = 0;
            analog01.MinValue = 0;
            analog01.MaxValue = 1;
            analog01.DeviceId = 52;
            analog01.ButtonId = 3001;
            analog01.Enabled = true;
          

            

            InputBoard arduinoBoard = new InputBoard(_simAdapter);
            arduinoBoard.DriverIndex = 0;
            arduinoBoard.Id = 2;
            arduinoBoard.Name = "Arduino Analog Board";
            arduinoBoard.Enabled = true;
            arduinoBoard.Inputs.Add(analog01);
            Boards.Add(arduinoBoard);

            
        }
    }
}