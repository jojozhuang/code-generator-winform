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
    public partial class ToolWindow : DockContent
    {
        public ToolWindow()
        {
            InitializeComponent();
        }

        protected virtual void CopyToClipboard()
        {

        }

        protected virtual void ClearTaskLog()
        {

        }

        protected virtual void CloseTabPage()
        {

        }

        protected virtual void CloseAllTabPage()
        {

        }

        private void MenuItemCopy_Click(object sender, EventArgs e)
        {
            try
            {
                CopyToClipboard();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("ToolWindow", ex);
            }
        }

        private void MenuItemClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearTaskLog();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("ToolWindow", ex);
            }
        }

        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            try
            {
                CloseTabPage();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("ToolWindow", ex);
            }
        }

        private void MenuItemCloseAll_Click(object sender, EventArgs e)
        {
            try
            {
                CloseAllTabPage();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("ToolWindow", ex);
            }
        }
    }
}