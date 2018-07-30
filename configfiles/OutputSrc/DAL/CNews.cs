using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// CNews is a DAL calss that represents dbo.C_News
	/// </summary>
	public class DALCNews
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLCNews> GetList()
        {
            IList<MDLCNews> list = new List<MDLCNews>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [NewsId], [Title], [SubTitle], [NewsCategoryId], [FirstImage], [SubContent], [Content], [Hits], [IsDisplay], [Sequence], [AddedTime], [AddedBy], [UpdatedTime], [UpdatedBy] ");
            strSql.Append(" FROM [CNews] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLCNews item = new MDLCNews(sdr.GetInt64(0), sdr.GetString(1), sdr.GetString(2), sdr.GetInt32(3), sdr.GetString(4), sdr.GetString(5), sdr.GetString(6), sdr.GetInt32(7), sdr.GetBoolean(8), sdr.GetInt32(9), sdr.GetDateTime(10), sdr.GetInt32(11), sdr.GetDateTime(12), sdr.GetInt32(13));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLCNews GetModel(int NewsId)
        {
			//Set up a return value
            MDLCNews model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [NewsId], [Title], [SubTitle], [NewsCategoryId], [FirstImage], [SubContent], [Content], [Hits], [IsDisplay], [Sequence], [AddedTime], [AddedBy], [UpdatedTime], [UpdatedBy] ");
            strSql.Append(" FROM [CNews] ");
            strSql.Append(" WHERE [NewsId]=" + NewsId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLCNews(sdr.GetInt64(0), sdr.GetString(1), sdr.GetString(2), sdr.GetInt32(3), sdr.GetString(4), sdr.GetString(5), sdr.GetString(6), sdr.GetInt32(7), sdr.GetBoolean(8), sdr.GetInt32(9), sdr.GetDateTime(10), sdr.GetInt32(11), sdr.GetDateTime(12), sdr.GetInt32(13));
				else
                    model = new MDLCNews();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLCNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [CNews](");
            strSql.Append("[Title],[SubTitle],[NewsCategoryId],[FirstImage],[SubContent],[Content],[Hits],[IsDisplay],[Sequence],[AddedTime],[AddedBy],[UpdatedTime],[UpdatedBy]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.Title + "',");
			strSql.Append("'" + model.SubTitle + "',");
			strSql.Append("" + model.NewsCategoryId + ",");
			strSql.Append("'" + model.FirstImage + "',");
			strSql.Append("'" + model.SubContent + "',");
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
        public void Update(MDLCNews model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [CNews] SET ");
            strSql.Append("[Title]='" + model.Title + "',");
			strSql.Append("[SubTitle]='" + model.SubTitle + "',");
			strSql.Append("[NewsCategoryId]=" + model.NewsCategoryId + ",");
			strSql.Append("[FirstImage]='" + model.FirstImage + "',");
			strSql.Append("[SubContent]='" + model.SubContent + "',");
			strSql.Append("[Content]='" + model.Content + "',");
			strSql.Append("[Hits]=" + model.Hits + ",");
			strSql.Append("[IsDisplay]=" + (model.IsDisplay == true ? "1" : "0") + ",");
			strSql.Append("[Sequence]=" + model.Sequence + ",");
			strSql.Append("[AddedTime]='" + model.AddedTime + "',");
			strSql.Append("[AddedBy]=" + model.AddedBy + ",");
			strSql.Append("[UpdatedTime]='" + model.UpdatedTime + "',");
			strSql.Append("[UpdatedBy]=" + model.UpdatedBy + "");
			strSql.Append(" WHERE [NewsId]=" + model.NewsId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int NewsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [CNews] WHERE [NewsId]=" + NewsId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int NewsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [CNews] WHERE [NewsId]=" + NewsId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
