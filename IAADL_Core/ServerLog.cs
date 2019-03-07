using IAADL_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAADL_Core
{
    public class ServerLog
    {
        public string Name { get; set; }
        public string URI { get; set; }
        public List<GroupLog> GroupLogs { get => m_groupLogs; set => m_groupLogs = value; }
        public ServerConnection Connection { get => m_connection; set => m_connection = value; }

        private ServerConnection m_connection = new ServerConnection();
        private List<GroupLog> m_groupLogs = new List<GroupLog>();
    }
}
