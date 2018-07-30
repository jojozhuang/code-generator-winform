using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Core
{
    public class Constants
    {
        //common
        public const string MESSAGEBOX_CAPTION = "Developer Assistant";
        public const string CONFIG_ROOT = "ZrCg";
        public const string COMMAND_CLEARLOG = "Johnny.Command.ClearLog";

        //folder
        public const string FOLDER_TASKS = "Tasks";
        public const string FOLDER_ACCOUNTS = "Accounts";
        public const string FOLDER_MASTERDATA = "MasterData";

        //task        
        public const string TASK_TASKS = "Tasks";
        public const string TASK_TASK = "Task";
        public const string TASK_TASKID = "TaskId";
        public const string TASK_TASKNAME = "TaskName";
        public const string TASK_GROUPNAME = "GroupName";
        public const string TASK_NODE_MISCELLANEOUS = "Miscellaneous";
        public const string TASK_MISCELLANEOUS_WRITELOGTOFILE = "WriteLogToFile";

        //CodeGenerator
        public const string COMP_CODEGENERATOR = "CodeGenerator";
        public const string COMP_CODEGENERATOR_DBSERVER = "DBServer";
        public const string COMP_CODEGENERATOR_DATABASETYPE = "DatabaseType";
        public const string COMP_CODEGENERATOR_SERVERNAME = "ServerName";
        public const string COMP_CODEGENERATOR_CONNECTIONSTRING = "ConnectionString";
        public const string COMP_CODEGENERATOR_DATABASENAME = "DatabaseName";
        public const string COMP_CODEGENERATOR_TABLES = "Tables";
        public const string COMP_CODEGENERATOR_TABLE = "Table";
        public const string COMP_CODEGENERATOR_TABLENAME = "TableName";
        public const string COMP_CODEGENERATOR_VIEWS = "Views";
        public const string COMP_CODEGENERATOR_SOLUTION = "Solution";
        public const string COMP_CODEGENERATOR_PROJECT = "Project";
        public const string COMP_CODEGENERATOR_TEMPLATE = "Template";
        public const string COMP_CODEGENERATOR_NAMESPACEPREFIX = "NameSpacePrefix";
        public const string COMP_CODEGENERATOR_NAMESPACESUFFIX = "NameSpaceSuffix";
        public const string COMP_CODEGENERATOR_MODULES = "Modules";
        public const string COMP_CODEGENERATOR_MODULE = "Module";
        public const string COMP_CODEGENERATOR_MODULENAME = "ModuleName";

        public const string MSG_TASK = "[Task]";

        //file
        public const string FILE_CGCONFIG = "CgConfig.xml";

        //config        
        public const string DB_DATABASETYPE = "DatabaseType";
        public const string DB_SERVERNAME = "ServerName";
        public const string DB_CONNECTIONSTRING = "ConnectionString";
        public const string DB_DATABASENAME = "DatabaseName";

        //node
        public const string NODE_ROOT = "ZrCg";
        public const string NODE_CODEGENERATORSETTINGS = "CodeGeneratorSettings";
        public const string NODE_SERVERS = "Servers";
        public const string NODE_DBSERVER = "DBServer";

        //status
        public const string STATUS_SUCCESS = "Ok";
        public const string STATUS_FAIL = "Fail";

        // Char
        public const string CHAR_SLASH = "/";
    }
}
