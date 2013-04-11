using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;

namespace net.willshouse.HogKeys.IO
{
    public abstract class Driver
    {
        protected UdpClient client;

        public int Port { get; set; }
        public string Host { get; set; }
        public BindingSource Inputs { get; set; }
        public BindingSource Outputs { get; set; }

        protected Driver()
        {
            client = new UdpClient();
        }

        public abstract void InitializeConnection(int deviceIndex);
        public abstract void Poll();


    }
}
