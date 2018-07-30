using System;
using System.Drawing;
using System.Windows.Forms;

using Johnny.Library.Helper;
using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.Controls.TemplateTree
{
	/// <summary>
	/// Summary description for Nodes.
	/// </summary>
	public class BaseNode : TreeNode {        
        public NodeType NodeType;
		public BaseNode(){}

        public BaseNode(string nodename)
        {
            NodeType = NodeType.Base;
            this.Text = nodename;
            this.ImageIndex = DataConvert.GetInt32(IconType.Templates);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Templates);
		}
	}

    public class TemplateNode : BaseNode
    {
        public TemplateInfo Template;
        public TemplateNode() { }

        public TemplateNode(string nodename)
        {
            NodeType = NodeType.Template;
            this.Text = nodename;
            this.ImageIndex = DataConvert.GetInt32(IconType.Template);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Template);
        }
    }       

    public class ModuleNode : BaseNode
    {
        public ModuleInfo Module;
		public ModuleNode(){}
        public ModuleNode(string nodename)
        {
            NodeType = NodeType.Module;
            this.Text = nodename;
            this.ImageIndex = DataConvert.GetInt32(IconType.Module);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Module);
		}
	}   
}
