using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAADL_Core
{
    public class MainConf
    {
        public static MainConf LoadConf(string filePath)
        {
            return JsonConvert.DeserializeObject<MainConf>(File.ReadAllText(filePath));
        }
        public void SaveConf(string filePath)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(filePath))
            {
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    serializer.Serialize(writer, this);
                }
            }
        }
        public String ConfigFilePath { get; set; }
    }

    public class ServerConf
    {
        public ServerConf()
        {
            GroupConfs = new List<GroupConf>();
        }
        public ServerConf(string name = "Server")
        {
            Name = name;
            URI = "";
            GroupConfs = new List<GroupConf>();
        }
        public ServerConf(ServerLog server)
        {
            if (server == null)
            {
                return;
            }
            Name = server.Name;
            URI = server.URI;
            GroupConfs = server.GroupLogs.ConvertAll(x => new GroupConf(x));
        }
        public String Name { get; set; }
        public String URI { get; set; }
        public List<GroupConf> GroupConfs { get; set; }
    }
    public class GroupConf
    {
        public GroupConf(GroupLog group)
        {
            if(group == null)
            {
                return;
            }

            Name = group.Name;
            CSVPath = group.FilePath;
            ItemConfs = new List<ItemConf>();
            LogFileSettings = group.LogFileSettings;
            UpdatePeriod = group.UpdatePeriod;
            LogRate = group.LogRate;
            foreach (ItemLog item in group.Items)
            {
                ItemConf itemConf = new ItemConf(item.MI);
                ItemConfs.Add(itemConf);
            }
        }
        public String Name { get; set; }
        public String CSVPath { get; set; }
        public int UpdatePeriod { get; set; }
        public int LogRate { get; set; }
        public LogFileConf LogFileSettings { get; set; }
        public List<ItemConf> ItemConfs {get; set;}
    }
    public class ItemConf
    {
        public ItemConf(MonitoredItem item)
        {
            if (item == null)
            {
                return;
            }
            Name = item.DisplayName;
            ID = item.ResolvedNodeId.ToString();
        }
        public String Name { get; set; }
        public String ID { get; set; }
    }
    public class LogFileConf
    {
        public bool AppendDate { get; set; }
        public bool AppendTime { get; set; }
        public bool CreationAfterDuration { get; set; }
        public int CADDuration { get; set; }
    }

    public class ConfigFile
    {
        public static List<ServerConf> LoadFromFile(string filePath)
        {
            return JsonConvert.DeserializeObject<List<ServerConf>>(File.ReadAllText(filePath));
        }

        public static void SaveToFile(List<ServerLog> servers, string filePath)
        {
            List<ServerConf> serverConfs = servers.ConvertAll(x=>new ServerConf(x));
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(filePath))
            {
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    serializer.Serialize(writer, serverConfs);
                }
            }
        }

    }
}
