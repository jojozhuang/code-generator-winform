using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Core
{
    [Serializable]
    public class ModuleInfo
    {        
        private string _fullname;
        private string _modulename;

        public ModuleInfo()
        { }

        public ModuleInfo(string fullname, string modulename)
        {
            _fullname = fullname;
            _modulename = modulename;
        }

        public string FullName
        {
            get { return _fullname; }
            set { _fullname = value; }
        }

        public string ModuleName
        {
            get { return _modulename; }
            set { _modulename = value; }
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(ModuleName))
                return base.ToString();
            else
                return ModuleName;
        }

        public override bool Equals(object obj)
        {
            var item = obj as ModuleInfo;

            if (item == null)
                return false;

            if (this.ModuleName == item.ModuleName)
                return true;
            else
                return false;
        }

    }
}
