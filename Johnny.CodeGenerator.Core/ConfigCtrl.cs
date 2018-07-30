using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Forms;

using Johnny.CodeGenerator.Core;
using Johnny.Library.Log;
using Johnny.Library.Helper;

namespace Johnny.CodeGenerator.Core
{
    public class ConfigCtrl
    {
        #region Private Methods
        private static DataView GetData(XmlDocument xmldoc, string XmlPathNode)
        {
            //get data from xml file
            DataSet ds = new DataSet();
            DataView dv = new DataView();

            XmlNode node = xmldoc.SelectSingleNode(XmlPathNode);
            if (node == null)
                dv.Table = new DataTable("table0");
            else
            {
                StringReader read = new StringReader(node.OuterXml);

                ds.ReadXml(read);
                if (ds.Tables.Count < 1)
                    dv.Table = new DataTable("table0");
                else
                    dv = ds.Tables[0].DefaultView;
            }

            return dv;
        }

        private static string GetTemplateName(string path)
        {
            if (path == null || path == string.Empty)
                return "";
            return path.Substring(path.LastIndexOf("\\") + 1);
        }
        private static string GetFileName(string filenamewithextension)
        {
            if (String.IsNullOrEmpty(filenamewithextension))
                return "";
            return filenamewithextension.Substring(0, filenamewithextension.LastIndexOf("."));
        }
        #endregion

        #region GetCGConfigFile
        public static XmlDocument GetCGConfigFile()
        {
            try
            {
                //load config info
                string configFile = Path.Combine(Application.StartupPath, Constants.FILE_CGCONFIG);
                if (!File.Exists(configFile))
                {
                    string configContent = UtilityHelper.GetCgConfig();
                    StreamWriter sw = new StreamWriter(configFile);
                    sw.Write(configContent);
                    sw.Close();
                    sw = null;
                }

                XmlDocument objXmlDoc = new XmlDocument();

                objXmlDoc.Load(configFile);

                return objXmlDoc;
            }
            catch (Exception ex)
            {
                Log4Helper.Write("ConfigCtrl.GetCGConfigFile", ex);
                throw;
            }
        }
        #endregion

        #region SetCGConfigFile
        private static bool SetCGConfigFile(XmlDocument xmldoc)
        {
            try
            {
                string configFile = Path.Combine(Application.StartupPath, Constants.FILE_CGCONFIG);
                xmldoc.Save(configFile);
                return true;
            }
            catch (Exception ex)
            {
                Log4Helper.Write("ConfigCtrl.SetCGConfigFile", ex);
                return false;
            }
        }
        #endregion

        #region GetCodeGeneratorSettings
        public static CodeGeneratorSettingsInfo GetCodeGeneratorSettings()
        {
            try
            {
                XmlDocument objXmlDoc = GetCGConfigFile();
                if (objXmlDoc == null)
                    return null;

                CodeGeneratorSettingsInfo cgsettings = new CodeGeneratorSettingsInfo();

                XmlNode objNode = objXmlDoc.SelectSingleNode(Constants.NODE_ROOT + Constants.CHAR_SLASH + Constants.NODE_CODEGENERATORSETTINGS);
                if (objNode == null)
                    return null;

                cgsettings.WorkingFolder = objNode.ChildNodes[0].InnerText;
                cgsettings.Template = objNode.ChildNodes[1].InnerText;
                cgsettings.VsTemplate = objNode.ChildNodes[2].InnerText;
                cgsettings.Output = objNode.ChildNodes[3].InnerText;
                cgsettings.Entity = objNode.ChildNodes[4].InnerText;

                return cgsettings;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region GetCodeGeneratorSettings
        public static bool SetCodeGeneratorSettings(CodeGeneratorSettingsInfo cgsettings)
        {
            try
            {
                XmlDocument objXmlDoc = GetCGConfigFile();
                if (objXmlDoc == null)
                    return false;

                XmlNode objNode = objXmlDoc.SelectSingleNode(Constants.NODE_ROOT + Constants.CHAR_SLASH + Constants.NODE_CODEGENERATORSETTINGS);
                if (objNode == null)
                    return false;

                objNode.ChildNodes[0].InnerText = cgsettings.WorkingFolder;
                objNode.ChildNodes[1].InnerText = cgsettings.Template;
                objNode.ChildNodes[2].InnerText = cgsettings.VsTemplate;
                objNode.ChildNodes[3].InnerText = cgsettings.Output;
                objNode.ChildNodes[4].InnerText = cgsettings.Entity;

                string configFile = Path.Combine(Application.StartupPath, Constants.FILE_CGCONFIG);

                objXmlDoc.Save(configFile);

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GetServers
        public static Collection<ServerInfo> GetServers()
        {
            try
            {
                XmlDocument objXmlDoc = GetCGConfigFile();
                if (objXmlDoc == null)
                    return null;

                DataView dv = GetData(objXmlDoc, Constants.NODE_ROOT + Constants.CHAR_SLASH + Constants.NODE_SERVERS);

                Collection<ServerInfo> servers = new Collection<ServerInfo>();

                for (int ix = 0; ix < dv.Table.Rows.Count; ix++)
                {
                    ServerInfo server = new ServerInfo();
                    server.DatabaseType = dv.Table.Rows[ix][0].ToString();
                    server.ServerName = dv.Table.Rows[ix][1].ToString();
                    server.ConnectionString = dv.Table.Rows[ix][2].ToString();
                    server.DatabaseName = dv.Table.Rows[ix][3].ToString();
                    servers.Add(server);
                }

                return servers;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region EditServer
        public static string EditServer(ServerInfo server)
        {
            try
            {
                XmlDocument objXmlDoc = GetCGConfigFile();
                if (objXmlDoc == null)
                    return "Config file doesn't exist!";

                if (IsExistServerNode(objXmlDoc, server))
                    return "The server has already existed!";
                else
                    InsertAccounNode(objXmlDoc, server);

                string configFile = Path.Combine(Application.StartupPath, Constants.FILE_CGCONFIG);

                objXmlDoc.Save(configFile);

                return Constants.STATUS_SUCCESS;
            }
            catch
            {
                return Constants.STATUS_FAIL;
            }
        }

        public static string DeleteServer(ServerInfo server)
        {
            try
            {
                XmlDocument objXmlDoc = GetCGConfigFile();
                if (objXmlDoc == null)
                    return "Config file doesn't exist!";

                DeleteServerNode(objXmlDoc, server);

                string configFile = Path.Combine(Application.StartupPath, Constants.FILE_CGCONFIG);

                objXmlDoc.Save(configFile);

                return "Ok";
            }
            catch
            {
                return "Fail";
            }
        }


        private static void InsertAccounNode(XmlDocument xmldoc, ServerInfo server)
        {

            XmlNode objRootNode = xmldoc.SelectSingleNode(Constants.NODE_ROOT + Constants.CHAR_SLASH + Constants.NODE_SERVERS);
            XmlElement objChildNode = xmldoc.CreateElement(Constants.NODE_DBSERVER);
            objRootNode.AppendChild(objChildNode);
            XmlElement emtType = xmldoc.CreateElement(Constants.DB_DATABASETYPE);
            emtType.InnerText = server.DatabaseType;
            XmlElement emtServerName = xmldoc.CreateElement(Constants.DB_SERVERNAME);
            emtServerName.InnerText = server.ServerName;
            XmlElement emtConnectionString = xmldoc.CreateElement(Constants.DB_CONNECTIONSTRING);
            emtConnectionString.InnerText = server.ConnectionString;
            XmlElement emtDatabaseName = xmldoc.CreateElement(Constants.DB_DATABASENAME);
            emtDatabaseName.InnerText = server.DatabaseName;
            objChildNode.AppendChild(emtType);
            objChildNode.AppendChild(emtServerName);
            objChildNode.AppendChild(emtConnectionString);
            objChildNode.AppendChild(emtDatabaseName);
        }

        //private static void EditAccountNode(XmlDocument xmldoc, string email, ServerInfo server)
        //{
        //    XmlNode objRootNode = xmldoc.SelectSingleNode(DatabaseConstants.NODE_ROOT + DatabaseConstants.CHAR_SLASH + DatabaseConstants.NODE_SERVERS);
        //    foreach (XmlNode xn in objRootNode.ChildNodes)
        //    {
        //        if (xn.ChildNodes[0].InnerText == email)
        //        {
        //            xn.ChildNodes[0].InnerText = user.Email;
        //            xn.ChildNodes[1].InnerText = user.Password;
        //            xn.ChildNodes[2].InnerText = user.UserName;
        //            xn.ChildNodes[3].InnerText = user.UserId;
        //            break;
        //        }
        //    }
        //}

        private static void DeleteServerNode(XmlDocument xmldoc, ServerInfo server)
        {
            XmlNode objRootNode = xmldoc.SelectSingleNode(Constants.NODE_ROOT + Constants.CHAR_SLASH + Constants.NODE_SERVERS);
            foreach (XmlNode xn in objRootNode.ChildNodes)
            {
                if (xn.ChildNodes[0].InnerText == server.DatabaseType &&
                    xn.ChildNodes[1].InnerText == server.ServerName &&
                    xn.ChildNodes[2].InnerText == server.ConnectionString &&
                    xn.ChildNodes[3].InnerText == server.DatabaseName)
                {
                    objRootNode.RemoveChild(xn);
                    break;
                }
            }
        }

        private static bool IsExistServerNode(XmlDocument xmldoc, ServerInfo server)
        {
            XmlNode objRootNode = xmldoc.SelectSingleNode(Constants.NODE_ROOT + Constants.CHAR_SLASH + Constants.NODE_SERVERS);
            foreach (XmlNode xn in objRootNode.ChildNodes)
            {
                if (xn.ChildNodes[0].InnerText == server.DatabaseType &&
                    xn.ChildNodes[1].InnerText == server.ServerName &&
                    xn.ChildNodes[2].InnerText == server.ConnectionString &&
                    xn.ChildNodes[3].InnerText == server.DatabaseName)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region GetVsTemplates
        public static Collection<VsTemplateInfo> GetVsTemplates()
        {
            Collection<VsTemplateInfo> vstemplates = new Collection<VsTemplateInfo>();
            CodeGeneratorSettingsInfo cgsettings = GetCodeGeneratorSettings();
            if (cgsettings != null)
            {
                if (Directory.Exists(cgsettings.VsTemplate))
                {
                    string[] directories = Directory.GetDirectories(cgsettings.VsTemplate);
                    for (int ix = 0; ix < directories.Length; ix++)
                    {
                        vstemplates.Add(new VsTemplateInfo(directories[ix], GetTemplateName(directories[ix])));
                    }
                }
            }

            return vstemplates;
        }
        #endregion

        #region IsVsTemplateExist
        public static bool IsVsTemplateExist(string vstemplatename)
        {
            CodeGeneratorSettingsInfo folder = GetCodeGeneratorSettings();
            if (folder != null)
            {
                if (Directory.Exists(Path.Combine(folder.VsTemplate, vstemplatename)))
                    return true;
                else
                    return false;
            }
            return false;
        }
        #endregion

        #region AddVsTemplate
        public static void AddVsTemplate(string vstemplatename)
        {
            CodeGeneratorSettingsInfo cgsettings = GetCodeGeneratorSettings();
            if (cgsettings != null)
            {
                Directory.CreateDirectory(Path.Combine(cgsettings.VsTemplate, vstemplatename));
            }
        }
        #endregion

        #region DeleteVsTemplate
        public static void DeleteVsTemplate(VsTemplateInfo vstemplate)
        {
            Directory.Delete(vstemplate.FullPath, true);
        }
        #endregion

        #region GetSolutions
        public static Collection<SolutionInfo> GetSolutions(string path)
        {
            Collection<SolutionInfo> solutions = new Collection<SolutionInfo>();
            string[] files = Directory.GetFiles(path);
            if (files != null)
            {
                for (int ix = 0; ix < files.Length; ix++)
                {
                    if (!Path.GetFileName(files[ix]).EndsWith("_sln.xslt"))
                        continue;

                    SolutionInfo solution = new SolutionInfo();
                    solution.FolderName = path;
                    solution.SolutionName = Path.GetFileNameWithoutExtension(files[ix]).Replace("_sln", "");

                    solutions.Add(solution);
                }
            }
            return solutions;
        }
        #endregion

        #region AddSolution
        public static void AddSolution(VsTemplateInfo vsversion, string solutionname)
        {
            File.Create(Path.Combine(vsversion.FullPath, String.Concat(solutionname, "_sln", ".xslt")));
        }
        #endregion

        #region IsSolutionExist
        public static bool IsSolutionExist(VsTemplateInfo vsversion, string solutionname)
        {
            if (Directory.Exists(Path.Combine(vsversion.FullPath, String.Concat(solutionname, "_sln", ".xslt"))))
                return true;
            else
                return false;
        }
        #endregion

        #region DeleteSolution
        public static void DeleteSolution(SolutionInfo solution)
        {
            File.Delete(solution.FileName);
        }
        #endregion

        #region GetProjects
        public static Collection<ProjectInfo> GetProjects(string path)
        {
            Collection<ProjectInfo> projects = new Collection<ProjectInfo>();
            string[] files = Directory.GetFiles(path);
            if (files != null)
            {
                for (int ix = 0; ix < files.Length; ix++)
                {
                    if (!Path.GetFileName(files[ix]).EndsWith("_csproj.xslt"))
                        continue;

                    ProjectInfo project = new ProjectInfo();
                    project.FolderName = path;
                    project.ProjectName = Path.GetFileNameWithoutExtension(files[ix]).Replace("_csproj", "");

                    projects.Add(project);
                }
            }
            return projects;
        }
        #endregion

        #region AddProject
        public static void AddProject(VsTemplateInfo vsversion, string projectname)
        {
            File.Create(Path.Combine(vsversion.FullPath, String.Concat(projectname, "_csproj", ".xslt")));
        }
        #endregion

        #region IsProjectExist
        public static bool IsProjectExist(VsTemplateInfo vsversion, string projectname)
        {
            if (Directory.Exists(Path.Combine(vsversion.FullPath, String.Concat(projectname, "_csproj",".xslt"))))
                return true;
            else
                return false;
        }
        #endregion

        #region DeleteProject
        public static void DeleteProject(ProjectInfo project)
        {
            File.Delete(project.FileName);
        }
        #endregion

        #region GetTemplates
        public static Collection<TemplateInfo> GetTemplates()
        {
            Collection<TemplateInfo> templates = new Collection<TemplateInfo>();
            CodeGeneratorSettingsInfo cgsettings = GetCodeGeneratorSettings();
            if (cgsettings != null)
            {
                if (Directory.Exists(cgsettings.Template))
                {
                    string[] directories = Directory.GetDirectories(cgsettings.Template);
                    for (int ix = 0; ix < directories.Length; ix++)
                    {
                        templates.Add(new TemplateInfo(directories[ix], GetTemplateName(directories[ix])));
                    }
                }
            }

            return templates;
        }
        #endregion

        #region AddTemplate
        public static void AddTemplate(string templatename)
        {
            CodeGeneratorSettingsInfo cgsettings = GetCodeGeneratorSettings();
            if (cgsettings != null)
            {
                Directory.CreateDirectory(Path.Combine(cgsettings.Template, templatename));
            }
        }
        #endregion

        #region IsTemplateExist
        public static bool IsTemplateExist(string templatename)
        {
            CodeGeneratorSettingsInfo folder = GetCodeGeneratorSettings();
            if (folder != null)
            {
                if (Directory.Exists(Path.Combine(folder.Template, templatename)))
                    return true;
                else
                    return false;
            }
            return false;
        }
        #endregion

        #region DeleteTemplate
        public static void DeleteTemplate(TemplateInfo template)
        {
            Directory.Delete(template.FullPath, true);
        }
        #endregion

        #region GetModules
        public static Collection<ModuleInfo> GetModules(string path)
        {
            Collection<ModuleInfo> modules = new Collection<ModuleInfo>();
            string[] files = Directory.GetFiles(path);
            if (files != null)
            {
                for (int ix = 0; ix < files.Length; ix++)
                {
                    ModuleInfo module = new ModuleInfo();
                    module.FullName = files[ix];
                    module.ModuleName = Path.GetFileNameWithoutExtension(files[ix]);
                    modules.Add(module);
                }
            }
            return modules;
        }
        #endregion

        #region IsModuleExist
        public static bool IsModuleExist(TemplateInfo template, string filename)
        {
            if (File.Exists(Path.Combine(template.FullPath, String.Concat(filename, ".xslt"))))
                return true;
            else
                return false;
        }
        #endregion

        #region AddModule
        public static void AddModule(TemplateInfo template, string modulename)
        {
            File.Create(Path.Combine(template.FullPath, String.Concat(modulename, ".xslt")));
        }
        #endregion

        #region GetTasks
        public static Collection<TaskInfo> GetTasks()
        {
            try
            {
                XmlDocument objXmlDoc = GetCGConfigFile();
                if (objXmlDoc == null)
                    return null;

                DataView dv = GetData(objXmlDoc, Constants.CONFIG_ROOT + Constants.CHAR_SLASH + Constants.TASK_TASKS);

                Collection<TaskInfo> tasks = new Collection<TaskInfo>();

                for (int ix = 0; ix < dv.Table.Rows.Count; ix++)
                {
                    try
                    {
                        TaskInfo task = new TaskInfo();
                        task = GetTask(dv.Table.Rows[ix][0].ToString(), dv.Table.Rows[ix][1].ToString());
                        tasks.Add(task);
                    }
                    catch
                    {
                        continue;
                    }
                }

                return tasks;
            }
            catch (Exception ex)
            {
                Log4Helper.Write("ConfigCtrl.GetTasks", ex, LogSeverity.Fatal);
                throw;
            }
        }
        #endregion

        #region Task Tree
        public static string EditTask(TaskInfo task)
        {
            try
            {
                XmlDocument objXmlDoc = GetCGConfigFile();
                if (objXmlDoc == null)
                    return "Config file does not exist!";

                if (task.TaskId == null || task.TaskId == string.Empty)
                {
                    Random rd = new Random();
                    int num = rd.Next(1, 999999999);
                    DateTime now = DateTime.Now; //获取系统时间   
                    string taskId = now.Year.ToString() + now.Month.ToString() + now.Day.ToString() + now.Hour.ToString() + now.Minute.ToString() + now.Second.ToString() + now.Millisecond.ToString() + "_" + num.ToString();

                    task.TaskId = taskId;
                    InsertTaskNode(objXmlDoc, task);
                }
                else
                {
                    EditTaskNode(objXmlDoc, task);
                }

                bool ret = SetCGConfigFile(objXmlDoc);
                if (ret)
                    return Constants.STATUS_SUCCESS;
                else
                    return Constants.STATUS_FAIL;
            }
            catch (Exception ex)
            {
                Log4Helper.Write("ConfigCtrl.EditTask:" + task.TaskName, ex);
                return Constants.STATUS_FAIL;
            }
        }

        public static string DeleteTask(TaskInfo task)
        {
            try
            {
                XmlDocument objXmlDoc = GetCGConfigFile();
                if (objXmlDoc == null)
                    return "Config file does not exist!";

                DeleteTaskNode(objXmlDoc, task);

                SetCGConfigFile(objXmlDoc);

                //delete task file
                string folder = Path.Combine(Application.StartupPath, Constants.FOLDER_TASKS);
                string taskFile = Path.Combine(folder, String.Concat(task.TaskId, ".xml"));
                File.Delete(taskFile);

                return Constants.STATUS_SUCCESS;
            }
            catch (Exception ex)
            {
                Log4Helper.Write("ConfigCtrl.DeleteTask:" + task.TaskName, ex);
                return Constants.STATUS_FAIL;
            }
        }
        private static void InsertTaskNode(XmlDocument xmldoc, TaskInfo task)
        {
            XmlNode objTasksNode = xmldoc.SelectSingleNode(Constants.CONFIG_ROOT + Constants.CHAR_SLASH + Constants.TASK_TASKS);
            XmlElement objChildNode = xmldoc.CreateElement(Constants.TASK_TASK);
            objTasksNode.AppendChild(objChildNode);
            XmlElement emtTaskId = xmldoc.CreateElement(Constants.TASK_TASKID);
            emtTaskId.InnerText = task.TaskId;
            XmlElement emtTaskName = xmldoc.CreateElement(Constants.TASK_TASKNAME);
            emtTaskName.InnerText = task.TaskName;
            objChildNode.AppendChild(emtTaskId);
            objChildNode.AppendChild(emtTaskName);
        }

        private static void EditTaskNode(XmlDocument xmldoc, TaskInfo task)
        {
            XmlNode objTasksNode = xmldoc.SelectSingleNode(Constants.CONFIG_ROOT + Constants.CHAR_SLASH + Constants.TASK_TASKS);
            foreach (XmlNode xn in objTasksNode.ChildNodes)
            {
                if (xn.SelectSingleNode(Constants.TASK_TASKID).InnerText == task.TaskId)
                {
                    xn.SelectSingleNode(Constants.TASK_TASKNAME).InnerText = task.TaskName;
                    if (xn.SelectSingleNode(Constants.TASK_GROUPNAME) == null)
                    {
                        XmlElement objGroupNameNode = xmldoc.CreateElement(Constants.TASK_GROUPNAME);
                        xn.AppendChild(objGroupNameNode);
                    }
                    xn.SelectSingleNode(Constants.TASK_GROUPNAME).InnerText = task.DatabaseServer.ServerName;
                    break;
                }
            }
        }

        private static void DeleteTaskNode(XmlDocument xmldoc, TaskInfo task)
        {
            XmlNode objTasksNode = xmldoc.SelectSingleNode(Constants.CONFIG_ROOT + Constants.CHAR_SLASH + Constants.TASK_TASKS);
            foreach (XmlNode xn in objTasksNode.ChildNodes)
            {
                if (xn.SelectSingleNode(Constants.TASK_TASKID).InnerText == task.TaskId)
                {
                    objTasksNode.RemoveChild(xn);
                    break;
                }
            }
        }

        private static bool IsExistTaskNode(XmlDocument xmldoc, TaskInfo task)
        {
            XmlNode objTasksNode = xmldoc.SelectSingleNode(Constants.CONFIG_ROOT + Constants.CHAR_SLASH + Constants.TASK_TASKS);
            foreach (XmlNode xn in objTasksNode.ChildNodes)
            {
                if (xn.SelectSingleNode(Constants.TASK_TASKID).InnerText == task.TaskId)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region GetTaskConfigFile
        private static XmlDocument GetTaskConfigFile(string taskid, string taskname)
        {
            try
            {
                //load config info
                string folder = Path.Combine(Application.StartupPath, Constants.FOLDER_TASKS);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                string configFile = Path.Combine(folder, String.Concat(taskid, ".xml"));
                if (!File.Exists(configFile))
                {
                    string configContent = UtilityHelper.GetTaskConfig(taskid, taskname);
                    StreamWriter sw = new StreamWriter(configFile);
                    sw.Write(configContent);
                    sw.Close();
                    sw = null;
                }

                XmlDocument objXmlDoc = new XmlDocument();

                objXmlDoc.Load(configFile);

                return objXmlDoc;
            }
            catch (Exception ex)
            {
                Log4Helper.Write("ConfigCtrl.GetTaskConfigFile:" + taskname, ex);
                throw;
            }
        }
        #endregion

        #region SetTaskConfigFile
        private static bool SetTaskConfigFile(XmlDocument xmldoc, string taskid)
        {
            try
            {
                string folder = Path.Combine(Application.StartupPath, Constants.FOLDER_TASKS);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                string configFile = Path.Combine(folder, String.Concat(taskid, ".xml"));
                xmldoc.Save(configFile);
                return true;
            }
            catch (Exception ex)
            {
                Log4Helper.Write("ConfigCtrl.SetTaskConfigFile" + taskid, ex);
                return false;
            }
        }
        #endregion

        #region GetTask
        public static TaskInfo GetTask(string taskid, string taskname)
        {
            try
            {
                XmlDocument objXmlDoc;
                TaskInfo task = new TaskInfo();

                if (taskid == null || taskid == string.Empty)
                    return null;

                objXmlDoc = GetTaskConfigFile(taskid, taskname);
                if (objXmlDoc == null)
                    return null;

                task.TaskId = taskid;
                task.TaskName = taskname;

                //root node
                XmlNode objTaskNode = objXmlDoc.SelectSingleNode(Constants.CONFIG_ROOT + Constants.CHAR_SLASH + Constants.TASK_TASK);
                if (objTaskNode == null)
                    return null;

                XmlNode objNode;
                DataView dv;
                /*------------------------------Code Generator-----------------------------------*/
                objNode = objTaskNode.SelectSingleNode(Constants.COMP_CODEGENERATOR);
                if (objNode != null)
                {
                    XmlNode nodeDbServer = objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_DBSERVER);
                    task.DatabaseServer.ServerName = DataConvert.GetString(nodeDbServer.SelectSingleNode(Constants.COMP_CODEGENERATOR_SERVERNAME).InnerText);
                    task.DatabaseServer.DatabaseName = DataConvert.GetString(nodeDbServer.SelectSingleNode(Constants.COMP_CODEGENERATOR_DATABASENAME).InnerText);
                    task.DatabaseServer.ConnectionString = DataConvert.GetString(nodeDbServer.SelectSingleNode(Constants.COMP_CODEGENERATOR_CONNECTIONSTRING).InnerText);
                    task.Solution = DataConvert.GetString(objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_SOLUTION).InnerText);
                    task.Project = DataConvert.GetString(objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_PROJECT).InnerText);
                    task.Template = DataConvert.GetString(objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_TEMPLATE).InnerText);
                    task.NameSpacePrefix = DataConvert.GetString(objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_NAMESPACEPREFIX).InnerText);
                    task.NameSpaceSuffix = DataConvert.GetString(objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_NAMESPACESUFFIX).InnerText);
                    /*------------------------------Tables-----------------------------------*/
                    dv = GetData(objXmlDoc, Constants.CONFIG_ROOT + Constants.CHAR_SLASH + Constants.TASK_TASK + Constants.CHAR_SLASH + Constants.COMP_CODEGENERATOR + Constants.CHAR_SLASH + Constants.COMP_CODEGENERATOR_TABLES);

                    Collection<TableInfo> tables = new Collection<TableInfo>();

                    for (int ix = 0; ix < dv.Table.Rows.Count; ix++)
                    {
                        TableInfo table = new TableInfo();
                        table.TableName = DataConvert.GetString(dv.Table.Rows[ix][0]);
                        tables.Add(table);
                    }
                    task.Tables = tables;
                    /*------------------------------Modules-----------------------------------*/
                    dv = GetData(objXmlDoc, Constants.CONFIG_ROOT + Constants.CHAR_SLASH + Constants.TASK_TASK + Constants.CHAR_SLASH + Constants.COMP_CODEGENERATOR + Constants.CHAR_SLASH + Constants.COMP_CODEGENERATOR_MODULES);

                    Collection<ModuleInfo> modules = new Collection<ModuleInfo>();

                    for (int ix = 0; ix < dv.Table.Rows.Count; ix++)
                    {
                        ModuleInfo module = new ModuleInfo();
                        module.ModuleName = DataConvert.GetString(dv.Table.Rows[ix][0]);
                        modules.Add(module);
                    }
                    task.Modules = modules;
                }
                /*------------------------------Code Generator-----------------------------------*/               

                /*------------------------------Miscellaneous-----------------------------------*/
                objNode = objTaskNode.SelectSingleNode(Constants.TASK_NODE_MISCELLANEOUS);
                if (objNode != null)
                {
                    if (objNode.SelectSingleNode(Constants.TASK_MISCELLANEOUS_WRITELOGTOFILE) != null)
                        task.WriteLogToFile = DataConvert.GetBool(objNode.SelectSingleNode(Constants.TASK_MISCELLANEOUS_WRITELOGTOFILE).InnerText);
                    else
                        task.WriteLogToFile = false;
                }
                /*------------------------------Miscellaneous-----------------------------------*/

                

                return task;
            }
            catch (Exception ex)
            {
                Log4Helper.Write("ConfigCtrl.GetTask", taskname + "(" + taskid.ToString() + ")", ex, LogSeverity.Fatal);
                throw;
            }
        }
        #endregion

        #region SetTask
        public static bool SetTask(string taskid, string taskname, TaskInfo taskitem)
        {
            try
            {
                if (taskid == null || taskid == string.Empty)
                    return false;

                XmlDocument objXmlDoc = GetTaskConfigFile(taskid, taskname);
                if (objXmlDoc == null)
                    return false;

                //root node
                XmlNode objTaskNode = objXmlDoc.SelectSingleNode(Constants.CONFIG_ROOT + Constants.CHAR_SLASH + Constants.TASK_TASK);
                if (objTaskNode == null)
                    return false;

                XmlNode objNode;
                /*------------------------------Code Generator-----------------------------------*/
                objNode = objTaskNode.SelectSingleNode(Constants.COMP_CODEGENERATOR);
                if (objNode != null)
                {
                    XmlNode objDbServer = objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_DBSERVER);
                    objDbServer.SelectSingleNode(Constants.COMP_CODEGENERATOR_SERVERNAME).InnerText = taskitem.DatabaseServer.ServerName;
                    objDbServer.SelectSingleNode(Constants.COMP_CODEGENERATOR_DATABASENAME).InnerText = taskitem.DatabaseServer.DatabaseName;
                    objDbServer.SelectSingleNode(Constants.COMP_CODEGENERATOR_CONNECTIONSTRING).InnerText = taskitem.DatabaseServer.ConnectionString;
                    objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_SOLUTION).InnerText = taskitem.Solution;
                    objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_PROJECT).InnerText = taskitem.Project;
                    objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_TEMPLATE).InnerText = taskitem.Template;
                    objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_NAMESPACEPREFIX).InnerText = taskitem.NameSpacePrefix;
                    objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_NAMESPACESUFFIX).InnerText = taskitem.NameSpaceSuffix;
                    /*------------------------------Tables-----------------------------------*/
                    XmlNode objTablesNode = objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_TABLES);
                    if (objTablesNode == null)
                        return false;

                    objTablesNode.RemoveAll();
                    foreach (TableInfo table in taskitem.Tables)
                    {
                        XmlElement objTableNode = objXmlDoc.CreateElement(Constants.COMP_CODEGENERATOR_TABLE);
                        objTablesNode.AppendChild(objTableNode);
                        XmlElement emtTableName = objXmlDoc.CreateElement(Constants.COMP_CODEGENERATOR_TABLENAME);
                        emtTableName.InnerText = table.TableName;
                        objTableNode.AppendChild(emtTableName);
                    }
                    /*------------------------------Modules-----------------------------------*/
                    XmlNode objModulesNode = objNode.SelectSingleNode(Constants.COMP_CODEGENERATOR_MODULES);
                    if (objModulesNode == null)
                        return false;

                    objModulesNode.RemoveAll();
                    foreach (ModuleInfo module in taskitem.Modules)
                    {
                        XmlElement objModuleNode = objXmlDoc.CreateElement(Constants.COMP_CODEGENERATOR_MODULE);
                        objModulesNode.AppendChild(objModuleNode);
                        XmlElement emtModuleName = objXmlDoc.CreateElement(Constants.COMP_CODEGENERATOR_MODULENAME);
                        emtModuleName.InnerText = module.ModuleName;
                        objModuleNode.AppendChild(emtModuleName);
                    }
                }
                /*------------------------------Code Generator-----------------------------------*/

                /*------------------------------Miscellaneous-----------------------------------*/
                objNode = objTaskNode.SelectSingleNode(Constants.TASK_NODE_MISCELLANEOUS);
                if (objNode != null)
                {
                    if (objNode.SelectSingleNode(Constants.TASK_MISCELLANEOUS_WRITELOGTOFILE) == null)
                    {
                        XmlElement objChildNode = objXmlDoc.CreateElement(Constants.TASK_MISCELLANEOUS_WRITELOGTOFILE);
                        objNode.AppendChild(objChildNode);
                    }
                    objNode.SelectSingleNode(Constants.TASK_MISCELLANEOUS_WRITELOGTOFILE).InnerText = taskitem.WriteLogToFile.ToString();
                }
                /*------------------------------Miscellaneous-----------------------------------*/
                
                //Main config file
                if (EditTask(taskitem) == Constants.STATUS_FAIL)
                    return false;

                return SetTaskConfigFile(objXmlDoc, taskid);

            }
            catch (Exception ex)
            {
                Log4Helper.Write("ConfigCtrl.SetTask:" + taskname, ex);
                return false;
            }
        }
        #endregion        

    }
}
