using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace net.willshouse.HogKeys.Inputs
{

    public class MultiSwitch : Input
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
