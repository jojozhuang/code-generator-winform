using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Core
{
    public class SingleGeneratorInfo
    {
        // Directory
        private string _xsltfile;
        private string _xmlfile;

        public SingleGeneratorInfo()
        { }

        public SingleGeneratorInfo(string xsltFile, string xmlFile)
        {
            _xsltfile = xsltFile;
            _xmlfile = xmlFile;
        }

        public string XsltFile
        {
            get { return _xsltfile; }
            set { _xsltfile = value; }
        }

        public string XmlFile
        {
            get { return _xmlfile; }
            set { _xmlfile = value; }
        }
    }
}
