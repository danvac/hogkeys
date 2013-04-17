using System.Windows.Forms;
using net.willshouse.HogKeys.SimulatorAdapter;

namespace net.willshouse.HogKeys.Boards
{
    public interface IOutputs
    {
        BindingSource Outputs { get; set; }
        void SimListenerMessageReceived(object sender, SimMessageEventArgs e);
    }
}
