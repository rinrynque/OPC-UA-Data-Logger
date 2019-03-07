using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAADL_Core
{
    public class ItemLog
    {
        public ItemLog(MonitoredItem i)
        {
            MI = i;
            Value = "";
        }
        public MonitoredItem MI { get; set; }
        public String Value { get; set; }
    }
}
