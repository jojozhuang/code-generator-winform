using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Core
{
    public class DatabaseInfo
    {
        private string _connectionstring;
        private string _servername;
        private string _databasename;

        public DatabaseInfo()
        {
        }

        public DatabaseInfo(string connectionstring, string servername, string databasename)
        {
            _connectionstring = connectionstring;
            _servername = servername;
            _databasename = databasename;
        }

        public string ConnectionString
        {
            get { return _connectionstring; }
            set { _connectionstring = value; }
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

        public override string ToString()
        {
            if (DatabaseName == string.Empty)
                return base.ToString();
            else
                return DatabaseName;
        }
    }
}
