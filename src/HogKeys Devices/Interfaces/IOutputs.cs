using System.Windows.Forms;
using net.willshouse.HogKeys.SimulatorAdapter;
using System.Collections.Generic;

using net.willshouse.HogKeys.IO;

namespace net.willshouse.HogKeys.Boards
{
    public interface IOutputs
    {
         List<Output> Outputs { get; set; }
        void SimListenerMessageReceived(object sender, SimMessageEventArgs e);
    }
}
