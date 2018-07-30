using System;
using System.Drawing;
using System.Windows.Forms;

using Johnny.Library.Helper;
using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.Controls.VSTempTree
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
            this.ImageIndex = DataConvert.GetInt32(IconType.VsTemplates);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.VsTemplates);
		}
	}

    public class VsVersionNode : BaseNode
    {
        public VsTemplateInfo VsVersion;
        public VsVersionNode() { }
        public VsVersionNode(string nodename)
        {
            NodeType = NodeType.VsVersion;
            this.Text = nodename;
            this.ImageIndex = DataConvert.GetInt32(IconType.VsVersion);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.VsVersion);
        }
    }  

    public class SolutionNode : BaseNode
    {
        public SolutionInfo Solution;
        public SolutionNode() { }

        public SolutionNode(string nodename)
        {
            NodeType = NodeType.Solution;
            this.Text = nodename;
            this.ImageIndex = DataConvert.GetInt32(IconType.Solution);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Solution);
        }
    }

    public class ProjectNode : BaseNode
    {
        public ProjectInfo Project;
		public ProjectNode(){}

        public ProjectNode(string nodename)
        {
            NodeType = NodeType.Project;
            this.Text = nodename;
            this.ImageIndex = DataConvert.GetInt32(IconType.Project);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Project);
		}
	}

     
}
