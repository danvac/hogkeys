using System.Linq;


namespace net.willshouse.HogKeys.IO.Inputs.Switches
{
    public class BinarySwitch : Switch
    {
        public BinarySwitch()
            : base("Enter Name", 1, 3001, InputType.None, "Enter Description")
        {
            Type = InputType.BinarySwitch;
        }

        public BinarySwitch(string switchName, int deviceId, int buttonId, InputType type, string description)
            : base(switchName, deviceId, buttonId, type, description)
        {
            Type = InputType.BinarySwitch;
        }

        public BinarySwitch(string switchName)
            : base(switchName, 1, 3001, InputType.None, "Enter Description")
        {
            Type = InputType.BinarySwitch;
        }
        
        public override string generateState(bool[] pokeysValues)
        {
            int valueIndex = 0;
            for (int i = 0; i < Pins.Count(); i++)
            {
                valueIndex = valueIndex + ((pokeysValues[Pins[i]] ? 1 : 0) << i);
            }
            return Values[valueIndex];
        }


    }
}
