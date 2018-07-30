using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// CBlogCategory is a DAL calss that represents dbo.C_BlogCategory
	/// </summary>
	public class DALCBlogCategory
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLCBlogCategory> GetList()
        {
            IList<MDLCBlogCategory> list = new List<MDLCBlogCategory>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [BlogCategoryId], [BlogCategoryName], [Sequence] ");
            strSql.Append(" FROM [CBlogCategory] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLCBlogCategory item = new MDLCBlogCategory(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLCBlogCategory GetModel(int BlogCategoryId)
        {
			//Set up a return value
            MDLCBlogCategory model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [BlogCategoryId], [BlogCategoryName], [Sequence] ");
            strSql.Append(" FROM [CBlogCategory] ");
            strSql.Append(" WHERE [BlogCategoryId]=" + BlogCategoryId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLCBlogCategory(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
				else
                    model = new MDLCBlogCategory();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLCBlogCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [CBlogCategory](");
            strSql.Append("[BlogCategoryName],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.BlogCategoryName + "',");
			strSql.Append("" + model.Sequence + "");
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
        public void Update(MDLCBlogCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [CBlogCategory] SET ");
            strSql.Append("[BlogCategoryName]='" + model.BlogCategoryName + "',");
			strSql.Append("[Sequence]=" + model.Sequence + "");
			strSql.Append(" WHERE [BlogCategoryId]=" + model.BlogCategoryId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int BlogCategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [CBlogCategory] WHERE [BlogCategoryId]=" + BlogCategoryId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int BlogCategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [CBlogCategory] WHERE [BlogCategoryId]=" + BlogCategoryId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
