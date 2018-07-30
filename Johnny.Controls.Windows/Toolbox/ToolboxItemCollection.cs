using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Johnny.Controls.Windows.Toolbox
{
    public class ToolboxItemCollection : Collection<ToolboxItem>
    {
        public event CollectionChangeEventHandler ItemChanged;

        public ToolboxItemCollection()
        {
            ItemChanged += new CollectionChangeEventHandler(OnToolBoxItemCollectionChanged);
        }

        protected override void InsertItem(int index, ToolboxItem item)
        {
            base.InsertItem(index, item);
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Add, item));
        }

        protected override void RemoveItem(int index)
        {
            ToolboxItem ti = base[index];
            base.RemoveItem(index);
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Remove, ti));
        }

        protected override void SetItem(int index, ToolboxItem item)
        {
            base.SetItem(index, item);
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Refresh, item));
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        public ToolboxItem this[String name]
        {
            get
            {
                Int32 index = -1;
                for (Int32 i = 0; i < this.Count; i++)
                {
                    if (this[i].Name == name)
                    {
                        index = i;
                        break;
                    }
                }

                if (index >= 0 && index < this.Count)
                {
                    return this[index];
                }

                return null;
            }
        }

        protected virtual void OnToolBoxItemCollectionChanged(Object sender, CollectionChangeEventArgs e)
        {
        }
    }
}
