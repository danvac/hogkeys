using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using net.willshouse.HogKeys.IO.Inputs;

namespace net.willshouse.HogKeys.IO
{
    public class PokeysDriver:Driver,IAnalogInputs,IOutputs
    {
        private bool[] currentPokeysSwitchValues;
        private bool[] previousPokeysSwitchValues;
        private int[] currentPokeysAnalogValues, previousPokeysAnalogValues;
        private PoKeysDevice_DLL.PoKeysDevice device;

        public PokeysDriver()
            :base()
        {
            currentPokeysSwitchValues = new bool[128];
            previousPokeysSwitchValues = new bool[128];
            currentPokeysAnalogValues = new int[7];
            previousPokeysAnalogValues = new int[7];
            device = new PoKeysDevice_DLL.PoKeysDevice();
        }

        public override void InitializeConnection(int deviceIndex)
        {
            int numberPokeysDevices = device.EnumerateDevices();

            if (numberPokeysDevices == 0)
            {
                throw new Exception("No Pokeys Devices Found");
            }
            device.ConnectToDevice(deviceIndex);
        }

        public override void Poll()
        {
            bool matrixResults = false;
            bool analogResults = false;
            if ((Inputs != null) && (Inputs.Count > 0))
            {
                // http://code.google.com/p/hogkeys/issues/detail?id=3
                // changed to get matrix status
                // check if we actually get valid results back before processing
                // this was causing a nasty intermittent bug where every input would shut off and on real quick
                // may want to put a counter on the main screen that shows "timeouts"

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
            /// <returns> Returns the value of an analog input located at index</returns>

            int[] value = new int[7];
            device.GetAllAnalogInputs(ref value);
            return value[index];
        }

        public void UDPListenerEventHandlerMessageReceived(object sender, UDPListenerEventArgs e)
        {
            //message format "offset:value,offset:value,"

            byte[] busData = new byte[10];
            string message = e.Message; //copy the received message into our buffer
            ConcurrentDictionary<int, string> offsets = new ConcurrentDictionary<int, string>();
            message = message.TrimEnd(','); //clean up the trailing , on the message
            string[] items = message.Split(','); //split into individual items tokenized by ,
            foreach (string item in items) //iterate through the received items
            {
                string[] offset = item.Split(':');
                offsets.TryAdd(Convert.ToInt32(offset[0]), offset[1]); //convert into key[offset],value[value[ into dictionary
            }
            foreach (Output item in Outputs) //iterate over each item in outputs for this device and attempt to set state
            {
                item.setState(offsets);
                switch (item.Type)
                {
                    case OutputType.ToggleOutput:
                        {
                            if (item.State == "ON") //since we create new bus data each time we only need to set the "Ons"
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
    }
}
