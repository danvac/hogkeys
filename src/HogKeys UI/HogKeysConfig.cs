﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using net.willshouse.HogKeys.IO;
using System.ComponentModel;
using System.Collections;
using net.willshouse.HogKeys.IO.Inputs;

namespace net.willshouse.HogKeys.UI
{
    public class HogKeysConfig
    {
        // This is just a container to host all the objects that will be saved out to a file
        public HogKeysConfig()
        {
            
        }
        public BindingList<Switch> Inputs { get; set; }

        public BindingList<Output> Outputs { get; set; }
    }
}