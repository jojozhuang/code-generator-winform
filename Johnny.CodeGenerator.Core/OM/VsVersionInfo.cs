using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Core
{
    public class VsTemplateInfo
    {        
        private string _fullpath;
        private string _name;

        public VsTemplateInfo()
        { }

        public VsTemplateInfo(string fullpath, string name)
        {
            _fullpath = fullpath;
            _name = name;
        }

        public string FullPath
        {
            get { return _fullpath; }
            set { _fullpath = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Name))
                return base.ToString();
            else
                return Name;
        }

    }
}
