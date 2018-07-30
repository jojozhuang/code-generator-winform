using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Johnny.CodeGenerator.Core
{
    public class EntityInfo
    {
        private string _namespace;
        private string _classname;
        private Collection<FieldInfo> _fields;

        public EntityInfo()
        {
            _fields = new Collection<FieldInfo>();
        }

        public string NameSpace
        {
            get { return _namespace; }
            set { _namespace = value; }
        }

        public string ClassName
        {
            get { return _classname; }
            set { _classname = value; }
        }

        public Collection<FieldInfo> Fileds
        {
            get { return _fields; }
            set { _fields = value; }
        }
    }
}
