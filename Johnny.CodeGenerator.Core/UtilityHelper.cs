using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Security.Principal;

namespace Johnny.CodeGenerator.Core
{
    public sealed class UtilityHelper
    {
        private UtilityHelper() { }

        public static string GetCgConfig()
        {
            return GetResource("Johnny.CodeGenerator.Core.Resources.CgConfig.xml");
        }
        public static string GetTaskConfig(string taskid, string taskname)
        {
            return GetResource("Johnny.CodeGenerator.Core.Resources.TaskConfig.xml", "#TaskId#", taskid, "#TaskName#", taskname);
        }
        internal static string GetResource(string name, string oldValue, string newValue, string oldValue2, string newValue2)
        {
            string returnValue = GetResource(name);
            returnValue = returnValue.Replace(oldValue, newValue);
            return returnValue.Replace(oldValue2, newValue2);
        }

        internal static string GetResource(string name, string oldValue, string newValue)
        {
            string returnValue = GetResource(name);
            return returnValue.Replace(oldValue, newValue);
        }

        internal static string GetResource(string name)
        {
            using (StreamReader streamReader = new StreamReader(GetResourceAsStream(name)))
            {
                return streamReader.ReadToEnd();
            }
        }

        internal static Stream GetResourceAsStream(string name)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
        }

        /// <summary>
        /// GetCurrentIdentityName retrieve the current threading identity name or windows identity name (when threading current pricipal is null).
        /// </summary>
        /// <returns>a string contains the crrent user identity name or empty string. </returns>
        public static string GetCurrentIdentityName()
        {
            string retVal = "";
            if (Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null)
            {
                retVal = Thread.CurrentPrincipal.Identity.Name;
            }
            if (String.IsNullOrEmpty(retVal))
            {
                WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                if (windowsIdentity != null)
                {
                    retVal = windowsIdentity.Name;
                }
            }
            return retVal;
        }

        /// <summary>
        /// Creates the GetXxx method to use for the specified column.
        /// </summary>
        /// <param name="column">The column to retrieve data for.</param>
        /// <returns>The name of the method to call on a SqlDataReader for the specified column.</returns>
        internal static string GetXxxMethod(Johnny.CodeGenerator.Core.ColumnInfo column)
        {
            switch (column.DataType.ToLower())
            {
                case "binary":
                    return "GetBytes";
                case "bigint":
                    return "GetInt64";
                case "bit":
                    return "GetBoolean";
                case "char":
                    return "GetString";
                case "datetime":
                    return "GetDateTime";
                case "decimal":
                    return "GetDecimal";
                case "float":
                    return "GetFloat";
                case "image":
                    return "GetBytes";
                case "int":
                    return "GetInt32";
                case "money":
                    return "GetDecimal";
                case "nchar":
                    return "GetString";
                case "ntext":
                    return "GetString";
                case "nvarchar":
                    return "GetString";
                case "numeric":
                    return "GetDecimal";
                case "real":
                    return "GetDecimal";
                case "smalldatetime":
                    return "GetDateTime";
                case "smallint":
                    return "GetIn16";
                case "smallmoney":
                    return "GetFloat";
                case "sql_variant":
                    return "GetBytes";
                case "sysname":
                    return "GetString";
                case "text":
                    return "GetString";
                case "timestamp":
                    return "GetDateTime";
                case "tinyint":
                    return "GetByte";
                case "varbinary":
                    return "GetBytes";
                case "varchar":
                    return "GetString";
                case "uniqueidentifier":
                    return "GetGuid";
                default:  // Unknow data type
                    throw (new Exception("Invalid SQL Server data type specified: " + column.DataType));
            }
        }

        /// <summary>
        /// Creates the GetPattern method to use for the specified column.
        /// </summary>
        /// <param name="column">The column to retrieve data for.</param>
        /// <returns>The name of the method to call on a SqlDataReader for the specified column.</returns>
        public static string GetPattern(string columntype)
        {
            switch (columntype.ToLower())
            {
                case "binary":
                    return "Yes";
                case "bigint":
                    return "No";
                case "bit":
                    return "Boolean";
                case "char":
                    return "Yes";
                case "datetime":
                    return "Yes";
                case "decimal":
                    return "No";
                case "float":
                    return "No";
                case "image":
                    return "Yes";
                case "int":
                    return "No";
                case "money":
                    return "No";
                case "nchar":
                    return "Yes";
                case "ntext":
                    return "Yes";
                case "nvarchar":
                    return "Yes";
                case "numeric":
                    return "No";
                case "real":
                    return "No";
                case "smalldatetime":
                    return "Yes";
                case "smallint":
                    return "No";
                case "smallmoney":
                    return "No";
                case "sql_variant":
                    return "Yes";
                case "sysname":
                    return "Yes";
                case "text":
                    return "Yes";
                case "timestamp":
                    return "Yes";
                case "tinyint":
                    return "No";
                case "varbinary":
                    return "Yes";
                case "varchar":
                    return "Yes";
                case "uniqueidentifier":
                    return "Yes";
                default:  // Unknow data type
                    throw (new Exception("Invalid SQL Server data type specified: " + columntype));
            }
        }


    }
}
