using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Controls.TemplateTree
{
    [Flags]
    [Serializable]
    public enum NodeType
    {
        Base = 0, //Template Group
        Template,
        Module
    }

    public enum IconType
    {
        Templates = 0,
        Template,
        Module
    }
}
