using System.Windows.Forms;
using System.Collections.Generic;
using net.willshouse.HogKeys.IO.Inputs;

namespace net.willshouse.HogKeys.Boards
{
    public interface IInputs
    {
        List<Input> Inputs { get; set; }

        void Poll();
    }
}
