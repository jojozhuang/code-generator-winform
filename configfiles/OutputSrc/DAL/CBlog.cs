using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// CBlog is a DAL calss that represents dbo.C_Blog
	/// </summary>
	public class DALCBlog
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLCBlog> GetList()
        {
            IList<MDLCBlog> list = new List<MDLCBlog>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [BlogId], [BlogTitle], [BlogCategory], [Tag], [Content], [Hits], [IsDisplay], [Sequence], [AddedTime], [AddedBy], [UpdatedTime], [UpdatedBy] ");
            strSql.Append(" FROM [CBlog] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLCBlog item = new MDLCBlog(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(5), sdr.GetBoolean(6), sdr.GetInt32(7), sdr.GetDateTime(8), sdr.GetInt32(9), sdr.GetDateTime(10), sdr.GetInt32(11));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLCBlog GetModel(int BlogId)
        {
			//Set up a return value
            MDLCBlog model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [BlogId], [BlogTitle], [BlogCategory], [Tag], [Content], [Hits], [IsDisplay], [Sequence], [AddedTime], [AddedBy], [UpdatedTime], [UpdatedBy] ");
            strSql.Append(" FROM [CBlog] ");
            strSql.Append(" WHERE [BlogId]=" + BlogId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLCBlog(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(5), sdr.GetBoolean(6), sdr.GetInt32(7), sdr.GetDateTime(8), sdr.GetInt32(9), sdr.GetDateTime(10), sdr.GetInt32(11));
				else
                    model = new MDLCBlog();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLCBlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [CBlog](");
            strSql.Append("[BlogTitle],[BlogCategory],[Tag],[Content],[Hits],[IsDisplay],[Sequence],[AddedTime],[AddedBy],[UpdatedTime],[UpdatedBy]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.BlogTitle + "',");
			strSql.Append("" + model.BlogCategory + ",");
			strSql.Append("'" + model.Tag + "',");
			strSql.Append("'" + model.Content + "',");
			strSql.Append("" + model.Hits + ",");
			strSql.Append("" + (model.IsDisplay == true ? "1" : "0") + ",");
			strSql.Append("" + model.Sequence + ",");
			strSql.Append("'" + model.AddedTime + "',");
			strSql.Append("" + model.AddedBy + ",");
			strSql.Append("'" + model.UpdatedTime + "',");
			strSql.Append("" + model.UpdatedBy + "");
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
        public void Update(MDLCBlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [CBlog] SET ");
            strSql.Append("[BlogTitle]='" + model.BlogTitle + "',");
			strSql.Append("[BlogCategory]=" + model.BlogCategory + ",");
			strSql.Append("[Tag]='" + model.Tag + "',");
			strSql.Append("[Content]='" + model.Content + "',");
			strSql.Append("[Hits]=" + model.Hits + ",");
			strSql.Append("[IsDisplay]=" + (model.IsDisplay == true ? "1" : "0") + ",");
			strSql.Append("[Sequence]=" + model.Sequence + ",");
			strSql.Append("[AddedTime]='" + model.AddedTime + "',");
			strSql.Append("[AddedBy]=" + model.AddedBy + ",");
			strSql.Append("[UpdatedTime]='" + model.UpdatedTime + "',");
			strSql.Append("[UpdatedBy]=" + model.UpdatedBy + "");
			strSql.Append(" WHERE [BlogId]=" + model.BlogId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int BlogId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [CBlog] WHERE [BlogId]=" + BlogId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int BlogId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [CBlog] WHERE [BlogId]=" + BlogId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
