using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Johnny.Controls.Windows.ExtendedWebBrowser;

namespace Johnny.CodeGenerator.WinUI
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1301:AvoidDuplicateAccelerators")]
    partial class FrmWebBrowser : FrmBaseCloseMenu
    {
        public FrmWebBrowser()
        {
            InitializeComponent();
            _windowManager = new WindowManager(this.tabControl);
            _windowManager.CommandStateChanged += new EventHandler<CommandStateEventArgs>(_windowManager_CommandStateChanged);
            _windowManager.StatusTextChanged += new EventHandler<TextChangedEventArgs>(_windowManager_StatusTextChanged);
        }

        // Update the status text
        void _windowManager_StatusTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.toolStripStatusLabel.Text = e.Text;
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser._windowManager_StatusTextChanged", ex);
            }
        }

        // Enable / disable buttons
        void _windowManager_CommandStateChanged(object sender, CommandStateEventArgs e)
        {
            try
            {
                this.forwardToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Forward) == BrowserCommands.Forward);
                this.backToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Back) == BrowserCommands.Back);
                this.printPreviewToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.PrintPreview) == BrowserCommands.PrintPreview);
                //this.printPreviewToolStripMenuItem.Enabled = ((e.BrowserCommands & BrowserCommands.PrintPreview) == BrowserCommands.PrintPreview);
                this.printToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Print) == BrowserCommands.Print);
                //this.printToolStripMenuItem.Enabled = ((e.BrowserCommands & BrowserCommands.Print) == BrowserCommands.Print);
                this.homeToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Home) == BrowserCommands.Home);
                this.searchToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Search) == BrowserCommands.Search);
                this.refreshToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Reload) == BrowserCommands.Reload);
                this.stopToolStripButton.Enabled = ((e.BrowserCommands & BrowserCommands.Stop) == BrowserCommands.Stop);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser._windowManager_CommandStateChanged", ex);
            }
        }

        #region Tools menu
        // Executed when the user clicks on Tools -> Options
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OptionsForm of = new OptionsForm())
                {
                    of.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.optionsToolStripMenuItem_Click", ex);
            }
        }
        // Tools -> Show script errors
        private void scriptErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptErrorManager.Instance.ShowWindow();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.scriptErrorToolStripMenuItem_Click", ex);
            }
        }

        #endregion

        #region File Menu

        // File -> Print
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Print();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.printToolStripMenuItem_Click", ex);
            }
        }

        // File -> Print Preview
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreview();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.printPreviewToolStripMenuItem_Click", ex);
            }
        }

        // File -> Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.exitToolStripMenuItem_Click", ex);
            }
        }

        // File -> Open URL
        private void openUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenUrlForm ouf = new OpenUrlForm())
                {
                    if (ouf.ShowDialog() == DialogResult.OK)
                    {
                        ExtendedWebBrowser brw = _windowManager.New(false);
                        brw.Navigate(ouf.Url);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.openUrlToolStripMenuItem_Click", ex);
            }
        }

        // File -> Open File
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = Johnny.Controls.Windows.Properties.Resources.OpenFileDialogFilter;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        Uri url = new Uri(ofd.FileName);
                        WindowManager.Open(url);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.openFileToolStripMenuItem_Click", ex);
            }
        }
        #endregion

        #region Help Menu

        // Executed when the user clicks on Help -> About
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                About();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.aboutToolStripMenuItem_Click", ex);
            }
        }

        /// <summary>
        /// Shows the AboutForm
        /// </summary>
        private void About()
        {
            using (AboutForm af = new AboutForm())
            {
                af.ShowDialog(this);
            }
        }

        #endregion
        
        /// <summary>
        /// The WindowManager class
        /// </summary>
        private WindowManager _windowManager;
        private string _startUrl;
        private bool _needsPost;
       
        // This is handy when all the tabs are closed.
        private void tabControl_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl.Visible)
                {
                    this.panel1.BackColor = SystemColors.Control;
                }
                else
                    this.panel1.BackColor = SystemColors.AppWorkspace;
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.tabControl_VisibleChanged", ex);
            }
        }

        // Starting the app here...
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (_startUrl != null & _startUrl != string.Empty)
                {
                    _windowManager.Open(new Uri(_startUrl));
                }
                else
                {
                    // Open a new browser window
                    _windowManager.New();
                }
                if (NeedsPost)
                {
                }            
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.MainForm_Load", ex);
            }
        }

        #region Printing & Print Preview
        private void Print()
        {
            ExtendedWebBrowser brw = _windowManager.ActiveBrowser;
            if (brw != null)
                brw.ShowPrintDialog();
        }

        private void PrintPreview()
        {
            ExtendedWebBrowser brw = _windowManager.ActiveBrowser;
            if (brw != null)
                brw.ShowPrintPreviewDialog();
        }
        #endregion

        #region Toolstrip buttons
        private void closeWindowToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this._windowManager.New();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.closeWindowToolStripButton_Click", ex);
            }
        }

        private void closeToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this._windowManager.Close();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.closeToolStripButton_Click", ex);
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Print();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.printToolStripButton_Click", ex);
            }
        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreview();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.printPreviewToolStripButton_Click", ex);
            }
        }

        private void backToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_windowManager.ActiveBrowser != null && _windowManager.ActiveBrowser.CanGoBack)
                    _windowManager.ActiveBrowser.GoBack();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.backToolStripButton_Click", ex);
            }
        }

        private void forwardToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_windowManager.ActiveBrowser != null && _windowManager.ActiveBrowser.CanGoForward)
                    _windowManager.ActiveBrowser.GoForward();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.forwardToolStripButton_Click", ex);
            }
        }

        private void stopToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_windowManager.ActiveBrowser != null)
                {
                    _windowManager.ActiveBrowser.Stop();
                }
                stopToolStripButton.Enabled = false;
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.stopToolStripButton_Click", ex);
            }
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_windowManager.ActiveBrowser != null)
                {
                    _windowManager.ActiveBrowser.Refresh(WebBrowserRefreshOption.Normal);
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.refreshToolStripButton_Click", ex);
            }
        }

        private void homeToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_windowManager.ActiveBrowser != null)
                    _windowManager.ActiveBrowser.GoHome();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.homeToolStripButton_Click", ex);
            }
        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_windowManager.ActiveBrowser != null)
                    _windowManager.ActiveBrowser.GoSearch();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmWebBrowser.searchToolStripButton_Click", ex);
            }
        }

        #endregion

        public WindowManager WindowManager
        {
            get { return _windowManager; }
        }

        public string StartUrl
        {
            get { return _startUrl; }
            set { _startUrl = value; }        
        }

        public bool NeedsPost
        {
            get { return _needsPost; }
            set { _needsPost = value; }
        }

       

        
    }
}