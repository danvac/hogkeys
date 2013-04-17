using net.willshouse.HogKeys.IO.Inputs;


namespace net.willshouse.HogKeys.SimulatorAdapter
{
    public delegate void SimMessageEventHandler(object sender, SimMessageEventArgs e);

    public interface ISimAdapter
    {
        int ListenerPort { get; set; }
        int Port { get; set; }
        string Host { get; set; }
        bool Listening { get; }
        
        event SimMessageEventHandler MessageReceived;
        void StartListening();
        void StopListening();
        void Send(Input input);

    }
}
