using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class FrmBaseCloseMenu : DockContent
    {
        public FrmBaseCloseMenu()
        {
            InitializeComponent();
        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.menuItemClose_Click(null, null);

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmBaseCloseMenu.menuItemClose_Click", ex);
            }

        }

        private void menuItemCloseAll_Click(object sender, EventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.menuItemCloseAll_Click(null, null);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmBaseCloseMenu.menuItemCloseAll_Click", ex);
            }
        }

        private void menuItemCloseAllButThisOne_Click(object sender, EventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.menuItemCloseAllButThisOne_Click(null, null);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmBaseCloseMenu.menuItemCloseAllButThisOne_Click", ex);
            }
        }

    }
}