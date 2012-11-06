using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.willshouse.HogKeys.IO
{
    public class ToggleOutput: Output
    {
        public ToggleOutput()
            : base()
        {
            Type = OutputType.ToggleOutput;
        }

        public override string generateState(System.Collections.Concurrent.ConcurrentDictionary<int, string> dcsValues)
        {
            if (dcsValues[Offset] != "OFF")
            {
                return ((Convert.ToDouble(dcsValues[Offset]) > LogicOnValue)) ? "ON" : "OFF";
            }
            else
            {
                return "OFF";
            }
        }
    }
}
