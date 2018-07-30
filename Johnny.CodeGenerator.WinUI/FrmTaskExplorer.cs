using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

using Johnny.CodeGenerator.Controls.TaskTree;

using Johnny.CodeGenerator.Core;
using System.Threading;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class FrmTaskExplorer : DockContent
    {
        private Dictionary<string, Thread> _threadList;
        private Dictionary<string, TaskManager> _taskManagerList;

        public delegate void MessageChangedEventHandler(string caption, string key, string message);
        public event MessageChangedEventHandler MessageChanged;

        public delegate void TaskStoppedEventHandler(string taskid, string taskname);
        public event TaskStoppedEventHandler TaskStopped;

        public FrmTaskExplorer()
        {
            InitializeComponent();
            _threadList = new Dictionary<string, Thread>();
            _taskManagerList = new Dictionary<string, TaskManager>();
        }

        protected override void OnRightToLeftLayoutChanged(EventArgs e)
        {
            taskTree.RightToLeftLayout = RightToLeftLayout;
        }

        private void FrmTaskManager_Load(object sender, EventArgs e)
        {
            try
            {
                taskTree.OpenTaskEditorEvent += new Johnny.CodeGenerator.Controls.TaskTree.TaskTree.OpenTaskEditorEventHandler(taskTree_OpenTaskEditorEvent);
                taskTree.OpenTaskConfigFileEvent += new TaskTree.OpenTaskConfigFileEventHandler(taskTree_OpenTaskConfigFileEvent);
                taskTree.StartTaskEvent += new Johnny.CodeGenerator.Controls.TaskTree.TaskTree.StartTaskEventHandler(taskTree_StartTaskEvent);
                taskTree.StopTaskEvent += new Johnny.CodeGenerator.Controls.TaskTree.TaskTree.StopTaskEventHandler(taskTree_StopTaskEvent);
                taskTree.TaskNodeSelectedEvent += new Johnny.CodeGenerator.Controls.TaskTree.TaskTree.TaskNodeSelectedEventHandler(taskTree_TaskNodeSelectedEvent);
                taskTree.RootNodeSelectedEvent += new Johnny.CodeGenerator.Controls.TaskTree.TaskTree.RootNodeSelectedEventHandler(taskTree_RootNodeSelectedEvent);
                //taskTree.OperationNodeSelectedEvent += new Johnny.Kaixin.Controls.TaskTree.TaskTree.OperationNodeSelectedEventHandler(taskTree_OperationNodeSelectedEvent);
                taskTree.TaskNameChangedEvent += new Johnny.CodeGenerator.Controls.TaskTree.TaskTree.TaskNameChangedEventHandler(taskTree_TaskNameChangedEvent);
                //taskTree.OpenAccountEvent += new Johnny.CodeGenerator.Controls.TaskTree.TaskTree.OpenAccountEventHandler(taskTree_OpenUserEvent);
                taskTree.InitialNodes();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskManager", "读取任务配置文件失败！\r\n请尝试删除以下目录中的所有文件，重新配置任务！\r\n" + Path.Combine(Application.StartupPath, "Tasks"), ex);
            }
        }

        void taskTree_OpenTaskConfigFileEvent(object sender, TaskEventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.OpenTaskConfigFile(e.Task);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskManager", ex);
            }
        }
        
        public void RefreshTaskNode(string taskid, string taskname)
        {
            taskTree.RefreshTaskNode(taskid, taskname);
        }

        /*
        private void taskTree_OperationNodeSelectedEvent(object sender, Johnny.CodeGenerator.Controls.TaskTree.OperationEventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.OperationNodeSelected(e.Operation);

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskManager", ex);
            }
        }*/

        private void taskTree_RootNodeSelectedEvent(object sender, Johnny.CodeGenerator.Controls.TaskTree.RootNodeEventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.RootNodeSelected(e.Tasks);

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskManager", ex);
            }
        }

        private void taskTree_TaskNodeSelectedEvent(object sender, Johnny.CodeGenerator.Controls.TaskTree.TaskEventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.TaskNodeSelected(e.Task);

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskManager", ex);
            }
        }

        private void taskTree_StopTaskEvent(object sender, Johnny.CodeGenerator.Controls.TaskTree.TaskEventArgs e)
        {
            try
            {
                if (TaskStopped != null)
                    TaskStopped(e.Task.TaskId, e.Task.TaskName);
                Thread currentThread;
                if (_threadList.TryGetValue(e.Task.TaskId, out currentThread))
                {
                    _taskManagerList.Remove(e.Task.TaskId);
                    currentThread.Abort();
                    currentThread.Interrupt();
                }              

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskManager", ex);
            }
        }

        private void taskTree_StartTaskEvent(object sender, Johnny.CodeGenerator.Controls.TaskTree.TaskEventArgs e)
        {
            try
            {
                string taskid = e.Task.TaskId;
                string taskname = e.Task.TaskName;

                Thread startThread;
                //if the thread is existing.
                if (_threadList.TryGetValue(taskid, out startThread))
                {
                    _threadList.Remove(taskid);
                }
                TaskManager task;
                if (_taskManagerList.TryGetValue(taskid, out task))
                {
                    _taskManagerList.Remove(taskid);
                }

                startThread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                {
                    task = new TaskManager(taskid, taskname);
                    task.MessageChanged += delegate(string caption, string key, string message)
                    {
                        if (MessageChanged != null)
                            MessageChanged(caption, key, message);
                    };
                    task.ExecutionFinished += delegate(string stoppedtaskid, string stoppedtaskname)
                    {
                        taskTree.SetStoppedIcon(stoppedtaskid, stoppedtaskname);
                    };
                    _taskManagerList.Add(taskid, task);
                    task.TaskStart();
                }));

                startThread.IsBackground = true;
                startThread.Start();
                _threadList.Add(taskid, startThread);

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskManager", ex);
            }
        }

        private void taskTree_OpenTaskEditorEvent(object sender, Johnny.CodeGenerator.Controls.TaskTree.TaskEventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.ShowTaskEditor(e.Task);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskManager", ex);
            }
        }

        private void taskTree_TaskNameChangedEvent(object sender, Johnny.CodeGenerator.Controls.TaskTree.TaskEventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.ChangeTaskEditTabName(e.Task);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskManager", ex);
            }
        }

        /*
        private void taskTree_OpenUserEvent(object sender, Johnny.CodeGenerator.Controls.TaskTree.AccountEventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                //if (mainform != null)
                //    mainform.ShowUserDetail(e.Group, e.Account);

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTaskManager", ex);
            }
        }
         */
    }
}