using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Collections.ObjectModel;

namespace Johnny.Controls.Windows.ListBoxSelector
{
    public partial class GenericListBoxSelector<T> : UserControl
    {
        private Collection<T> _allitems;
        private Collection<T> _allselecteditems;

        public GenericListBoxSelector()
        {
            InitializeComponent();
            _allitems = new Collection<T>();
            _allselecteditems = new Collection<T>();
        }

        public void Clear()
        {
            lstAllItems.Items.Clear();
            lstSelectedItems.Items.Clear();
        }

        #region list Select Event
        private void btnSelectOne_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (T item in lstAllItems.SelectedItems)
                {
                    lstSelectedItems.Items.Add(item);
                }
                for (int ix = lstAllItems.SelectedItems.Count - 1; ix >= 0; ix--)
                    lstAllItems.Items.Remove(lstAllItems.SelectedItems[0]);
            }
            catch
            {
                throw;
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (T item in lstAllItems.Items)
                {
                    lstSelectedItems.Items.Add(item);
                }
                for (int ix = lstAllItems.Items.Count - 1; ix >= 0; ix--)
                    lstAllItems.Items.Remove(lstAllItems.Items[0]);
            }
            catch
            {
                throw;
            }
        }

        private void btnUnselectOne_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (T item in lstSelectedItems.SelectedItems)
                {
                    lstAllItems.Items.Add(item);
                }
                for (int ix = lstSelectedItems.SelectedItems.Count - 1; ix >= 0; ix--)
                    lstSelectedItems.Items.Remove(lstSelectedItems.SelectedItems[0]);
            }
            catch
            {
                throw;
            }
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (T item in lstSelectedItems.Items)
                {
                    lstAllItems.Items.Add(item);
                }
                for (int ix = lstSelectedItems.Items.Count - 1; ix >= 0; ix--)
                    lstSelectedItems.Items.Remove(lstSelectedItems.Items[0]);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        public Collection<T> AllItems
        {
            get { return _allitems; }
            set
            {
                _allselecteditems.Clear();
                lstSelectedItems.Items.Clear();
                _allitems = value;
                if (_allitems != null)
                {
                    lstAllItems.Items.Clear();
                    foreach (object item in _allitems)
                    {
                        lstAllItems.Items.Add(item);
                    }
                }
            }
        }

        public Collection<T> AllSelectedItems
        {
            get
            {
                _allselecteditems.Clear();
                foreach (T item in lstSelectedItems.Items)
                {
                    _allselecteditems.Add(item);
                }

                return _allselecteditems;
            }
            set
            {
                _allselecteditems = value;

                if (_allitems == null || _allitems.Count == 0)
                    return;

                if (_allselecteditems == null || _allselecteditems.Count == 0)
                    return;

                lstAllItems.Items.Clear();
                lstSelectedItems.Items.Clear();

                foreach (T item in _allitems)
                {
                    foreach (T selecteditem in _allselecteditems)
                    {
                        if (selecteditem.Equals(item))
                            lstSelectedItems.Items.Add(item);
                        else
                            lstAllItems.Items.Add(item);
                    }
                }
            }
        }
   }
}
