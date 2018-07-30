using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Johnny.CodeGenerator.Core
{
    public class ProjectInfo
    {
        
        private string _foldername;
        private string _projectname;

        public ProjectInfo()
        { }

        public ProjectInfo(string foldername, string projectname)
        {
            _foldername = foldername;
            _projectname = projectname;
        }

        public string FolderName
        {
            get { return _foldername; }
            set { _foldername = value; }
        }

        public string ProjectName
        {
            get { return _projectname; }
            set { _projectname = value; }
        }

        public string FileName
        {
            get { return Path.Combine(FolderName, String.Concat(ProjectName, "_csproj", ".xslt")); }
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(ProjectName))
                return base.ToString();
            else
                return ProjectName;
        }

    }
}
