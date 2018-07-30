using System;
using System.Drawing;
using System.Windows.Forms;

using Johnny.Library.Helper;
using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.Controls.TaskTree
{
	/// <summary>
	/// Summary description for Nodes.
	/// </summary>
	public class BaseNode : TreeNode {        
        public NodeType nodeType;
		public BaseNode(){}

        public BaseNode(string Text)
        {
            nodeType = NodeType.Base;
			this.Text = Text;
            this.ImageIndex = DataConvert.GetInt32(IconType.Tasks);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Tasks);
		}
	}

    public class TaskNode : BaseNode
    {
        public TaskInfo Task;

        public TaskNode() { }

        public TaskNode(TaskInfo tsk)
        {
            nodeType = NodeType.Task;
            Task = tsk;
            this.Text = tsk.TaskName;
            this.ImageIndex = DataConvert.GetInt32(IconType.Task);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Task);
        }
    }

    /*
    public class OperationNode : BaseNode
    {
        public OperationInfo Operation;

        public OperationNode() { }

        public OperationNode(OperationInfo op)
        {
            nodeType = NodeType.Operation;
            Operation = op;
            this.Text = op.Account.UserName;
            this.ImageIndex = DataConvert.GetInt32(IconType.User);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.User);
        }
    }  */
}
