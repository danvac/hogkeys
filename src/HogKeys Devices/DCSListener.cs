using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace net.willshouse.HogKeys.IO
{
    class DCSListener : SimListenerBase<DCSListener>
    {
        private UdpClient client;
        private IPEndPoint endPoint;
        private Thread thread;
        private string currentMessage, previousMessage;
        
        private DCSListener()
        {

        }
        
        public override void StartListening()
        {
            if (!listening)
            {

                client = new UdpClient(Port);
                endPoint = new IPEndPoint(IPAddress.Any, 0);
                thread = new Thread(Listen);
                thread.Start();
                listening = true;
            }
            else throw (new InvalidOperationException("DCSListener is Already Running"));
        }

        public override void StopListening()
        {
            listening = false;
            client.Close();
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
        
    }
}
