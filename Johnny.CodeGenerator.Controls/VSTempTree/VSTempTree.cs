using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;
using System.Collections.ObjectModel;

using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.Controls.VSTempTree
{

    public class VSTempTree : TreeView
    {
        #region Variable

        private System.ComponentModel.IContainer components;
        private ImageList imageListIcon;
        private ContextMenuStrip contextmenustrip = new ContextMenuStrip();

        #endregion

        #region OpenSolutionTemplateClick event
        //event        
        public delegate void OpenSolutionTemplateEventHandler(object sender, SolutionNodeEventArgs e);
        public event OpenSolutionTemplateEventHandler OpenSolutionTemplate;
        protected virtual void OnOpenSolutionTemplate(SolutionNodeEventArgs e)
        {
            if (OpenSolutionTemplate != null)
                OpenSolutionTemplate(this, e);
        }
        #endregion

        #region OpenProjectTemplateClick event
        //event        
        public delegate void OpenProjectTemplateEventHandler(object sender, ProjectNodeEventArgs e);
        public event OpenProjectTemplateEventHandler OpenProjectTemplate;
        protected virtual void OnOpenProjectTemplate(ProjectNodeEventArgs e)
        {
            if (OpenProjectTemplate != null)
                OpenProjectTemplate(this, e);
        }
        #endregion

        #region Ctor
        public VSTempTree()
        {
            this.InitializeComponent();
            this.ContextMenuStrip = contextmenustrip;
            this.MouseDown += new MouseEventHandler(OnMouseDown);
        }
        #endregion

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VSTempTree));
            this.imageListIcon = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageListIcon
            // 
            this.imageListIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcon.ImageStream")));
            this.imageListIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcon.Images.SetKeyName(0, "templates.ico");
            this.imageListIcon.Images.SetKeyName(1, "template.ico");
            this.imageListIcon.Images.SetKeyName(2, "solution.ico");
            this.imageListIcon.Images.SetKeyName(3, "project.ico");
            this.imageListIcon.Images.SetKeyName(4, "add.ico");
            this.imageListIcon.Images.SetKeyName(5, "refresh.png");
            this.imageListIcon.Images.SetKeyName(6, "delete.ico");
            this.imageListIcon.Images.SetKeyName(7, "property.png");
            this.imageListIcon.Images.SetKeyName(8, "open.ico");
            // 
            // VSTempTree
            // 
            this.ImageIndex = 0;
            this.ImageList = this.imageListIcon;
            this.LineColor = System.Drawing.Color.Black;
            this.SelectedImageIndex = 0;
            this.ResumeLayout(false);

        }
        #endregion

        #region Initlize VSTree
        public void InitialNodes()
        {
            base.Nodes.Clear();           

            //build Root node
            BaseNode Root = new BaseNode("VS Templates");
            base.Nodes.Add(Root);

            //build Servers node
            Collection<VsTemplateInfo> versions = ConfigCtrl.GetVsTemplates();
            if (versions != null)
            {
                foreach (VsTemplateInfo item in versions)
                {
                    VsVersionNode vvn = new VsVersionNode(item.Name);
                    vvn.VsVersion = new VsTemplateInfo(item.FullPath, item.Name);
                    Root.Nodes.Add(vvn);

                    RefreshVsVersionNode(vvn);              
                }
            }

            if (Root.Nodes.Count > 0)
            {
                Root.Expand();
            }
        }

        private void RefreshVsVersionNode(VsVersionNode vvn)        
        {
            if (vvn != null)
            {
                vvn.Nodes.Clear();

                //Solutions
                Collection<SolutionInfo> solutions = ConfigCtrl.GetSolutions(vvn.VsVersion.FullPath);

                foreach (SolutionInfo solution in solutions)
                {
                    SolutionNode sn = new SolutionNode(solution.SolutionName);
                    sn.Solution = solution;
                    vvn.Nodes.Add(sn);
                }

                //Projects
                Collection<ProjectInfo> projects = ConfigCtrl.GetProjects(vvn.VsVersion.FullPath);

                foreach (ProjectInfo project in projects)
                {
                    ProjectNode pn = new ProjectNode(project.ProjectName);
                    pn.Project = project;
                    vvn.Nodes.Add(pn);                    
                }
            }
        }
        #endregion        

        #region Override Event

        private void OnMouseDown(object o, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextmenustrip.Items.Clear();

                //onfocus when right click on the node
                BaseNode bn = (BaseNode)this.GetNodeAt(e.X, e.Y);
                if (bn == null)
                    return;
                else
                    this.SelectedNode = bn;

                switch (bn.NodeType)
                {
                    //BaseNode
                    case NodeType.Base:
                        contextmenustrip.Items.Add("Add VS Version");
                        contextmenustrip.Items.Add("Refresh");
                        contextmenustrip.Items[0].Click += new EventHandler(OnAddVsVersionClick);
                        contextmenustrip.Items[0].Image = imageListIcon.Images[4];
                        contextmenustrip.Items[1].Click += new EventHandler(OnRefreshVsVersionsClick);
                        contextmenustrip.Items[1].Image = imageListIcon.Images[5];
                        break;
                    //VS Version Node
                    case NodeType.VsVersion:
                        contextmenustrip.Items.Add("Add Solution");
                        contextmenustrip.Items.Add("Add Project");
                        contextmenustrip.Items.Add("Refresh");
                        contextmenustrip.Items.Add("Delete");
                        contextmenustrip.Items.Add(new ToolStripSeparator());
                        contextmenustrip.Items.Add("Property");
                        contextmenustrip.Items[0].Click += new EventHandler(OnAddSolutionClick);
                        contextmenustrip.Items[0].Image = imageListIcon.Images[2];
                        contextmenustrip.Items[1].Click += new EventHandler(OnAddProjectClick);
                        contextmenustrip.Items[1].Image = imageListIcon.Images[3];
                        contextmenustrip.Items[2].Click += new EventHandler(OnRefreshVsVersionClick);
                        contextmenustrip.Items[2].Image = imageListIcon.Images[5];
                        contextmenustrip.Items[3].Click += new EventHandler(OnDeleteVsVersionClick);
                        contextmenustrip.Items[3].Image = imageListIcon.Images[6];
                        contextmenustrip.Items[5].Image = imageListIcon.Images[7];
                        break;
                    //Solution Node
                    case NodeType.Solution:
                        contextmenustrip.Items.Add("Open");
                        contextmenustrip.Items.Add("Delete");
                        contextmenustrip.Items[0].Click += new EventHandler(OpenSolutionClick);
                        contextmenustrip.Items[0].Image = imageListIcon.Images[8];
                        contextmenustrip.Items[1].Click += new EventHandler(OnDeleteSolutionClick);
                        contextmenustrip.Items[1].Image = imageListIcon.Images[6];
                        break;
                    //Project Node
                    case NodeType.Project:
                        contextmenustrip.Items.Add("Open");
                        contextmenustrip.Items.Add("Delete");
                        contextmenustrip.Items[0].Click += new EventHandler(OpenProjectClick);
                        contextmenustrip.Items[0].Image = imageListIcon.Images[8];
                        contextmenustrip.Items[1].Click += new EventHandler(OnDeleteProjectClick);
                        contextmenustrip.Items[1].Image = imageListIcon.Images[6];
                        break;
                    default:
                        break;
                }
            }
        }
       
        #endregion

        #region Base node Event
        private void OnAddVsVersionClick(object o, EventArgs e)
        {
            DlgAddVsVersion at = new DlgAddVsVersion();
            if (at.ShowDialog() == DialogResult.OK)
            {
                InitialNodes();
            }            
        }
        private void OnRefreshVsVersionsClick(object o, EventArgs e)
        {
            try
            {
                InitialNodes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
        #endregion

        #region VsVersion Node Event
        private void OnAddSolutionClick(object o, EventArgs e)
        {
            try
            {
                VsVersionNode vvn = this.SelectedNode as VsVersionNode;
                if (vvn != null)
                {
                    DlgAddSolution das = new DlgAddSolution();
                    das.VsVersion = vvn.VsVersion;
                    if (das.ShowDialog() == DialogResult.OK)
                    {
                        RefreshVsVersionNode(vvn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnAddProjectClick(object o, EventArgs e)
        {
            try
            {
                VsVersionNode vvn = this.SelectedNode as VsVersionNode;
                if (vvn != null)
                {
                    DlgAddProject ap = new DlgAddProject();
                    ap.VsVersion = vvn.VsVersion;
                    if (ap.ShowDialog() == DialogResult.OK)
                    {
                        RefreshVsVersionNode(vvn);
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnRefreshVsVersionClick(object o, EventArgs e)
        {
            try
            {
                VsVersionNode vvn = this.SelectedNode as VsVersionNode;
                RefreshVsVersionNode(vvn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnDeleteVsVersionClick(object o, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    VsVersionNode vvn = this.SelectedNode as VsVersionNode;
                    if (vvn != null && vvn.VsVersion != null)
                    {
                        ConfigCtrl.DeleteVsTemplate(vvn.VsVersion);
                        InitialNodes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Solution Node Event
        private void OpenSolutionClick(object o, EventArgs e)
        {
            try
            {
                SolutionNode sn = this.SelectedNode as SolutionNode;
                if (sn != null && sn.Solution != null)
                {
                    SolutionNodeEventArgs sne = new SolutionNodeEventArgs();
                    sne.Solution = sn.Solution;
                    OnOpenSolutionTemplate(sne);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnDeleteSolutionClick(object o, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    SolutionNode sn = this.SelectedNode as SolutionNode;
                    if (sn != null && sn.Solution != null)
                    {
                        ConfigCtrl.DeleteSolution(sn.Solution);
                        VsVersionNode vvn = sn.Parent as VsVersionNode;
                        RefreshVsVersionNode(vvn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion 

        #region Project Node Event
        private void OpenProjectClick(object o, EventArgs e)
        {
            try
            {
                ProjectNode pn = this.SelectedNode as ProjectNode;
                if (pn != null && pn.Project != null)
                {
                    ProjectNodeEventArgs pne = new ProjectNodeEventArgs();
                    pne.Project = pn.Project;
                    OnOpenProjectTemplate(pne);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnDeleteProjectClick(object o, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    ProjectNode pn = this.SelectedNode as ProjectNode;
                    if (pn != null && pn.Project != null)
                    {
                        ConfigCtrl.DeleteProject(pn.Project);
                        VsVersionNode vvn = pn.Parent as VsVersionNode;
                        RefreshVsVersionNode(vvn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion        
                        
    }

    public class SolutionNodeEventArgs : EventArgs
    {
        public SolutionInfo Solution;
    }
    public class ProjectNodeEventArgs : EventArgs
    {
        public ProjectInfo Project;
    }

}
