using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Johnny.Controls.Windows.OutputTab
{
    public partial class OutputTab : UserControl
    {
        public bool IsNewTabPage = false;

        public OutputTab()
        {
            InitializeComponent();
        }

        public void SetSelection(string caption, string key)
        {
            TabPage page = GetTagPage(caption, key);
            if (page != null)
            {
                tabControlOutput.SelectedTab = page;
            }
        }

        public void CopyToClipboard()
        {
            TabPage page = this.tabControlOutput.SelectedTab;
            if (page != null)
            {
                TextBox txtOutput = page.Controls[0] as TextBox;
                if (txtOutput != null)
                {
                    Clipboard.SetDataObject(txtOutput.Text);//
                }
                tabControlOutput.SelectedTab = page;
            }
        }

        public void ClearMessage()
        {
            TabPage page = this.tabControlOutput.SelectedTab;
            if (page != null)
            {
                TextBox txtOutput = page.Controls[0] as TextBox;
                if (txtOutput != null)
                {
                    txtOutput.Clear();
                }
                tabControlOutput.SelectedTab = page;
            }
        }

        public void CloseTagPage()
        {
            TabPage page = this.tabControlOutput.SelectedTab;
            if (page != null)
            {
                int tabindex = this.tabControlOutput.SelectedIndex;
                this.tabControlOutput.TabPages.Remove(page);
                if (tabindex > this.tabControlOutput.TabCount - 1)
                    tabindex = tabindex - 1;
                if (tabindex >= 0)
                    this.tabControlOutput.SelectedIndex = tabindex;
                page.Dispose();
            }
        }

        public void CloseAllTagPage()
        {
            if (this.tabControlOutput.TabPages != null)
            {
                foreach (TabPage page in this.tabControlOutput.TabPages)
                {
                    if (page != null)
                    {
                        this.tabControlOutput.TabPages.Remove(page);                        
                        page.Dispose();
                    }
                }
            }            
        } 

        private TabPage New(string caption, string key)
        {
            // Create a new tab page
            TabPage page = new TabPage();
            page.BackColor = System.Drawing.Color.White;
            page.Padding = new Padding(0, 0, 2, 3);
            page.Text = caption;
            page.Tag = key;
            // Add the new page to the tab control
            TextBox txtBox = new TextBox();
            txtBox.ReadOnly = true;
            txtBox.Multiline = true;
            txtBox.Dock = DockStyle.Fill;
            txtBox.ScrollBars = ScrollBars.Both;
            txtBox.WordWrap = false;
            txtBox.BackColor = System.Drawing.SystemColors.Window;
            page.Controls.Add(txtBox);
            tabControlOutput.TabPages.Add(page);
            tabControlOutput.SelectedTab = page;
            tabControlOutput.Visible = true;

            return page;
        }

        public void SetMessage(string caption, string key, string message)
        {
            TabPage page = GetTagPage(caption, key);
            if (page != null && page.Controls.Count > 0)
            {
                TextBox txtOutput = page.Controls[0] as TextBox;
                if (txtOutput != null)
                {
                    txtOutput.AppendText(message);
                    txtOutput.ScrollToCaret();
                }
            }
        }

        public void ClearMessage(string caption, string key)
        {
            TabPage page = GetTagPage(caption, key);
            if (page != null)
            {
                TextBox txtOutput = page.Controls[0] as TextBox;
                if (txtOutput != null)
                {
                    txtOutput.Clear();
                }
                //tabControlOutput.SelectedTab = page;
            }
        }

        private TabPage GetTagPage(string caption, string key)
        {
            IsNewTabPage = false;
            foreach (TabPage page in tabControlOutput.TabPages)
            {
                if (page.Text == caption && page.Tag.ToString() == key)
                    return page;
            }

            IsNewTabPage = true;
            return New(caption, key);
        }
    }
}
