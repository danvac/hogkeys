using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.willshouse.HogKeys.IO
{
    public abstract class DriverFactory
    {
        public string Host { get; set; }
        public int Port { get; set; }

        protected virtual Driver GetDriver(string type)
        {
            object o = Activator.CreateInstance<Type>();
            return (Driver) o;
            
        }
    }
}
