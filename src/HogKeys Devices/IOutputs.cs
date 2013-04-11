using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.willshouse.HogKeys.IO
{
    public interface IOutputs
    {
        void UDPListenerEventHandlerMessageReceived(object sender, UDPListenerEventArgs e);
    }
}
