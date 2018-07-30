using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

using Johnny.Library.Log;
using Johnny.CodeGenerator.Core;
using System.Collections.ObjectModel;

namespace Johnny.CodeGenerator.Core
{
    public class TaskManager : TaskBase
    {
        private string _taskid;
        private string _taskname;

        public delegate void ExecutionFinishedEventHandler(string taskid, string taskname);
        public event ExecutionFinishedEventHandler ExecutionFinished;

        public TaskManager(string taskid, string taskname)
        {
            base.Caption = taskname;
            base.Key = taskid;           

            _taskid = taskid;
            _taskname = taskname;

            Task = ConfigCtrl.GetTask(taskid, taskname);
        }

        #region TaskStart
        public void TaskStart()
        {
            try
            {
                _module = Constants.MSG_TASK;

                TaskRun();

                if (ExecutionFinished != null)
                    ExecutionFinished(_taskid, _taskname);
            }
            catch (ThreadAbortException)
            {
                //LogHelper.Write("TaskManager.TaskStart", "ThreadAbortException", LogSeverity.Info);
                SetMessageLn("Execution Aborted!");
                if (Task.WriteLogToFile)
                    WriteLogToFile(Task.TaskName, this.ExecutionLog.ToString());
            }
            catch (ThreadInterruptedException)
            {
                //LogHelper.Write("TaskManager.TaskStart", "ThreadInterruptedException", LogSeverity.Info);
                SetMessageLn("Execution Aborted!");
                if (Task.WriteLogToFile)
                    WriteLogToFile(Task.TaskName, this.ExecutionLog.ToString());
            }
            catch (Exception ex)
            {
                Log4Helper.Write("TaskManager.TaskStart", ex);
                SetMessageLn("Exception occurs, task is aborted! Error:" + ex.Message);
                if (Task.WriteLogToFile)
                    WriteLogToFile(Task.TaskName, this.ExecutionLog.ToString());
            }
        }
        #endregion

        #region TaskRun
        public void TaskRun()
        {
            try
            {
                //重新读取
                Task = ConfigCtrl.GetTask(_taskid, _taskname);

                base.ExecutionLog = new StringBuilder();
                //base.Proxy = ConfigCtrl.GetProxy();
                //base.Delay = ConfigCtrl.GetDelay();             

                SetMessage(Constants.COMMAND_CLEARLOG);
                //start
                SetMessage("\r\n" + "============================== START ==============================");
                
                CodeGeneratorSettingsInfo cgsettings = ConfigCtrl.GetCodeGeneratorSettings();
                SetMessageLn("Check working folders:" + cgsettings.WorkingFolder);
                if (!Directory.Exists(cgsettings.WorkingFolder))
                {
                    SetMessageLn("Working folders doesn't exist! Execution aborted!");
                    return;
                }
                string taskfolder = Path.Combine(cgsettings.WorkingFolder, Task.TaskName);
                if (!Directory.Exists(taskfolder))
                { 
                    Directory.CreateDirectory(taskfolder);
                }
                string entityfolder = Path.Combine(taskfolder, cgsettings.Entity);
                if (!Directory.Exists(entityfolder))
                {
                    Directory.CreateDirectory(entityfolder);
                }
                string outputfolder = Path.Combine(taskfolder, cgsettings.Output);
                if (!Directory.Exists(outputfolder))
                {
                    Directory.CreateDirectory(outputfolder);
                }                
                Collection<TableInfo> tables = Johnny.CodeGenerator.Core.DatabaseCtrl.GetTables(Task.DatabaseServer.ConnectionString, Task.DatabaseServer.ServerName, Task.DatabaseServer.DatabaseName);

                int modulenum = 0;
                foreach (ModuleInfo module in Task.Modules)
                {
                    modulenum++;
                    SetMessageLn("------ Totally [" + Task.Modules.Count + "] modules, No.[" + modulenum + "]:" + module.ModuleName + " ------");

                    string modulefolder = Path.Combine(outputfolder, module.ModuleName);
                    if (!Directory.Exists(modulefolder))
                    {
                        Directory.CreateDirectory(modulefolder);
                    }

                    int tablenum = 0;
                    foreach (TableInfo table in Task.Tables)
                    {
                        try
                        {
                            //Thread.Sleep(2000);
                            this._module = Constants.MSG_TASK;

                            tablenum++;
                            SetMessageLn("------ Totally [" + Task.Tables.Count + "] tables, No.[" + tablenum + "]:" + table.TableName + " ------");

                            foreach (TableInfo item in tables)
                            {
                                if (table.TableName == item.TableName)
                                {
                                    string prefix = Task.NameSpacePrefix;
                                    string suffix = Task.NameSpaceSuffix;
                                    string xmlfile = Path.Combine(entityfolder, String.Concat(Generator.GetModelName(item.TableName), ".xml"));
                                    string xsltfile = Path.Combine(cgsettings.Template, Path.Combine(Task.Template, String.Concat(module.ModuleName, ".xslt")));
                                    string outputfile = Path.Combine(outputfolder, Path.Combine(module.ModuleName, String.Concat(Generator.GetModelName(item.TableName), ".cs")));
                                    Generator.BulkGenerator(item, entityfolder, prefix, suffix, xmlfile, xsltfile, outputfile);
                                }
                            }
                        }
                        catch (ThreadAbortException)
                        {
                            //LogHelper.Write("TaskManager.TaskRun", "ThreadAbortException" + account.UserName, LogSeverity.Info);
                        }
                        catch (ThreadInterruptedException)
                        {
                            //LogHelper.Write("TaskManager.TaskRun", "ThreadInterruptedException" + account.UserName, LogSeverity.Info);
                        }
                        catch (Exception ex)
                        {
                            Log4Helper.Write("TaskManager.TaskRun", table.TableName, ex, LogSeverity.Error);
                            SetMessageLn("Exception occured, the code generation for this table failed! Error:" + ex.Message);
                        }
                    }
                }

                SetMessage("\r\n" + "============================== FINISHED ==============================");

                _module = Constants.MSG_TASK;

                if (Task.WriteLogToFile)
                    WriteLogToFile(Task.TaskName, this.ExecutionLog.ToString());
            }
            catch (ThreadAbortException)
            {
                //LogHelper.Write("TaskManager.TaskRun", "AferAllAccounts-ThreadAbortException", LogSeverity.Info);
            }
            catch (ThreadInterruptedException)
            {
                //LogHelper.Write("TaskManager.TaskRun", "AferAllAccounts-ThreadInterruptedException", LogSeverity.Info);
            }
            catch (Exception ex)
            {
                Log4Helper.Write("TaskManager.TaskRun", ex);
                SetMessageLn("Exception occurs, the current task has been aborted! Error:" + ex.Message);
            }
        }

        #endregion

        #region TaskWait
        public void TaskWait(string msg)
        {
            SetMessageLn(msg);
        }
        #endregion              

    }
}
