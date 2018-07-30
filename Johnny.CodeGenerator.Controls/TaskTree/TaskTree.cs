using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;
using System.Collections.ObjectModel;

using Johnny.Library.Helper;
using Johnny.CodeGenerator.Core;
using System.Threading;

namespace Johnny.CodeGenerator.Controls.TaskTree
{
    public class TaskTree : TreeView
    {
        #region Variable
  
        private System.ComponentModel.IContainer components;
        private ImageList imageListIcon;
        private ContextMenuStrip contextmenustrip = new ContextMenuStrip();
        private TaskInfo _task;
        private Collection<string> _executingTaskIdList;

        #endregion        

        #region OnTaskNodeSelected
        public delegate void TaskNodeSelectedEventHandler(object sender, TaskEventArgs e);
        public event TaskNodeSelectedEventHandler TaskNodeSelectedEvent;
        protected virtual void OnTaskNodeSelected(TaskEventArgs e)
        {
            if (TaskNodeSelectedEvent != null)
                TaskNodeSelectedEvent(this, e);
        }
        #endregion

        #region OnOpenTaskEditor
        public delegate void OpenTaskEditorEventHandler(object sender, TaskEventArgs e);
        public event OpenTaskEditorEventHandler OpenTaskEditorEvent;
        protected virtual void OnOpenTaskEditor(TaskEventArgs e)
        {
            if (OpenTaskEditorEvent != null)
                OpenTaskEditorEvent(this, e);
        }
        #endregion

        #region OnOpenTaskConfigFile
        public delegate void OpenTaskConfigFileEventHandler(object sender, TaskEventArgs e);
        public event OpenTaskConfigFileEventHandler OpenTaskConfigFileEvent;
        protected virtual void OnOpenTaskConfigFile(TaskEventArgs e)
        {
            if (OpenTaskConfigFileEvent != null)
                OpenTaskConfigFileEvent(this, e);
        }
        #endregion

        #region OnStartTask
        public delegate void StartTaskEventHandler(object sender, TaskEventArgs e);
        public event StartTaskEventHandler StartTaskEvent;
        protected virtual void OnStartTask(TaskEventArgs e)
        {
            if (StartTaskEvent != null)
                StartTaskEvent(this, e);
        }
        #endregion

        #region OnStopTask
        public delegate void StopTaskEventHandler(object sender, TaskEventArgs e);
        public event StopTaskEventHandler StopTaskEvent;
        protected virtual void OnStopTask(TaskEventArgs e)
        {
            if (StopTaskEvent != null)
                StopTaskEvent(this, e);
        }
        #endregion

        #region OnRootNodeSelected
        public delegate void RootNodeSelectedEventHandler(object sender, RootNodeEventArgs e);
        public event RootNodeSelectedEventHandler RootNodeSelectedEvent;
        protected virtual void OnRootNodeSelected(RootNodeEventArgs e)
        {
            if (RootNodeSelectedEvent != null)
                RootNodeSelectedEvent(this, e);
        }
        #endregion

        
        #region OnOperationNodeSelected
        /*public delegate void OperationNodeSelectedEventHandler(object sender, OperationEventArgs e);
        public event OperationNodeSelectedEventHandler OperationNodeSelectedEvent;
        protected virtual void OnOperationNodeSelected(OperationEventArgs e)
        {
            if (OperationNodeSelectedEvent != null)
                OperationNodeSelectedEvent(this, e);
        }*/
        #endregion


        #region OnTaskNameChanged
        public delegate void TaskNameChangedEventHandler(object sender, TaskEventArgs e);
        public event TaskNameChangedEventHandler TaskNameChangedEvent;
        protected virtual void OnTaskNameChanged(TaskEventArgs e)
        {
            if (TaskNameChangedEvent != null)
                TaskNameChangedEvent(this, e);
        }
        #endregion        

        #region OnOpenAccount
        /*
        public delegate void OpenAccountEventHandler(object sender, AccountEventArgs e);
        public event OpenAccountEventHandler OpenAccountEvent;
        protected virtual void OnOpenAccount(AccountEventArgs e)
        {
            if (OpenAccountEvent != null)
                OpenAccountEvent(this, e);
        }*/
        #endregion

        #region Ctor

        public TaskTree()
        {
            this.InitializeComponent();
            this.ContextMenuStrip = contextmenustrip;
            this.MouseDown += new MouseEventHandler(OnMouseDown);
            this.DoubleClick += new EventHandler(OnDoubleClick);
            this.BeforeLabelEdit += new NodeLabelEditEventHandler(TaskTree_BeforeLabelEdit);
            this.AfterLabelEdit += new NodeLabelEditEventHandler(TaskTree_AfterLabelEdit);
            this.AfterSelect += new TreeViewEventHandler(TaskTree_AfterSelect);
            this.AfterExpand += new TreeViewEventHandler(TaskTree_AfterExpand);
            this.BeforeCollapse += new TreeViewCancelEventHandler(TaskTree_BeforeCollapse);
            this.BeforeExpand += new TreeViewCancelEventHandler(TaskTree_BeforeExpand);
            _executingTaskIdList = new Collection<string>();
        }

        private const int WM_LBUTTONDBLCLK = 515;
        private bool bDoubleClick = false;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK)
                bDoubleClick = true;

            base.WndProc(ref m);
        }

        void TaskTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (bDoubleClick)
            {
                e.Cancel = true;
                bDoubleClick = false;
            }
        }

        void TaskTree_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (bDoubleClick)
            {
                e.Cancel = true;
                bDoubleClick = false;
            }
        }

        void TaskTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TaskTree_AfterSelect(sender, e);
        }
        #endregion

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskTree));
            this.imageListIcon = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageListIcon
            // 
            this.imageListIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcon.ImageStream")));
            this.imageListIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcon.Images.SetKeyName(0, "tasks.ico");
            this.imageListIcon.Images.SetKeyName(1, "task.ico");
            this.imageListIcon.Images.SetKeyName(2, "addtask.ico");
            this.imageListIcon.Images.SetKeyName(3, "refresh.png");
            this.imageListIcon.Images.SetKeyName(4, "delete.ico");
            this.imageListIcon.Images.SetKeyName(5, "start.ico");
            this.imageListIcon.Images.SetKeyName(6, "stop.ico");
            this.imageListIcon.Images.SetKeyName(7, "started.ico");
            this.imageListIcon.Images.SetKeyName(8, "paused.ico");
            this.imageListIcon.Images.SetKeyName(9, "table.ico");
            this.imageListIcon.Images.SetKeyName(10, "xml.ico");
            this.imageListIcon.Images.SetKeyName(11, "unknow.ico");
            // 
            // TaskTree
            // 
            this.ImageIndex = 0;
            this.ImageList = this.imageListIcon;
            this.LineColor = System.Drawing.Color.Black;
            this.SelectedImageIndex = 0;
            this.ResumeLayout(false);

        }
        #endregion

        #region Initlize TaskTree
        public void InitialNodes()
        {
            //set nodes
            base.Nodes.Clear();

            //build Root node
            BaseNode Root = new BaseNode("All Tasks");
            base.Nodes.Add(Root);

            //build Task node
            Collection<TaskInfo> tasks = ConfigCtrl.GetTasks();
            foreach (TaskInfo task in tasks)
            {
                if (task != null)
                {
                    TaskNode tn = new TaskNode(task);
                    Root.Nodes.Add(tn);
                    /*
                    foreach (AccountInfo account in task.Accounts)
                    {
                        OperationInfo operation = ConfigCtrl.GetOperation(task.GroupName, account);
                        OperationNode on = new OperationNode(operation);
                        tn.Nodes.Add(on);
                    }*/
                    //set the started icon if the task is running
                    if (_executingTaskIdList.Contains(task.TaskId))
                    {
                        tn.ImageIndex = DataConvert.GetInt32(IconType.Started);
                        tn.SelectedImageIndex = DataConvert.GetInt32(IconType.Started);
                    }                    
                }
            }

            if (Root.Nodes.Count > 0)
            {
                Root.Expand();
            }            
        }
        #endregion

        #region RefreshTaskNode
        public void RefreshTaskNode(string taskid, string taskname)
        {
            foreach (TaskNode tasknode in base.Nodes[0].Nodes)
            {
                if (tasknode.Task.TaskId == taskid && tasknode.Task.TaskName == taskname)
                {
                    TaskEventArgs te = new TaskEventArgs();
                    //te.Operations = new Collection<OperationInfo>();
                    TaskInfo task = ConfigCtrl.GetTask(tasknode.Task.TaskId, tasknode.Task.TaskName);
                    if (task == null)
                    {
                        MessageBox.Show("Fail to load the task config file!", Constants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tasknode.Task = task;
                    te.Task = task;
                    tasknode.Nodes.Clear();
                    /*
                    foreach (AccountInfo account in task.Accounts)
                    {
                        OperationInfo op = ConfigCtrl.GetOperation(task.GroupName, account);
                        OperationNode on = new OperationNode(op);
                        tasknode.Nodes.Add(on);
                        te.Operations.Add(op);
                    }*/
                    OnTaskNodeSelected(te);

                    break;
                }
            }
        }
        #endregion        
  
        #region Override Tree Event

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    contextmenustrip.Items.Clear();

                    //onfocus when right click on the node
                    BaseNode bn = (BaseNode)this.GetNodeAt(e.X, e.Y);
                    if (bn == null)
                        return;
                    else
                        this.SelectedNode = bn;

                    switch (bn.nodeType)
                    {
                        //BaseNode
                        case NodeType.Base:
                            contextmenustrip.Items.Add("Add Task");
                            contextmenustrip.Items.Add("Refresh");
                            contextmenustrip.Items.Add(new ToolStripSeparator());
                            contextmenustrip.Items.Add("Start All");
                            contextmenustrip.Items.Add("Stop All");
                            contextmenustrip.Items[0].Image = imageListIcon.Images[DataConvert.GetInt32(IconType.AddTask)];
                            contextmenustrip.Items[0].Click += new EventHandler(OnAddTaskClick);
                            contextmenustrip.Items[1].Image = imageListIcon.Images[DataConvert.GetInt32(IconType.Refresh)];
                            contextmenustrip.Items[1].Click += new EventHandler(OnRefreshTasksClick);
                            contextmenustrip.Items[3].Image = imageListIcon.Images[DataConvert.GetInt32(IconType.Start)];
                            contextmenustrip.Items[3].Click += new EventHandler(OnStartAllTasksClick);
                            contextmenustrip.Items[4].Image = imageListIcon.Images[DataConvert.GetInt32(IconType.Stop)];
                            contextmenustrip.Items[4].Click += new EventHandler(OnStopAllTasksClick);
                            if (_executingTaskIdList != null && _executingTaskIdList.Count == bn.Nodes.Count)
                                contextmenustrip.Items[3].Enabled = false;
                            else
                                contextmenustrip.Items[3].Enabled = true;
                            if (_executingTaskIdList == null || _executingTaskIdList.Count == 0)
                                contextmenustrip.Items[4].Enabled = false;
                            else
                                contextmenustrip.Items[4].Enabled = true;                            
                            break;
                        //TaskNode
                        case NodeType.Task:
                            contextmenustrip.Items.Add("Edit Task");
                            contextmenustrip.Items.Add("Open Task Config File");
                            contextmenustrip.Items.Add(new ToolStripSeparator());
                            contextmenustrip.Items.Add("Refresh");
                            contextmenustrip.Items.Add("Rename");
                            contextmenustrip.Items.Add("Delete");
                            contextmenustrip.Items.Add(new ToolStripSeparator());
                            contextmenustrip.Items.Add("Start");
                            contextmenustrip.Items.Add("Stop");

                            contextmenustrip.Items[0].Image = imageListIcon.Images[DataConvert.GetInt32(IconType.AddTask)];
                            contextmenustrip.Items[0].Click += new EventHandler(OnOpenTaskEditorClick);
                            contextmenustrip.Items[1].Image = imageListIcon.Images[DataConvert.GetInt32(IconType.Xml)];
                            contextmenustrip.Items[1].Click += new EventHandler(OnOpenTaskConfigFileClick);
                            contextmenustrip.Items[3].Image = imageListIcon.Images[DataConvert.GetInt32(IconType.Refresh)];
                            contextmenustrip.Items[3].Click += new EventHandler(OnRefreshOperationsClick);                            
                            contextmenustrip.Items[4].Click += new EventHandler(OnRenameTaskClick);
                            contextmenustrip.Items[5].Image = imageListIcon.Images[DataConvert.GetInt32(IconType.Delete)];
                            contextmenustrip.Items[5].Click += new EventHandler(OnDeleteClick);
                            contextmenustrip.Items[7].Image = imageListIcon.Images[DataConvert.GetInt32(IconType.Start)];
                            contextmenustrip.Items[7].Click += new EventHandler(OnTaskStartClick);
                            contextmenustrip.Items[8].Image = imageListIcon.Images[DataConvert.GetInt32(IconType.Stop)];
                            contextmenustrip.Items[8].Click += new EventHandler(OnTaskStopClick);
                            TaskNode tn = bn as TaskNode;
                            if (_executingTaskIdList.Contains(tn.Task.TaskId))
                                contextmenustrip.Items[7].Enabled = false;                                
                            else
                                contextmenustrip.Items[8].Enabled = false;
                            break;
                        //OperationNode
                        /*case NodeType.Operation:
                            contextmenustrip.Items.Add("≈‰÷√");
                            contextmenustrip.Items[0].Image = imageListIcon.Images[DataConvert.GetInt32(IconType.Operation)];
                            contextmenustrip.Items[0].Click += new EventHandler(OnOpenUserClick);
                            break;*/
                        default:
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }

        private void TaskTree_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            try
            {
                if (e.Node is TaskNode)
                {
                    TaskNode tn = e.Node as TaskNode;
                    if (tn != null)
                    {
                        _task = tn.Task;
                    }
                }
                else
                {
                    e.CancelEdit = true;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }

        private void TaskTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            try
            {
                if (e.Label != null && e.Label.Trim() != string.Empty)
                {
                    _task.TaskName = e.Label;

                    ConfigCtrl.EditTask(_task);

                    TaskEventArgs ta = new TaskEventArgs();
                    ta.Task = _task;
                    OnTaskNameChanged(ta);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }

        private void OnDoubleClick(object sender, EventArgs e)
        {
            try
            {                
                TaskNode tn = this.SelectedNode as TaskNode;
                if (tn != null)
                {
                    TaskEventArgs te = new TaskEventArgs();
                    te.Task = tn.Task;
                    OnOpenTaskEditor(te);
                    return;
                }
                
                /*
                OperationNode on = this.SelectedNode as OperationNode;
                if (on != null)
                {
                    AccountEventArgs te = new AccountEventArgs();
                    tn = on.Parent as TaskNode;
                    te.Group = tn.Task.GroupName;
                    te.Account = on.Operation.Account;
                    OnOpenAccount(te);
                }*/
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }

        private void TaskTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node is TaskNode)
                {
                    TaskNode tn = e.Node as TaskNode;
                    TaskEventArgs te = new TaskEventArgs();
                    if (tn != null)
                    {
                        te.Task = ConfigCtrl.GetTask(tn.Task.TaskId, tn.Task.TaskName);

                        /*
                        te.Operations = new Collection<OperationInfo>();
                        foreach (AccountInfo account in te.Task.Accounts)
                        {
                            te.Operations.Add(ConfigCtrl.GetOperation(te.Task.GroupName, account));
                        }*/

                        //te.Task = tn.Task;
                        //te.Operations = new Collection<OperationInfo>();
                        //foreach (OperationNode on in tn.Nodes)
                        //{
                        //    te.Operations.Add(on.Operation);
                        //}
                    }
                    else
                        te.Task = null;
                    OnTaskNodeSelected(te);
                }
                else if (this.SelectedNode is TaskNode)
                {
                    TaskNode tn = this.SelectedNode as TaskNode;
                    TaskEventArgs te = new TaskEventArgs();
                    if (tn != null)
                    {
                        te.Task = tn.Task;
                        /*
                        te.Operations = new Collection<OperationInfo>();
                        foreach (OperationNode on in tn.Nodes)
                        {
                            te.Operations.Add(on.Operation);
                        }*/
                    }
                    else
                        te.Task = null;
                    OnTaskNodeSelected(te);
                }
                    /*
                else if (this.SelectedNode is OperationNode)
                {
                    OperationNode on = this.SelectedNode as OperationNode;
                    OperationEventArgs oe = new OperationEventArgs();
                    if (on != null)
                        oe.Operation = on.Operation;
                    else
                        oe.Operation = null;
                    OnOperationNodeSelected(oe);
                }*/
                else if (this.SelectedNode is BaseNode)
                {
                    BaseNode bn = this.SelectedNode as BaseNode;
                    if (bn != null)
                    {
                        RootNodeEventArgs re = new RootNodeEventArgs();
                        re.Tasks = new Collection<TaskInfo>();
                        foreach (TaskNode tasknode in bn.Nodes)
                        {
                            re.Tasks.Add(tasknode.Task);
                        }
                        OnRootNodeSelected(re);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }
        #endregion

        #region Custom Tree Event

        #region Root Node
        private void OnAddTaskClick(object sender, EventArgs e)
        {
            try
            {
                DlgAddTask adt = new DlgAddTask();
                if (adt.ShowDialog() == DialogResult.OK)
                {
                    BaseNode bn = (BaseNode)this.SelectedNode;
                    TaskNode tn = new TaskNode(adt.Task);
                    bn.Nodes.Add(tn);
                    if (bn.Parent != null && bn.Parent.Nodes.Count > 0)
                    {
                        bn.Parent.Expand();
                    }
                }

                if (this.SelectedNode is BaseNode)
                {
                    BaseNode bn = this.SelectedNode as BaseNode;
                    if (bn != null)
                    {
                        RootNodeEventArgs re = new RootNodeEventArgs();
                        re.Tasks = new Collection<TaskInfo>();
                        foreach (TaskNode tasknode in bn.Nodes)
                        {
                            re.Tasks.Add(tasknode.Task);
                        }
                        OnRootNodeSelected(re);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }           
        }

        private void OnRefreshTasksClick(object sender, EventArgs e)
        {
            try
            {
                this.BeforeCollapse -= new TreeViewCancelEventHandler(TaskTree_BeforeCollapse);
                this.BeforeExpand -= new TreeViewCancelEventHandler(TaskTree_BeforeExpand);
                InitialNodes();
                this.BeforeCollapse += new TreeViewCancelEventHandler(TaskTree_BeforeCollapse);
                this.BeforeExpand += new TreeViewCancelEventHandler(TaskTree_BeforeExpand);
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, "Fail to load config file!\r\nPlease try to delete all of the files in the below folder and create task again!\r\n" + Path.Combine(Application.StartupPath, "Tasks"), ex);
            }
        }

        private void OnStartAllTasksClick(object sender, EventArgs e)
        {
            try
            {
                BaseNode bn = this.SelectedNode as BaseNode;
                if (bn != null)
                {
                    foreach (TreeNode node in bn.Nodes)
                    {                        
                        TaskNode tn = node as TaskNode;
                        if (tn != null)
                        {
                            if (!_executingTaskIdList.Contains(tn.Task.TaskId))
                            {
                                //icon
                                tn.ImageIndex = DataConvert.GetInt32(IconType.Started);
                                tn.SelectedImageIndex = DataConvert.GetInt32(IconType.Started);                                

                                TaskEventArgs te = new TaskEventArgs();
                                te.Task = tn.Task;
                                OnStartTask(te);
                                _executingTaskIdList.Add(tn.Task.TaskId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }

        private void OnStopAllTasksClick(object sender, EventArgs e)
        {
            try
            {
                BaseNode bn = this.SelectedNode as BaseNode;
                if (bn != null)
                {
                    foreach (TreeNode node in bn.Nodes)
                    {                        
                        TaskNode tn = node as TaskNode;
                        if (tn != null)
                        {
                            if (_executingTaskIdList.Contains(tn.Task.TaskId))
                            {
                                //icon
                                tn.ImageIndex = DataConvert.GetInt32(IconType.Task);
                                tn.SelectedImageIndex = DataConvert.GetInt32(IconType.Task);                                

                                TaskEventArgs te = new TaskEventArgs();
                                te.Task = tn.Task;
                                OnStopTask(te);
                                _executingTaskIdList.Remove(tn.Task.TaskId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }
        #endregion

        #region Task Node
        private void OnOpenTaskEditorClick(object sender, EventArgs e)
        {
            try
            {                
                TaskNode tn = this.SelectedNode as TaskNode;
                if (tn != null)
                {
                    TaskEventArgs te = new TaskEventArgs();
                    te.Task = tn.Task;
                    OnOpenTaskEditor(te);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }

        private void OnOpenTaskConfigFileClick(object sender, EventArgs e)
        {
            try
            {                
                TaskNode tn = this.SelectedNode as TaskNode;
                if (tn != null)
                {
                    TaskEventArgs te = new TaskEventArgs();
                    te.Task = tn.Task;
                    OnOpenTaskConfigFile(te);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }

        private void OnRefreshOperationsClick(object sender, EventArgs e)
        {
            try
            {
                /*
                TaskNode tn = this.SelectedNode as TaskNode;
                if (tn != null)
                {
                    tn.Nodes.Clear();
                    TaskInfo task = ConfigCtrl.GetTask(tn.Task.TaskId, tn.Task.TaskName);
                    foreach (AccountInfo account in task.Accounts)
                    {
                        OperationInfo operation = ConfigCtrl.GetOperation(task.GroupName, account);
                        OperationNode an = new OperationNode(operation);
                        tn.Nodes.Add(an);
                    }
                }*/
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }

        private void OnRenameTaskClick(object sender, EventArgs e)
        {
            try
            {
                TaskNode tn = this.SelectedNode as TaskNode;
                if (tn != null)
                {
                    DlgAddTask adu = new DlgAddTask();
                    adu.Task = tn.Task;
                    if (adu.ShowDialog() == DialogResult.OK)
                    {
                        tn.Text = adu.Task.TaskName;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to delete?", Constants.MESSAGEBOX_CAPTION, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    TaskNode tn = this.SelectedNode as TaskNode;
                    TaskInfo task = null;
                    if (tn != null)
                        task = tn.Task;
                    if (task != null)
                    {
                        string ret = ConfigCtrl.DeleteTask(task);
                        if (ret != Constants.STATUS_SUCCESS)
                        {
                            MessageBox.Show(ret, Constants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        BaseNode bn = (BaseNode)tn.Parent;
                        bn.Nodes.Remove(tn);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }

        private void OnTaskStartClick(object sender, EventArgs e)
        {
            try
            {               
                TaskNode tn = this.SelectedNode as TaskNode;
                if (tn != null)
                {
                    //icon
                    tn.ImageIndex = DataConvert.GetInt32(IconType.Started);
                    tn.SelectedImageIndex = DataConvert.GetInt32(IconType.Started);                    

                    TaskEventArgs te = new TaskEventArgs();
                    te.Task = tn.Task;
                    OnStartTask(te);
                    _executingTaskIdList.Add(tn.Task.TaskId);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }

        private void OnTaskStopClick(object sender, EventArgs e)
        {
            try
            {                
                TaskNode tn = this.SelectedNode as TaskNode;
                if (tn != null)
                {
                    //icon
                    tn.ImageIndex = DataConvert.GetInt32(IconType.Task);
                    tn.SelectedImageIndex = DataConvert.GetInt32(IconType.Task);

                    TaskEventArgs te = new TaskEventArgs();
                    te.Task = tn.Task;
                    OnStopTask(te);
                    _executingTaskIdList.Remove(tn.Task.TaskId);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }
        #endregion

        #region Operation Node
        private void OnOpenUserClick(object sender, EventArgs e)
        {
            try
            {        /*        
                OperationNode on = this.SelectedNode as OperationNode;
                if (on != null)
                {
                    TaskNode tn = on.Parent as TaskNode;
                    if (tn != null)
                    {
                        AccountEventArgs te = new AccountEventArgs();
                        te.Group = tn.Task.GroupName;
                        te.Account = on.Operation.Account;
                        OnOpenAccount(te);
                    }
                }*/
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }
        #endregion

        public void SetStoppedIcon(string taskid, string taskname)
        {
            if (base.Nodes == null || base.Nodes.Count == 0)
                return;

            BaseNode bn = base.Nodes[0] as BaseNode;
            if (bn != null)
            {
                foreach (TreeNode item in bn.Nodes)
                {
                    TaskNode tn = item as TaskNode;
                    if (tn != null)
                    {
                        if (tn.Task.TaskId == taskid && tn.Task.TaskName == taskname)
                        {
                            //icon
                            tn.ImageIndex = DataConvert.GetInt32(IconType.Task);
                            tn.SelectedImageIndex = DataConvert.GetInt32(IconType.Task);
                            _executingTaskIdList.Remove(tn.Task.TaskId);
                            break;
                        }
                    }
                }
            }
        }
        #endregion

    }
}
