using System.ComponentModel;
using net.willshouse.HogKeys.IO;
using net.willshouse.HogKeys.IO.Inputs;

namespace net.willshouse.HogKeys.UI
{
    public class HogKeysConfig
    {
        // This is just a container to host all the objects that will be saved out to a file
        public HogKeysConfig()
        {
            
        }
        public BindingList<Input> Inputs { get; set; }

        public BindingList<Output> Outputs { get; set; }
    }
}
