using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;

using WeifenLuo.WinFormsUI.Docking;
using Johnny.Library.Helper;
using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class FrmTaskEditor : FrmBaseCloseMenu
    {
        private string _taskid;
        private string _taskname;
        private DatabaseInfo _dbserver;
        private string _database;
        private Collection<TableInfo> _tables;

        public delegate void TaskSavedEventHandler(string taskid, string taskname);
        public event TaskSavedEventHandler taskSaved;

        public FrmTaskEditor()
        {
            InitializeComponent();
        }

        protected override string GetPersistString()
        {
            return GetType().ToString() + "," + _taskid + "," + _taskname + "," + _dbserver.ServerName + "," + _dbserver.DatabaseName + "," + Text;
        }

        #region FrmTaskEditor_Load
        private void FrmTaskEditor_Load(object sender, EventArgs e)
        {
            try
            {
                BuildCmbTemplate();
                BuildCmbServer();
                
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskEditor.FrmTaskEditor_Load", ex);
            }
        }
        #endregion

        #region btnSave_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbServer.Items.Count == 0 || cmbServer.Text == string.Empty)
                {
                    MessageBox.Show("Please select a server£¡", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbServer.Select();
                    return;
                }

                if (cmbDatabase.Items.Count == 0 || cmbDatabase.Text == string.Empty)
                {
                    MessageBox.Show("Please select a database first£¡", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDatabase.Select();
                    return;
                }

                if (cmbTemplate.Items.Count == 0 || cmbTemplate.Text == string.Empty)
                {
                    MessageBox.Show("Please select a template first£¡", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTemplate.Select();
                    return;
                }

                if (selectorModule.AllSelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select a module first£¡", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    selectorModule.Select();
                    return;
                }
                if (String.IsNullOrEmpty(txtNameSpacePrefix.Text))
                {
                    MessageBox.Show("Please input the prefix of name space!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNameSpacePrefix.Select();
                    return;
                }
                if (String.IsNullOrEmpty(txtNameSpaceSuffix.Text))
                {
                    MessageBox.Show("Please input the suffix of name space!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNameSpaceSuffix.Select();
                    return;
                }

                TaskInfo taskitem = new TaskInfo();
                //taskitem.
                taskitem.TaskId = _taskid;
                taskitem.TaskName = _taskname;
                DatabaseInfo db = cmbDatabase.SelectedItem as DatabaseInfo;
                taskitem.DatabaseServer = db;
                TemplateInfo template = cmbTemplate.SelectedItem as TemplateInfo;
                taskitem.Template = template.Name;
                taskitem.Modules = selectorModule.AllSelectedItems;
                taskitem.NameSpacePrefix = txtNameSpacePrefix.Text;
                taskitem.NameSpaceSuffix = txtNameSpaceSuffix.Text;
                taskitem.WriteLogToFile = chkWriteLogToFile.Checked;
                
                //accounts
                foreach (object item in lstSelectedTables.Items)
                {
                    TableInfo table = item as TableInfo;
                    if (table != null)
                    {
                        taskitem.Tables.Add(table);
                    }
                }                

                if (ConfigCtrl.SetTask(_taskid, _taskname, taskitem))
                    MessageBox.Show("Succeed to save task!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.None);
                else
                    MessageBox.Show("Fail to save task!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                if (taskSaved != null)
                    taskSaved(_taskid, _taskname);
                
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskEditor", ex);
            }
        }
        #endregion

        #region btnReload_Click
        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTaskConfig();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskEditor", ex);
            }
        }
        #endregion

        #region list Select Event
        private void btnSelectOne_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (object item in lstAllTables.SelectedItems)
                {
                    lstSelectedTables.Items.Add(item);
                }
                for (int ix = lstAllTables.SelectedItems.Count - 1; ix >= 0; ix--)
                    lstAllTables.Items.Remove(lstAllTables.SelectedItems[0]);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskEditor", ex);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (object item in lstAllTables.Items)
                {
                    lstSelectedTables.Items.Add(item);
                }
                for (int ix = lstAllTables.Items.Count - 1; ix >= 0; ix--)
                    lstAllTables.Items.Remove(lstAllTables.Items[0]);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskEditor", ex);
            }
        }

        private void btnUnselectOne_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (object item in lstSelectedTables.SelectedItems)
                {
                    lstAllTables.Items.Add(item);
                }
                for (int ix = lstSelectedTables.SelectedItems.Count - 1; ix >= 0; ix--)
                    lstSelectedTables.Items.Remove(lstSelectedTables.SelectedItems[0]);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskEditor", ex);
            }
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (object item in lstSelectedTables.Items)
                {
                    lstAllTables.Items.Add(item);
                }
                for (int ix = lstSelectedTables.Items.Count - 1; ix >= 0; ix--)
                    lstSelectedTables.Items.Remove(lstSelectedTables.Items[0]);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskEditor", ex);
            }
        }
        #endregion               

        #region BuildCmbServer
        private void BuildCmbServer()
        {
            Collection<ServerInfo> servers = ConfigCtrl.GetServers();
            if (servers != null)
            {
                foreach (ServerInfo item in servers)
                {
                    cmbServer.Items.Add(item);
                }
            }
            
            LoadTaskConfig();
        }

        private void BuildCmbTemplate()
        {
            //templates
            Collection<TemplateInfo> templates = ConfigCtrl.GetTemplates();
            foreach (TemplateInfo item in templates)
            {
                cmbTemplate.Items.Add(item);
            }
            if (cmbTemplate.Items.Count > 0)
                cmbTemplate.SelectedIndex = 0;
        }
        #endregion
        
        #region LoadTaskConfig
        private void LoadTaskConfig()
        {
            if (!String.IsNullOrEmpty(_dbserver.ServerName))
            {
                for (int ix = 0; ix < cmbServer.Items.Count; ix++)
                {
                    if (cmbServer.Items[ix].ToString() == _dbserver.ServerName)
                        cmbServer.SelectedIndex = ix;
                }
            }
            //else if (cmbServer.Items.Count > 0)
            //    cmbServer.SelectedIndex = 0;

            if (!String.IsNullOrEmpty(_dbserver.DatabaseName))
            {
                for (int ix = 0; ix < cmbDatabase.Items.Count; ix++)
                {
                    if (cmbDatabase.Items[ix].ToString() == _dbserver.DatabaseName)
                        cmbDatabase.SelectedIndex = ix;
                }
            }
           // else if (cmbDatabase.Items.Count > 0)
           //     cmbDatabase.SelectedIndex = 0;        
           

            //load config info            
            TaskInfo taskitem = ConfigCtrl.GetTask(_taskid, _taskname);
            if (taskitem == null)
            {
                MessageBox.Show("Fail to read task config file!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Template
            if (!String.IsNullOrEmpty(taskitem.Template))
            {
                for (int ix = 0; ix < cmbTemplate.Items.Count; ix++)
                {
                    if (cmbTemplate.Items[ix].ToString() == taskitem.Template)
                        cmbTemplate.SelectedIndex = ix;
                }
            }
            else if (cmbTemplate.Items.Count > 0)
                cmbTemplate.SelectedIndex = 0;
            
            //Modules
            if (cmbTemplate.SelectedIndex >= 0)
            {
                selectorModule.AllSelectedItems = taskitem.Modules;
            }

            //tables
            if (cmbServer.SelectedIndex >= 0 && cmbDatabase.SelectedIndex >= 0)
            {
                _tables = DatabaseCtrl.GetTables(taskitem.DatabaseServer);

                lstAllTables.Items.Clear();
                lstSelectedTables.Items.Clear();

                if (_tables != null)
                {
                    lstAllTables.Items.Clear();
                    bool isAdded;
                    foreach (TableInfo table in _tables)
                    {
                        isAdded = false;
                        if (taskitem.Tables != null)
                        {
                            foreach (TableInfo selecteditem in taskitem.Tables)
                            {
                                if (selecteditem.TableName == table.TableName)
                                {
                                    lstSelectedTables.Items.Add(table);
                                    isAdded = true;
                                    break;
                                }
                            }
                        }

                        if (!isAdded)
                            lstAllTables.Items.Add(table);
                    }
                }
            }

            txtNameSpacePrefix.Text = taskitem.NameSpacePrefix;
            txtNameSpaceSuffix.Text = taskitem.NameSpaceSuffix;
            chkWriteLogToFile.Checked = taskitem.WriteLogToFile;
        }
        #endregion        

        #region cmbServer_SelectedIndexChanged
        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerInfo server = cmbServer.SelectedItem as ServerInfo;
            if (server != null)
            {
                Collection<DatabaseInfo> dbs = DatabaseCtrl.GetDataBases(server);
                if (dbs != null)
                {
                    foreach (DatabaseInfo item in dbs)
                    {
                        cmbDatabase.Items.Add(item);
                    }
                }
            }
        }
        #endregion      
                
        #region cmbDatabase_SelectedIndexChanged
        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServer.Items.Count > 0 && cmbServer.Text != string.Empty)
            {
                DatabaseInfo db = cmbDatabase.SelectedItem as DatabaseInfo;
                _tables = DatabaseCtrl.GetTables(db);
                lstAllTables.Items.Clear();
                lstSelectedTables.Items.Clear();
                if (_tables != null)
                {
                    foreach (TableInfo table in _tables)
                    {
                        lstAllTables.Items.Add(table);
                    }
                }
            }
        }
        #endregion

        #region cmbTemplate_SelectedIndexChanged
        private void cmbTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTemplate.SelectedIndex < 0)
                return;

            TemplateInfo template = cmbTemplate.SelectedItem as TemplateInfo;
            if (template != null)
            {
                Collection<ModuleInfo> modules = ConfigCtrl.GetModules(template.FullPath);                
                selectorModule.AllItems = modules;
            }
        }
        #endregion

        #region Properties
        public string TaskId
        {
            get { return _taskid; }
            set { _taskid = value; }
        }

        public string TaskName
        {
            get { return _taskname; }
            set { _taskname = value; }
        }

        public DatabaseInfo DbServer
        {
            get { return _dbserver; }
            set { _dbserver = value; }
        }
        #endregion        

        private void txtNameSpacePrefix_TextChanged(object sender, EventArgs e)
        {
            ChangeNameSpacePreview();
        }

        private void txtNameSpaceSuffix_TextChanged(object sender, EventArgs e)
        {
            ChangeNameSpacePreview();
        }

        private void ChangeNameSpacePreview()
        {
            if (String.IsNullOrEmpty(txtNameSpacePrefix.Text) || String.IsNullOrEmpty(txtNameSpaceSuffix.Text))
                txtNameSpacePreview.Text = "";
            else
                txtNameSpacePreview.Text = string.Concat(txtNameSpacePrefix.Text, ".XXX.", txtNameSpaceSuffix.Text);
        }
        

              
    }
}