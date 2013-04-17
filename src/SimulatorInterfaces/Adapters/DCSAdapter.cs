using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using net.willshouse.HogKeys.IO.Inputs;

namespace net.willshouse.HogKeys.SimulatorAdapter.Adapters
{
    public sealed class DCSAdapter : ISimAdapter
    {
        private static readonly DCSAdapter instance = new DCSAdapter();
        private UdpClient client,sender;
        private IPEndPoint endPoint;
        private Thread thread;
        private string currentMessage, previousMessage;
        private bool listening;


        public event SimMessageEventHandler MessageReceived;
        public int ListenerPort { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public bool Listening
        {
            get
            {
                return listening;
            }

        }


        public static DCSAdapter Instance
        {
            get { return instance; }
        }

        public void StartListening()
        {
            if (!listening)
            {

                client = new UdpClient(ListenerPort);
                endPoint = new IPEndPoint(IPAddress.Any, 0);
                thread = new Thread(Listen);
                thread.Start();
                listening = true;
            }
            
        }

        public void StopListening()
        {
            if (listening)
            {
                listening = false;
                client.Close();
            }
        }

        private DCSAdapter() {
        sender = new UdpClient();
        }

        private void Listen()
        {
            while (listening)
            {
                try
                {
                    byte[] message = client.Receive(ref endPoint);
                    currentMessage = Encoding.ASCII.GetString(message);
                    if (currentMessage != previousMessage)
                    {
                        OnMessage(currentMessage);
                        previousMessage = String.Copy(currentMessage);

                    }
                }
                catch (SocketException)
                {
                    listening = false;
                }
            }
        }

        private void OnMessage(string currentMessage)
        {
            if (MessageReceived != null)
            {
                MessageReceived(null, new SimMessageEventArgs(currentMessage));
            }
        }

        private void SendOnClickParameters(Input input)
        {
            Byte[] message = Encoding.ASCII.GetBytes("C" + input.DeviceId + "," + input.ButtonId + "," + input.State);
            sender.Send(message, message.Length, Host, Port);
        }





        public void Send(Input input)
        {
            SendOnClickParameters(input);
        }
    }
}
