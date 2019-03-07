using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAADL_Core
{
    public class ItemLog
    {
        public ItemLog(MonitoredItem i, GroupLog papa)
        {
            MI = i;
            Value = "";
            Group = papa;
        }
        public MonitoredItem MI { get; set; }
        public String Value { get; set; }
        public object Handle { get; set; }
        public GroupLog Group { get; }
    }
}
