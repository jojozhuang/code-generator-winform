using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// AccountsPermissions is a DAL calss that represents dbo.Accounts_Permissions
	/// </summary>
	public class DALAccountsPermissions
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsPermissions> GetList()
        {
            IList<MDLAccountsPermissions> list = new List<MDLAccountsPermissions>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [PermissionId], [PermissionName], [PermissionCategoryId], [Sequence] ");
            strSql.Append(" FROM [AccountsPermissions] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLAccountsPermissions item = new MDLAccountsPermissions(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetInt32(3));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsPermissions GetModel(int PermissionId)
        {
			//Set up a return value
            MDLAccountsPermissions model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [PermissionId], [PermissionName], [PermissionCategoryId], [Sequence] ");
            strSql.Append(" FROM [AccountsPermissions] ");
            strSql.Append(" WHERE [PermissionId]=" + PermissionId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLAccountsPermissions(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetInt32(3));
				else
                    model = new MDLAccountsPermissions();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsPermissions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [AccountsPermissions](");
            strSql.Append("[PermissionName],[PermissionCategoryId],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.PermissionName + "',");
			strSql.Append("" + model.PermissionCategoryId + ",");
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
        public void Update(MDLAccountsPermissions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [AccountsPermissions] SET ");
            strSql.Append("[PermissionName]='" + model.PermissionName + "',");
			strSql.Append("[PermissionCategoryId]=" + model.PermissionCategoryId + ",");
			strSql.Append("[Sequence]=" + model.Sequence + "");
			strSql.Append(" WHERE [PermissionId]=" + model.PermissionId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int PermissionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [AccountsPermissions] WHERE [PermissionId]=" + PermissionId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int PermissionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [AccountsPermissions] WHERE [PermissionId]=" + PermissionId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
