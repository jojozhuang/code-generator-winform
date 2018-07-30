using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Johnny.CodeGenerator.Core
{
    public class TableInfo
    {
        private string _servername;
        private string _databasename;
        private string _tablename;
        private string _alias;
        private string _schema;
        private string _fullname;
        private Collection<ColumnInfo> _columns;

        public TableInfo()
        {
            _columns = new Collection<ColumnInfo>();
        }

        public TableInfo(string tablename, string schema)
        {
            _columns = new Collection<ColumnInfo>();
            _tablename = tablename;
            _schema = schema;
        }
        public TableInfo(string servername, string databasename, string tablename)
        {
            _columns = new Collection<ColumnInfo>();
            _servername = servername;
            _databasename = databasename;
            _tablename = tablename;
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

        public string TableName
        {
            get { return _tablename; }
            set { _tablename = value; }
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
                    return Schema + "." + TableName;
                }
                else
                {
                    return TableName;
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
            if (TableName == string.Empty)
                return base.ToString();
            else
                return TableName;
        }
        
    }
}
