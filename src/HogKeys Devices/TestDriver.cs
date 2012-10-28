using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
//using net.willshouse.HogKeys.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Collections.Concurrent;


namespace net.willshouse.HogKeys.IO
{
    public class TestDriver
    {
        private BindingSource inputs;
        private BindingSource outputs;
        private PoKeysDevice_DLL.PoKeysDevice device;
        private UdpClient client;
        private bool[] currentPokeysValues;
        private bool[] previousPokeysValues;

        public TestDriver()
        {
            //pokeys bulk pin get uses 55 values
            // pokeys bulk matrix pin get is 128 values
            client = new UdpClient();
            // http://code.google.com/p/hogkeys/issues/detail?id=3
            currentPokeysValues = new bool[128];
            previousPokeysValues = new bool[128];
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
                device.GetMatrixKeyboardKeyStatus(ref currentPokeysValues);
                //DumpValues();
                if (previousPokeysValues == null)
                {
                    ProcessInputs();
                }
                else if (!currentPokeysValues.SequenceEqual(previousPokeysValues))
                {
                    ProcessInputs();
                    currentPokeysValues.CopyTo(previousPokeysValues, 0);
                }
            }
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

        private void ProcessInputs()
        {
            foreach (Input input in inputs)
            {

                if (input.isStateChanged(currentPokeysValues))
                {
                    Byte[] message = Encoding.ASCII.GetBytes("C" + input.DeviceId + "," + input.ButtonId + "," + input.State);
                    client.Send(message, message.Length, Host, Port);
                }
            }
        }
        public void DumpValues()
        {
            string values = String.Empty;
            foreach (bool value in currentPokeysValues)
            {
                values += value.ToString() + ",";
            }
            MessageBox.Show(values);
        }

        public void UDPListenerEventHandlerMessageReceived(object sender, UDPListenerEventArgs e)
        {
            byte[] busData = new byte[10];
            string message = e.Message;
            ConcurrentDictionary<int, double> offsets = new ConcurrentDictionary<int, double>();
            message = message.TrimEnd(',');
            string[] items = message.Split(',');
            foreach (string item in items)
            {
                string[] offset = item.Split(':');
                offsets.TryAdd(Convert.ToInt32(offset[0]), Convert.ToDouble(offset[1]));
            }
            foreach (Output item in outputs)
            {
                item.setState(offsets);
                switch (item.Type)
                {
                    case OutputType.ToggleOutput:
                        {
                            if (item.State == "1")
                            {
                                busData[9 - item.BusIndex] = (byte)(busData[9 - item.BusIndex] | (1 << 7-item.ByteIndex));

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
