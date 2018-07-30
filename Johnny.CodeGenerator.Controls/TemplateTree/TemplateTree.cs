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

namespace Johnny.CodeGenerator.Controls.TemplateTree
{
    public class TemplateTree : TreeView
    {
        #region Variable

        private System.ComponentModel.IContainer components;
        private ImageList imageListIcon;
        private ContextMenuStrip contextmenustrip = new ContextMenuStrip();

        #endregion

        #region OpenXsltTemplateClick event
        //event        
        public delegate void OpenModuleTemplateEventHandler(object sender, ModuleNodeEventArgs e);
        public event OpenModuleTemplateEventHandler OpenModule;
        protected virtual void OnOpenXsltTemplate(ModuleNodeEventArgs e)
        {
            if (OpenModule != null)
                OpenModule(this, e);
        }
        #endregion

        #region Ctor
        public TemplateTree()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateTree));
            this.imageListIcon = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageListIcon
            // 
            this.imageListIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcon.ImageStream")));
            this.imageListIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcon.Images.SetKeyName(0, "templates.ico");
            this.imageListIcon.Images.SetKeyName(1, "template.ico");
            this.imageListIcon.Images.SetKeyName(2, "module.ico");
            this.imageListIcon.Images.SetKeyName(3, "add.ico");
            this.imageListIcon.Images.SetKeyName(4, "refresh.png");
            this.imageListIcon.Images.SetKeyName(5, "delete.ico");
            this.imageListIcon.Images.SetKeyName(6, "property.png");
            this.imageListIcon.Images.SetKeyName(7, "open.ico");
            // 
            // TemplateTree
            // 
            this.ImageIndex = 0;
            this.ImageList = this.imageListIcon;
            this.LineColor = System.Drawing.Color.Black;
            this.SelectedImageIndex = 0;
            this.ResumeLayout(false);

        }
        #endregion

        #region Initlize TemplateTree
        public void InitialNodes()
        {
            base.Nodes.Clear();           

            //build Root node
            BaseNode Root = new BaseNode("Templates");
            base.Nodes.Add(Root);

            //build Template node
            Collection<TemplateInfo> templates = ConfigCtrl.GetTemplates();
            if (templates != null)
            {
                foreach (TemplateInfo item in templates)
                {
                    TemplateNode tn = new TemplateNode(item.Name);
                    tn.Template = new TemplateInfo(item.FullPath, item.Name);
                    Root.Nodes.Add(tn);

                    RefreshTemplateNode(tn);              
                }
            }

            if (Root.Nodes.Count > 0)
            {
                Root.Expand();
            }
        }

        private void RefreshTemplateNode(TemplateNode tn)        
        {
            if (tn != null)
            {
                tn.Nodes.Clear();
                Collection<ModuleInfo> modules = ConfigCtrl.GetModules(tn.Template.FullPath);

                foreach (ModuleInfo module in modules)
                {
                    ModuleNode xn = new ModuleNode(module.ModuleName);
                    xn.Module = module;
                    tn.Nodes.Add(xn);
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
                        contextmenustrip.Items.Add("Add Template");
                        contextmenustrip.Items.Add("Refresh");
                        contextmenustrip.Items[0].Click += new EventHandler(OnAddTemplateClick);
                        contextmenustrip.Items[0].Image = imageListIcon.Images[3];
                        contextmenustrip.Items[1].Click += new EventHandler(OnRefreshTemplatesClick);
                        contextmenustrip.Items[1].Image = imageListIcon.Images[4];
                        break;
                    //TemplateNode
                    case NodeType.Template:
                        contextmenustrip.Items.Add("Add Module");
                        contextmenustrip.Items.Add("Refresh");
                        contextmenustrip.Items.Add("Delete");
                        contextmenustrip.Items.Add(new ToolStripSeparator());
                        contextmenustrip.Items.Add("Property");
                        contextmenustrip.Items[0].Click += new EventHandler(OnAddModuleClick);
                        contextmenustrip.Items[0].Image = imageListIcon.Images[3];
                        contextmenustrip.Items[1].Click += new EventHandler(OnRefreshTemplateClick);
                        contextmenustrip.Items[1].Image = imageListIcon.Images[4];
                        contextmenustrip.Items[2].Click += new EventHandler(OnDeleteTemplateClick);
                        contextmenustrip.Items[2].Image = imageListIcon.Images[5];
                        contextmenustrip.Items[4].Image = imageListIcon.Images[6];
                        break;
                    //Module Node
                    case NodeType.Module:
                        contextmenustrip.Items.Add("Open");
                        contextmenustrip.Items[0].Click += new EventHandler(OpenXsltTemplateClick);
                        contextmenustrip.Items[0].Image = imageListIcon.Images[7];
                        break;
                    default:
                        break;
                }
            }
        }
       
        #endregion

        #region Base node Event
        private void OnAddTemplateClick(object o, EventArgs e)
        {
            DlgAddTemplate at = new DlgAddTemplate();
            if (at.ShowDialog() == DialogResult.OK)
            {
                InitialNodes();
            }            
        }
        private void OnRefreshTemplatesClick(object o, EventArgs e)
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

        #region Template Node Event
        private void OnAddModuleClick(object o, EventArgs e)
        {
            try
            {
                TemplateNode tn = this.SelectedNode as TemplateNode;
                if (tn != null)
                {
                    DlgAddModule dlgam = new DlgAddModule();
                    dlgam.Template = tn.Template;
                    if (dlgam.ShowDialog() == DialogResult.OK)
                    {
                        RefreshTemplateNode(tn);
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnRefreshTemplateClick(object o, EventArgs e)
        {
            try
            {
                TemplateNode tn = this.SelectedNode as TemplateNode;
                RefreshTemplateNode(tn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteTemplateClick(object o, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    TemplateNode tn = this.SelectedNode as TemplateNode;
                    if (tn != null && tn.Template != null)
                    {
                        ConfigCtrl.DeleteTemplate(tn.Template);
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

        #region Xslt Node Event
        private void OpenXsltTemplateClick(object o, EventArgs e)
        {
            try
            {
                ModuleNode mn = this.SelectedNode as ModuleNode;
                if (mn != null && mn.Module != null)
                {
                    ModuleNodeEventArgs mne = new ModuleNodeEventArgs();
                    mne.Module = mn.Module;
                    OnOpenXsltTemplate(mne);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CGConstants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion               
        
    }
    public class ModuleNodeEventArgs : EventArgs
    {
        public ModuleInfo Module;
    }
}
