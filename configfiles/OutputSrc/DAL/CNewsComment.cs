using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// CNewsComment is a DAL calss that represents dbo.C_NewsComment
	/// </summary>
	public class DALCNewsComment
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLCNewsComment> GetList()
        {
            IList<MDLCNewsComment> list = new List<MDLCNewsComment>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [Id], [NewsId], [Content], [IssueDate] ");
            strSql.Append(" FROM [CNewsComment] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLCNewsComment item = new MDLCNewsComment(sdr.GetInt32(0), sdr.GetInt32(1), sdr.GetString(2), sdr.GetDateTime(3));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLCNewsComment GetModel(int )
        {
			//Set up a return value
            MDLCNewsComment model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [Id], [NewsId], [Content], [IssueDate] ");
            strSql.Append(" FROM [CNewsComment] ");
            strSql.Append(" WHERE []=" + .ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLCNewsComment(sdr.GetInt32(0), sdr.GetInt32(1), sdr.GetString(2), sdr.GetDateTime(3));
				else
                    model = new MDLCNewsComment();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLCNewsComment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [CNewsComment](");
            strSql.Append("[NewsId],[Content],[IssueDate]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("" + model.NewsId + ",");
			strSql.Append("'" + model.Content + "',");
			strSql.Append("'" + model.IssueDate + "'");
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
        public void Update(MDLCNewsComment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [CNewsComment] SET ");
            strSql.Append("[NewsId]=" + model.NewsId + ",");
			strSql.Append("[Content]='" + model.Content + "',");
			strSql.Append("[IssueDate]='" + model.IssueDate + "'");
			strSql.Append(" WHERE [);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [CNewsComment] WHERE []=" + .ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [CNewsComment] WHERE []=" + .ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
