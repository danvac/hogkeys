using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using net.willshouse.HogKeys.IO.Inputs;


namespace net.willshouse.HogKeys.IO
{
    public class TestDriver
    {
        private BindingSource inputs;
        private BindingSource outputs;
        private PoKeysDevice_DLL.PoKeysDevice device;
        private UdpClient client;
        private bool[] currentPokeysSwitchValues;
        private bool[] previousPokeysSwitchValues;
        private int[] currentPokeysAnalogValues, previousPokeysAnalogValues;

        public TestDriver()
        {
            //pokeys bulk pin get uses 55 values
            // pokeys bulk matrix pin get is 128 values
            client = new UdpClient();
            // http://code.google.com/p/hogkeys/issues/detail?id=3
            currentPokeysSwitchValues = new bool[128];
            previousPokeysSwitchValues = new bool[128];
            currentPokeysAnalogValues = new int[7];
            previousPokeysAnalogValues = new int[7];
            device = new PoKeysDevice_DLL.PoKeysDevice();


        }

        public int Port { get; set; }
        public string Host { get; set; }



        public BindingSource Inputs
        {
            set
            {
                inputs = value;
            }
        }

        public BindingSource Outputs
        {
            set
            {
                outputs = value;
            }
        }

        public void poll()
        {

            if ((inputs != null) && (inputs.Count > 0))
            {
                // http://code.google.com/p/hogkeys/issues/detail?id=3
                // changed to get matrix status
                device.GetMatrixKeyboardKeyStatus(ref currentPokeysSwitchValues);
                device.GetAllAnalogInputs(ref currentPokeysAnalogValues);
                //DumpValues();
                //Process Switch inputs
                ProcessInputs<IState<bool>, bool>(currentPokeysSwitchValues, previousPokeysSwitchValues);
                //Process Analog Inputs
                ProcessInputs<IState<int>, int>(currentPokeysAnalogValues, previousPokeysAnalogValues);
            }
        }

        public  int PollAnalogIndex(int index)
        {
            int [] value = new int[7];
            device.GetAllAnalogInputs(ref value);
            return value[index];
        }


        ~TestDriver()
        {
            device.DisconnectDevice();

        }

        public void InitializeConnection(int deviceIndex)
        {
            int numberPokeysDevices = device.EnumerateDevices();

            if (numberPokeysDevices == 0)
            {
                throw new Exception("No Pokeys Devices Found");
            }
            device.ConnectToDevice(deviceIndex);
        }

        //private void ProcessSwitchInputs()
        //{
        //    foreach (Input input in inputs)
        //    {

        //        if (input is Switch)
        //        {
        //            if (((Switch)input).isStateChanged(currentPokeysSwitchValues))
        //            {
        //                SendOnClickParameters(input);
        //            }
        //        }

        //    }

        //}

        private void ProcessInputs<interfaceType, valueType>(valueType[] currentPokeysValues, valueType[] previousPokeysValues)
            where interfaceType : IState<valueType>
        {
            if ((previousPokeysValues == null) || (!currentPokeysValues.SequenceEqual(previousPokeysValues)))
            {

                foreach (Input input in inputs)
                {
                    if (input is IState<valueType>)
                    {
                        if (((IState<valueType>)input).isStateChanged(currentPokeysValues))
                        {
                            SendOnClickParameters(input);
                        }
                    }
                }
                currentPokeysValues.CopyTo(previousPokeysValues, 0);
            }
        }

        private void SendOnClickParameters(Input input)
        {
            Byte[] message = Encoding.ASCII.GetBytes("C" + input.DeviceId + "," + input.ButtonId + "," + input.State);
            client.Send(message, message.Length, Host, Port);
        }
        public void DumpValues()
        {
            string values = String.Empty;
            foreach (bool value in currentPokeysSwitchValues)
            {
                values += value.ToString() + ",";
            }
            MessageBox.Show(values);
        }

        public void UDPListenerEventHandlerMessageReceived(object sender, UDPListenerEventArgs e)
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
            foreach (Output item in outputs)
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
            //  device.AuxilaryBusSetData(1, busData);
            device.AuxilaryBusSetData(1, 1, busData);
        }
    }
}
