using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Core
{
    public class FieldInfo
    {
        private string _type;
        private string _name;
        private string _csharptype;

        public FieldInfo()
        {
        }

        public FieldInfo(string type, string name)
        {
            _type = type;
            _name = name;
        }

        private string GetCSharpType(string type)
        {
            if (String.IsNullOrEmpty(type))
                throw new ArgumentNullException("type");
            switch (type)
            { 
                case "Int":
                    return "int";
                case "String":
                    return "string";
                case "Bool":
                    return "bool";
                default:
                    throw new FormatException("invalid type");
            }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string CSharpType
        {
            get { return GetCSharpType(_type); }
        }

        public string PrivateFieldName
        {
            get { return "_" + _name.ToLower(); }
        }

        public string PropertyName
        {
            get { return _name.Substring(0, 1).ToUpper() + _name.Substring(1, _name.Length - 1); }
        }

        public string ParamName
        {
            get { return _name.ToLower(); }
        }
    }
}
