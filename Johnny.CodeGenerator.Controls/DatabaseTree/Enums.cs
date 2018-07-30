using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Controls.DatabaseTree
{
    [Flags]
    [Serializable]
    public enum NodeType
    {
        Base = 0,
        Server,
        Database,
        Tables,
        Table,        
        View,
        Column,
        Procedure,
        Hidden
    }

    public enum IconType
    {
        Servers = 0,
        Server,
        Database,
        Tables,
        Table,
        View,
        Column,
        Procedure
    } 
}
