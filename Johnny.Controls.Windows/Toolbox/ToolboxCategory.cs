using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Johnny.Controls.Windows.Toolbox
{
    public class ToolboxCategory : ToolboxItem
    {
        #region fields
        private ToolboxItemCollection _items = null;
        private Boolean _isOpen = false;
        #endregion

        #region Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ToolboxItemCollection Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        public Boolean IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
            }
        }
        #endregion

        public ToolboxCategory()
        {
            _items = new ToolboxItemCollection();
        }
    }
}
