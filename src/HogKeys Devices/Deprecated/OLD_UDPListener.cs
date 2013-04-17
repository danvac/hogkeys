using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using net.willshouse.HogKeys.SimulatorAdapter;
namespace net.willshouse.HogKeys.IO
{
    
    

    public static class UDPListener
    {
        private static int port;
        private static bool listening;
        private static UdpClient client;
        private static IPEndPoint endPoint;
        private static Thread thread;
        private static string currentMessage, previousMessage;
        public delegate void SimMessageEventHandler(object sender, SimMessageEventArgs e);
        public static event SimMessageEventHandler MessageReceived;

        public static int Port
        {
            get { return port; }
        }

        public static bool Listening
        {
            get { return listening; }
        }

        public static void StartListening(int listenPort)
        {
            if (!listening)
            {
                port = listenPort;
                client = new UdpClient(port);
                endPoint = new IPEndPoint(IPAddress.Any, 0);
                thread = new Thread(Listen);
                thread.Start();
                listening = true;
            }
            else throw (new InvalidOperationException("UDPListener is Already Running"));
        }

        private static void Listen()
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

        private static void OnMessage(string currentMessage)
        {
            if (MessageReceived != null)
            {
                MessageReceived(null, new SimMessageEventArgs(currentMessage));
            }
        }

        public static void StopListening()
        {
            if (listening)
            {
                listening = false;
                client.Close();
            }
        }
            


    }
}
