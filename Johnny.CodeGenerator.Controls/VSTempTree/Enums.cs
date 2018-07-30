using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Controls.VSTempTree
{
    [Flags]
    [Serializable]
    public enum NodeType
    {
        Base = 0, //VS Templates
        VsVersion,
        Solution,
        Project
    }

    public enum IconType
    {
        VsTemplates = 0,
        VsVersion,
        Solution,
        Project
    }
}
