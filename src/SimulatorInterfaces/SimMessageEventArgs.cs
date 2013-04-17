using System;

namespace net.willshouse.HogKeys.SimulatorAdapter
{
    public class SimMessageEventArgs : EventArgs
    {
        public SimMessageEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
