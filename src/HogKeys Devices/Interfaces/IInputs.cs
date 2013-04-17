using System.Windows.Forms;

namespace net.willshouse.HogKeys.Boards
{
    public interface IInputs
    {
        BindingSource Inputs { get; set; }

        void Poll();
    }
}
