using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

using WeifenLuo.WinFormsUI.Docking;
using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class FrmProperty : DockContent
    {
        private TaskInfo _task;
        private Collection<TaskInfo> _tasks;
        //private OperationInfo _operation;
        //private Collection<OperationInfo> _operations;
        //private AccountInfo _account;
        //private Collection<AccountInfo> _accounts;
        private string _group;
        private string[] _groups;

        public FrmProperty()
        {
            InitializeComponent();
            cmbCollection.Items.Clear();
        }

        #region Task
        public TaskInfo Task
        {
            get { return _task; }
            set
            { 
                _task = value;
                if (_task != null)
                {
                    cmbCollection.Items.Clear();
                    if (_tasks != null)
                    {
                        foreach (TaskInfo item in _tasks)
                        {
                            cmbCollection.Items.Add(item);
                            if (item.TaskId == _task.TaskId)
                                cmbCollection.SelectedItem = item;
                        }
                    }                    
                    propertyGrid.SelectedObject = _task;

                }
                else
                {
                    propertyGrid.SelectedObject = null;
                }
            }
        }

        public Collection<TaskInfo> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                propertyGrid.SelectedObject = null;
                cmbCollection.Items.Clear();
                cmbCollection.Items.Insert(0, "All Tasks");
                cmbCollection.SelectedIndex = 0;
            }
        }
        #endregion

        #region Operation
        /*
        public OperationInfo Operation
        {
            get { return _operation; }
            set
            {
                _operation = value;
                if (_operation != null)
                {
                    cmbCollection.Items.Clear();
                    if (_operations != null)
                    {
                        foreach (OperationInfo item in _operations)
                        {
                            cmbCollection.Items.Add(item);
                            if (item.Email == _operation.Email)
                                cmbCollection.SelectedItem = item;
                        }
                    }
                    propertyGrid.SelectedObject = _operation;
                }
                else
                {
                    propertyGrid.SelectedObject = null;
                }
            }
        }

        public Collection<OperationInfo> Operations
        {
            get { return _operations; }
            set
            {
                _operations = value;
            }
        }*/
        #endregion

        #region Account
        /*
        public AccountInfo Account
        {
            get { return _account; }
            set
            {
                _account = value;
                if (_account != null)
                {
                    cmbCollection.Items.Clear();
                    if (_accounts != null)
                    {
                        foreach (AccountInfo item in _accounts)
                        {
                            cmbCollection.Items.Add(item);
                        }
                    }
                    propertyGrid.SelectedObject = _account;
                    if (cmbCollection.Items.Count > 0)
                        cmbCollection.SelectedItem = _account;
                }
                else
                {
                    propertyGrid.SelectedObject = null;
                }
            }
        }

        public Collection<AccountInfo> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
                propertyGrid.SelectedObject = null;
                cmbCollection.Items.Clear();
                cmbCollection.Items.Insert(0, "所有账号");
                cmbCollection.SelectedIndex = 0;
            }
        }

        public string Group
        {
            get { return _group; }
            set
            {
                _group = value;
                if (_group != null)
                {
                    cmbCollection.Items.Clear();
                    if (_groups != null)
                    {
                        foreach (string item in _groups)
                        {
                            cmbCollection.Items.Add(item);
                        }
                    }
                    propertyGrid.SelectedObject = _group.ToString();
                    if (cmbCollection.Items.Count > 0)
                        cmbCollection.SelectedItem = _group.ToString();
                }
                else
                {
                    propertyGrid.SelectedObject = null;
                }
            }
        }

        public string[] Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                propertyGrid.SelectedObject = null;
                cmbCollection.Items.Clear();
                cmbCollection.Items.Insert(0, "所有组");
                cmbCollection.SelectedIndex = 0;
            }
        }
         */
        #endregion

        #region ComboBox event

        private void cmbCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCollection.Items.Count <= 0 || cmbCollection.SelectedIndex < 0)
                return;
            TaskInfo task = cmbCollection.SelectedItem as TaskInfo;
            if (task != null)
            {
                propertyGrid.SelectedObject = task;
                return;
            }
            /*
            AccountInfo account = cmbCollection.SelectedItem as AccountInfo;
            if (account != null)
            {
                propertyGrid.SelectedObject = account;
                return;
            }*/
        }

        #endregion

    }
}