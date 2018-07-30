using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using System.Runtime.InteropServices;

using Johnny.CodeGenerator.WinUI.FormManager;
using Johnny.CodeGenerator.WinUI.Toolbox;
using WeifenLuo.WinFormsUI.Docking;
using Johnny.CodeGenerator.WinUI.Customization;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

using Johnny.CodeGenerator.WinUI.Editor;
using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class MainForm : Form
    {
        #region Variable
        private bool _bSaveLayout = true;
        private DeserializeDockContent _deserializeDockContent;
        private FrmTaskExplorer _taskManagerForm = new FrmTaskExplorer();
        private FrmProperty _propertyForm = new FrmProperty();
        private FrmToolbox _toolboxForm = new FrmToolbox();
        private FrmOutput _outputForm = new FrmOutput();
        private DummyTaskList _taskListForm = new DummyTaskList();
        private FrmDatabaseExplorer _databaseManagerForm = new FrmDatabaseExplorer();
        private FrmTemplateExplorer _templateManagerForm = new FrmTemplateExplorer();
        private FrmVSManager _vsManagerForm = new FrmVSManager();
        private FrmSingleGenerator _codeGenerator = new FrmSingleGenerator();
        private FindAndReplaceForm _findForm = new FindAndReplaceForm();
        
        private TextEditorControl _editor;
        private ITextEditorProperties _editorSettings;
        private FrmDocument _docform;
        #endregion

        #region Ctor
        public MainForm()
        {
            InitializeComponent();
			_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
        }
        #endregion

        #region Splash Screen Form
        private SplashScreenForm splash;
        private System.Windows.Forms.Timer splashTimer;
        private void ShowSplashScreen()
        {            
            splashTimer = new System.Windows.Forms.Timer();
            splashTimer.Enabled = true;
            splashTimer.Interval = 100;
            splashTimer.Tick += new System.EventHandler(this.splashTimer_Tick);
            splashTimer.Start();
            splash = new SplashScreenForm();
            splash.Opacity = 0.2;
            splash.Show(this);
            splash.TopMost = true;
        }

        private void splashTimer_Tick(object sender, System.EventArgs e)
        {
            try
            {
                this.splashTimer.Stop();
                if (splash.Opacity < 1)
                {
                    splash.Opacity = splash.Opacity + 0.04;
                }
                else
                {
                    this.splashTimer.Enabled = false;
                    splash.Dispose();
                }
                this.splashTimer.Start();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.splashTimer_Tick.", ex);
            }
        }
        #endregion

        #region Minimize to taskbar
        private bool _isHiding;
        private FormWindowState _beforeHideState;
        private void contextMenuOpenOrHide_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isHiding)
                {
                    this.Visible = true;
                    this.WindowState = _beforeHideState;
                    this.Show();
                    this.Activate();
                    _isHiding = false;
                }
                else
                {
                    _beforeHideState = this.WindowState;
                    this.Hide();
                    _isHiding = true;
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.contextMenuOpenOrHide_Click", ex);
            }
        }

        private void contextMenuQuit_Click(object sender, EventArgs e)
        {
            try
            {
                string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), MainConstants.DOCK_CONFIGFILE);
                if (_bSaveLayout)
                    dockPanel.SaveAsXml(configFile);
                else if (File.Exists(configFile))
                    File.Delete(configFile);

                this.notifyIcon.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.contextMenuQuit_Click", ex);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Hide();
                    _isHiding = true;
                }
                if (this.WindowState == FormWindowState.Normal)
                {
                    _beforeHideState = this.WindowState;
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.MainForm_Resize", ex);
            }
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = true;
                _beforeHideState = this.WindowState;
                this.Hide();
                _isHiding = true;
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.MainForm_Closing", ex);
            }
        }

        private void notifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (_isHiding)
                    {
                        this.Visible = true;
                        this.WindowState = _beforeHideState;
                        this.Show();
                        this.Activate();
                        _isHiding = false;
                    }
                    else
                    {
                        _beforeHideState = this.WindowState;
                        this.Hide();
                        _isHiding = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.notifyIcon_MouseDown", ex);
            }
        }

        #endregion

        #region MainForm_Load
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.notifyIcon.Visible = false;
                this.Text = ".Net Develop Assistant V" + typeof(MainForm).Assembly.GetName().Version.ToString() + " Test Version By Johnny";
                notifyIcon.Text = ".Net Develop Assistant V" + typeof(MainForm).Assembly.GetName().Version.ToString();
                
                //log4netConfigFile
                string log4netConfigFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), MainConstants.LOG4NET_CONFIGFILE);

                if (!File.Exists(log4netConfigFile))
                {
                    string resname = "Johnny.CodeGenerator.WinUI.Resources.log4net.config";
                    using (StreamReader streamReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(resname)))
                    {
                        string configContent = streamReader.ReadToEnd();
                        FileStream fs = new FileStream(log4netConfigFile, FileMode.Create);
                        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("GB2312"));
                        sw.Write(configContent);
                        sw.Close();
                        sw = null;
                    }
                }

                //dockpanel
                string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), MainConstants.DOCK_CONFIGFILE);

                if (!File.Exists(configFile))
                {
                    string resname = "Johnny.CodeGenerator.WinUI.Resources.DockPanel.config";
                    using (StreamReader streamReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(resname)))
                    {
                        string configContent = streamReader.ReadToEnd();
                        FileStream fs = new FileStream(configFile, FileMode.Create);
                        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Unicode);
                        sw.Write(configContent);
                        sw.Close();
                        sw = null;
                    }
                }
                dockPanel.LoadFromXml(configFile, _deserializeDockContent);

                _isHiding = false;
                this.notifyIcon.Visible = true;

                //Splash Screen Form
                ShowSplashScreen();

                //start page
                menuItemHomePage_Click(sender, e);
                MenuToolEnabled();
                dockPanel.ShowDocumentIcon = menuItemShowDocumentIcon.Checked = !menuItemShowDocumentIcon.Checked;
                dockPanel.ActiveContentChanged += new EventHandler(dockPanel_ActiveContentChanged);
                _beforeHideState = this.WindowState;

                //events register
                _taskManagerForm.MessageChanged += _taskManagerForm_MessageChanged;
                _taskManagerForm.TaskStopped += _taskManagerForm_TaskStopped;

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.MainForm_Load", ex);
            }

        }

        void _taskManagerForm_TaskStopped(string taskid, string taskname)
        {
            _outputForm.SetSelection(taskname, taskid);
        }

        void _taskManagerForm_MessageChanged(string caption, string key, string message)
        {
            Output_MessageChanged(caption, key, message);
        }

        #endregion

        #region BeforeQuit
        private bool BeforeQuit()
        {
            //document
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {
                IDockContent[] documents = dockPanel.DocumentsToArray();
                foreach (IDockContent content in documents)
                {
                    FrmDocument frmDoc = content as FrmDocument;
                    if (frmDoc != null)
                    {
                        if (!String.IsNullOrEmpty(frmDoc.Text) && frmDoc.Text.EndsWith("*"))
                        {
                            DialogResult result = MessageBox.Show("文件 " + frmDoc.Text.Substring(0, frmDoc.Text.Length - 1) + " 的文字已经改变。\r\n想保存文件吗？", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                            if (result == DialogResult.Yes)
                            {
                                TextEditorControl editor = frmDoc.Controls[0] as TextEditorControl;
                                if (editor != null)
                                    DoSave(editor);
                            }
                            else if (result == DialogResult.Cancel)
                            {
                                return false;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }

            return true;
        }
        #endregion

        #region dockPanel_ActiveContentChanged
        private void dockPanel_ActiveContentChanged(object sender, EventArgs e)
        {
            try
            {
                MenuToolEnabled();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }
        #endregion

        #region MainMenu

        #region File

        private void menuItemFile_Popup(object sender, System.EventArgs e)
        {
            try
            {
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    menuItemClose.Enabled = menuItemCloseAll.Enabled = (ActiveMdiChild != null);
                }
                else
                {
                    menuItemClose.Enabled = (dockPanel.ActiveDocument != null);
                    menuItemCloseAll.Enabled = (dockPanel.DocumentsCount > 0);
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemFile_Popup", ex);
            }
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDocument dummyDoc = CreateNewDocument("new file");
                TextEditorControl editor = dummyDoc.Controls[0] as TextEditorControl;
                editor.Document.DocumentChanged += new DocumentEventHandler(Document_DocumentChanged);
                // Modified flag is set during loading because the document 
                // "changes" (from nothing to something). So, clear it again.
                SetModifiedFlag(editor, false);
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    dummyDoc.MdiParent = this;
                    dummyDoc.Show();
                }
                else
                    dummyDoc.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemNew_Click", ex);
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.InitialDirectory = Application.ExecutablePath;
                openFileDialog.Filter = "cs files (*.cs)|*.cs|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 3;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    // Try to open chosen file
                    OpenFiles(openFileDialog.FileNames);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemOpenAppConfigFile_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigCtrl.GetCGConfigFile(); //make sure the file exists, if not, create a default one.
                string fullName = Path.Combine(Application.StartupPath, Constants.FILE_CGCONFIG);
                OpenFile(fullName, "App Config File");
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            try
            {
                TextEditorControl editor = ActiveEditor;
                if (editor != null)
                    DoSave(editor);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }


        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                TextEditorControl editor = ActiveEditor;
                if (editor != null)
                    DoSaveAs(editor);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemSaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                IDockContent[] documents = dockPanel.DocumentsToArray();
                foreach (IDockContent content in documents)
                {
                    FrmDocument form = content as FrmDocument;
                    if (form != null)
                    {
                        TextEditorControl editor = form.Controls[0] as TextEditorControl;
                        if (editor != null)
                            DoSaveAs(editor);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        public void menuItemClose_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                    ActiveMdiChild.Close();
                else if (dockPanel.ActiveDocument != null)
                    dockPanel.ActiveDocument.DockHandler.Close();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemOpen_Click", ex);
            }
        }

        public void menuItemCloseAll_Click(object sender, System.EventArgs e)
        {
            try
            {
                CloseAllDocuments();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemCloseAll_Click", ex);
            }
        }

        public void menuItemCloseAllButThisOne_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    Form activeMdi = ActiveMdiChild;
                    foreach (Form form in MdiChildren)
                    {
                        if (form != activeMdi)
                            form.Close();
                    }
                }
                else
                {
                    //foreach (IDockContent document in dockPanel.Documents)
                    //{
                    //    if (!document.DockHandler.IsActivated)
                    //        document.DockHandler.Close();
                    //}
                    IDockContent[] documents = dockPanel.DocumentsToArray();
                    foreach (IDockContent content in documents)
                        if (!content.DockHandler.IsActivated)
                            content.DockHandler.Close();
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemCloseAllButThisOne_Click", ex);
            }
        }
        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            try
            {
                contextMenuQuit_Click(null, null);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemExit_Click", ex);
            }
        }

        private void exitWithoutSavingLayout_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BeforeQuit())
                    return;

                _bSaveLayout = false;
                Close();
                _bSaveLayout = true;
                this.Dispose();
                Application.Exit();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.exitWithoutSavingLayout_Click", ex);
            }
        }
        #endregion

        #region Edit

        //判断菜单按钮是否可用
        private void menuItemEdit_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                MenuToolEnabled();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemUndo_Click(object sender, EventArgs e)
        {
            try
            {
                DoEditAction(ActiveEditor, new ICSharpCode.TextEditor.Actions.Undo());
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemRedo_Click(object sender, EventArgs e)
        {
            try
            {
                DoEditAction(ActiveEditor, new ICSharpCode.TextEditor.Actions.Redo());
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemCut_Click(object sender, EventArgs e)
        {
            try
            {
                if (HaveSelection())
                    DoEditAction(ActiveEditor, new ICSharpCode.TextEditor.Actions.Cut());
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (HaveSelection())
                    DoEditAction(ActiveEditor, new ICSharpCode.TextEditor.Actions.Copy());
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemPaste_Click(object sender, EventArgs e)
        {
            try
            {
                DoEditAction(ActiveEditor, new ICSharpCode.TextEditor.Actions.Paste());
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (HaveSelection())
                    DoEditAction(ActiveEditor, new ICSharpCode.TextEditor.Actions.Delete());
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemFind_Click(object sender, EventArgs e)
        {
            try
            {
                TextEditorControl editor = ActiveEditor;
                if (editor == null) return;
                _findForm.ShowFor(editor, false);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }


        private void menuItemFindAndReplace_Click(object sender, EventArgs e)
        {
            try
            {
                TextEditorControl editor = ActiveEditor;
                if (editor == null) return;
                _findForm.ShowFor(editor, true);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemFindNext_Click(object sender, EventArgs e)
        {
            try
            {
                _findForm.FindNext(true, false,
                string.Format("找不到\"{0}\"", _findForm.LookFor));
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuItemFindPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                _findForm.FindNext(true, true,
                string.Format("找不到\"{0}\"", _findForm.LookFor));
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }


        private void menuitemToggleBookmark_Click(object sender, EventArgs e)
        {
            try
            {
                TextEditorControl editor = ActiveEditor;
                if (editor != null)
                {
                    DoEditAction(ActiveEditor, new ICSharpCode.TextEditor.Actions.ToggleBookmark());
                    editor.IsIconBarVisible = editor.Document.BookmarkManager.Marks.Count > 0;
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuitemGoToPrevBookmark_Click(object sender, EventArgs e)
        {
            try
            {
                DoEditAction(ActiveEditor, new ICSharpCode.TextEditor.Actions.GotoPrevBookmark(
                   delegate(Bookmark bookmark)
                   {
                       return true;
                   }));
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }

        private void menuitemGoToNextBookmark_Click(object sender, EventArgs e)
        {
            try
            {
                DoEditAction(ActiveEditor, new ICSharpCode.TextEditor.Actions.GotoNextBookmark(
                   delegate(Bookmark bookmark)
                   {
                       return true;
                   }));
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }
        private void menuitemGoToClearAllBookmark_Click(object sender, EventArgs e)
        {
            try
            {
                DoEditAction(ActiveEditor, new ICSharpCode.TextEditor.Actions.ClearAllBookmarks(
                   delegate(Bookmark bookmark)
                   {
                       return true;
                   }));
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }
        #endregion

        #region View
        private void menuItemDatabaseManager_Click(object sender, EventArgs e)
        {
            try
            {
                _databaseManagerForm.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemDatabaseManager_Click", ex);
            }
        }

        private void menuItemTemplateManager_Click(object sender, EventArgs e)
        {
            try
            {
                _templateManagerForm.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemTemplateManager_Click", ex);
            }
        }

        private void menuItemVisualStudioTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                _vsManagerForm.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemVisualStudioTemplate_Click", ex);
            }
        }

        private void menuItemTaskManager_Click(object sender, EventArgs e)
        {
            try
            {
                _taskManagerForm.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemTaskManager_Click", ex);
            }
        }

        private void menuItemPropertyWindow_Click(object sender, System.EventArgs e)
        {
            try
            {
                _propertyForm.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemPropertyWindow_Click", ex);
            }
        }

        private void menuItemToolbox_Click(object sender, System.EventArgs e)
        {
            try
            {
                _toolboxForm.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemToolbox_Click", ex);
            }
        }

        private void menuItemOutputWindow_Click(object sender, System.EventArgs e)
        {
            try
            {
                //_outputForm.DockState = DockState.DockBottom;
                //_outputForm.DockAreas = DockAreas.DockBottom;
                _outputForm.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemOutputWindow_Click", ex);
            }
        }

        private void menuItemTaskList_Click(object sender, System.EventArgs e)
        {
            try
            {
                _taskListForm.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemTaskList_Click", ex);
            }
        }

        private void menuItemToolBar_Click(object sender, System.EventArgs e)
        {
            try
            {
                toolBar.Visible = menuItemToolBar.Checked = !menuItemToolBar.Checked;
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemToolBar_Click", ex);
            }
        }

        private void menuItemStatusBar_Click(object sender, System.EventArgs e)
        {
            try
            {
                statusBar.Visible = menuItemStatusBar.Checked = !menuItemStatusBar.Checked;
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemStatusBar_Click", ex);
            }
        }

        private void menuItemHomePage_Click(object sender, EventArgs e)
        {
            try
            {
                FrmWebBrowser frmBrowser = new FrmWebBrowser();
                frmBrowser.StartUrl = MainConstants.SUPPORT_HOMEPAGE;
                frmBrowser.Text = "Start Page";
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    frmBrowser.MdiParent = this;
                    frmBrowser.Show();
                }
                else
                    frmBrowser.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemHomePage_Click", ex);
            }
        }

        private void menuItemWebBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                FrmWebBrowser frmBrowser = new FrmWebBrowser();
                frmBrowser.Text = "Web Browser";
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    frmBrowser.MdiParent = this;
                    frmBrowser.Show();
                }
                else
                    frmBrowser.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemWebBrowser_Click", ex);
            }
        }

        #endregion

        #region Option

        private void menuItemWorkingFolderSetting_Click(object sender, EventArgs e)
        {
            try
            {
                DlgSettingsCG dlgSettingsCG = new DlgSettingsCG();
                dlgSettingsCG.ShowDialog();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemWorkingFolderSetting_Click", ex);
            }
        }

        private void menuItemSplitTextArea_Click(object sender, EventArgs e)
        {
            try
            {
                TextEditorControl editor = ActiveEditor;
                if (editor == null) return;
                editor.Split();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemSplitTextArea_Click", ex);
            }
        }

        private void menuItemShowSpacesAndTabs_Click(object sender, EventArgs e)
        {
            try
            {
                TextEditorControl editor = ActiveEditor;
                if (editor == null) return;
                editor.ShowSpaces = editor.ShowTabs = !editor.ShowSpaces;
                OnSettingsChanged();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemShowSpacesAndTabs_Click", ex);
            }
        }

        private void menuItemShowNewlines_Click(object sender, EventArgs e)
        {
            TextEditorControl editor = ActiveEditor;
            if (editor == null) return;
            editor.ShowEOLMarkers = !editor.ShowEOLMarkers;
            OnSettingsChanged();
        }

        private void menuItemShowLineNumbers_Click(object sender, EventArgs e)
        {
            TextEditorControl editor = ActiveEditor;
            if (editor == null) return;
            editor.ShowLineNumbers = !editor.ShowLineNumbers;
            OnSettingsChanged();
        }

        private void menuItemHighlightCurrentRow_Click(object sender, EventArgs e)
        {
            TextEditorControl editor = ActiveEditor;
            if (editor == null) return;
            editor.LineViewerStyle = editor.LineViewerStyle == LineViewerStyle.None
                ? LineViewerStyle.FullRow : LineViewerStyle.None;
            OnSettingsChanged();
        }

        private void menuItemHhighlightMatchingBracketsWhenCursorIsAfter_Click(object sender, EventArgs e)
        {
            TextEditorControl editor = ActiveEditor;
            if (editor == null) return;
            editor.BracketMatchingStyle = editor.BracketMatchingStyle == BracketMatchingStyle.After
                ? BracketMatchingStyle.Before : BracketMatchingStyle.After;
            OnSettingsChanged();
        }

        private void menuItemAllowCursorPastEndofline_Click(object sender, EventArgs e)
        {
            TextEditorControl editor = ActiveEditor;
            if (editor == null) return;
            editor.AllowCaretBeyondEOL = !editor.AllowCaretBeyondEOL;
            OnSettingsChanged();
        }

        private void menuItemSetTabSize_Click(object sender, EventArgs e)
        {
            if (ActiveEditor != null)
            {
                string result = InputBox.Show("Specify the desired tab width.", "Tab size", _editorSettings.TabIndent.ToString());
                int value;
                if (result != null && int.TryParse(result, out value) && (value >= 1 && value <= 32))
                {
                    ActiveEditor.TabIndent = value;
                }
            }
        }

        private void menuItemSetFont_Click(object sender, EventArgs e)
        {
            TextEditorControl editor = ActiveEditor;
            if (editor != null)
            {
                fontDialog.Font = editor.Font;
                if (fontDialog.ShowDialog(this) == DialogResult.OK)
                {
                    editor.Font = fontDialog.Font;
                    OnSettingsChanged();
                }
            }
        }

        

        #endregion

        #region Tools

        private void menuItemTools_Popup(object sender, System.EventArgs e)
        {
            try
            {
                menuItemLockLayout.Checked = !this.dockPanel.AllowEndUserDocking;
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemTools_Popup", ex);
            }
        }

        private void menuItemLockLayout_Click(object sender, System.EventArgs e)
        {
            try
            {
                dockPanel.AllowEndUserDocking = !dockPanel.AllowEndUserDocking;
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemLockLayout_Click", ex);
            }
        }

        private void menuItemShowDocumentIcon_Click(object sender, System.EventArgs e)
        {
            try
            {
                dockPanel.ShowDocumentIcon = menuItemShowDocumentIcon.Checked = !menuItemShowDocumentIcon.Checked;
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemShowDocumentIcon_Click", ex);
            }
        }

        private void menuItemAddFriends_Click(object sender, EventArgs e)
        {
            try
            {
                ShowEntityCreator();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemAddFriends_Click", ex);
            }
        }

        public void ShowEntityCreator()
        {
            FrmEntityCreator frmEntityCreator = new FrmEntityCreator();

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                frmEntityCreator.MdiParent = this;
                frmEntityCreator.Show();
            }
            else
            {
                foreach (IDockContent content in dockPanel.Documents)
                {
                    FrmEntityCreator form = content as FrmEntityCreator;
                    if (form != null)
                    {
                        content.DockHandler.Show();
                        return;
                    }
                }
                frmEntityCreator.Show(dockPanel);
            }
        }

        private void menuItemSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                //ShowSendMessage();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemSendMessage_Click", ex);
            }
        }

        private void menuItemCreateTeam_Click(object sender, EventArgs e)
        {
            try
            {
               // ShowCreateTeam();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemCreateTeam_Click", ex);
            }
        }

        #endregion

        #region Window
        private void menuItemNewWindow_Click(object sender, System.EventArgs e)
        {
            try
            {
                MainForm newWindow = new MainForm();
                newWindow.Text = newWindow.Text + " - New";
                newWindow.Show();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemNewWindow_Click", ex);
            }
        }
        #endregion

        #region Help
        private void menuItemRelatedInfo_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(MainConstants.SUPPORT_HOMEPAGE);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开链接。错误信息：" + ex.Message, MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItemDownload_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://kaixintools.ys168.com/");
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开链接。错误信息：" + ex.Message, MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItemDownloadFramework_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.microsoft.com/downloads/details.aspx?familyid=0856EACB-4362-4B0D-8EDD-AAB15C5E04F5&displaylang=zh-cn");
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开链接。错误信息：" + ex.Message, MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
            try
            {
                AboutDialog aboutDialog = new AboutDialog();
                aboutDialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.menuItemAbout_Click", ex);
            }
        }
        #endregion

        #endregion

        #region ToolBar Event
        private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem == toolBarButtonSave)
                    menuItemSave_Click(null, null);
                else if (e.ClickedItem == toolBarButtonSaveAll)
                    menuItemSaveAll_Click(null, null);
                else if (e.ClickedItem == toolBarButtonCut)
                    menuItemCut_Click(null, null);
                else if (e.ClickedItem == toolBarButtonCopy)
                    menuItemCopy_Click(null, null);
                else if (e.ClickedItem == toolBarButtonPaste)
                    menuItemPaste_Click(null, null);
                else if (e.ClickedItem == toolBarButtonUndo)
                    menuItemUndo_Click(null, null);
                else if (e.ClickedItem == toolBarButtonRedo)
                    menuItemRedo_Click(null, null);
                else if (e.ClickedItem == toolBarButtonTemplateExplorer)
                    menuItemTemplateManager_Click(null, null);
                else if (e.ClickedItem == toolBarButtonProperty)
                    menuItemPropertyWindow_Click(null, null);
                else if (e.ClickedItem == toolBarButtonToolbox)
                    menuItemToolbox_Click(null, null);
                else if (e.ClickedItem == toolBarButtonOutput)
                    menuItemOutputWindow_Click(null, null);
                else if (e.ClickedItem == toolBarButtonTaskList)
                    menuItemTaskList_Click(null, null);
                else if (e.ClickedItem == toolBarButtonSeverExplorer)
                    menuItemDatabaseManager_Click(null, null);
                else if (e.ClickedItem == toolBarButtonTaskManager)
                    menuItemTaskManager_Click(null, null);
                else if (e.ClickedItem == toolBarButtonHomePage)
                    menuItemHomePage_Click(null, null);
                else if (e.ClickedItem == toolBarButtonWebBrowser)
                    menuItemWebBrowser_Click(null, null);
                else if (e.ClickedItem == toolBarButtonVsTempExplorer)
                    menuItemVisualStudioTemplate_Click(null, null);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.toolBar_ButtonClick", ex);
            }
        }

        private void toolBarButtonDropDownNew_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem == toolBarButtonNewFile)
                    menuItemNew_Click(null, null);
                //else if (e.ClickedItem == toolBarButtonNewAssistantConfig)
                //    menuItemNewAssistantConfig_Click(null, null);
                //else if (e.ClickedItem == toolBarButtonNewAccount)
                //    menuItemNewAccount_Click(null, null);
                //else if (e.ClickedItem == toolBarButtonNewTask)
                //    menuItemNewTask_Click(null, null);
                //else if (e.ClickedItem == toolBarButtonNewCars)
                //    menuItemNewCars_Click(null, null);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.toolBarButtonDropDownNew_DropDownItemClicked", ex);
            }
        }

        private void toolBarButtonDropDownOpen_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem == toolBarButtonOpenFile)
                    menuItemOpen_Click(null, null);
                else if (e.ClickedItem == toolBarButtonOpenAppConfigFile)
                    menuItemOpenAppConfigFile_Click(null, null);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm.toolBarButtonDropDownOpen_DropDownItemClicked", ex);
            }
        }
        #endregion

        #region Private Methods

        private IDockContent FindDocument(string text)
		{
			if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
			{
				foreach (Form form in MdiChildren)
					if (form.Text == text)
						return form as IDockContent;
				
				return null;
			}
			else
			{
				foreach (IDockContent content in dockPanel.Documents)
					if (content.DockHandler.TabText == text)
						return content;

				return null;
			}
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(FrmTaskExplorer).ToString())
                return _taskManagerForm;
            else if (persistString == typeof(FrmProperty).ToString())
                return _propertyForm;
            else if (persistString == typeof(FrmToolbox).ToString())
                return _toolboxForm;
            else if (persistString == typeof(FrmOutput).ToString())
                return _outputForm;
            else if (persistString == typeof(DummyTaskList).ToString())
                return _taskListForm;
            else if (persistString == typeof(FrmDatabaseExplorer).ToString())
                return _databaseManagerForm;
            else if (persistString == typeof(FrmTemplateExplorer).ToString())
                return _templateManagerForm;
            else if (persistString == typeof(FrmVSManager).ToString())
                return _vsManagerForm;
            else
            {
                string[] parsedStrings = persistString.Split(new char[] { ',' });
                if (parsedStrings.Length == 3)
                {
                    if (parsedStrings[0] != typeof(FrmDocument).ToString())
                        return null;

                    FrmDocument dummyDoc = new FrmDocument();
                    TextEditorControl editor;
                    if (parsedStrings[1] != string.Empty && parsedStrings[2] != string.Empty)
                    {
                        if (!File.Exists(parsedStrings[1]))
                            return null;

                        dummyDoc = CreateNewDocument(Path.GetFileName(parsedStrings[1]));
                        editor = dummyDoc.Controls[0] as TextEditorControl;
                        editor.LoadFile(parsedStrings[1]);
                        editor.Document.DocumentChanged += new DocumentEventHandler(Document_DocumentChanged);
                        // Modified flag is set during loading because the document 
                        // "changes" (from nothing to something). So, clear it again.
                        SetModifiedFlag(editor, false);
                        if (!String.IsNullOrEmpty(parsedStrings[2]))
                            dummyDoc.Text = parsedStrings[2];
                        dummyDoc.LastWriteTime = new FileInfo(parsedStrings[1]).LastWriteTime;
                        dummyDoc.Show(dockPanel);
                    }
                    else
                    {
                        dummyDoc = CreateNewDocument("新文档");
                        editor = dummyDoc.Controls[0] as TextEditorControl;
                        editor.Document.DocumentChanged += new DocumentEventHandler(Document_DocumentChanged);
                        // Modified flag is set during loading because the document 
                        // "changes" (from nothing to something). So, clear it again.
                        SetModifiedFlag(editor, false);
                        dummyDoc.Show(dockPanel);
                    }
                    //文档已经打开，只是为了符合函数返回类型               
                    return dummyDoc;
                }                
                else
                {
                    return null;
                }
            }           
        }

        private bool IsHiding()
        {
            if (_propertyForm.DockState == DockState.DockBottomAutoHide || _propertyForm.DockState == DockState.DockLeftAutoHide || _propertyForm.DockState == DockState.DockRightAutoHide || _propertyForm.DockState == DockState.DockTopAutoHide)
                return true;
            else
                return false;
        }
        #endregion       

        #region Public Methods
        public void OpenTaskConfigFile(TaskInfo task)
        {
            string folder = Path.Combine(Application.StartupPath, Constants.FOLDER_TASKS);
            string fullName = Path.Combine(folder, String.Concat(task.TaskId, ".xml"));
            OpenFile(fullName, task.TaskName + "[Task]");
        }

        public void ShowTaskEditor(TaskInfo task)
        {
            FrmTaskEditor frmtaskeditor = new FrmTaskEditor();
            frmtaskeditor.TaskId = task.TaskId;
            frmtaskeditor.TaskName = task.TaskName;
            frmtaskeditor.DbServer = task.DatabaseServer;
            frmtaskeditor.Text = task.TaskName;
            frmtaskeditor.taskSaved += new FrmTaskEditor.TaskSavedEventHandler(frmtaskeditor_taskSaved);
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                frmtaskeditor.MdiParent = this;
                frmtaskeditor.Show();
            }
            else
            {
                foreach (IDockContent content in dockPanel.Documents)
                {
                    FrmTaskEditor form = content as FrmTaskEditor;
                    if (form != null && form.TaskId == task.TaskId)
                    {
                        content.DockHandler.Show();
                        return;
                    }
                }
                frmtaskeditor.Show(dockPanel);
            }
        }
        private void frmtaskeditor_taskSaved(string taskid, string taskname)
        {
            _taskManagerForm.RefreshTaskNode(taskid, taskname);
        }

        #endregion

        #region Output_MessageChanged
        private void Output_MessageChanged(string caption, string key, string message)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    //this.Invoke(new SingleGenerator.MessageChangedEventHandler(Output_MessageChanged), new object[] { caption, key, message });
                    this.Invoke(new TaskManager.MessageChangedEventHandler(Output_MessageChanged), new object[] { caption, key, message });
                }
                else
                {
                    _outputForm.SetMessage(caption, key, message, dockPanel);
                }
            }
            catch (ObjectDisposedException)
            {
                //do nothing
            }
            catch (ThreadAbortException)
            {
                //do nothing
            }
            catch (ThreadInterruptedException)
            {
                //do nothing
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }
        #endregion

        #region Task Tree
        public void TaskNodeSelected(TaskInfo task)
        {
            if (!IsHiding())
            {
                _propertyForm.Task = task;
                //_propertyForm.Operations = operations;
                _propertyForm.Show(dockPanel);
            }
        }

        public void RootNodeSelected(Collection<TaskInfo> tasks)
        {
            if (!IsHiding())
            {
                _propertyForm.Tasks = tasks;
                _propertyForm.Show(dockPanel);
            }
        }

        public void ChangeTaskEditTabName(TaskInfo task)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {

            }
            else
            {
                foreach (IDockContent content in dockPanel.Documents)
                {
                    FrmTaskEditor form = content as FrmTaskEditor;
                    if (form != null && form.TaskId == task.TaskId)
                    {
                        form.TaskName = task.TaskName;
                        form.Text = task.TaskName;
                        return;
                    }
                }
            }
        }
        #endregion

        #region Code Generator
        public void ShowCodeGenerator(string ConnectionString, string Server, string Database, string Table)
        {
            if (_codeGenerator.Text == string.Empty)
                _codeGenerator = new FrmSingleGenerator();
            _codeGenerator._connectionstring = ConnectionString;
            _codeGenerator._server = Server;
            _codeGenerator._database = Database;
            _codeGenerator._table = Table;
            _codeGenerator.ShowDgv();
            _codeGenerator.Show(dockPanel);
        }

        public void ShowToolForm(string uniqueId)
        {
            FrmToolBase toolform = FormManager.FormManager.Instance.GetWindow(uniqueId);
            toolform.Show(dockPanel);
        }

        #endregion

        #region Edit Functionality

        #region File
        private FrmDocument CreateNewDocument(string text)
        {
            FrmDocument dummyDoc = new FrmDocument();
            dummyDoc.Text = text;

            _editor = dummyDoc.Controls[0] as TextEditorControl;
            if (_editorSettings == null)
            {
                _editorSettings = _editor.TextEditorProperties;
                OnSettingsChanged();
            }
            else
                _editor.TextEditorProperties = _editorSettings;

            return dummyDoc;
        }

        //private void OpenFile(string filename)
        //{
        //    string[] files = new string[1];
        //    files[0] = filename;
        //    OpenFiles(files);
        //}

        public void OpenFile(string filename, string caption)
        {
            string[] files = new string[1];
            files[0] = filename;
            OpenFiles(files, caption);
        }

        private void OpenFiles(string[] fns)
        {
            OpenFiles(fns, "");
        }

        private void OpenFiles(string[] fns, string caption)
        {
            // Open file(s)
            foreach (string fn in fns)
            {
                FrmDocument dummyDoc = new FrmDocument(); ;
                TextEditorControl editor = new TextEditorControl();

                try
                {
                    if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                    {
                        dummyDoc = CreateNewDocument(Path.GetFileName(fn));
                        dummyDoc.MdiParent = this;
                        dummyDoc.Show();
                    }
                    else
                    {
                        foreach (IDockContent content in dockPanel.Documents)
                        {
                            dummyDoc = content as FrmDocument;
                            if (dummyDoc != null)
                            {
                                editor = dummyDoc.Controls[0] as TextEditorControl;
                                if (editor.FileName == fn)
                                {
                                    content.DockHandler.Show();
                                    return;
                                }
                            }
                        }

                        dummyDoc = CreateNewDocument(Path.GetFileName(fn));
                        editor = dummyDoc.Controls[0] as TextEditorControl;
                        editor.LoadFile(fn);
                        editor.Document.DocumentChanged += new DocumentEventHandler(Document_DocumentChanged);
                        // Modified flag is set during loading because the document 
                        // "changes" (from nothing to something). So, clear it again.
                        SetModifiedFlag(editor, false);
                        if (!String.IsNullOrEmpty(caption))
                            dummyDoc.Text = caption;
                        dummyDoc.LastWriteTime = new FileInfo(fn).LastWriteTime;
                        dummyDoc.Show(dockPanel);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().Name);
                    dummyDoc.Close();
                    dummyDoc.Dispose();
                    return;
                }

                // ICSharpCode.TextEditor doesn't have any built-in code folding
                // strategies, so I've included a simple one. Apparently, the
                // foldings are not updated automatically, so in this demo the user
                // cannot add or remove folding regions after loading the file.
                editor.Document.FoldingManager.FoldingStrategy = new RegionFoldingStrategy();
                editor.Document.FoldingManager.UpdateFoldings(null, null);
            }
        }

        private void Document_DocumentChanged(object sender, DocumentEventArgs e)
        {
            if (ActiveEditor != null)
                SetModifiedFlag(ActiveEditor, true);
        }

        public bool DoSave(TextEditorControl editor)
        {
            if (string.IsNullOrEmpty(editor.FileName))
                return DoSaveAs(editor);
            else
            {
                try
                {
                    editor.SaveFile(editor.FileName);
                    SetModifiedFlag(editor, false);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().Name);
                    return false;
                }
            }
        }
        private bool DoSaveAs(TextEditorControl editor)
        {
            saveFileDialog.FileName = editor.FileName;
            saveFileDialog.InitialDirectory = Application.ExecutablePath;
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    editor.SaveFile(saveFileDialog.FileName);
                    _docform.LastWriteTime = new FileInfo(saveFileDialog.FileName).LastWriteTime;
                    editor.Parent.Text = Path.GetFileName(editor.FileName);
                    SetModifiedFlag(editor, false);

                    // The syntax highlighting strategy doesn't change
                    // automatically, so do it manually.
                    editor.Document.HighlightingStrategy =
                        HighlightingStrategyFactory.CreateHighlightingStrategyForFile(editor.FileName);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().Name);
                }
            }
            return false;
        }
        private bool IsModified(TextEditorControl editor)
        {
            return editor.Parent.Text.EndsWith("*");
        }
        private void SetModifiedFlag(TextEditorControl editor, bool flag)
        {
            if (IsModified(editor) != flag)
            {
                Control p = editor.Parent;
                if (IsModified(editor))
                {
                    p.Text = p.Text.Substring(0, p.Text.Length - 1);
                    _docform.LastWriteTime = new FileInfo(editor.FileName).LastWriteTime;
                }
                else
                    p.Text += "*";
            }
        }

        private void CloseAllDocuments()
        {
            try
            {
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    foreach (Form form in MdiChildren)
                        form.Close();
                }
                else
                {
                    IDockContent[] documents = dockPanel.DocumentsToArray();
                    foreach (IDockContent content in documents)
                        content.DockHandler.Close();
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("MainForm", ex);
            }
        }
        #endregion

        #region Edit
        private void DoEditAction(TextEditorControl editor, ICSharpCode.TextEditor.Actions.IEditAction action)
        {
            if (editor != null && action != null)
            {
                TextArea area = editor.ActiveTextAreaControl.TextArea;
                editor.BeginUpdate();
                try
                {
                    lock (editor.Document)
                    {
                        action.Execute(area);
                        if (area.SelectionManager.HasSomethingSelected && area.AutoClearSelection /*&& caretchanged*/)
                        {
                            if (area.Document.TextEditorProperties.DocumentSelectionMode == DocumentSelectionMode.Normal)
                            {
                                area.SelectionManager.ClearSelection();
                            }
                        }
                    }
                }
                finally
                {
                    editor.EndUpdate();
                    area.Caret.UpdateCaretPosition();
                }
            }
        }
        private bool HaveSelection()
        {
            TextEditorControl editor = ActiveEditor;
            return editor != null &&
                editor.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected;
        }
        private bool IsTextEditor()
        {
            return ActiveEditor != null;
        }
        #endregion

        #region Option
        /// <summary>Show current settings on the Options menu</summary>
        /// <remarks>We don't have to sync settings between the editors because 
        /// they all share the same DefaultTextEditorProperties object.</remarks>
        private void OnSettingsChanged()
        {
            //menuItemShowSpacesAndTabs.Checked = _editorSettings.ShowSpaces;
            //menuItemShowNewlines.Checked = _editorSettings.ShowEOLMarker;
            //menuItemShowLineNumbers.Checked = _editorSettings.ShowLineNumbers;
            //menuItemHighlightCurrentRow.Checked = _editorSettings.LineViewerStyle == LineViewerStyle.FullRow;
            //menuItemHhighlightMatchingBracketsWhenCursorIsAfter.Checked = _editorSettings.BracketMatchingStyle == BracketMatchingStyle.After;
            //menuItemAllowCursorPastEndofline.Checked = _editorSettings.AllowCaretBeyondEOL;
        }
        #endregion

        #region PropertyChangedInTextEditor
        public void PropertyChangedInTextEditor()
        {
            MenuToolEnabled();
        }
        #endregion

        #region MenuToolEnabled
        private void MenuToolEnabled()
        {
            bool isTextEditor = IsTextEditor();
            bool isHaveSelection = HaveSelection();

            //menu
            menuItemSave.Enabled = isTextEditor;
            menuItemSaveAs.Enabled = isTextEditor;
            menuItemUndo.Enabled = isTextEditor && ActiveEditor.Document.UndoStack.CanUndo;
            menuItemRedo.Enabled = isTextEditor && ActiveEditor.Document.UndoStack.CanRedo;
            menuItemCut.Enabled = isTextEditor && isHaveSelection;
            menuItemCopy.Enabled = isTextEditor && isHaveSelection;
            menuItemPaste.Enabled = isTextEditor && ActiveEditor.ActiveTextAreaControl.TextArea.ClipboardHandler.EnablePaste;
            menuItemDelete.Enabled = isTextEditor && isHaveSelection;
            menuItemFind.Enabled = isTextEditor;
            menuItemFindAndReplace.Enabled = isTextEditor;
            menuItemFindNext.Enabled = isTextEditor;
            menuItemFindPrevious.Enabled = isTextEditor;
            menuitemToggleBookmark.Enabled = isTextEditor;
            menuitemGoToPrevBookmark.Enabled = isTextEditor;
            menuitemGoToNextBookmark.Enabled = isTextEditor;
            menuitemGoToClearAllBookmark.Enabled = isTextEditor;

            //toolbar
            toolBarButtonSave.Enabled = menuItemSave.Enabled;
            toolBarButtonCut.Enabled = menuItemCut.Enabled;
            toolBarButtonCopy.Enabled = menuItemCopy.Enabled;
            toolBarButtonPaste.Enabled = menuItemPaste.Enabled;
            toolBarButtonUndo.Enabled = menuItemUndo.Enabled;
            toolBarButtonRedo.Enabled = menuItemRedo.Enabled;

        }
        #endregion

        #endregion

        #region Property
        private TextEditorControl ActiveEditor
        {
            get
            {
                IDockContent[] documents = dockPanel.DocumentsToArray();
                foreach (IDockContent content in documents)
                {
                    if (content.DockHandler.IsActivated)
                    {
                        _docform = content as FrmDocument;
                        if (_docform != null)
                            return _docform.Controls[0] as TextEditorControl;
                        else
                            return null;
                    }
                }
                return null;
            }
        }
        #endregion        


    }
       
    #region RegionFoldingStrategy
    /// <summary>
    /// The class to generate the foldings, it implements ICSharpCode.TextEditor.Document.IFoldingStrategy
    /// </summary>
    public class RegionFoldingStrategy : IFoldingStrategy
    {
        /// <summary>
        /// Generates the foldings for our document.
        /// </summary>
        /// <param name="document">The current document.</param>
        /// <param name="fileName">The filename of the document.</param>
        /// <param name="parseInformation">Extra parse information, not used in this sample.</param>
        /// <returns>A list of FoldMarkers.</returns>
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
        {
            List<FoldMarker> list = new List<FoldMarker>();

            Stack<int> startLines = new Stack<int>();

            // Create foldmarkers for the whole document, enumerate through every line.
            for (int i = 0; i < document.TotalNumberOfLines; i++)
            {
                LineSegment seg = document.GetLineSegment(i);
                int offs, end = document.TextLength;
                char c;
                for (offs = seg.Offset; offs < end && ((c = document.GetCharAt(offs)) == ' ' || c == '\t'); offs++)
                { }
                if (offs == end)
                    break;
                int spaceCount = offs - seg.Offset;

                // now offs points to the first non-whitespace char on the line
                if (document.GetCharAt(offs) == '#')
                {
                    string text = document.GetText(offs, seg.Length - spaceCount);
                    if (text.StartsWith("#region"))
                        startLines.Push(i);
                    if (text.StartsWith("#endregion") && startLines.Count > 0)
                    {
                        // Add a new FoldMarker to the list.
                        int start = startLines.Pop();
                        list.Add(new FoldMarker(document, start,
                            document.GetLineSegment(start).Length,
                            i, spaceCount + "#endregion".Length));
                    }
                }
            }

            return list;
        }
    }
    #endregion

}