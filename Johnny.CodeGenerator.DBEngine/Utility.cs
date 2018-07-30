using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace Johnny.CodeGenerator.DBEngine
{
	/// <summary>
	/// Provides utility functions for the data tier generator.
	/// </summary>
	internal sealed class Utility
	{
        private Utility() { }

		/// <summary>
		/// Creates the specified sub-directory, if it doesn't exist.
		/// </summary>
		/// <param name="name">The name of the sub-directory to be created.</param>
		internal static void CreateSubDirectory(string name)
		{
			if (Directory.Exists(name) == false)
			{
				Directory.CreateDirectory(name);
			}
		}

		/// <summary>
		/// Creates the specified sub-directory, if it doesn't exist.
		/// </summary>
		/// <param name="name">The name of the sub-directory to be created.</param>
		/// <param name="deleteIfExists">Indicates if the directory should be deleted if it exists.</param>
		internal static void CreateSubDirectory(string name, bool deleteIfExists)
		{
			if (Directory.Exists(name))
			{
				Directory.Delete(name, true);
			}

			Directory.CreateDirectory(name);
		}

		/// <summary>
		/// Retrieves the specified manifest resource stream from the executing assembly.
		/// </summary>
		/// <param name="name">Name of the resource to retrieve.</param>
		/// <returns>A stream that contains the resource.</returns>
		internal static Stream GetResourceAsStream(string name)
		{
			return Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
		}

		/// <summary>
		/// Retrieves the specified manifest resource stream from the executing assembly as a string.
		/// </summary>
		/// <param name="name">Name of the resource to retrieve.</param>
		/// <returns>The value of the specified manifest resource.</returns>
		internal static string GetResource(string name)
		{
			using (StreamReader streamReader = new StreamReader(GetResourceAsStream(name)))
			{
				return streamReader.ReadToEnd();
			}
		}

		/// <summary>
		/// Retrieves the specified manifest resource stream from the executing assembly as a string, replacing the specified old value with the specified new value.
		/// </summary>
		/// <param name="name">Name of the resource to retrieve.</param>
		/// <param name="oldValue">A string to be replaced.</param>
		/// <param name="newValue">A string to replace all occurrences of oldValue.</param>
		/// <returns>The value of the specified manifest resource, with all instances of oldValue replaced with newValue.</returns>
		internal static string GetResource(string name, string oldValue, string newValue)
		{
			string returnValue = GetResource(name);
			return returnValue.Replace(oldValue, newValue);
		}

		/// <summary>
		/// Writes a compiled resource to a file.
		/// </summary>
		/// <param name="resourceName">The name of the resource.</param>
		/// <param name="fileName">The name of the file to write to.</param>
		internal static void WriteResourceToFile(string resourceName, string fileName)
		{
			using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
			{
				using (Stream stream = Utility.GetResourceAsStream(resourceName))
				{
					while (true)
					{
						int intValue = stream.ReadByte();
						if (intValue >= 0)
						{
							byte byteValue = (byte) intValue;
							fileStream.WriteByte(byteValue);
						}
						else
						{
							break;
						}
					}
				}
			}
		}

        /// <summary>
        /// Returns the query that should be used for retrieving the list of tables for the specified database.
        /// </summary>
        /// <param name="databaseName">The database to be queried for.</param>
        /// <returns>The query that should be used for retrieving the list of tables for the specified database.</returns>
        internal static string GetDatabaseQuery(string databaseName)
        {
            return GetResource("Johnny.CodeGenerator.DBEngine.SQL2005.DatabaseQuery.sql", "#DatabaseName#", databaseName);
        }

        /// <summary>
        /// Returns the query that should be used for retrieving the list of tables for the specified database.
        /// </summary>
        /// <param name="databaseName">The database to be queried for.</param>
        /// <returns>The query that should be used for retrieving the list of tables for the specified database.</returns>
        internal static string GetDatabaseAllQuery()
        {
            return GetResource("Johnny.CodeGenerator.DBEngine.SQL2005.DatabaseAllQuery.sql");
        }

		/// <summary>
		/// Returns the query that should be used for retrieving the list of tables for the specified database.
		/// </summary>
		/// <param name="databaseName">The database to be queried for.</param>
		/// <returns>The query that should be used for retrieving the list of tables for the specified database.</returns>
		internal static string GetTableQuery(string databaseName)
		{
            return GetResource("Johnny.CodeGenerator.DBEngine.SQL2005.TableQuery.sql", "#DatabaseName#", databaseName);
		}

        /// <summary>
        /// Returns the query that should be used for retrieving the list of tables for the specified database.
        /// </summary>
        /// <param name="databaseName">The database to be queried for.</param>
        /// <returns>The query that should be used for retrieving the list of tables for the specified database.</returns>
        internal static string GetViewQuery()
        {
            return GetResource("Johnny.CodeGenerator.DBEngine.SQL2005.ViewQuery.sql");
        }

		/// <summary>
		/// Returns the query that should be used for retrieving the list of columns for the specified table.
		/// </summary>
		/// <param name="databaseName">The table to be queried for.</param>
		/// <returns>The query that should be used for retrieving the list of columns for the specified table.</returns>
		internal static string GetColumnQuery(string tableName)
		{
            return GetResource("Johnny.CodeGenerator.DBEngine.SQL2005.ColumnQuery.sql", "#TableName#", tableName);
		}

        /// <summary>
        /// Returns the query that should be used for retrieving the list of columns for the specified table.
        /// </summary>
        /// <param name="databaseName">The table to be queried for.</param>
        /// <returns>The query that should be used for retrieving the list of columns for the specified table.</returns>
        internal static string GetGridColumnQuery(string tableName)
        {
            return GetResource("Johnny.CodeGenerator.Core.Resources.GridColumn.sql", "#TableName#", tableName);
        }

		/// <summary>
		/// Retrieves the specified manifest resource stream from the executing assembly as a string, replacing the specified old value with the specified new value.
		/// </summary>
		/// <param name="name">Name of the resource to retrieve.</param>
		/// <param name="databaseName">The name of the database to be used.</param>
		/// <param name="grantLoginName">The name of the user to be used.</param>
		/// <returns>The queries that should be used to create the specified database login.</returns>
		internal static string GetUserQueries(string databaseName, string grantLoginName)
		{
			string returnValue = GetResource("Johnny.CodeGenerator.Core.Resources.User.sql");
			returnValue = returnValue.Replace("#DatabaseName#", databaseName);
			returnValue = returnValue.Replace("#UserName#", grantLoginName);
			return returnValue;
		}

		/// <summary>
		/// Returns the query that should be used for retrieving the list of tables for the specified database.
		/// </summary>
		/// <param name="databaseName">The database to be queried for.</param>
		/// <returns>The query that should be used for retrieving the list of tables for the specified database.</returns>
		internal static string Get(string databaseName)
		{
			return GetResource("Johnny.CodeGenerator.Core.Resources.TableQuery.sql", "#DatabaseName#", databaseName);
		}

		/// <summary>
		/// Retrieves the foreign key information for the specified table.
		/// </summary>
		/// <param name="connection">The SqlConnection to be used when querying for the table information.</param>
		/// <param name="tableName">Name of the table that foreign keys should be checked for.</param>
		/// <returns>DataReader containing the foreign key information for the specified table.</returns>
		internal static DataTable GetForeignKeyList(SqlConnection connection, string tableName)
		{
			SqlParameter parameter;

			using (SqlCommand command = new SqlCommand("sp_fkeys", connection))
			{
				command.CommandType = CommandType.StoredProcedure;

				parameter = new SqlParameter("@pktable_name", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "pktable_name", DataRowVersion.Current, DBNull.Value);
				command.Parameters.Add(parameter);
				parameter = new SqlParameter("@pktable_owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "pktable_owner", DataRowVersion.Current, DBNull.Value);
				command.Parameters.Add(parameter);
				parameter = new SqlParameter("@pktable_qualifier", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "pktable_qualifier", DataRowVersion.Current, DBNull.Value);
				command.Parameters.Add(parameter);
				parameter = new SqlParameter("@fktable_name", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "fktable_name", DataRowVersion.Current, tableName);
				command.Parameters.Add(parameter);
				parameter = new SqlParameter("@fktable_owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "fktable_owner", DataRowVersion.Current, DBNull.Value);
				command.Parameters.Add(parameter);
				parameter = new SqlParameter("@fktable_qualifier", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "fktable_qualifier", DataRowVersion.Current, DBNull.Value);
				command.Parameters.Add(parameter);

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
				DataTable dataTable = new DataTable();
				dataAdapter.Fill(dataTable);

				return dataTable;
			}
		}

		/// <summary>
		/// Retrieves the primary key information for the specified table.
		/// </summary>
		/// <param name="connection">The SqlConnection to be used when querying for the table information.</param>
		/// <param name="tableName">Name of the table that primary keys should be checked for.</param>
		/// <returns>DataReader containing the primary key information for the specified table.</returns>
		internal static DataTable GetPrimaryKeyList(SqlConnection connection, string tableName)
		{
			SqlParameter parameter;

			using (SqlCommand command = new SqlCommand("sp_pkeys", connection))
			{
				command.CommandType = CommandType.StoredProcedure;

				parameter = new SqlParameter("@table_name", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "table_name", DataRowVersion.Current, tableName);
				command.Parameters.Add(parameter);
				parameter = new SqlParameter("@table_owner", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "table_owner", DataRowVersion.Current, DBNull.Value);
				command.Parameters.Add(parameter);
				parameter = new SqlParameter("@table_qualifier", SqlDbType.NVarChar, 128, ParameterDirection.Input, true, 0, 0, "table_qualifier", DataRowVersion.Current, DBNull.Value);
				command.Parameters.Add(parameter);

				SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
				DataTable dataTable = new DataTable();
				dataAdapter.Fill(dataTable);

				return dataTable;
			}
		}

		/// <summary>
		/// Creates a string containing the parameter declaration for a stored procedure based on the parameters passed in.
		/// </summary>
		/// <param name="column">Object that stores the information for the column the parameter represents.</param>
		/// <param name="checkForOutputParameter">Indicates if the created parameter should be checked to see if it should be created as an output parameter.</param>
		/// <returns>String containing parameter information of the specified column for a stored procedure.</returns>
        //internal static string CreateParameterString(Column column, bool checkForOutputParameter)
        //{
        //    string parameter;

        //    switch (column.Type.ToLower())
        //    {
        //        case "binary":
        //            parameter = "@" + column.Name + " " + column.Type + "(" + column.Length + ")";
        //            break;
        //        case "bigint":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "bit":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "char":
        //            parameter = "@" + column.Name + " " + column.Type + "(" + column.Length + ")";
        //            break;
        //        case "datetime":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "decimal":
        //            if (column.Scale.Length == 0)
        //                parameter = "@" + column.Name + " " + column.Type + "(" + column.Precision + ")";
        //            else
        //                parameter = "@" + column.Name + " " + column.Type + "(" + column.Precision + ", " + column.Scale + ")";
        //            break;
        //        case "float":
        //            parameter = "@" + column.Name + " " + column.Type + "(" + column.Precision + ")";
        //            break;
        //        case "image":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "int":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "money":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "nchar":
        //            parameter = "@" + column.Name + " " + column.Type + "(" + column.Length + ")";
        //            break;
        //        case "ntext":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "nvarchar":
        //            parameter = "@" + column.Name + " " + column.Type + "(" + column.Length + ")";
        //            break;
        //        case "numeric":
        //            if (column.Scale.Length == 0)
        //                parameter = "@" + column.Name + " " + column.Type + "(" + column.Precision + ")";
        //            else
        //                parameter = "@" + column.Name + " " + column.Type + "(" + column.Precision + ", " + column.Scale + ")";
        //            break;
        //        case "real":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "smalldatetime":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "smallint":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "smallmoney":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "sql_variant":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "sysname":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "text":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "timestamp":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "tinyint":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        case "varbinary":
        //            parameter = "@" + column.Name + " " + column.Type + "(" + column.Length + ")";
        //            break;
        //        case "varchar":
        //            parameter = "@" + column.Name + " " + column.Type + "(" + column.Length + ")";
        //            break;
        //        case "uniqueidentifier":
        //            parameter = "@" + column.Name + " " + column.Type;
        //            break;
        //        default:  // Unknow data type
        //            throw (new Exception("Invalid SQL Server data type specified: " + column.Type));
        //    }

        //    // Return the new parameter string
        //    if (checkForOutputParameter && (column.IsIdentity || column.IsRowGuidCol))
        //    {
        //        return parameter + " OUTPUT";
        //    }
        //    else
        //    {
        //        return parameter;
        //    }
        //}

		/// <summary>
		/// Creates a string for a method parameter representing the specified column.
		/// </summary>
		/// <param name="column">Object that stores the information for the column the parameter represents.</param>
		/// <returns>String containing parameter information of the specified column for a method call.</returns>
        //internal static string CreateMethodParameter(Column column)
        //{
        //    return GetCsType(column) + " " + FormatCamel(column.Name);;
        //}
		
		/// <summary>
		/// Creates the name of the method to call on a SqlDataReader for the specified column.
		/// </summary>
		/// <param name="column">The column to retrieve data for.</param>
		/// <returns>The name of the method to call on a SqlDataReader for the specified column.</returns>
        //internal static string GetCsType(Column column)
        //{
        //    switch (column.Type.ToLower())
        //    {
        //        case "binary":
        //            return "byte[]";
        //        case "bigint":
        //            return "long";
        //        case "bit":
        //            return "bool";
        //        case "char":
        //            return "string";
        //        case "datetime":
        //            return "DateTime";
        //        case "decimal":
        //            return "decimal";
        //        case "float":
        //            return "float";
        //        case "image":
        //            return "byte[]";
        //        case "int":
        //            return "int";
        //        case "money":
        //            return "decimal";
        //        case "nchar":
        //            return "string";
        //        case "ntext":
        //            return "string";
        //        case "nvarchar":
        //            return "string";
        //        case "numeric":
        //            return "decimal";
        //        case "real":
        //            return "decimal";
        //        case "smalldatetime":
        //            return "DateTime";
        //        case "smallint":
        //            return "short";
        //        case "smallmoney":
        //            return "float";
        //        case "sql_variant":
        //            return "byte[]";
        //        case "sysname":
        //            return "string";
        //        case "text":
        //            return "string";
        //        case "timestamp":
        //            return "DateTime";
        //        case "tinyint":
        //            return "byte";
        //        case "varbinary":
        //            return "byte[]";
        //        case "varchar":
        //            return "string";
        //        case "uniqueidentifier":
        //            return "Guid";
        //        default:  // Unknow data type
        //            throw (new Exception("Invalid SQL Server data type specified: " + column.Type));
        //    }
        //}

		/// <summary>
		/// Creates the GetXxx method to use for the specified column.
		/// </summary>
		/// <param name="column">The column to retrieve data for.</param>
		/// <returns>The name of the method to call on a SqlDataReader for the specified column.</returns>
        //internal static string GetXxxMethod(Column column)
        //{
        //    switch (column.Type.ToLower())
        //    {
        //        case "binary":
        //            return "GetBytes";
        //        case "bigint":
        //            return "GetInt64";
        //        case "bit":
        //            return "GetBoolean";
        //        case "char":
        //            return "GetString";
        //        case "datetime":
        //            return "GetDateTime";
        //        case "decimal":
        //            return "GetDecimal";
        //        case "float":
        //            return "GetFloat";
        //        case "image":
        //            return "GetBytes";
        //        case "int":
        //            return "GetInt32";
        //        case "money":
        //            return "GetDecimal";
        //        case "nchar":
        //            return "GetString";
        //        case "ntext":
        //            return "GetString";
        //        case "nvarchar":
        //            return "GetString";
        //        case "numeric":
        //            return "GetDecimal";
        //        case "real":
        //            return "GetDecimal";
        //        case "smalldatetime":
        //            return "GetDateTime";
        //        case "smallint":
        //            return "GetIn16";
        //        case "smallmoney":
        //            return "GetFloat";
        //        case "sql_variant":
        //            return "GetBytes";
        //        case "sysname":
        //            return "GetString";
        //        case "text":
        //            return "GetString";
        //        case "timestamp":
        //            return "GetDateTime";
        //        case "tinyint":
        //            return "GetByte";
        //        case "varbinary":
        //            return "GetBytes";
        //        case "varchar":
        //            return "GetString";
        //        case "uniqueidentifier":
        //            return "GetGuid";
        //        default:  // Unknow data type
        //            throw (new Exception("Invalid SQL Server data type specified: " + column.Type));
        //    }
        //}
		
        ///// <summary>
        ///// Creates a string for the default value of a column's data type.
        ///// </summary>
        ///// <param name="column">The column to get a default value for.</param>
        ///// <returns>The default value for the column.</returns>
        //internal static string GetDefaultValue(Column column)
        //{
        //    switch (column.Type.ToLower())
        //    {
        //        case "binary":
        //            return "new byte[0]";
        //        case "bigint":
        //            return "0";
        //        case "bit":
        //            return "false";
        //        case "char":
        //            return "String.Empty";
        //        case "datetime":
        //            return "DateTime.Now";
        //        case "decimal":
        //            return "Decimal.Zero";
        //        case "float":
        //            return "0.0F";
        //        case "image":
        //            return "new byte[0]";
        //        case "int":
        //            return "0";
        //        case "money":
        //            return "Decimal.Zero";
        //        case "nchar":
        //            return "String.Empty";
        //        case "ntext":
        //            return "String.Empty";
        //        case "nvarchar":
        //            return "String.Empty";
        //        case "numeric":
        //            return "Decimal.Zero";
        //        case "real":
        //            return "Decimal.Zero";
        //        case "smalldatetime":
        //            return "DateTime.Now";
        //        case "smallint":
        //            return "0";
        //        case "smallmoney":
        //            return "0.0F";
        //        case "sql_variant":
        //            return "new byte[0]";
        //        case "sysname":
        //            return "String.Empty";
        //        case "text":
        //            return "String.Empty";
        //        case "timestamp":
        //            return "DateTime.Now";
        //        case "tinyint":
        //            return "0x00";
        //        case "varbinary":
        //            return "new byte[0]";
        //        case "varchar":
        //            return "String.Empty";
        //        case "uniqueidentifier":
        //            return "Guid.Empty";
        //        default:  // Unknow data type
        //            throw (new Exception("Invalid SQL Server data type specified: " + column.Type));
        //    }
        //}

		/// <summary>
		/// Formats a string in Camel case (the first letter is in lower case).
		/// </summary>
		/// <param name="original">A string to be formatted.</param>
		/// <returns>A string in Camel case.</returns>
		internal static string FormatCamel(string original)
		{
			if (original.Length > 0)
			{
				return Char.ToLower(original[0]) + original.Substring(1);
			}
			else
			{
				return String.Empty;
			}
		}

		/// <summary>
		/// Formats a string in Pascal case (the first letter is in upper case).
		/// </summary>
		/// <param name="original">A string to be formatted.</param>
		/// <returns>A string in Pascal case.</returns>
		internal static string FormatPascal(string original)
		{
			if (original.Length > 0)
			{
				return Char.ToUpper(original[0]) + original.Substring(1);
			}
			else
			{
				return String.Empty;
			}
		}

		/// <summary>
		/// Formats the table name for use as a data transfer object.
		/// </summary>
		/// <param name="tableName">The name of the table to format.</param>
		/// <returns>The table name, formatted for use as a data transfer object.</returns>
		internal static string FormatClassName(string tableName)
		{
			string className;

			if (Char.IsUpper(tableName[0]))
			{
				className = tableName;
			}
			else
			{
				className = FormatPascal(tableName);
			}

			// Attept to removing a trailing 's' or 'S', unless, the last two characters are both 's' or 'S'.
			if (className[className.Length - 1] == 'S' && className[className.Length - 2] != 'S')
			{
				className = className.Substring(0, className.Length - 1);
			}
			else if (className[className.Length - 1] == 's' && className[className.Length - 2] != 's')
			{
				className = className.Substring(0, className.Length - 1);
			}

			return className;
		}

		/// <summary>
		/// Matches a SQL Server data type to a SqlClient.SqlDbType.
		/// </summary>
		/// <param name="sqlDbType">A string representing a SQL Server data type.</param>
		/// <returns>A string representing a SqlClient.SqlDbType.</returns>
		internal static string GetSqlDbType(string sqlDbType)
		{
			switch (sqlDbType.ToLower())
			{
				case "binary":
					return "Binary";
				case "bigint":
					return "BigInt";
				case "bit":
					return "Bit";
				case "char":
					return "Char";
				case "datetime":
					return "DateTime";
				case "decimal":
					return "Decimal";
				case "float":
					return "Float";
				case "image":
					return "Image";
				case "int":
					return "Int";
				case "money":
					return "Money";
				case "nchar":
					return "NChar";
				case "ntext":
					return "NText";
				case "nvarchar":
					return "NVarChar";
				case "numeric":
					return "Decimal";
				case "real":
					return "Real";
				case "smalldatetime":
					return "SmallDateTime";
				case "smallint":
					return "SmallInt";
				case "smallmoney":
					return "SmallMoney";
				case "sql_variant":
					return "Variant";
				case "sysname":
					return "VarChar";
				case "text":
					return "Text";
				case "timestamp":
					return "Timestamp";
				case "tinyint":
					return "TinyInt";
				case "varbinary":
					return "VarBinary";
				case "varchar":
					return "VarChar";
				case "uniqueidentifier":
					return "UniqueIdentifier";
				default:  // Unknow data type
					throw (new Exception("Invalid SQL Server data type specified: " + sqlDbType));
			}
		}

		/// <summary>
		/// Creates a string for a SqlParameter representing the specified column.
		/// </summary>
		/// <param name="column">Object that stores the information for the column the parameter represents.</param>
		/// <returns>String containing SqlParameter information of the specified column for a method call.</returns>
        //internal static string CreateSqlParameter(Table table, Column column)
        //{
        //    string className = Utility.FormatClassName(table.Name);
        //    string variableName = Utility.FormatCamel(className);
			
        //    return "new SqlParameter(\"@" + column.Name + "\", " + variableName + "." + FormatPascal(column.Name) + ")";
        //}
	}
}
