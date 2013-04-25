using System.Linq;
using System.Windows.Forms;
using net.willshouse.HogKeys.IO;
using net.willshouse.HogKeys.IO.Inputs;
using net.willshouse.HogKeys.SimulatorAdapter;
using System.Collections.Generic;

namespace net.willshouse.HogKeys.Boards
{
    public class InputBoard : Board, IInputs, IAnalogInputs
    {
        private HogDuino_DLL.HogDuino driver;
        private int analogInputCount;
        private int[] currentAnalogValues, previousAnalogValues;
        private ISimAdapter simAdapter;
        private bool connected;


        #region Properties

        public List<Input> Inputs
        { get; set; }

        public override bool Connected
        {
            // should probabaly change this to driver.connected
            get { return driver.Connected; }
        }

        public int AnalogInputCount
        {
            get { return analogInputCount; }
        }

        #endregion


        #region Constructors

        public InputBoard()
        {
            driver = new HogDuino_DLL.HogDuino();
            Inputs = new List<Input>();

        }

        ~InputBoard()
        {
            driver.Disconnect();
        }

        #endregion


        public override void Initialize(ISimAdapter adapter)
        {
            simAdapter = adapter;
            int devices = driver.EnumerateDevices();
            if (devices == 0 | devices < DriverIndex)
            {
                //throw new Exception(String.Format("HogDuino Device not found at index: {0}, ListenerPort: {1}", DriverIndex, "placeHolder"));
            }
            connected = driver.ConnectToDevice(DriverIndex);
            analogInputCount = 8; // this value will come from the board in the future
            currentAnalogValues = new int[analogInputCount];
            previousAnalogValues = new int[analogInputCount];


        }

        public void Poll()
        {
            //driver.Ping(); // placeholder to make sure everything works
            // need to implement driver.connected call and check everywhere if its connected

            if ((driver.Connected) && (Inputs != null) && (Inputs.Count > 0))
            {
                if (driver.GetAllAnalogInputs(ref currentAnalogValues))
                {
                    ProcessInputs<IState<int>, int>(currentAnalogValues, previousAnalogValues);

                }
            }
        }

        public int PollAnalogIndex(int index)
        {
            if (driver.Connected)
            {
                int[] value = new int[analogInputCount];
                driver.GetAllAnalogInputs(ref value);
                return value[index];
            }

            else return 0;
        }
        

        private void ProcessInputs<interfaceType, valueType>(valueType[] currentValues, valueType[] previousValues)
            where interfaceType : IState<valueType>
        {
            if ((previousValues == null) || (!currentValues.SequenceEqual(previousValues)))
            {

                foreach (Input input in Inputs)
                {
                    if (input is IState<valueType>)
                    {
                        if (((IState<valueType>)input).isStateChanged(currentValues))
                        {
                            simAdapter.Send(input);
                            //SendOnClickParameters(input);
                            // make a call to the simAdapter to push data out
                        }
                    }
                }
                currentValues.CopyTo(previousValues, 0);
            }
        }


    }
}
