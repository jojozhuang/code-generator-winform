using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.ObjectModel;

using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.Core
{
    public class TaskInfo
    {
        private string _taskid;
        private string _taskname;
        private bool _writelogtofile;
        //Code Generator
        private DatabaseInfo _dbserver;
        private Collection<TableInfo> _tables;
        //private Collection<View> _views;
        private string _solution;
        private string _project;
        private string _template;
        private Collection<ModuleInfo> _modules;
        private string _namespaceprefix;
        private string _namespacesuffix;

        public TaskInfo()
        {
            _writelogtofile = false;
            _dbserver = new DatabaseInfo();
            _tables = new Collection<TableInfo>();
            _modules = new Collection<ModuleInfo>(); 
        }

        [Browsable(false)]
        public string TaskId
        {
            get { return _taskid; }
            set { _taskid = value; }
        }

        [Browsable(false)]
        public string TaskName
        {
            get { return _taskname; }
            set { _taskname = value; }
        }

        [Category("Server")]
        [DisplayName("Database Server")]
        [Description("Database Server")]
        public DatabaseInfo DatabaseServer
        {
            get { return _dbserver; }
            set { _dbserver = value; }
        }

        [Category("Server")]
        [DisplayName("Tables")]
        [Description("Tables")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [EditorAttribute(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Collection<TableInfo> Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }

        #region Behaviour
        [Category("Behaviour")]
        [DisplayName("Write Logs to File")]
        [Description("Write the logs generated during task running to local files")]
        [DefaultValue(false)]
        public bool WriteLogToFile
        {
            get { return _writelogtofile; }
            set { _writelogtofile = value; }
        }
        #endregion

        #region Code Generator

        [Category("Code Generator")]
        [DisplayName("Solution Template")]
        [Description("Solution Template")]
        [DefaultValue("")]
        public string Solution
        {
            get { return _solution; }
            set { _solution = value; }
        }

        [Category("Code Generator")]
        [DisplayName("Project Template")]
        [Description("Project Template")]
        [DefaultValue("")]
        public string Project
        {
            get { return _project; }
            set { _project = value; }
        }

        [Category("Code Generator")]
        [DisplayName("Code Template")]
        [Description("Code Template")]
        [DefaultValue("")]
        public string Template
        {
            get { return _template; }
            set { _template = value; }
        }

        [Category("Code Generator")]
        [DisplayName("Modules")]
        [Description("Modules")]
        [DefaultValue("")]
        public Collection<ModuleInfo> Modules
        {
            get { return _modules; }
            set { _modules = value; }
        }

        [Category("Code Generator")]
        [DisplayName("Prefix of Name Space")]
        [Description("Prefix of Name Space")]
        [DefaultValue("")]
        public string NameSpacePrefix
        {
            get { return _namespaceprefix; }
            set { _namespaceprefix = value; }
        }

        [Category("Code Generator")]
        [DisplayName("Suffix of Name Space")]
        [Description("Suffix of Name Space")]
        [DefaultValue("")]
        public string NameSpaceSuffix
        {
            get { return _namespacesuffix; }
            set { _namespacesuffix = value; }
        }
        #endregion

        #region override
        public override string ToString()
        {
            if (_taskname != null && _taskname != string.Empty)
                return _taskname;
            else
                return base.ToString();
        }
        #endregion
    }
}
