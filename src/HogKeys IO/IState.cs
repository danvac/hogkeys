using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.willshouse.HogKeys.IO
{
    public interface IState<T>
    {
         bool isStateChanged(T[] values);
         string generateState(T[] values);
    }
}
