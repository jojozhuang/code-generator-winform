using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Johnny.CodeGenerator.Core
{
    public class SolutionInfo
    {
        
        private string _foldername;
        private string _solutionname;

        public SolutionInfo()
        { }

        public SolutionInfo(string foldername, string solutionname)
        {
            _foldername = foldername;
            _solutionname = solutionname;
        }

        public string FolderName
        {
            get { return _foldername; }
            set { _foldername = value; }
        }

        public string SolutionName
        {
            get { return _solutionname; }
            set { _solutionname = value; }
        }

        public string FileName
        {
            get { return Path.Combine(FolderName, String.Concat(SolutionName, "_sln", ".xslt")); }
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(SolutionName))
                return base.ToString();
            else
                return SolutionName;
        }

    }
}
