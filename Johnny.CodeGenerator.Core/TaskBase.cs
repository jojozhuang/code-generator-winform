using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Johnny.Library.Log;
using System.IO;
using System.Windows.Forms;

namespace Johnny.CodeGenerator.Core
{
    public class TaskBase : IDisposable
    {
        private bool IsDisposed = false;
        private TaskInfo _task;
        //private OperationInfo _operation;
        private string _caption;
        private string _key;
        //private AccountInfo _account;
        //private ProxyInfo _proxy;
        //private DelayInfo _delay;
        private StringBuilder _sblog;

        protected string _module;
        protected Thread _threadMain;

        public delegate void MessageChangedEventHandler(string caption, string key, string message);
        public event MessageChangedEventHandler MessageChanged;

        public delegate void OperationFailedEventHandler();
        public event OperationFailedEventHandler OperationFailed;

        #region Ctor
        public TaskBase()
        {
            _sblog = new StringBuilder();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool Disposing)
        {
            if (!IsDisposed)
            {
                if (Disposing)
                {
                    //清理托管资源
                }
                //清理非托管资源
            }
            IsDisposed = true;
        }

        ~TaskBase()
        {
            Dispose(false);
        }
        #endregion

        #region Clone
        public void Clone(TaskBase source)
        {
            Clone(source, false);
        }
        public void Clone(TaskBase source, bool ignoreValidateEvent)
        {
            try
            {               
                this.MessageChanged += new MessageChangedEventHandler(source.SetMessageByParam);               
                this.Task = source.Task;               
                this.Caption = source.Caption;
                this.Key = source.Key;
                this.ExecutionLog = source.ExecutionLog;
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (ThreadInterruptedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Log4Helper.Write("KaixinBase.Clone", ex);
                throw;
            }
        }
        #endregion

        #region Initial
        public void Initial()
        {
            Initial(true);
        }
        public void Initial(bool newhttp)
        {
            try
            {
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (ThreadInterruptedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Log4Helper.Write("KaixinBase.Initial", ex);
                throw;
            }
        }
        #endregion

        #region StopThread
        public void StopThread()
        {
            try
            {
                if (_threadMain != null && _threadMain.ThreadState != ThreadState.Stopped)
                {
                    _threadMain.Abort();
                }
            }
            catch (Exception ex)
            {
                Log4Helper.Write("KaixinBase.StopThread", ex);
                throw;
            }
        }
        #endregion

        #region _hh_messageChanged
        private void _hh_messageChanged(string message)
        {
            SetMessage(message);
        }
        #endregion

        #region SetMessageByParam
        public void SetMessageByParam(string caption, string key, string msg)
        {
            if (MessageChanged != null)
                MessageChanged(caption, key, msg);
        }
        #endregion

        #region SetMessageLn
        protected void SetMessageLn(string msg)
        {
            msg = TraceLog.SetMessageLn(_module, msg);

            if (MessageChanged != null)
                MessageChanged(_caption, _key, msg);

            if (Task != null && (Task.WriteLogToFile) && msg != Constants.COMMAND_CLEARLOG)
                _sblog.Append(msg);
        }
        protected void SetMessage(string msg)
        {
            msg = TraceLog.SetMessage(msg);

            if (MessageChanged != null)
                MessageChanged(_caption, _key, msg);
            if (Task != null && (Task.WriteLogToFile) && msg != Constants.COMMAND_CLEARLOG)
                _sblog.Append(msg);
        }
        #endregion        

        #region ExecuteByThread
        public delegate void TryCatchBlock();
        protected void ExecuteTryCatchBlock(TryCatchBlock method, string ErrorMsg)
        {
            try
            {
                method();
            }
            catch (ThreadAbortException)
            {
                SetMessageLn("Execution Aborted!");
                if (OperationFailed != null)
                    OperationFailed();
            }
            catch (ThreadInterruptedException)
            {
                SetMessageLn("Execution Aborted!");
                if (OperationFailed != null)
                    OperationFailed();
            }
            catch (Exception ex)
            {
                Log4Helper.Write(ErrorMsg + this.Caption, ex);
                SetMessageLn(ErrorMsg + "Error:" + ex.Message);
                if (OperationFailed != null)
                    OperationFailed();
            }
        }
        #endregion

        public static void WriteLogToFile(string taskname, string log)
        {
            string folder = Path.Combine(Application.StartupPath, "Log");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            string file = Path.Combine(folder, "Task_" + taskname + ".txt");
            if (File.Exists(file))
            {
                FileInfo info = new FileInfo(file);
                if (info.LastWriteTime.Year != System.DateTime.Now.Year ||
                    info.LastWriteTime.Month != System.DateTime.Now.Month ||
                    info.LastWriteTime.Day != System.DateTime.Now.Day)
                {
                    //rename
                    File.Move(file, Path.Combine(info.DirectoryName, "Task_" + taskname + System.DateTime.Now.AddDays(-1).ToString("yyyyMMdd") + ".txt"));
                }
            }
            StreamWriter sw = File.AppendText(file);
            sw.WriteLine(log);
            sw.Flush();
            sw.Close();
        }

        #region Properties
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string Module
        {
            get { return _module; }
            set { _module = value; }
        }        

        public TaskInfo Task
        {
            get { return _task; }
            set { _task = value; }
        }

        public StringBuilder ExecutionLog
        {
            get { return _sblog; }
            set { _sblog = value; }
        }

        #endregion
    }
}
