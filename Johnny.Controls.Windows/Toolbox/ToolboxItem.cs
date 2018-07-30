using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Johnny.Controls.Windows.Toolbox
{
    public class ToolboxItem
    {
        private String _name = "";
        private Int32 _imageIndex = -1;
        private ToolboxItem _parent = null;
        private string _className = "";

        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Int32 ImageIndex
        {
            get
            {
                return _imageIndex;
            }
            set
            {
                _imageIndex = value;
            }
        }

        [Browsable(false)]
        public ToolboxItem Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }
        public String ClassName
        {
            get
            {
                return _className;
            }
            set
            {
                _className = value;
            }
        }
    }
}
