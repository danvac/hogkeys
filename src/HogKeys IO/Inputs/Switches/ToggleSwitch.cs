

namespace net.willshouse.HogKeys.IO.Inputs.Switches
{
    public class ToggleSwitch : Switch
    {

        public ToggleSwitch()
            : base("Enter Name", 1, 3001, InputType.None, "Enter Description")
        {
            Type = InputType.ToggleSwitch;
        }

        public ToggleSwitch(string switchName, int deviceId, int buttonId, InputType type, string description)
            : base(switchName, deviceId, buttonId, type, description)
        {
            Type = InputType.ToggleSwitch;
        }

        public ToggleSwitch(string switchName)
            : base(switchName, 1, 3001, InputType.None, "Enter Description")
        {
            Type = InputType.ToggleSwitch;
        }

        public override string generateState(bool[] pokeysValues)
        {
            return pokeysValues[Pins[0]] ? Values[1] : Values[0];
        }
    }
}
