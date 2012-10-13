using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace net.willshouse.HogKeys.Inputs
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
            throw new NotImplementedException();
        }


    }
}
