using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Text;

using Johnny.Library.Log;
using Johnny.Library.Helper;
using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.Core
{
    //public delegate void CountUpdate(object sender, CountEventArgs e);

	/// <summary>
	/// Generates C# and SQL code for accessing a database.
	/// </summary>
	public class Generator
    {
        /*
        #region old
        public static event CountUpdate DatabaseCounted;
		public static event CountUpdate TableCounted;

		/// <summary>
		/// Generates the SQL and C# code for the specified database.
		/// </summary>
		/// <param name="outputDirectory">The directory where the C# and SQL code should be created.</param>
		/// <param name="connectionString">The connection string to be used to connect the to the database.</param>
		/// <param name="grantLoginName">The SQL Server login name that should be granted execute rights on the generated stored procedures.</param>
		/// <param name="storedProcedurePrefix">The prefix that should be used when creating stored procedures.</param>
		/// <param name="createMultipleFiles">A flag indicating if the generated stored procedures should be created in one file or separate files.</param>
		/// <param name="targetNamespace">The namespace that the generated C# classes should contained in.</param>
		/// <param name="daoSuffix">The suffix to be applied to all generated DAO classes.</param>
		public static void Generate(string outputDirectory, string connectionString, string grantLoginName, string storedProcedurePrefix, bool createMultipleFiles, string targetNamespace, string daoSuffix)
		{
			List<Table> tableList = new List<Table>();
			string databaseName;
			string sqlPath;
			string csPath;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				databaseName = Utility.FormatPascal(connection.Database);
				sqlPath = Path.Combine(outputDirectory, "SQL");
				csPath = Path.Combine(outputDirectory, "CS");

				connection.Open();

				// Get a list of the entities in the database
				DataTable dataTable = new DataTable();
				SqlDataAdapter dataAdapter = new SqlDataAdapter(Utility.GetTableQuery(connection.Database), connection);
				dataAdapter.Fill(dataTable);

				// Process each table
				foreach (DataRow dataRow in dataTable.Rows)
				{
					Table table = new Table();
					table.Name = (string) dataRow["TABLE_NAME"];
					QueryTable(connection, table);
					tableList.Add(table);
				}
			}

			DatabaseCounted(null, new CountEventArgs(tableList.Count));

			// Generate the necessary SQL and C# code for each table
			int count = 0;
			if (tableList.Count > 0)
			{
				// Create the necessary directories
				Utility.CreateSubDirectory(sqlPath, true);
				Utility.CreateSubDirectory(csPath, true);
				Utility.CreateSubDirectory(Path.Combine(csPath, "Data"), true);
				Utility.CreateSubDirectory(Path.Combine(csPath, "Data\\Mocks"), true);
				Utility.CreateSubDirectory(Path.Combine(csPath, "Services"), true);

				// Create the necessary database logins
				SqlGenerator.CreateUserQueries(databaseName, grantLoginName, sqlPath, createMultipleFiles);

				// Create the CRUD stored procedures and data access code for each table
				foreach (Table table in tableList)
				{
					SqlGenerator.CreateInsertStoredProcedure(table, grantLoginName, storedProcedurePrefix, sqlPath, createMultipleFiles);
					SqlGenerator.CreateUpdateStoredProcedure(table, grantLoginName, storedProcedurePrefix, sqlPath, createMultipleFiles);
					SqlGenerator.CreateDeleteStoredProcedure(table, grantLoginName, storedProcedurePrefix, sqlPath, createMultipleFiles);
					SqlGenerator.CreateDeleteAllByStoredProcedures(table, grantLoginName, storedProcedurePrefix, sqlPath, createMultipleFiles);
					SqlGenerator.CreateSelectStoredProcedure(table, grantLoginName, storedProcedurePrefix, sqlPath, createMultipleFiles);
					SqlGenerator.CreateSelectAllStoredProcedure(table, grantLoginName, storedProcedurePrefix, sqlPath, createMultipleFiles);
					SqlGenerator.CreateSelectAllByStoredProcedures(table, grantLoginName, storedProcedurePrefix, sqlPath, createMultipleFiles);

					CsGenerator.CreateDataTransferClass(table, targetNamespace, storedProcedurePrefix, csPath);
					CsGenerator.CreateDataAccessClass(databaseName, table, targetNamespace, storedProcedurePrefix, daoSuffix, csPath);
					CsGenerator.CreateMockClass(table, targetNamespace, storedProcedurePrefix, daoSuffix, csPath);

					count++;
					TableCounted(null, new CountEventArgs(count));
				}

				CsGenerator.CreateSharpCore(csPath);
				CsGenerator.CreateAssemblyInfo(csPath, databaseName, databaseName);
				CsGenerator.CreateService(csPath, targetNamespace);
				CsGenerator.CreateServiceUtility(csPath, targetNamespace);
				CsGenerator.CreateProjectFile(csPath, databaseName, tableList, daoSuffix);
				ConfigGenerator.CreateAppConfig(outputDirectory, tableList, databaseName, connectionString, targetNamespace, daoSuffix);
				ConfigGenerator.CreateMockConfig(outputDirectory, tableList, databaseName, connectionString, targetNamespace, daoSuffix);
			}
		}

		/// <summary>
		/// Retrieves the column, primary key, and foreign key information for the specified table.
		/// </summary>
		/// <param name="connection">The SqlConnection to be used when querying for the table information.</param>
		/// <param name="table">The table instance that information should be retrieved for.</param>
		private static void QueryTable(SqlConnection connection, Table table)
		{
			// Get a list of the entities in the database
			DataTable dataTable = new DataTable();
			SqlDataAdapter dataAdapter = new SqlDataAdapter(Utility.GetColumnQuery(table.Name), connection);
			dataAdapter.Fill(dataTable);

			foreach (DataRow columnRow in dataTable.Rows)
			{
				Column column = new Column();
				column.Name = columnRow["COLUMN_NAME"].ToString();
				column.Type = columnRow["DATA_TYPE"].ToString();
				column.Precision = columnRow["NUMERIC_PRECISION"].ToString();
				column.Scale = columnRow["NUMERIC_SCALE"].ToString();

				// Determine the column's length
				if (columnRow["CHARACTER_MAXIMUM_LENGTH"] != DBNull.Value)
				{
					column.Length = columnRow["CHARACTER_MAXIMUM_LENGTH"].ToString();
				}
				else
				{
					column.Length = columnRow["COLUMN_LENGTH"].ToString();
				}

				// Is the column a RowGuidCol column?
				if (columnRow["IS_ROWGUIDCOL"].ToString() == "1")
				{
					column.IsRowGuidCol = true;
				}

				// Is the column an Identity column?
				if (columnRow["IS_IDENTITY"].ToString() == "1")
				{
					column.IsIdentity = true;
				}

				// Is columnRow column a computed column?
				if (columnRow["IS_COMPUTED"].ToString() == "1")
				{
					column.IsComputed = true;
				}

				table.Columns.Add(column);
			}

			// Get the list of primary keys
			DataTable primaryKeyTable = Utility.GetPrimaryKeyList(connection, table.Name);
			foreach (DataRow primaryKeyRow in primaryKeyTable.Rows)
			{
				string primaryKeyName = primaryKeyRow["COLUMN_NAME"].ToString();

				foreach (Column column in table.Columns)
				{
					if (column.Name == primaryKeyName)
					{
						table.PrimaryKeys.Add(column);
						break;
					}
				}
			}

			// Get the list of foreign keys
			DataTable foreignKeyTable = Utility.GetForeignKeyList(connection, table.Name);
			foreach (DataRow foreignKeyRow in foreignKeyTable.Rows)
			{
				string name = foreignKeyRow["FK_NAME"].ToString();
				string columnName = foreignKeyRow["FKCOLUMN_NAME"].ToString();

				if (table.ForeignKeys.ContainsKey(name) == false)
				{
					table.ForeignKeys.Add(name, new List<Column>());
				}

				List<Column> foreignKeys = table.ForeignKeys[name];

				foreach (Column column in table.Columns)
				{
					if (column.Name == columnName)
					{
						foreignKeys.Add(column);
						break;
					}
				}
			}
        }
        #endregion

        

        



        



        

        

        #region GenerateCode
        public static void GenerateCode(string xmlRootPath, string xsltRootPath, string outputRootPath, string outputFileExtension)
        {
            if (Directory.Exists(xmlRootPath) && Directory.Exists(xsltRootPath))
            {
                string[] xsltDiretories = Directory.GetDirectories(xsltRootPath);
                string[] xmlFiles = Directory.GetFiles(xmlRootPath);
                for (int ix = 0; ix < xsltDiretories.Length; ix++)
                {
                    string strProjectName = GetTemplateName(xsltDiretories[ix]);
                    string xsltFileName = Path.Combine(xsltDiretories[ix], String.Concat(strProjectName, ".xslt"));

                    if (File.Exists(xsltFileName))
                    {
                        if (!Directory.Exists(Path.Combine(outputRootPath, strProjectName)))
                        {
                            Directory.CreateDirectory(Path.Combine(outputRootPath, strProjectName));
                        }
                        Transform(xsltFileName, xmlFiles, Path.Combine(outputRootPath, strProjectName), outputFileExtension);

                        string[] csFiles = new string[xmlFiles.Length];
                        for (int iy = 0; iy < xmlFiles.Length; iy++)
                        {
                            csFiles[iy] = String.Concat(Path.GetFileNameWithoutExtension(xmlFiles[iy]), ".", outputFileExtension);
                        }
                        string projectFileName = Path.Combine(outputRootPath, strProjectName) + String.Concat("\\", strProjectName, ".csproj");
                        BuildProject(Path.Combine(xsltDiretories[ix], String.Concat(strProjectName, ".csproj")), csFiles, projectFileName);
                    }

                }
            }
        }
        #endregion

        

        

        #region BuildProject
        public static void BuildProject(string projPath, string[] csFiles, string outputPath)
        {
            StreamReader sr = new StreamReader(projPath);
            string template = sr.ReadToEnd();
            StringBuilder sb = new StringBuilder();
            foreach (string csFileName in csFiles)
            {
                //<Compile Include="ServerInfo.cs" />
                sb.Append(String.Concat("    <Compile Include=\"", csFileName, "\" />\r\n"));
            }
            sb.Remove(sb.Length - 2, 2);
            template = template.Replace("$CsFiles$", sb.ToString());
            StreamWriter sw = new StreamWriter(outputPath);
            sw.Write(template);
            sw.Close();
            sw = null;
        }
        #endregion

        #region GetTemplateName
        private static string GetTemplateName(string path)
        {
            if (path == null || path == string.Empty)
                return "";
            return path.Substring(path.LastIndexOf("\\") + 1);
        }
        #endregion

       

        
        */

        public static void BulkGenerator(TableInfo table, string entityfolder, string prefix, string suffix, string xmlfile, string xsltfile, string outputfile)
        {
            GenerateEntityXmlFromTable(table, entityfolder, prefix, suffix);

            if (!String.IsNullOrEmpty(xsltfile) && !String.IsNullOrEmpty(xmlfile))
            {
                if (File.Exists(xsltfile) && File.Exists(xmlfile))
                {
                    using (StringWriter resultWriter = new StringWriter(System.Globalization.CultureInfo.CurrentUICulture))
                    {
                        //Load xslt via XmlTextReader
                        XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
                        xslCompiledTransform.Load(xsltfile, XsltSettings.Default, new XmlUrlResolver());

                        //transform the input to output
                        xslCompiledTransform.Transform(xmlfile, null, resultWriter);
                        string retVal = resultWriter.ToString();
                        resultWriter.Close();
                        StreamWriter sw = new StreamWriter(outputfile);
                        sw.Write(retVal);
                        sw.Close();
                        sw = null;
                    }
                }
            }
        }

        #region GenerateEntityXmlFromTable
        public static void GenerateEntityXmlFromTable(TableInfo table, string outputPath, string prefix, string suffix)
        {
            if (table == null || !Directory.Exists(outputPath))
                return;

            Log4Helper.Write("GenerateEntityXmlFromTable", String.Format("Process of table {0} starts at {1}.", table.TableName, System.DateTime.Now.ToString("s")), LogSeverity.Info);

            string entityName = GetModelName(table.TableName);

            using (System.Xml.XmlTextWriter xtw = new System.Xml.XmlTextWriter(System.IO.Path.Combine(outputPath, String.Concat(entityName, ".xml")), System.Text.Encoding.UTF8))
            {
                xtw.Formatting = System.Xml.Formatting.Indented;
                xtw.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");

                //generate entity calss
                xtw.WriteStartElement("entity");
                xtw.WriteAttributeString("name", entityName);
                xtw.WriteAttributeString("modelName", string.Concat(prefix, ".OM.", suffix, ".", entityName));
                xtw.WriteAttributeString("namespaceBLL", string.Concat(prefix, ".BLL.", suffix));
                xtw.WriteAttributeString("namespaceDAL", string.Concat(prefix, ".DAL.", suffix));
                xtw.WriteAttributeString("namespaceModel", string.Concat(prefix, ".OM.", suffix));
                xtw.WriteAttributeString("author", UtilityHelper.GetCurrentIdentityName());
                xtw.WriteAttributeString("createdDateTime", System.DateTime.Now.ToString("s"));
                xtw.WriteAttributeString("schema", table.Schema);
                xtw.WriteAttributeString("tableName", table.TableName);
                xtw.WriteAttributeString("description", table.TableName);

                #region primary key
                xtw.WriteStartElement("primaryKey");
                foreach (ColumnInfo col in table.Columns)
                {
                    if (col.IsPrimaryKey)
                    {
                        xtw.WriteStartElement("column");
                        xtw.WriteAttributeString("columnName", col.ColumnName);
                        xtw.WriteAttributeString("lowerName", col.ColumnName.ToLower());
                        xtw.WriteAttributeString("sqlParameter", GetParameter(col.DataType, col.ColumnLength));
                        xtw.WriteEndElement();
                    }
                }
                xtw.WriteEndElement();
                #endregion

                #region ForeignKeys
                //xtw.WriteStartElement("foreignKeys");
                //foreach (ForeignKey fk in table.ForeignKeys)
                //{
                //    xtw.WriteStartElement("foreignKey");
                //    xtw.WriteAttributeString("name", fk.Name);
                //    xtw.WriteAttributeString("referencedTableSchema", fk.ReferencedTableSchema);
                //    xtw.WriteAttributeString("referencedTable", fk.ReferencedTable);
                //    xtw.WriteAttributeString("referencedKey", fk.ReferencedKey);
                //    foreach (ForeignKeyColumn fkCol in fk.Columns)
                //    {
                //        xtw.WriteStartElement("column");
                //        xtw.WriteAttributeString("columnName", fkCol.Name);
                //        xtw.WriteAttributeString("referencedColumn", fkCol.ReferencedColumn);
                //        xtw.WriteEndElement();
                //    }
                //    xtw.WriteEndElement();
                //}
                //xtw.WriteEndElement();

                //#endregion

                //#region indexes
                //xtw.WriteStartElement("indexes");
                //foreach (Index idx in table.Indexes)
                //{
                //    xtw.WriteStartElement("index");
                //    xtw.WriteAttributeString("name", idx.Name);
                //    xtw.WriteAttributeString("isClustered", idx.IsClustered.ToString(System.Globalization.CultureInfo.InvariantCulture));
                //    xtw.WriteAttributeString("isUnique", idx.IsUnique.ToString(System.Globalization.CultureInfo.InvariantCulture));
                //    xtw.WriteAttributeString("ignoreDuplicateKeys", idx.IgnoreDuplicateKeys.ToString(System.Globalization.CultureInfo.InvariantCulture));
                //    foreach (IndexedColumn idxcol in idx.IndexedColumns)
                //    {
                //        xtw.WriteStartElement("column");
                //        xtw.WriteAttributeString("columnName", idxcol.Name);
                //        xtw.WriteAttributeString("descending", idxcol.Descending.ToString(System.Globalization.CultureInfo.InvariantCulture));
                //        //xtw.WriteAttributeString("isIncluded", idxcol.IsIncluded.ToString(System.Globalization.CultureInfo.InvariantCulture));
                //        xtw.WriteEndElement();
                //    }
                //    xtw.WriteEndElement();
                //}
                //xtw.WriteEndElement();
                #endregion

                #region columns/properties
                xtw.WriteStartElement("columns");
                foreach (ColumnInfo c in table.Columns)
                {
                    GenerateXmlElementFromColumn(c, xtw);
                }
                xtw.WriteEndElement();
                #endregion

                xtw.WriteEndElement();
                xtw.Flush();
                xtw.Close();
            }

            Log4Helper.Write("GenerateEntityXmlFromTable", String.Format("Process of table {0} ends at {1}.", table.TableName, System.DateTime.Now.ToString("s")), LogSeverity.Info);
        }
        #endregion

        public static string GetModelName(string input)
        {
            string[] models = input.Split('_');
            return models[1].Substring(0, 1).ToUpper() + models[1].Substring(1, models[1].Length - 1);
        }

        #region GenerateXmlElementFromColumn
        /// <summary>
        /// GenerateXmlElementFromColumn generate a xml element from column's definition.
        /// </summary>
        /// <param name="schema">schema name,</param>
        /// <param name="table">table name</param>
        /// <param name="c">column</param>
        /// <param name="keepSymbol">whether keep symbol when convert column anme to property name.</param>
        /// <param name="xtw">xml text writer</param>
        /// <param name="elementName">name of the xml element</param>
        /// <param name="sqlOnly">whether only generate the xml attributes that related to sql.</param>
        private static void GenerateXmlElementFromColumn(ColumnInfo column, System.Xml.XmlTextWriter xtw)
        {
            string initialValue, cSharpType, sqlDefaultValue;


            initialValue = "";
            cSharpType = "";


            #region initial type depended attributes
            switch (GetDataType(column.DataType))
            {
                case SqlDataType.BigInt:
                    cSharpType = "long";
                    initialValue = "0";
                    sqlDefaultValue = "0";
                    //uiLength = Utility.SafeToString(long.MaxValue).Length + 1;
                    break;

                case SqlDataType.Int:
                    cSharpType = "int";
                    initialValue = "0";
                    sqlDefaultValue = "0";
                    //uiLength = Utility.SafeToString(int.MaxValue).Length + 1;
                    break;

                case SqlDataType.SmallInt:
                    cSharpType = "short";
                    initialValue = "0";
                    sqlDefaultValue = "0";
                    //uiLength = Utility.SafeToString(short.MaxValue).Length + 1;
                    break;

                case SqlDataType.TinyInt:
                    cSharpType = "byte";
                    initialValue = "0";
                    sqlDefaultValue = "0";
                    //uiLength = Utility.SafeToString(byte.MaxValue).Length;
                    break;

                case SqlDataType.Bit:
                    cSharpType = "bool";
                    initialValue = "false";
                    sqlDefaultValue = "0";
                    //uiLength = 5;
                    break;

                case SqlDataType.Decimal:
                case SqlDataType.Numeric:
                    cSharpType = "decimal";
                    initialValue = "0M";
                    sqlDefaultValue = "0";
                    //uiLength = Utility.SafeToString(decimal.MaxValue).Length + 1;
                    //sqlType += "(" + c.DataType.NumericPrecision.ToString() + ", " + c.DataType.NumericScale.ToString() + ")";
                    break;

                case SqlDataType.Money:
                case SqlDataType.SmallMoney:
                    cSharpType = "decimal";
                    initialValue = "0M";
                    sqlDefaultValue = "0";
                    //uiLength = Utility.SafeToString(decimal.MaxValue).Length + 1;
                    break;

                case SqlDataType.Float:
                    cSharpType = "float";
                    initialValue = "0D";
                    sqlDefaultValue = "0";
                    //uiLength = Utility.SafeToString(double.MaxValue).Length + 1;
                    break;

                case SqlDataType.Real:
                    cSharpType = "float";
                    initialValue = "0F";
                    sqlDefaultValue = "0";
                    //uiLength = Utility.SafeToString(double.MaxValue).Length + 1;
                    break;

                case SqlDataType.DateTime:
                case SqlDataType.SmallDateTime:
                    cSharpType = "DateTime";
                    initialValue = "System.DateTime.MinValue";
                    sqlDefaultValue = "null";
                    //uiLength = 10;
                    break;

                case SqlDataType.UniqueIdentifier:
                    cSharpType = "System.Guid";
                    initialValue = "System.Guid.Empty";
                    sqlDefaultValue = "null";
                    //uiLength = 32;
                    break;

                case SqlDataType.Char:
                case SqlDataType.NChar:
                case SqlDataType.VarChar:
                case SqlDataType.VarCharMax:
                case SqlDataType.NVarChar:
                case SqlDataType.NVarCharMax:
                case SqlDataType.Text:
                case SqlDataType.NText:
                    cSharpType = "string";
                    initialValue = "\"\"";
                    sqlDefaultValue = "''''";
                    //uiLength = c.DataType.MaximumLength;
                    //if (uiLength <= 0) uiLength = 0;
                    //if (c.DataType.SqlDataType != SqlDataType.Text
                    //    && c.DataType.SqlDataType != SqlDataType.NText)
                    //{
                    //    if (c.DataType.MaximumLength > 0)
                    //        sqlType += "(" + c.DataType.MaximumLength.ToString() + ")";
                    //    else
                    //    {
                    //        sqlType = sqlType.Remove(sqlType.Length - 3) + "(max)";
                    //    }
                    //}
                    break;

                //following SqlDataType are not processed in this version
                case SqlDataType.Binary:
                case SqlDataType.Image:
                case SqlDataType.SysName:
                case SqlDataType.Timestamp:
                case SqlDataType.VarBinary:
                case SqlDataType.VarBinaryMax:
                case SqlDataType.Variant:
                case SqlDataType.Xml:
                case SqlDataType.UserDefinedType:
                case SqlDataType.UserDefinedDataType:
                    cSharpType = "string";
                    initialValue = "\"\"";
                    sqlDefaultValue = "''''";
                    break;

                default:
                    cSharpType = "string";
                    initialValue = "\"\"";
                    sqlDefaultValue = "''''";
                    break;
            }

            #endregion

            //#region process nullable
            //if (c.Nullable)
            //{
            //    //if (!type.Equals("string", StringComparison.InvariantCultureIgnoreCase))
            //    //{
            //    //    type = string.Concat(type, "?");
            //    //}
            //    initialValue = "null";
            //    sqlDefaultValue = "null";
            //}
            //#endregion


            #region write xml element
            xtw.WriteStartElement("property");
            xtw.WriteAttributeString("sequence", column.Sequence.ToString());
            xtw.WriteAttributeString("columnName", column.ColumnName);
            xtw.WriteAttributeString("dataType", column.DataType);
            xtw.WriteAttributeString("columnLength", column.ColumnLength.ToString());
            xtw.WriteAttributeString("precisionLength", column.PrecisionLength.ToString());
            xtw.WriteAttributeString("scale", column.Scale.ToString());
            xtw.WriteAttributeString("defaultValue", column.DefaultValue);
            xtw.WriteAttributeString("columnDescription", column.ColumnDescription);
            xtw.WriteAttributeString("isIdentity", column.IsIdentity.ToString(System.Globalization.CultureInfo.InvariantCulture));
            xtw.WriteAttributeString("isPrimaryKey", column.IsPrimaryKey.ToString(System.Globalization.CultureInfo.InvariantCulture));
            xtw.WriteAttributeString("isNullable", column.IsNullable.ToString(System.Globalization.CultureInfo.InvariantCulture));
            xtw.WriteAttributeString("lowerName", column.ColumnName.ToLower());
            xtw.WriteAttributeString("field", string.Concat("_", column.ColumnName.ToLower()));
            if (column.DataType == "nvarchar" || column.DataType == "varchar")
                xtw.WriteAttributeString("sqlParameter", GetParameter(column.DataType, column.PrecisionLength));
            else
                xtw.WriteAttributeString("sqlParameter", GetParameter(column.DataType, column.ColumnLength));
            xtw.WriteAttributeString("csharptype", cSharpType);
            xtw.WriteAttributeString("getMethod", UtilityHelper.GetXxxMethod(column));
            xtw.WriteAttributeString("pattern", UtilityHelper.GetPattern(column.DataType));
            xtw.WriteAttributeString("initialValue", initialValue);
            xtw.WriteEndElement();
            #endregion
        }
        #endregion

        #region GetDataType
        private static SqlDataType GetDataType(string sqltype)
        {
            SqlDataType sqlDataType;
            switch (sqltype)
            {
                case "bigint":
                    sqlDataType = SqlDataType.BigInt;
                    break;
                case "binary":
                    sqlDataType = SqlDataType.Binary;
                    break;
                case "bit":
                    sqlDataType = SqlDataType.Bit;
                    break;
                case "char":
                    sqlDataType = SqlDataType.Char;
                    break;
                case "date":
                    sqlDataType = SqlDataType.Date;
                    break;
                case "datetime":
                    sqlDataType = SqlDataType.DateTime;
                    break;
                case "decimal":
                    sqlDataType = SqlDataType.Decimal;
                    break;
                case "float":
                    sqlDataType = SqlDataType.Float;
                    break;
                case "image":
                    sqlDataType = SqlDataType.Image;
                    break;
                case "int":
                    sqlDataType = SqlDataType.Int;
                    break;
                case "money":
                    sqlDataType = SqlDataType.Money;
                    break;
                case "nchar":
                    sqlDataType = SqlDataType.NChar;
                    break;
                case "ntext":
                    sqlDataType = SqlDataType.NText;
                    break;
                case "numeric":
                    sqlDataType = SqlDataType.Numeric;
                    break;
                case "nvarchar":
                    sqlDataType = SqlDataType.NVarChar;
                    break;
                case "real":
                    sqlDataType = SqlDataType.Real;
                    break;
                case "smalldatetime":
                    sqlDataType = SqlDataType.SmallDateTime;
                    break;
                case "smallint":
                    sqlDataType = SqlDataType.SmallInt;
                    break;
                case "smallmoney":
                    sqlDataType = SqlDataType.SmallMoney;
                    break;
                case "text":
                    sqlDataType = SqlDataType.Text;
                    break;
                case "time":
                    sqlDataType = SqlDataType.Time;
                    break;
                case "tinyint":
                    sqlDataType = SqlDataType.TinyInt;
                    break;
                case "uniqueidentifier":
                    sqlDataType = SqlDataType.UniqueIdentifier;
                    break;
                case "varchar":
                    sqlDataType = SqlDataType.VarChar;
                    break;
                case "variant":
                    sqlDataType = SqlDataType.Variant;
                    break;
                case "xml":
                    sqlDataType = SqlDataType.Xml;
                    break;
                default:
                    sqlDataType = SqlDataType.VarChar;
                    break;
            }

            return sqlDataType;
        }
        #endregion

        #region GetParameter
        private static string GetParameter(string sqltype, int columnlength)
        {
            string strParameter;
            switch (sqltype)
            {
                case "bigint":
                    strParameter = "SqlDbType.BigInt," + columnlength;
                    break;
                case "binary":
                    strParameter = "SqlDbType.Binary";
                    break;
                case "bit":
                    strParameter = "SqlDbType.Bit";
                    break;
                case "char":
                    strParameter = "SqlDbType.Char";
                    break;
                case "date":
                    strParameter = "SqlDbType.Date";
                    break;
                case "datetime":
                    strParameter = "SqlDbType.DateTime";
                    break;
                case "decimal":
                    strParameter = "SqlDbType.Decimal";
                    break;
                case "float":
                    strParameter = "SqlDbType.Float";
                    break;
                case "image":
                    strParameter = "SqlDbType.Image";
                    break;
                case "int":
                    strParameter = "SqlDbType.Int," + columnlength;
                    break;
                case "money":
                    strParameter = "SqlDbType.Money";
                    break;
                case "nchar":
                    strParameter = "SqlDbType.NChar";
                    break;
                case "ntext":
                    strParameter = "SqlDbType.NText";
                    break;
                case "numeric":
                    strParameter = "SqlDbType.Numeric";
                    break;
                case "nvarchar":
                    strParameter = "SqlDbType.NVarChar," + columnlength;
                    break;
                case "real":
                    strParameter = "SqlDbType.Real";
                    break;
                case "smalldatetime":
                    strParameter = "SqlDbType.SmallDateTime";
                    break;
                case "smallint":
                    strParameter = "SqlDbType.SmallInt," + columnlength;
                    break;
                case "smallmoney":
                    strParameter = "SqlDbType.SmallMoney";
                    break;
                case "text":
                    strParameter = "SqlDbType.Text";
                    break;
                case "time":
                    strParameter = "SqlDbType.Time";
                    break;
                case "tinyint":
                    strParameter = "SqlDbType.TinyInt";
                    break;
                case "uniqueidentifier":
                    strParameter = "SqlDbType.UniqueIdentifier";
                    break;
                case "varchar":
                    strParameter = "SqlDbType.VarChar," + columnlength;
                    break;
                case "variant":
                    strParameter = "SqlDbType.Variant";
                    break;
                case "xml":
                    strParameter = "SqlDbType.Xml";
                    break;
                default:
                    strParameter = "SqlDbType.VarChar," + columnlength;
                    break;
            }

            return strParameter;
        }
        #endregion

        #region GenerateTextXmlFromTable
        public static void GenerateTextXmlFromTable(TableInfo table, string outputPath)
        {
            if (table == null || !Directory.Exists(outputPath))
                return;

            Log4Helper.Write("GenerateTextXmlFromTable", String.Format("Process of table {0} starts at {1}.", table.TableName, System.DateTime.Now.ToString("s")), LogSeverity.Info);

            string entityName = GetModelName(table.TableName);

            using (System.Xml.XmlTextWriter xtw = new System.Xml.XmlTextWriter(System.IO.Path.Combine(outputPath, String.Concat(entityName, ".xml")), System.Text.Encoding.UTF8))
            {
                xtw.Formatting = System.Xml.Formatting.Indented;
                xtw.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");

                //generate entity calss
                xtw.WriteStartElement("modeltext");

                #region columns/properties
                foreach (ColumnInfo c in table.Columns)
                {
                    xtw.WriteStartElement("field");
                    xtw.WriteAttributeString("key", entityName + "_" + c.ColumnName);
                    xtw.WriteAttributeString("value", c.ColumnDescription);
                    xtw.WriteEndElement();
                }
                xtw.WriteEndElement();
                #endregion

                xtw.Flush();
                xtw.Close();
            }

            Log4Helper.Write("GenerateTextXmlFromTable", String.Format("Process of table {0} ends at {1}.", table.TableName, System.DateTime.Now.ToString("s")), LogSeverity.Info);
        }
        #endregion

        public static string GenerateSingle(string connectionstring, string database, string server, string table, string template, string project)
        {
            //WorkingFolderInfo folder = ConfigCtrl.GetWorkingFolder();
            //GenerateEntityXml(connectionstring, table, "dbo", server, database, true, folder.EntityXml, "pr_", "Johnny.CMS");
            return Transform(template, project, table);
        }

        #region Transform
        public static void Transform(string xsltFile, string[] xmlFiles, string outputPath, string outputFileExtension)
        {
            if (!String.IsNullOrEmpty(xsltFile) && (xmlFiles != null))
            {
                if (File.Exists(xsltFile))
                {
                    //Load xslt via XslCompiledTransform
                    XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
                    xslCompiledTransform.Load(xsltFile, XsltSettings.Default, new XmlUrlResolver());

                    //transform the input to output
                    for (int ix = 0; ix < xmlFiles.Length; ix++)
                    {
                        if (File.Exists(xmlFiles[ix]))
                        {
                            string outputFile = Path.Combine(outputPath, String.Concat(Path.GetFileNameWithoutExtension(xmlFiles[ix]), ".", outputFileExtension));
                            if (File.Exists(outputFile))
                            {
                                File.Delete(outputFile);
                            }
                            xslCompiledTransform.Transform(xmlFiles[ix], outputFile);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Transform transforms xml with xslt to a string.
        /// </summary>
        /// <param name="xsltFile">xslt file path. </param>
        /// <param name="xmlFile">xml fuile path. </param>
        /// <returns>a string conatins transformation result. </returns>
        public static string Transform(string template, string project, string table)
        {
            SingleGeneratorInfo single = GetSingleGeneratorConfig(template, project, table);

            string retVal = "";
            if (!String.IsNullOrEmpty(single.XsltFile) && !String.IsNullOrEmpty(single.XmlFile))
            {
                if (File.Exists(single.XsltFile) && File.Exists(single.XmlFile))
                {
                    using (StringWriter resultWriter = new StringWriter(System.Globalization.CultureInfo.CurrentUICulture))
                    {
                        //Load xslt via XmlTextReader
                        XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
                        xslCompiledTransform.Load(single.XsltFile, XsltSettings.Default, new XmlUrlResolver());

                        //transform the input to output
                        xslCompiledTransform.Transform(single.XmlFile, null, resultWriter);
                        retVal = resultWriter.ToString();
                        resultWriter.Close();
                    }
                }
            }
            return retVal;
        }

        #endregion

        private static SingleGeneratorInfo GetSingleGeneratorConfig(string template, string project, string table)
        {
            CodeGeneratorSettingsInfo cgsettings = ConfigCtrl.GetCodeGeneratorSettings();

            string xsltFile = cgsettings.Template + "\\" + template + "\\" + project + ".xslt";
            string xmlFile = cgsettings.EntityFullPath + "\\" + table + ".xml";

            return new SingleGeneratorInfo(xsltFile, xmlFile);
        }

        #region GenerateEntityXml
        public static string GenerateEntityXml(string outputPath, EntityInfo entity)
        {
            string ret = String.Empty;

            if (entity == null || !Directory.Exists(outputPath))
                return ret;

            Log4Helper.Write("GenerateEntityXml", String.Format("Process of entity {0} starts at {1}.", entity.ClassName, System.DateTime.Now.ToString("s")), LogSeverity.Info);

            using (System.Xml.XmlTextWriter xtw = new System.Xml.XmlTextWriter(System.IO.Path.Combine(outputPath, String.Concat(entity.ClassName, ".xml")), System.Text.Encoding.UTF8))
            {
                xtw.Formatting = System.Xml.Formatting.Indented;
                xtw.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");

                //generate entity calss
                xtw.WriteStartElement("entity");
                xtw.WriteAttributeString("namespace", entity.NameSpace);
                xtw.WriteAttributeString("name", entity.ClassName);

                #region columns/properties
                //generate property node
                xtw.WriteStartElement("fields");
                foreach (FieldInfo field in entity.Fileds)
                {
                    xtw.WriteStartElement("property");
                    xtw.WriteAttributeString("type", field.Type);
                    xtw.WriteAttributeString("name", field.Name);
                    xtw.WriteAttributeString("privateFieldName", field.PrivateFieldName);
                    xtw.WriteAttributeString("paramName", field.ParamName);
                    xtw.WriteAttributeString("propetyName", field.PropertyName);
                    xtw.WriteAttributeString("csharpType", field.CSharpType);
                    xtw.WriteEndElement();
                }
                xtw.WriteEndElement();
                #endregion
                ret = xtw.ToString();
                xtw.WriteEndElement();
                xtw.Flush();
                xtw.Close();
            }

            Log4Helper.Write("GenerateEntityXmlFromTable", String.Format("Process of table {0} ends at {1}.", entity.ClassName, System.DateTime.Now.ToString("s")), LogSeverity.Info);
            return ret;
        }
        public static void GenerateEntityXml(string connectionstring, string tablename, string schema, string servername, string databasename, string outputPath, string prefix, string suffix)
        {
            TableInfo tb = new TableInfo(tablename, schema);
            tb.ServerName = servername;
            tb.DatabaseName = databasename;
            tb.Columns = DatabaseCtrl.GetColumns(connectionstring + "Database=" + databasename + ";", tablename);

            GenerateEntityXmlFromTable(tb, outputPath, prefix, suffix);
        }
        #endregion
    }
}
