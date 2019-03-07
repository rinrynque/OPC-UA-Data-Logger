using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Opc.Ua;
using Opc.Ua.Client;

namespace IAADL_Core
{
    public class GroupLog
    {
        public GroupLog()
        {
            LogFileSettings = new LogFileConf();

            UpdatePeriod = 1000;
            LogRate = 5000;
            LogFileSettings.AppendDate = true;
            LogFileSettings.AppendTime = true;
            LogFileSettings.CreationAfterDuration = false;
            LogFileSettings.CADDuration = 120;
            m_MonitoredItem_Notification = new MonitoredItemNotificationEventHandler(MonitoredItem_Notification);

        }

        public string Name { get; set; }
        public ServerLog Server { get; set; }
        public string FilePath { get => m_filePath; set => m_filePath = value; }
        public bool IsLogging { get => m_isLogging;}
        public bool IsLoggingPaused { get => m_isLoggingPaused; }
        public int UpdatePeriod { get; set; }
        public int LogRate { get; set; }
        public LogFileConf LogFileSettings { get; set; }
        internal List<ItemLog> Items { get => m_items; set => m_items = value; }

        /// <summary>
        /// Raised after successfully adding a Monitored Item to the group.
        /// </summary>
        public event ItemEventHandler ItemAdded
        {
            add { m_itemAddedEvent += value; }
            remove { m_itemAddedEvent -= value; }
        }

        private Subscription m_subscription;
        private List<ItemLog> m_items = new List<ItemLog>();
        private MonitoredItemNotificationEventHandler m_MonitoredItem_Notification;
        private string m_filePath = "out.csv";
        private CsvWriter m_csvWriter;
        private StreamWriter m_streamWriter;
        private bool m_isLogging = false;
        private bool m_isLoggingPaused = false;
        private System.Timers.Timer m_LogDurationTimer;
        private System.Timers.Timer m_LogLineTimer;
        private ItemEventHandler m_itemAddedEvent;

        public void StartLogging()
        {
            if (m_isLoggingPaused)
            {
                m_isLoggingPaused = false;
                return;
            }

            if (LogFileSettings.CreationAfterDuration && m_LogDurationTimer == null)
            {
                m_LogDurationTimer = new System.Timers.Timer(LogFileSettings.CADDuration*1000*60);
                //m_LogDurationTimer.SynchronizingObject = (System.ComponentModel.ISynchronizeInvoke)m_items;
                m_LogDurationTimer.Elapsed += CycleLogFile;
                m_LogDurationTimer.AutoReset = true;
                m_LogDurationTimer.Enabled = true;
            }

            var thisFilePath = Path.Combine(Path.GetDirectoryName(FilePath), Path.GetFileNameWithoutExtension(FilePath));
            if (LogFileSettings.AppendDate)
            {
                thisFilePath += Utils.Format("{0:_ddMMyyyy}", DateTime.Now.ToLocalTime());
            }
            if(LogFileSettings.AppendTime)
            {
                thisFilePath += Utils.Format("{0:_HHmmss}", DateTime.Now.ToLocalTime());
            }
            thisFilePath += ".csv";

            m_streamWriter = new StreamWriter(thisFilePath);
            m_csvWriter = new CsvWriter(m_streamWriter);

            m_csvWriter.WriteField("Date");
            m_csvWriter.WriteField("Time");
            m_csvWriter.WriteField("Errors");
            foreach (ItemLog item in m_items)
            {
                m_csvWriter.WriteField(item.MI.DisplayName);
            }
            m_csvWriter.NextRecord();
            m_isLogging = true;
            m_LogLineTimer = new System.Timers.Timer(LogRate);
            m_LogLineTimer.Elapsed += LogLine;
            m_LogLineTimer.AutoReset = true;
            m_LogLineTimer.Enabled = true;
        }

        public void StopLogging()
        {
            if(m_LogDurationTimer != null)
            {
                m_LogDurationTimer.Dispose();
            }
            if (m_csvWriter != null)
            {
                m_csvWriter.Dispose();
                m_streamWriter.Close();
            }
            if(m_LogLineTimer != null)
            {
                m_LogLineTimer.Dispose();
            }
            m_isLogging = false;
            m_isLoggingPaused = false;
        }

        public void PauseLogging()
        {
            m_isLoggingPaused = true;
        }

        private void CycleLogFile(Object source, System.Timers.ElapsedEventArgs e)
        {
            StopLogging();
            StartLogging();
        }
        private void LogLine(Object source, System.Timers.ElapsedEventArgs e)
        {
            if(!IsLoggingPaused)
            {
                var now = DateTime.Now;
                m_csvWriter.WriteField(Utils.Format("{0:dd/MM/yyyy}", now));
                m_csvWriter.WriteField(Utils.Format("{0:HH:mm:ss}", now));
                m_csvWriter.WriteField("");
                foreach (ItemLog item in m_items)
                {
                    if(item.MI.LastValue == null)
                    {
                        continue;
                    }
                    string value = ((MonitoredItemNotification)item.MI.LastValue).Value.ToString();
                    if (value == "True")
                    {
                        value = "1";
                    }
                    if(value == "False")
                    {
                        value = "0";
                    }
                    m_csvWriter.WriteField(value);
                }
                m_csvWriter.NextRecord();
                m_streamWriter.Flush();
            }
        }

        /// <summary>
        /// Creates the monitored item.
        /// </summary>
        public ItemLog CreateMonitoredItem(NodeId nodeId, string displayName)
        {
            if (m_subscription == null)
            {
                m_subscription = new Subscription(Server.Connection.Session.DefaultSubscription);
                m_subscription.PublishingEnabled = true;
                m_subscription.PublishingInterval = 1000;
                m_subscription.KeepAliveCount = 10;
                m_subscription.LifetimeCount = 10;
                m_subscription.MaxNotificationsPerPublish = 1000;
                m_subscription.Priority = 100;

                Server.Connection.Session.AddSubscription(m_subscription);

                m_subscription.Create();
            }

            // add the new monitored item.
            MonitoredItem monitoredItem = new MonitoredItem(m_subscription.DefaultItem);

            monitoredItem.StartNodeId = nodeId;
            monitoredItem.AttributeId = Attributes.Value;
            monitoredItem.DisplayName = displayName;
            monitoredItem.MonitoringMode = MonitoringMode.Reporting;
            monitoredItem.SamplingInterval = UpdatePeriod;
            monitoredItem.QueueSize = 0;
            monitoredItem.DiscardOldest = true;

            monitoredItem.Notification += m_MonitoredItem_Notification;

            m_subscription.AddItem(monitoredItem);
            var itemLog = new ItemLog(monitoredItem);
            monitoredItem.Handle = itemLog;

            m_subscription.ApplyChanges();
            m_items.Add(itemLog);

            if (m_itemAddedEvent != null)
            {
                ItemEventArgs e = new ItemEventArgs(ItemEventArgs.ItemActionEnum.Created, monitoredItem.DisplayName, itemLog);
                m_itemAddedEvent(this, e);
            }
            return itemLog;
        }

        /// <summary>
        /// Updates the display with a new value for a monitored variable. 
        /// </summary>
        private void MonitoredItem_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            try
            {
                ItemLog itemLog = (ItemLog)monitoredItem.Handle;
                if (Server.Connection.Session == null)
                {
                    return;
                }

                MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;

                if (notification == null)
                {
                    return;
                }

                if(m_items.Count()>1)
                {
                    if(m_items[1] == itemLog)
                    {

                    }
                    if(itemLog == null)
                    {

                    }
                }

                itemLog.Value = Utils.Format("{0}", notification.Value.WrappedValue);
                //item.SubItems[3].Text = Utils.Format("{0}", notification.Value.StatusCode);
                //item.SubItems[5].Text = Utils.Format("{0:dd/MM/yyyy}", notification.Value.SourceTimestamp.ToLocalTime());
                //item.SubItems[4].Text = Utils.Format("{0:HH:mm:ss}", notification.Value.SourceTimestamp.ToLocalTime());

                if (ServiceResult.IsBad(monitoredItem.Status.Error))
                {
                    //item.SubItems[6].Text = monitoredItem.Status.Error.StatusCode.ToString();
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Handles the Click event of the Monitoring_DeleteMI control.
        /// </summary>
        public void DeleteMonitoredItem(ItemLog item)
        {
            m_items.Remove(item);
            //item.MI.Notification -= m_MonitoredItem_Notification;

            if (m_subscription != null)
            {
                m_subscription.RemoveItem(item.MI);
            }

            // update the server.
            if (m_subscription != null)
            {
                m_subscription.ApplyChanges();

                if (ServiceResult.IsBad(item.MI.Status.Error))
                {
                    //itemToDelete.SubItems[6].Text = item.Status.Error.StatusCode.ToString();
                }
            }
        }

    }

    /// <summary>
    /// The event arguments provided when an item is modified in a group
    /// </summary>
    public class ItemEventArgs : EventArgs
    {
        internal ItemEventArgs(ItemActionEnum action, string name, ItemLog item)
        {
            m_action = action;
            m_name = name;
            m_item = item;
        }
        public enum ItemActionEnum { Deleted, Renamed, Created }
        private ItemActionEnum m_action;
        private string m_name;
        private ItemLog m_item;

        public ItemActionEnum Action { get => m_action; set => m_action = value; }
        public string Name { get => m_name; set => m_name = value; }
        public ItemLog Item { get => m_item; set => m_item = value; }
    }
    public delegate void ItemEventHandler(Object sender, ItemEventArgs e);
}
