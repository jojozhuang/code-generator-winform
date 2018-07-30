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

namespace Johnny.CodeGenerator.Controls.DatabaseTree
{
    public class DatabaseTree : TreeView
    {
        #region Variable

        private bool DoubleClicked = false;
        public ArrayList arrDbServers = new ArrayList();
        private ImageList imageListIcon;
        private System.ComponentModel.IContainer components;
        private ContextMenuStrip contextmenustrip = new ContextMenuStrip();

        #endregion
                
        #region OnTableNodeClick event
        //event        
        public delegate void TableNodeClickEventHandler(object sender, TableNodeClickEventArgs e);
        public event TableNodeClickEventHandler TableNodeClick;
        protected virtual void OnTableNodeClick(TableNodeClickEventArgs e)
        {
            if (TableNodeClick != null)
                TableNodeClick(this, e);
        }
        #endregion

        #region Ctor
        public DatabaseTree()
        {
            this.InitializeComponent();
            this.ContextMenuStrip = contextmenustrip;
            this.BeforeExpand += new TreeViewCancelEventHandler(OnBeforeExpand);
            this.MouseDown += new MouseEventHandler(OnMouseDown);
        }
        #endregion

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseTree));
            this.imageListIcon = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageListIcon
            // 
            this.imageListIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcon.ImageStream")));
            this.imageListIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIcon.Images.SetKeyName(0, "servers.ico");
            this.imageListIcon.Images.SetKeyName(1, "sever.ico");
            this.imageListIcon.Images.SetKeyName(2, "db.ico");
            this.imageListIcon.Images.SetKeyName(3, "tables.ico");
            this.imageListIcon.Images.SetKeyName(4, "table.ico");
            this.imageListIcon.Images.SetKeyName(5, "view.ico");
            this.imageListIcon.Images.SetKeyName(6, "column.ico");
            this.imageListIcon.Images.SetKeyName(7, "procedure.ico");
            this.imageListIcon.Images.SetKeyName(8, "open.ico");
            this.imageListIcon.Images.SetKeyName(9, "refresh.png");
            this.imageListIcon.Images.SetKeyName(10, "delete.ico");
            this.imageListIcon.Images.SetKeyName(11, "property.png");
            this.imageListIcon.Images.SetKeyName(12, "generator.ico");
            // 
            // DatabaseTree
            // 
            this.ImageIndex = 0;
            this.ImageList = this.imageListIcon;
            this.LineColor = System.Drawing.Color.Black;
            this.SelectedImageIndex = 0;
            this.ResumeLayout(false);

        }
        #endregion

        #region Initlize DatabaseTree
        public void InitialNodes()
        {
            //set nodes
            base.Nodes.Clear();           

            //build Root node
            BaseNode Root = new BaseNode("Servers");
            base.Nodes.Add(Root);

            //build Servers node
            Collection<ServerInfo> servers = ConfigCtrl.GetServers();
            if (servers != null)
            {
                foreach (ServerInfo server in servers)
                {
                    ServerNode sn = new ServerNode(server);
                    Root.Nodes.Add(sn);
                }
            }

            if (Root.Nodes.Count > 0)
            {
                Root.Expand();
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
                        contextmenustrip.Items.Add("Add Server");
                        contextmenustrip.Items.Add("Refresh");
                        contextmenustrip.Items[0].Click += new EventHandler(OnAddServerClick);
                        contextmenustrip.Items[0].Image = imageListIcon.Images[1];
                        contextmenustrip.Items[1].Click += new EventHandler(OnRefreshServersClick);
                        contextmenustrip.Items[1].Image = imageListIcon.Images[9];
                        break;
                    //ServerNode
                    case NodeType.Server:
                        contextmenustrip.Items.Add("Connect");
                        contextmenustrip.Items.Add("Disconnect");
                        contextmenustrip.Items.Add("Refresh");
                        contextmenustrip.Items.Add("Delete");

                        contextmenustrip.Items[0].Click += new EventHandler(OnConnectClick);
                        contextmenustrip.Items[1].Click += new EventHandler(OnDisconnectClick);
                        contextmenustrip.Items[2].Click += new EventHandler(OnRefreshClick);
                        contextmenustrip.Items[2].Image = imageListIcon.Images[9];
                        contextmenustrip.Items[3].Click += new EventHandler(OnDeleteClick);
                        contextmenustrip.Items[3].Image = imageListIcon.Images[10];
                        break;
                    //DatabaseNode
                    /*case NodeType.Database:
                        contextmenustrip.Items.Add("Open Generator");
                        contextmenustrip.Items[0].Click += new EventHandler(OnOpenGenerator_Click);
                        contextmenustrip.Items[0].Image = imageListIcon.Images[12];
                        break;*/
                    //Tables
                    /*case NodeType.Tables:
                        contextmenustrip.Items.Add("Open CodeGenerator");
                        contextmenustrip.Items.Add("GenerateTextXml");
                        contextmenustrip.Items[0].Click += new EventHandler(OpenCodeGeneratorClick);
                        contextmenustrip.Items[1].Click += new EventHandler(GenerateTextXmlClick);*/
                        break;
                    //TableNode
                    case NodeType.Table:
                        contextmenustrip.Items.Add("Open Single CodeGenerator");
                        contextmenustrip.Items.Add("Generate Entity");
                        contextmenustrip.Items.Add("Generate Text");
                        contextmenustrip.Items[0].Click += new EventHandler(OpenCodeGeneratorClick);
                        contextmenustrip.Items[0].Image = imageListIcon.Images[12];
                        contextmenustrip.Items[1].Click += new EventHandler(GenerateEntityXmlClick);
                        contextmenustrip.Items[1].Image = imageListIcon.Images[8];
                        contextmenustrip.Items[2].Click += new EventHandler(GenerateTextXmlClick);
                        contextmenustrip.Items[2].Image = imageListIcon.Images[8];
                        break;
                    default:
                        break;

                }
            }
        }
        
        private void OnRefreshServersClick(object o, EventArgs e)
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

        private void OnBeforeExpand(object o, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            if (DoubleClicked)
            {
                e.Cancel = true;
                DoubleClicked = false;
                e.Node.Collapse();
            }
            else
            {
                DatabaseNode dbn = e.Node as DatabaseNode;
                if (dbn != null)
                {
                    if (dbn.Nodes.Count == 1)
                    { 
                        HiddenNode hn = dbn.Nodes[0] as HiddenNode;
                        if (hn != null)
                        {
                            dbn.Nodes.Clear();

                            // build tables
                            TablesNode TableRoot = new TablesNode("Tables");

                            Collection<TableInfo> tables = DatabaseCtrl.GetTables(dbn.DbInfo);

                            foreach (TableInfo tbl in tables)
                            {
                                TableNode tNode = new TableNode(tbl);
                                foreach (ColumnInfo column in tbl.Columns)
                                {
                                    ColumnNode cNode = new ColumnNode(column.ColumnName);
                                    tNode.Nodes.Add(cNode);
                                }
                                TableRoot.Nodes.Add(tNode);
                            }

                            dbn.Nodes.Add(TableRoot);

                            // build views
                            TableRoot = new TablesNode("Views");

                            Collection<ViewInfo> views = DatabaseCtrl.GetViews(dbn.DbInfo);

                            foreach (ViewInfo view in views)
                            {
                                ViewNode vNode = new ViewNode(view.ViewName);
                                foreach (ColumnInfo column in view.Columns)
                                {
                                    ColumnNode cNode = new ColumnNode(column.ColumnName);
                                    vNode.Nodes.Add(cNode);
                                }
                                TableRoot.Nodes.Add(vNode);
                            }

                            dbn.Nodes.Add(TableRoot);
                        }
                    }
                }                
            }
        }

        #endregion

        #region Servers Node Event
        private void OnAddServerClick(object o, EventArgs e)
        {
            DlgAddSqlServer ass = new DlgAddSqlServer();
            if (ass.ShowDialog() == DialogResult.OK)
            {
                BaseNode bn = (BaseNode)this.SelectedNode;
                ServerNode sn = new ServerNode(ass.NewSqlServer);
                bn.Nodes.Add(sn);
            }
        }
        #endregion

        #region Server Node Event
        private void OnConnectClick(object o, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            ServerNode sn = (ServerNode)this.SelectedNode;
            sn.Nodes.Clear();

            Collection<DatabaseInfo> dbs = DatabaseCtrl.GetDataBases(sn.Server);

            foreach (DatabaseInfo database in dbs)
            {
                DatabaseNode dbn = new DatabaseNode(database);
                dbn.Nodes.Add(new HiddenNode("temp"));
                sn.Nodes.Add(dbn);
            }

            this.Cursor = Cursors.Default;
        }

        private void OnDisconnectClick(object o, EventArgs e)
        {
            ServerNode sn = (ServerNode)this.SelectedNode;
            sn.Nodes.Clear();
        }
        private void OnRefreshClick(object o, EventArgs e)
        {
            OnConnectClick(o, e);
        }
        private void OnDeleteClick(object o, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button2)== DialogResult.OK)
            {
                ServerNode sn = (ServerNode)this.SelectedNode;
                ServerInfo dbServer = new ServerInfo();
                dbServer = sn.Server;
                if (dbServer != null)
                {
                    string ret = ConfigCtrl.DeleteServer(dbServer);
                    if (ret != CGConstants.STATUS_SUCCESS)
                    {
                        MessageBox.Show(ret, CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    BaseNode bn = (BaseNode)sn.Parent;
                    bn.Nodes.Remove(sn);
                }
            }
        }
        #endregion

        #region Table Event
        private void OpenCodeGeneratorClick(object o, EventArgs e)
        {
            TableNodeClickEventArgs te = new TableNodeClickEventArgs();
            TableNode tn = (TableNode)this.SelectedNode;
            DatabaseNode dn = (DatabaseNode)tn.Parent.Parent;
            ServerNode sn= (ServerNode)tn.Parent.Parent.Parent;
            te.ConnectionString = sn.Server.ConnectionString + "Database=" + dn.Text + ";";
            te.Server = sn.Server.ServerName;
            te.Database = dn.Text;
            te.Table = tn.Text;
            OnTableNodeClick(te);
        }

        private void GenerateEntityXmlClick(object o, EventArgs e)
        {            
            TableNode tn = (TableNode)this.SelectedNode;

            if (tn == null)
                return;
            CodeGeneratorSettingsInfo folder = ConfigCtrl.GetCodeGeneratorSettings();
            Generator.GenerateEntityXmlFromTable(tn.Table, folder.EntityFullPath, "Johnny.CMS", "Access");
           
        }

        private void GenerateTextXmlClick(object o, EventArgs e)
        {
            TableNode tn = (TableNode)this.SelectedNode;

            if (tn == null)
                return;
            CodeGeneratorSettingsInfo folder = ConfigCtrl.GetCodeGeneratorSettings();
            Generator.GenerateTextXmlFromTable(tn.Table, @"D:\WorkSpace\Projects_GitHub\CodeGenerator\Dev\Src\CodeGenerator\");

        }

        #endregion        
    }

    public class TableNodeClickEventArgs : EventArgs
    {
        public string ConnectionString;
        public string Server;
        public string Database;
        public string Table;
    }

    public class DatabaseNodeClickEventArgs : EventArgs
    {
        public DatabaseInfo DbInfo;
    }
}
