using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Johnny.Library.Database;

namespace Johnny.CodeGenerator.DBEngine
{
    public class Sql2kDriver
    {
        /// <summary>
        /// GetDataBases
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="servername"></param>
        /// <param name="databasename"></param>
        /// <returns></returns>
        public static DataTable GetDataBases(string connectionstring, string servername, string databasename)
        {
            string strSql = "";
            if (String.IsNullOrEmpty(databasename))
                strSql = Utility.GetDatabaseAllQuery();
            else
                strSql = Utility.GetDatabaseQuery(databasename);

            return SqlHelper.ExecuteDataset(connectionstring, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// GetTables
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="databasename"></param>
        /// <returns></returns>
        public static DataTable GetTables(string connectionstring, string databasename)
        {
            return SqlHelper.ExecuteDataset(connectionstring + "Database=" + databasename + ";", CommandType.Text, Utility.GetTableQuery(databasename)).Tables[0];
        }

        /// <summary>
        /// GetViews
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="DatabaseName"></param>
        /// <returns></returns>
        public static DataTable GetViews(string connectionstring, string databasename)
        {
            return SqlHelper.ExecuteDataset(connectionstring + "Database=" + databasename + ";", CommandType.Text, Utility.GetViewQuery()).Tables[0];
        }

        /// <summary>
        /// GetColumns
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataTable GetColumns(string connectionstring, string tablename)
        {
            return SqlHelper.ExecuteDataset(connectionstring, CommandType.Text, Utility.GetColumnQuery(tablename)).Tables[0];
        }
    }
}
