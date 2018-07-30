using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Johnny.Controls.Windows.Toolbox
{
    public class ToolboxCategoryCollection : Collection<ToolboxCategory>
    {
        public event CollectionChangeEventHandler ItemChanged;

        public ToolboxCategoryCollection()
        {
            ItemChanged += new CollectionChangeEventHandler(OnToolBoxCategoryCollectionChanged);
        }

        protected override void InsertItem(int index, ToolboxCategory item)
        {
            base.InsertItem(index, item);
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Add, item));
        }

        protected override void RemoveItem(int index)
        {
            ToolboxCategory tc = base[index];
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Remove, tc));
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, ToolboxCategory item)
        {
            base.SetItem(index, item);
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Refresh, item));
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            ItemChanged(this, new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
        }

        public ToolboxCategory this[String name]
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

        protected virtual void OnToolBoxCategoryCollectionChanged(Object sender, CollectionChangeEventArgs e)
        {
        }
    }
}
