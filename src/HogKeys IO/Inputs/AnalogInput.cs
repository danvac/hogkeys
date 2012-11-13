using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.willshouse.HogKeys.IO.Inputs
{
    public class AnalogInput : Input<int>
    {
        public AnalogInput()
            : base()
        {
            Type = InputType.Analog;
        }

        public AnalogInput(string name)
            : base()
        {
            Name = name;
        }

        public override string generateState(int[] pokeysValues)
        {
            throw new NotImplementedException();
        }

       
    }
}
