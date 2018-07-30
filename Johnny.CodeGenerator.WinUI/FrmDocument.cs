using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Threading;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class FrmDocument : FrmBaseCloseMenu
    {
        private DateTime _lastWriteTime;

        public FrmDocument()
        {
            InitializeComponent();
            _lastWriteTime = new DateTime();
            this.Activated += new EventHandler(FrmDocument_Activated);
        }

        void FrmDocument_Activated(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(richtxtContent.FileName))
                {
                    //check whether the content in the texteditor has been modified outside of this tool
                    FileInfo fi = new FileInfo(richtxtContent.FileName);
                    if (fi.LastWriteTime.CompareTo(_lastWriteTime) != 0)
                    {
                        DialogResult result = MessageBox.Show("文件 " + this.Text + " 的内容已经在本工具之外被修改。\r\n需要重新载入吗？", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes)
                        {
                            richtxtContent.LoadFile(richtxtContent.FileName);
                            _lastWriteTime = new FileInfo(richtxtContent.FileName).LastWriteTime;
                            this.Text = this.Text.Substring(0, this.Text.Length - 1);
                        }
                        //Thread thread = new Thread(new ThreadStart(delegate
                        //{
                        //    ShowRemiderMessage();
                        //}));
                        //thread.IsBackground = true;
                        //thread.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmDocument", ex);
            }
        }

        private void ShowRemiderMessage()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    //this.Invoke(delegate() { ShowRemiderMessage(); });
                }
                else
                {
                    DialogResult result = MessageBox.Show("文件 " + this.Text + " 的内容已经在本工具之外被修改。\r\n需要重新载入吗？", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        richtxtContent.LoadFile(richtxtContent.FileName);
                        _lastWriteTime = new FileInfo(richtxtContent.FileName).LastWriteTime;
                        this.Text = this.Text.Substring(0, this.Text.Length - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmDocument", ex);
            }
        }

        protected override string GetPersistString()
        {
            //更改后尚未保存，此时关闭程序， 忽略*号(变更)
            if (Text.LastIndexOf("*") == Text.Length - 1)
                Text = Text.Substring(0, Text.Length - 1);
            return GetType().ToString() + "," + richtxtContent.FileName + "," + Text;
        }

        private void FrmXmlDocument_Load(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(richtxtContent.FileName))
                {
                    string strExtension = Path.GetExtension(richtxtContent.FileName.ToLower());
                    if (strExtension == ".xml")
                    {
                        this.Icon = Icon.FromHandle(((Bitmap)imageList.Images[5]).GetHicon());
                        richtxtContent.SetHighlighting("XML");
                    }
                    else if (strExtension == ".txt")
                    {
                        this.Icon = Icon.FromHandle(((Bitmap)imageList.Images[0]).GetHicon());
                    }
                    else if (strExtension == ".cs")
                    {
                        this.Icon = Icon.FromHandle(((Bitmap)imageList.Images[1]).GetHicon());
                        richtxtContent.SetHighlighting("C#");
                    }
                    else if (strExtension == ".html")
                    {
                        this.Icon = Icon.FromHandle(((Bitmap)imageList.Images[4]).GetHicon());
                        richtxtContent.SetHighlighting("HTML");
                    }
                    else if (strExtension == ".xslt")
                    {
                        this.Icon = Icon.FromHandle(((Bitmap)imageList.Images[3]).GetHicon());
                        richtxtContent.SetHighlighting("XML");
                    }
                    else
                    {
                        this.Icon = Icon.FromHandle(((Bitmap)imageList.Images[2]).GetHicon());
                    }
                }
                richtxtContent.Font = new Font("新宋体", 9);
                richtxtContent.Dock = DockStyle.Fill;                
                richtxtContent.ShowEOLMarkers = false;
                richtxtContent.ShowSpaces = false;
                richtxtContent.ShowTabs = false;
                richtxtContent.ShowInvalidLines = false;
                richtxtContent.ShowVRuler = false;
                richtxtContent.ActiveTextAreaControl.TextArea.SelectionManager.SelectionChanged += new EventHandler(SelectionManager_SelectionChanged);
                richtxtContent.Document.UndoStack.ActionRedone += new EventHandler(UndoStack_ActionRedone);
                richtxtContent.Document.UndoStack.ActionUndone += new EventHandler(UndoStack_ActionUndone);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmDocument", ex);
            }
        }

        private void UndoStack_ActionUndone(object sender, EventArgs e)
        {
            try
            {
                PropertyChangedInTextEditor();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmDocument", ex);
            }
        }

        private void UndoStack_ActionRedone(object sender, EventArgs e)
        {
            try
            {
                PropertyChangedInTextEditor();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmDocument", ex);
            }
        }

        private void SelectionManager_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                PropertyChangedInTextEditor();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmDocument", ex);
            }
        }

        private void PropertyChangedInTextEditor()
        {
            //get the top form
            MainForm mainform = this.TopLevelControl as MainForm;
            if (mainform != null)
                mainform.PropertyChangedInTextEditor();
        }

        private void FrmDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.Text) && this.Text.EndsWith("*"))
                {
                    DialogResult result = MessageBox.Show("文件 " + this.Text.Substring(0, this.Text.Length - 1) + " 的文字已经改变。\r\n想保存文件吗？", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        MainForm mainform = this.TopLevelControl as MainForm;
                        if (mainform != null)
                            mainform.DoSave(richtxtContent);
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmDocument", ex);
            }
        }

        public DateTime LastWriteTime
        {
            get { return _lastWriteTime; }
            set { _lastWriteTime = value; }
        }
    }
}