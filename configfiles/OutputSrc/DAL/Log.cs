using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// Log is a DAL calss that represents dbo.Log
	/// </summary>
	public class DALLog
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLLog> GetList()
        {
            IList<MDLLog> list = new List<MDLLog>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [Id], [Date], [Thread], [Level], [Logger], [Message], [Exception] ");
            strSql.Append(" FROM [Log] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLLog item = new MDLLog(sdr.(0), sdr.(1), sdr.(2), sdr.(3), sdr.(4), sdr.(5), sdr.(6));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLLog GetModel(int )
        {
			//Set up a return value
            MDLLog model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [Id], [Date], [Thread], [Level], [Logger], [Message], [Exception] ");
            strSql.Append(" FROM [Log] ");
            strSql.Append(" WHERE []=" + .ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLLog(sdr.(0), sdr.(1), sdr.(2), sdr.(3), sdr.(4), sdr.(5), sdr.(6));
				else
                    model = new MDLLog();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [Log](");
            strSql.Append("[Id],[Date],[Thread],[Level],[Logger],[Message],[Exception]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("" + model.Id + ",");
			strSql.Append("" + model.Date + ",");
			strSql.Append("" + model.Thread + ",");
			strSql.Append("" + model.Level + ",");
			strSql.Append("" + model.Logger + ",");
			strSql.Append("" + model.Message + ",");
			strSql.Append("" + model.Exception + "");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [Log] SET ");
            strSql.Append("[Id]=" + model.Id + ",");
			strSql.Append("[Date]=" + model.Date + ",");
			strSql.Append("[Thread]=" + model.Thread + ",");
			strSql.Append("[Level]=" + model.Level + ",");
			strSql.Append("[Logger]=" + model.Logger + ",");
			strSql.Append("[Message]=" + model.Message + ",");
			strSql.Append("[Exception]=" + model.Exception + "");
			strSql.Append(" WHERE [);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [Log] WHERE []=" + .ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [Log] WHERE []=" + .ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
