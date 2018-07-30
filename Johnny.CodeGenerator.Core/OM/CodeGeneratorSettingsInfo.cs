using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.CodeGenerator.Core
{
    public class CodeGeneratorSettingsInfo
    {
        // Directory
        private string _workingfolder;
        private string _template;
        private string _vstemplate;
        private string _output;
        private string _entity;

        public CodeGeneratorSettingsInfo()
        { }

        public CodeGeneratorSettingsInfo(string workingfolder, string template, string vstemplate, string output, string entity)
        {
            _workingfolder = workingfolder;
            _template = template;
            _vstemplate = vstemplate;
            _output = output;
            _entity = entity;
        }

        public string WorkingFolder
        {
            get { return _workingfolder; }
            set { _workingfolder = value; }
        }

        public string Template
        {
            get { return _template; }
            set { _template = value; }
        }

        public string VsTemplate
        {
            get { return _vstemplate; }
            set { _vstemplate = value; }
        }

        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }

        public string Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        public string EntityFullPath
        {
            get { return _workingfolder + "\\Temp" + "\\" + _entity; }
        }
    }
}
