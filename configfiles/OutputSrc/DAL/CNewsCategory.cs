using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// CNewsCategory is a DAL calss that represents dbo.C_NewsCategory
	/// </summary>
	public class DALCNewsCategory
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLCNewsCategory> GetList()
        {
            IList<MDLCNewsCategory> list = new List<MDLCNewsCategory>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [NewsCategoryId], [NewsCategoryName], [Sequence] ");
            strSql.Append(" FROM [CNewsCategory] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLCNewsCategory item = new MDLCNewsCategory(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLCNewsCategory GetModel(int NewsCategoryId)
        {
			//Set up a return value
            MDLCNewsCategory model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [NewsCategoryId], [NewsCategoryName], [Sequence] ");
            strSql.Append(" FROM [CNewsCategory] ");
            strSql.Append(" WHERE [NewsCategoryId]=" + NewsCategoryId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLCNewsCategory(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
				else
                    model = new MDLCNewsCategory();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLCNewsCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [CNewsCategory](");
            strSql.Append("[NewsCategoryName],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.NewsCategoryName + "',");
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
        public void Update(MDLCNewsCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [CNewsCategory] SET ");
            strSql.Append("[NewsCategoryName]='" + model.NewsCategoryName + "',");
			strSql.Append("[Sequence]=" + model.Sequence + "");
			strSql.Append(" WHERE [NewsCategoryId]=" + model.NewsCategoryId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int NewsCategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [CNewsCategory] WHERE [NewsCategoryId]=" + NewsCategoryId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int NewsCategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [CNewsCategory] WHERE [NewsCategoryId]=" + NewsCategoryId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
