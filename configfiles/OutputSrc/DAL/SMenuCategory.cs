using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// SMenuCategory is a DAL calss that represents dbo.S_MenuCategory
	/// </summary>
	public class DALSMenuCategory
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLSMenuCategory> GetList()
        {
            IList<MDLSMenuCategory> list = new List<MDLSMenuCategory>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [MenuCategoryId], [MenuCategoryName], [Sequence] ");
            strSql.Append(" FROM [SMenuCategory] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLSMenuCategory item = new MDLSMenuCategory(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLSMenuCategory GetModel(int MenuCategoryId)
        {
			//Set up a return value
            MDLSMenuCategory model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [MenuCategoryId], [MenuCategoryName], [Sequence] ");
            strSql.Append(" FROM [SMenuCategory] ");
            strSql.Append(" WHERE [MenuCategoryId]=" + MenuCategoryId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLSMenuCategory(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
				else
                    model = new MDLSMenuCategory();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLSMenuCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [SMenuCategory](");
            strSql.Append("[MenuCategoryName],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.MenuCategoryName + "',");
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
        public void Update(MDLSMenuCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [SMenuCategory] SET ");
            strSql.Append("[MenuCategoryName]='" + model.MenuCategoryName + "',");
			strSql.Append("[Sequence]=" + model.Sequence + "");
			strSql.Append(" WHERE [MenuCategoryId]=" + model.MenuCategoryId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int MenuCategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [SMenuCategory] WHERE [MenuCategoryId]=" + MenuCategoryId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int MenuCategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [SMenuCategory] WHERE [MenuCategoryId]=" + MenuCategoryId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
