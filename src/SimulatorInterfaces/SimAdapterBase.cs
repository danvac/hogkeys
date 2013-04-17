using net.willshouse.HogKeys.IO.Inputs;

namespace net.willshouse.HogKeys.SimulatorAdapter
{
    public abstract class SimAdapterBase
    {


        public int Port { get; set; }
        public string  Host { get; set; }

        public abstract void Send(Input input);

    }
}
