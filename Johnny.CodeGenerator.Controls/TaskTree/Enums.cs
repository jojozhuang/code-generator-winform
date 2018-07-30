using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Controls.TaskTree
{
    [Flags]
    [Serializable]
    public enum NodeType
    {
        Base = 0,
        Task
    }

    public enum IconType
    {
        Tasks = 0,
        Task,
        AddTask,
        Refresh,
        Delete,
        Start,        
        Stop,
        Started,
        Paused,
        Table,
        Xml,
        Unknow
    } 
}
