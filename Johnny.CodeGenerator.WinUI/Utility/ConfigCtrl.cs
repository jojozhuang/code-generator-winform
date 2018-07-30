using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Forms;

using Johnny.Library.Helper;
using Johnny.Library.Log;

namespace Johnny.CodeGenerator.WinUI.Utility
{
    public sealed class ConfigCtrl
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

        private static string GetFolderName(string path)
        {
            if (path == null || path == string.Empty)
                return "";
            return path.Substring(path.LastIndexOf("\\") + 1);
        }

        private static XmlNode GetAppendNode(XmlNode parentNode, XmlDocument objXmlDoc, string nodename, string defaultvalue)
        {
            XmlNode target = parentNode.SelectSingleNode(nodename);
            if (target == null)
            {
                XmlElement objChildNode = objXmlDoc.CreateElement(nodename);
                if (!String.IsNullOrEmpty(defaultvalue))
                    objChildNode.InnerText = defaultvalue;
                parentNode.AppendChild(objChildNode);
                target = parentNode.SelectSingleNode(nodename);
            }
            return target;
        }
        #endregion

        #region GetToolboxItemsConfigFile
        public static XmlDocument GetToolboxItemsConfigFile()
        {
            try
            {
                //load config info
                string configFile = Path.Combine(Application.StartupPath, MainConstants.FILE_TOOLBOXITEMS);
                if (!File.Exists(configFile))
                {
                    throw new FileNotFoundException("File not found", configFile);
                }

                XmlDocument objXmlDoc = new XmlDocument();

                objXmlDoc.Load(configFile);

                return objXmlDoc;
            }
            catch (FileNotFoundException fx)
            {
                Log4Helper.Write("GetToolboxItemsConfigFile", fx.FileName, fx, LogSeverity.Error);
                return null;
            }
            catch (Exception ex)
            {
                Log4Helper.Write("GetToolboxItemsConfigFile", ex);
                return null;
            }
        }
        #endregion        
    }
}
