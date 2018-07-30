using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.Controls.TaskTree
{
    public class TaskEventArgs : EventArgs
    {
        public TaskInfo Task;
        //public Collection<OperationInfo> Operations;
    }

    //public class OperationEventArgs : EventArgs
    //{
    //    public OperationInfo Operation;
    //}

    public class RootNodeEventArgs : EventArgs
    {
        public Collection<TaskInfo> Tasks;
    }

    /*
    public class AccountEventArgs : EventArgs
    {
        public string Group;
        public Table Account;
    }*/
}
