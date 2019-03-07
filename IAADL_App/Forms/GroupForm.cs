using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IAADL_App.Controls;
using IAADL_Core;

namespace IAADL_App.Forms
{
    public partial class GroupForm : Form
    {
        public GroupForm(GroupLog group)
        {
            InitializeComponent();
            m_group = group;
            selectFileCtrl1.FilePathControl = filePathTB;
            selectFileCtrl1.Filter = "CSV Files (*.csv)|*.csv|All Files(*.*)|*.*";

            nameTB.Text = group.Name;
            filePathTB.Text = m_group.FilePath;
            updatePeriodNUD.Value = m_group.UpdatePeriod;
            appendDateCB.Checked = m_group.LogFileSettings.AppendDate;
            logRateNUD.Value = m_group.LogRate;
            appendTimeCB.Checked = m_group.LogFileSettings.AppendTime;
            afterDurationCB.Checked = m_group.LogFileSettings.CreationAfterDuration;
            afterDurationNUD.Value = m_group.LogFileSettings.CADDuration;
        }
        GroupLog m_group;

        private void okBTN_Click(object sender, EventArgs e)
        {
            m_group.Name = nameTB.Text;
            m_group.FilePath = filePathTB.Text;
            m_group.UpdatePeriod = (int)updatePeriodNUD.Value;
            m_group.LogRate = (int)logRateNUD.Value;
            m_group.LogFileSettings.AppendDate = appendDateCB.Checked;
            m_group.LogFileSettings.AppendTime = appendTimeCB.Checked;
            m_group.LogFileSettings.CreationAfterDuration = afterDurationCB.Checked;
            m_group.LogFileSettings.CADDuration = (int)afterDurationNUD.Value;

            this.Close();
        }
    }
}
