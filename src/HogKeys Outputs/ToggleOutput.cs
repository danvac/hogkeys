using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.willshouse.HogKeys.Outputs
{
    public class ToggleOutput: Output
    {
        public ToggleOutput()
            : base()
        {
            Type = OutputType.ToggleOutput;
        }

        public override string generateState(System.Collections.Concurrent.ConcurrentDictionary<int, double> dcsValues)
        {
            return ((dcsValues[Offset] > LogicOnValue)) ? "1" : "0";
        }
    }
}
