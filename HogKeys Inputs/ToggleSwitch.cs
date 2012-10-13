using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace net.willshouse.HogKeys.Inputs
{
    public class ToggleSwitch : Input
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

        public override void setSwitchPositionData(List<string> positionsData)
        {
            Values = new System.ComponentModel.BindingList<string>()
           {
               positionsData[0],
               positionsData[1]
           };
        }

        
    }
}
