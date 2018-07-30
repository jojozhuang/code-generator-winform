using System;
using System.Data;
using System.Collections.ObjectModel;

using Johnny.CodeGenerator.Core;
using Johnny.CodeGenerator.DBEngine;
using Johnny.Library.Helper;

namespace Johnny.CodeGenerator.Core
{
    public sealed class DatabaseCtrl
    {
        public static Collection<DatabaseInfo> GetDataBases(ServerInfo server)
        {
            return GetDataBases(server.ConnectionString, server.ServerName, server.DatabaseName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionstring"></param>
        /// <param name="servername"></param>
        /// <param name="databasename"></param>
        /// <returns></returns>
        public static Collection<DatabaseInfo> GetDataBases(string connectionstring, string servername, string databasename)
        {
            Collection<DatabaseInfo> dbs = new Collection<DatabaseInfo>();

            DataTable dt = Sql2kDriver.GetDataBases(connectionstring, servername, databasename);
            foreach (DataRow dataRow in dt.Rows)
            {
                dbs.Add(new DatabaseInfo(connectionstring, servername, (string)dataRow[0]));
            }

            return dbs;
        }

        public static Collection<TableInfo> GetTables(DatabaseInfo database)
        {
            return GetTables(database.ConnectionString, database.ServerName, database.DatabaseName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="ServerName"></param>
        /// <param name="DatabaseName"></param>
        /// <returns></returns>
        public static Collection<TableInfo> GetTables(string connectionstring, string servername, string databasename)
        {
            Collection<TableInfo> tbls = new Collection<TableInfo>();

            DataTable dt = Sql2kDriver.GetTables(connectionstring, databasename);
            foreach (DataRow dataRow in dt.Rows)
            {
                TableInfo tb = new TableInfo((string)dataRow["TABLE_NAME"], (string)dataRow["TABLE_SCHEMA"]);
                tb.ServerName = servername;
                tb.DatabaseName = databasename;
                tb.Columns = GetColumns(connectionstring + "Database=" + databasename + ";", (string)dataRow["TABLE_NAME"]);
                tbls.Add(tb);
            }

            return tbls;
        }

        public static Collection<ViewInfo> GetViews(DatabaseInfo database)
        {
            return GetViews(database.ConnectionString, database.DatabaseName);
        }

        public static Collection<ViewInfo> GetViews(string connectionstring, string databasename)
        {
            Collection<ViewInfo> views = new Collection<ViewInfo>();

            DataTable dt = Sql2kDriver.GetViews(connectionstring, databasename);

            foreach (DataRow dataRow in dt.Rows)
            {
                ViewInfo tb = new ViewInfo((string)dataRow["VIEW_NAME"], (string)dataRow["TABLE_SCHEMA"]);
                tb.Columns = GetColumns(connectionstring + "Database=" + databasename + ";", (string)dataRow["VIEW_NAME"]);
                views.Add(tb);
            }

            return views;
        }

        public static Collection<ColumnInfo> GetColumns(string connectionstring, string tablename)
        {
            Collection<ColumnInfo> columns = new Collection<ColumnInfo>();

            DataTable dt = Sql2kDriver.GetColumns(connectionstring, tablename);

            foreach (DataRow dataRow in dt.Rows)
            {
                ColumnInfo column = new ColumnInfo();
                column.Sequence = DataConvert.GetInt32(dataRow["Sequence"]);
                column.ColumnName = DataConvert.GetString(dataRow["Column_Name"]);
                column.DataType = DataConvert.GetString(dataRow["Data_Type"]);
                column.ColumnLength = DataConvert.GetInt32(dataRow["Column_Length"]);
                column.PrecisionLength = DataConvert.GetInt32(dataRow["Precision_Length"]);
                column.Scale = DataConvert.GetInt32(dataRow["Scale"]);
                column.DefaultValue = DataConvert.GetString(dataRow["Default_Value"]);
                column.ColumnDescription = DataConvert.GetString(dataRow["Column_Description"]);
                column.IsIdentity = DataConvert.GetBool(DataConvert.GetInt32(dataRow["IsIdentity"]));
                column.IsPrimaryKey = DataConvert.GetBool(DataConvert.GetInt32(dataRow["IsPrimaryKey"]));
                column.IsNullable = DataConvert.GetBool(DataConvert.GetInt32(dataRow["IsNullable"]));
                columns.Add(column);
            }

            return columns;
        }
    }
}
