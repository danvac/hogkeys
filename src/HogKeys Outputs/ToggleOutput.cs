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
        }

        public override string generateState(System.Collections.Concurrent.ConcurrentDictionary<int, double> dcsValues)
        {
            throw new NotImplementedException();
        }
    }
}
