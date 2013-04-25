using GalaSoft.MvvmLight;
using net.willshouse.HogKeys.SimulatorAdapter;
using net.willshouse.HogKeys.Boards;
using System.Collections.Generic;
using net.willshouse.HogKeys.IO;
using net.willshouse.HogKeys.IO.Inputs.Switches;
using net.willshouse.HogKeys.IO.Inputs;

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
            GenerateTestData();
            foreach (var board in _boards)
            {
                board.Initialize(_simAdapter);
            }
        }

        #endregion

        public void Poll()
        {
            foreach (IInputs board in _boards)
            {
                board.Poll();

            }
        }

        private void GenerateTestData()
        {

            //pokeys test data
            ToggleOutput test1;
            test1 = new ToggleOutput();
            test1.Name = "TestOutput1";

            ToggleSwitch test2 = new ToggleSwitch("test3");
            test2.Values.Add("-1");
            test2.Values.Add("1");
            test2.Pins.Add(31);
            test2.Enabled = true;

            AnalogInput analog01 = new AnalogInput("test Analog1");
            analog01.CalMin = 0;
            analog01.CalMax = 1023;
            analog01.Index = 0;
            analog01.MinValue = -1;
            analog01.MaxValue = 1;

            AnalogInput analog02 = new AnalogInput("test Analog2");
            analog01.CalMin = 0;
            analog01.CalMax = 1023;
            analog01.Index = 0;
            analog01.MinValue = -1;
            analog01.MaxValue = 1;
            analog01.Enabled = true;

            PokeysBoard pokeysBoard = new PokeysBoard();
            pokeysBoard.DriverIndex = 0;
            pokeysBoard.Id = 1;
            pokeysBoard.Name = "My Test Board";
            pokeysBoard.Enabled = false;

            pokeysBoard.Outputs.Add((Output)test1);
            pokeysBoard.Inputs.Add((Input)test2);
            pokeysBoard.Inputs.Add((Input)analog02);
           
            Boards.Add(pokeysBoard);

            InputBoard arduinoBoard = new InputBoard();
            arduinoBoard.DriverIndex = 0;
            arduinoBoard.Id = 2;
            arduinoBoard.Name = "Arduino Analog Board";
            arduinoBoard.Enabled = true;
            arduinoBoard.Inputs.Add(analog01);
            Boards.Add(arduinoBoard);

            
        }
    }
}