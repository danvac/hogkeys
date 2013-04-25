using System;
using System.Collections.Concurrent;
using System.Windows.Forms;
using net.willshouse.HogKeys.IO;
using net.willshouse.HogKeys.IO.Inputs;
using net.willshouse.HogKeys.SimulatorAdapter;
using System.Collections.Generic;

namespace net.willshouse.HogKeys.Boards
{
    public class PokeysBoard : Board, IDiscreteInputs, IAnalogInputs, IOutputs
    {
        private PoKeysDevice_DLL.PoKeysDevice device;
        private bool connected;
        private bool[] currentPokeysSwitchValues, previousPokeysSwitchValues;
        private int[] currentPokeysAnalogValues, previousPokeysAnalogValues;
        private int discreteInputCount, analogInputCount;
        private ISimAdapter simAdapter;

        public int DiscreteInputCount { get { return discreteInputCount; } }
        public int AnalogInputCount { get { return analogInputCount; } }
        public List<Input> Inputs
        { get; set; }
        public List<Output> Outputs
        { get; set; }


        public PokeysBoard()
            : base()
        {
            device = new PoKeysDevice_DLL.PoKeysDevice();
            Inputs = new List<Input>();

            Outputs = new List<Output>();
            
            connected = false;
        }


        public override void Initialize(ISimAdapter adapter)
        {
            simAdapter = adapter;
            InitializeConnection(this.DriverIndex);
            currentPokeysSwitchValues = new bool[discreteInputCount];
            previousPokeysSwitchValues = new bool[discreteInputCount];
            currentPokeysAnalogValues = new int[analogInputCount];
            previousPokeysAnalogValues = new int[analogInputCount];
            

        }

        public void Poll()
        {
           // throw new NotImplementedException();
        }

        public int PollAnalogIndex(int index)
        {
            int[] value = new int[analogInputCount];
            device.GetAllAnalogInputs(ref value);
            return value[index];
        }

        public void SimListenerMessageReceived(object sender, SimulatorAdapter.SimMessageEventArgs e)
        {
            byte[] busData = new byte[10];
            string message = e.Message;
            ConcurrentDictionary<int, string> offsets = new ConcurrentDictionary<int, string>();
            message = message.TrimEnd(',');
            string[] items = message.Split(',');
            foreach (string item in items)
            {
                string[] offset = item.Split(':');
                offsets.TryAdd(Convert.ToInt32(offset[0]), offset[1]);
            }
            foreach (Output item in Outputs)
            {
                item.setState(offsets);
                switch (item.Type)
                {
                    case OutputType.ToggleOutput:
                        {
                            if (item.State == "ON")
                            {
                                busData[9 - item.BusIndex] = (byte)(busData[9 - item.BusIndex] | (1 << 7 - item.ByteIndex));

                                // MessageBox.Show(busData[9 - item.BusIndex].ToString());

                            }
                            break;

                        }

                }
            }
            //  device.AuxilaryBusSetData(1, busData); // for auxbus pins
            device.AuxilaryBusSetData(1, 1, busData); // for default pins
        }

        private void InitializeConnection(int deviceIndex)
        {
            int numberPokeysDevices = device.EnumerateDevices();

            if ((numberPokeysDevices == 0) | (numberPokeysDevices < deviceIndex))
            {
                
                //throw new Exception(String.Format("Pokeys Device not found at index:{0}", deviceIndex));
            }
            connected = device.ConnectToDevice(deviceIndex);
            // the stuff below could be read from some boards
            discreteInputCount = 128;
            analogInputCount = 7;
        }





        public override bool Connected
        {
            get { return device.Connected(); }
        }
    }
}
