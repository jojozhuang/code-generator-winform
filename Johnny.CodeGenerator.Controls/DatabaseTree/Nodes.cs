using System;
using System.Drawing;
using System.Windows.Forms;

using Johnny.Library.Helper;
using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.Controls.DatabaseTree
{
	/// <summary>
	/// Summary description for Nodes.
	/// </summary>
	public class BaseNode : TreeNode {        
        public NodeType NodeType;
		public BaseNode(){}

        public BaseNode(string Text)
        {
            NodeType = NodeType.Base;
			this.Text = Text;
            this.ImageIndex = DataConvert.GetInt32(IconType.Servers);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Servers);
		}
	}

    public class ServerNode : BaseNode
    {
        public ServerNode() { }
        public ServerInfo Server;
        public bool IsConnected;

        public ServerNode(ServerInfo dbs)
        {
            NodeType = NodeType.Server;
            Server = dbs;
            this.IsConnected = false;
            this.Text = dbs.ToString();
            this.ImageIndex = DataConvert.GetInt32(IconType.Server);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Server);
        }
    }

    public class DatabaseNode : BaseNode
    {        
		public DatabaseNode(){}
        public DatabaseInfo DbInfo;
        public DatabaseNode(DatabaseInfo db)
        {
            NodeType = NodeType.Database;
            DbInfo = db;
			this.Text = db.DatabaseName;
            this.ImageIndex = DataConvert.GetInt32(IconType.Database);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Database);
		}
	}

    public class TablesNode : BaseNode
    {
		public TablesNode(){}       
        public TablesNode(string Text)
        {
            NodeType = NodeType.Tables;
			this.Text = Text;            
            this.ImageIndex = DataConvert.GetInt32(IconType.Tables);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Tables);
		}
	}

    public class TableNode : BaseNode
    {
        public TableInfo Table;
        public TableNode(TableInfo table)
        {
            NodeType = NodeType.Table;
            this.Text = table.TableName;
            this.Table = table;
            this.ImageIndex = DataConvert.GetInt32(IconType.Table);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Table);
        }
	}
    
    public class ViewNode : BaseNode
    {
        public ViewNode(string Text)
        {
            NodeType = NodeType.View;
            this.Text = Text;
            this.ImageIndex = DataConvert.GetInt32(IconType.View);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.View);
        }
    }

    public class ColumnNode : BaseNode
    {
		public ColumnNode(string Text) {
            NodeType = NodeType.Column;
			this.Text = Text;
            this.ImageIndex = DataConvert.GetInt32(IconType.Column);
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Column);
		}
	}

    public class ProcedureNode : BaseNode
    {
		public ProcedureNode(string Text) {
            NodeType = NodeType.Procedure;
			this.Text = Text;
            this.SelectedImageIndex = DataConvert.GetInt32(IconType.Procedure);
            this.ImageIndex = DataConvert.GetInt32(IconType.Procedure);
		}
	}

    public class HiddenNode : BaseNode
    {
        public HiddenNode(string Text)
        {
            NodeType = NodeType.Hidden;
            this.Text = Text;
        }
    }
}
