using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Core
{
    public class ServerInfo
    {
        private string _databasetype;
        private string _servername;
        private string _connectionstring;
        private string _databasename;

        public ServerInfo()
        {
        }

        public ServerInfo(string databasetype, string servername, string connectionstring, string databasename)
        {
            _databasetype = databasetype;
            _servername = servername;
            _connectionstring = connectionstring;
            _databasename = databasename;
        }

        public string DatabaseType
        {
            get { return _databasetype; }
            set { _databasetype = value; }
        }

        public string ServerName
        {
            get { return _servername; }
            set { _servername = value; }
        }

        public string ConnectionString
        {
            get { return _connectionstring; }
            set { _connectionstring = value; }
        }

        public string DatabaseName
        {
            get { return _databasename; }
            set { _databasename = value; }
        }

        public override string ToString()
        {
            if (ServerName == string.Empty)
                return "";

            string fullName = ServerName;
            if (DatabaseName != string.Empty)
                fullName += "." + DatabaseName;
            return fullName;
        }
        
    }
}
