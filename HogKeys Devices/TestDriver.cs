using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using net.willshouse.HogKeys.Inputs;
using System.Net.Sockets;
using System.Windows.Forms;


namespace net.willshouse.HogKeys.Devices
{
    public class TestDriver
    {
        private BindingSource inputs;
        private PoKeysDevice_DLL.PoKeysDevice device;
        private UdpClient client;
        private string host;
        private int port;
        private bool[] currentPokeysValues;
        private bool[] previousPokeysValues;

        public TestDriver()
        {
            //pokeys bulk pin get uses 55 values
            // pokeys bulk matrix pin get is 128 values
            host = "127.0.0.1";
            port = 9089;
            client = new UdpClient();
            currentPokeysValues = new bool[55];
            previousPokeysValues = new bool[55];
            device = new PoKeysDevice_DLL.PoKeysDevice();
            
        }

        public BindingSource Inputs 
        {
            set
            {
                inputs = value;
            }
        }
        public void poll()
        {
            if ((inputs != null) && (inputs.Count > 0))
            {

                device.BlockGetInputAll55(ref currentPokeysValues);
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

        public void InitializeConnection( int deviceIndex)
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
                    client.Send(message, message.Length, host, port);
                }
            }
        }
    }
}
