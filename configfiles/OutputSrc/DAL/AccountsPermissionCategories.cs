using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// AccountsPermissionCategories is a DAL calss that represents dbo.Accounts_PermissionCategories
	/// </summary>
	public class DALAccountsPermissionCategories
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsPermissionCategories> GetList()
        {
            IList<MDLAccountsPermissionCategories> list = new List<MDLAccountsPermissionCategories>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [PermissionCategoryId], [Description], [Sequence] ");
            strSql.Append(" FROM [AccountsPermissionCategories] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLAccountsPermissionCategories item = new MDLAccountsPermissionCategories(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsPermissionCategories GetModel(int PermissionCategoryId)
        {
			//Set up a return value
            MDLAccountsPermissionCategories model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [PermissionCategoryId], [Description], [Sequence] ");
            strSql.Append(" FROM [AccountsPermissionCategories] ");
            strSql.Append(" WHERE [PermissionCategoryId]=" + PermissionCategoryId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLAccountsPermissionCategories(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
				else
                    model = new MDLAccountsPermissionCategories();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsPermissionCategories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [AccountsPermissionCategories](");
            strSql.Append("[Description],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.Description + "',");
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
        public void Update(MDLAccountsPermissionCategories model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [AccountsPermissionCategories] SET ");
            strSql.Append("[Description]='" + model.Description + "',");
			strSql.Append("[Sequence]=" + model.Sequence + "");
			strSql.Append(" WHERE [PermissionCategoryId]=" + model.PermissionCategoryId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int PermissionCategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [AccountsPermissionCategories] WHERE [PermissionCategoryId]=" + PermissionCategoryId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int PermissionCategoryId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [AccountsPermissionCategories] WHERE [PermissionCategoryId]=" + PermissionCategoryId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
