using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Johnny.CodeGenerator.Core
{
    public class ViewInfo
    {
        private string _servername;
        private string _databasename;
        private string _viewname;
        private string _alias;
        private string _schema;
        private Collection<ColumnInfo> _columns;

        public ViewInfo()
        {
            _columns = new Collection<ColumnInfo>();
        }

        public ViewInfo(string viewname, string schema)
        {
            _columns = new Collection<ColumnInfo>();
            _viewname = viewname;
            _schema = schema;
        }

        public ViewInfo(string servername, string databasename, string viewname)
        {
            _columns = new Collection<ColumnInfo>();
            _servername = servername;
            _databasename = databasename;
            _viewname = viewname;
        }

        public string ServerName
        {
            get { return _servername; }
            set { _servername = value; }
        }        

        public string DatabaseName
        {
            get { return _databasename; }
            set { _databasename = value; }
        }

        public string ViewName
        {
            get { return _viewname; }
            set { _viewname = value; }
        }

        public string Alias
        {
            get { return _alias; }
            set { _alias = value; }
        }

        public string Schema
        {
            get { return _schema; }
            set { _schema = value; }
        }

        public string FullName
        {
            get
            {
                if (Schema != "")
                {
                    return Schema + "." + ViewName;
                }
                else
                {
                    return ViewName;
                }
            }
        }

        public Collection<ColumnInfo> Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }


        public override string ToString()
        {
            if (ViewName == string.Empty)
                return base.ToString();
            else
                return ViewName;
        }
        
    }
}
