

namespace net.willshouse.HogKeys.IO.Inputs.Switches
{

    public class MultiSwitch : Switch
    {
        public MultiSwitch()
            : base("Enter Name", 1, 3001, InputType.None, "Enter Description")
        {
            Type = InputType.MultiSwitch;
        }

        public MultiSwitch(string switchName, int deviceId, int buttonId, InputType type, string description)
            : base(switchName, deviceId, buttonId, type, description)
        {
            Type = InputType.MultiSwitch;
        }

        public MultiSwitch(string switchName)
            : base(switchName, 1, 3001, InputType.None, "Enter Description")
        {
            Type = InputType.MultiSwitch;
        }

        public override string generateState(bool[] pokeysValues)
        {
            int valueIndex = 0;
            for (int i = 0; i < Pins.Count; i++)
            {
                if (pokeysValues[Pins[i]])
                    valueIndex = i;
            }
            return Values[valueIndex];
        }


    }
}
