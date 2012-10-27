using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace net.willshouse.HogKeys.IO
{
    public class BinarySwitch : Input
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

        public override void setSwitchPositionData(List<string> positionsData)
        {
            throw new NotImplementedException();

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
