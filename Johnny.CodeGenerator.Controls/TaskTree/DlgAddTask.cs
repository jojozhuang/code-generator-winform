using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.Controls.TaskTree
{
    public partial class DlgAddTask : Form
    {
        private TaskInfo _task;

        public DlgAddTask()
        {
            InitializeComponent();
        }

        #region DlgAddTask_Load
        private void DlgAddTask_Load(object sender, EventArgs e)
        {
            try
            {
                if (_task != null && _task.TaskId != string.Empty)
                {
                    txtTaskName.Text = _task.TaskName;
                    this.Text = "Change Task Name";
                }
                else
                {
                    _task = new TaskInfo();
                    this.Text = "Add New Task";
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
        }
        #endregion

        #region btnOk_Click
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaskName.Text == string.Empty)
                {
                    txtTaskName.Select();
                    MessageBox.Show("Task Name cann't be empty£¡", Constants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                _task.TaskName = txtTaskName.Text;

                string ret = ConfigCtrl.EditTask(_task);
                if (ret != Constants.STATUS_SUCCESS)
                {
                    MessageBox.Show(ret, Constants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                ErrorHandler.ShowMessageBox(CGConstants.MODULE_TASKTREE, ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Properties

        public TaskInfo Task
        {
            get { return _task; }
            set { _task = value; }
        }

        #endregion
        
    }
}