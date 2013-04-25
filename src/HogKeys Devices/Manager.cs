using System;
using System.Windows.Forms;
using net.willshouse.HogKeys.IO;
using net.willshouse.HogKeys.IO.Inputs;
using net.willshouse.HogKeys.IO.Inputs.Switches;
using net.willshouse.HogKeys.SimulatorAdapter;
using net.willshouse.HogKeys.SimulatorAdapter.Adapters;

namespace net.willshouse.HogKeys.Boards
{
    public class Manager
    {

        private ISimAdapter simAdapter;
        //private static readonly Manager instance = new Manager();

        public BindingSource Boards { get; set; }

        public int ListenerPort
        {
            get { return simAdapter.ListenerPort; }
            set { simAdapter.ListenerPort = value; }
        }

        public int SimPort
        {
            get { return simAdapter.Port; }
            set { simAdapter.Port = value; }
        }

        public string SimHost
        {
            get { return simAdapter.Host; }
            set { simAdapter.Host = value; }
        }

        //public static Manager Instance
        //{
        //    get { return instance; }
        //}

        public Manager()
        {
            Boards = new BindingSource();
            simAdapter = DCSAdapter.Instance;
            Boards.DataSource = typeof(Board);
            GenerateTestData();
        }

        public void Initialize()
        {


            foreach (Board board in Boards)
            {
                try
                {
                    board.Initialize(simAdapter);
                }
                catch (Exception ex)
                {
                    // in the future send out an error event and let the gui deal with it
              //      MessageBox.Show(ex.Message, "MANAGER-DEBUG");
                }
            }
        }

        public void Poll()
        {
            foreach (IInputs board in Boards)
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

            PokeysBoard pokeysBoard = new PokeysBoard();
            pokeysBoard.DriverIndex = 0;
            pokeysBoard.Id = 1;
            pokeysBoard.Name = "My Test Board";

            pokeysBoard.Outputs.Add((Output)test1);
            pokeysBoard.Inputs.Add((Input)test2);

            try
            {
                
                pokeysBoard.Inputs.Add((Input)analog02);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Boards.Add(pokeysBoard);

            InputBoard arduinoBoard = new InputBoard();
            arduinoBoard.DriverIndex = 0;
            arduinoBoard.Id = 2;
            arduinoBoard.Name = "Arduino Analog Board";
            arduinoBoard.Inputs.Add(analog01);
            Boards.Add(arduinoBoard);

        }


    }
}
