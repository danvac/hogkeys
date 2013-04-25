using System;
using System.Collections.Concurrent;
using System.Windows.Forms;
using net.willshouse.HogKeys.IO;
using net.willshouse.HogKeys.IO.Inputs;
using net.willshouse.HogKeys.SimulatorAdapter;
using System.Collections.Generic;
using System.Linq;

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


        public PokeysBoard(ISimAdapter adapter)
            : base(adapter)
        {
            simAdapter = adapter;
            device = new PoKeysDevice_DLL.PoKeysDevice();
            Inputs = new List<Input>();

            Outputs = new List<Output>();

            connected = false;
        }


        public override void Initialize()
        {

            InitializeConnection(this.DriverIndex);
            currentPokeysSwitchValues = new bool[discreteInputCount];
            previousPokeysSwitchValues = new bool[discreteInputCount];
            currentPokeysAnalogValues = new int[analogInputCount];
            previousPokeysAnalogValues = new int[analogInputCount];
            Enabled = true;
        }

        public override void Shutdown()
        {
            
            Enabled = false;
            connected = false;
            device.DisconnectDevice();
        }

        public void Poll()
        {
            bool matrixResults = false;
            bool analogResults = false;
            if ((device.Connected()) && (this.Enabled)&&(Inputs != null) && (Inputs.Count > 0))
            {
                matrixResults = device.GetMatrixKeyboardKeyStatus(ref currentPokeysSwitchValues);
                analogResults = device.GetAllAnalogInputs(ref currentPokeysAnalogValues);

                //Process Switch inputs
                if (matrixResults)
                {
                    ProcessInputs<IState<bool>, bool>(currentPokeysSwitchValues, previousPokeysSwitchValues);
                }
                else
                {
                    // MessageBox.Show("MatrixResults is False");
                }
                //Process Analog Inputs
                if (analogResults)
                {
                    ProcessInputs<IState<int>, int>(currentPokeysAnalogValues, previousPokeysAnalogValues);
                }
                else
                {
                    // MessageBox.Show("AnalogResults is False");
                }

               
            }
        }

        public int PollAnalogIndex(int index)
        {
            if ((this.Enabled)&&(device.Connected()) && (this.Enabled))
            {
                int[] value = new int[analogInputCount];
                device.GetAllAnalogInputs(ref value);
                return value[index];
            }
            else return 0;
        }

        public void SimListenerMessageReceived(object sender, SimulatorAdapter.SimMessageEventArgs e)
        {
            if ((this.Enabled) && (device.Connected()))
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
        }

        private void InitializeConnection(int deviceIndex)
        {
            int numberPokeysDevices = device.EnumerateDevices();

            if ((numberPokeysDevices == 0) | (numberPokeysDevices < deviceIndex))
            {
                Enabled = false;
                return;
                //throw new Exception(String.Format("Pokeys Device not found at index:{0}", deviceIndex));
            }
            connected = device.ConnectToDevice(deviceIndex);
            if (!connected)
            {
                Enabled = false;
                return;
            }
            // the stuff below could be read from some boards
            discreteInputCount = 128;
            analogInputCount = 7;
        }

        private void ProcessInputs<interfaceType, valueType>(valueType[] currentPokeysValues, valueType[] previousPokeysValues)
            where interfaceType : IState<valueType>
        {
            if ((previousPokeysValues == null) || (!currentPokeysValues.SequenceEqual(previousPokeysValues)))
            {

                foreach (Input input in Inputs)
                {
                    if (input is IState<valueType>)
                    {
                        if (((IState<valueType>)input).isStateChanged(currentPokeysValues))
                        {
                            simAdapter.Send(input);
                        }
                    }
                }
                currentPokeysValues.CopyTo(previousPokeysValues, 0);
            }
        }



        public override bool Connected
        {
            get { return device.Connected(); }
        }
    }
}
