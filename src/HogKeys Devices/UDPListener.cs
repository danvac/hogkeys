using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace net.willshouse.HogKeys.IO
{
    public class UDPListenerEventArgs : EventArgs
    {
        public UDPListenerEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    

    public static class UDPListener
    {
        private static int port;
        private static bool isRunning;
        private static UdpClient client;
        private static IPEndPoint endPoint;
        private static Thread thread;
        private static string currentMessage, previousMessage;
        public delegate void UDPListenerEventHandler(object sender, UDPListenerEventArgs e);
        public static event UDPListenerEventHandler MessageReceived;

        public static int Port
        {
            get { return port; }
        }

        public static bool IsRunning
        {
            get { return isRunning; }
        }

        public static void Start(int listenPort)
        {
            if (!isRunning)
            {
                port = listenPort;
                client = new UdpClient(port);
                endPoint = new IPEndPoint(IPAddress.Any, 0);
                thread = new Thread(Poll);
                thread.Start();
                isRunning = true;
            }
            else throw (new InvalidOperationException("UDPListener is Already Running"));
        }

        private static void Poll()
        {
            while (isRunning)
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
                    isRunning = false;
                }
            }
        }

        private static void OnMessage(string currentMessage)
        {
            if (MessageReceived != null)
            {
                MessageReceived(null, new UDPListenerEventArgs(currentMessage));
            }
        }

        public static void Stop()
        {
            isRunning = false;
            client.Close();
        }


    }
}
