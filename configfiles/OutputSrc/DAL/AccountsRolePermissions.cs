using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// AccountsRolePermissions is a DAL calss that represents dbo.Accounts_RolePermissions
	/// </summary>
	public class DALAccountsRolePermissions
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsRolePermissions> GetList()
        {
            IList<MDLAccountsRolePermissions> list = new List<MDLAccountsRolePermissions>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RoleId], [PermissionId] ");
            strSql.Append(" FROM [AccountsRolePermissions] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLAccountsRolePermissions item = new MDLAccountsRolePermissions(sdr.GetInt32(0), sdr.GetInt32(1));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsRolePermissions GetModel(int )
        {
			//Set up a return value
            MDLAccountsRolePermissions model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RoleId], [PermissionId] ");
            strSql.Append(" FROM [AccountsRolePermissions] ");
            strSql.Append(" WHERE []=" + .ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLAccountsRolePermissions(sdr.GetInt32(0), sdr.GetInt32(1));
				else
                    model = new MDLAccountsRolePermissions();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsRolePermissions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [AccountsRolePermissions](");
            strSql.Append("[RoleId],[PermissionId]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("" + model.RoleId + ",");
			strSql.Append("" + model.PermissionId + "");
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
        public void Update(MDLAccountsRolePermissions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [AccountsRolePermissions] SET ");
            strSql.Append("[RoleId]=" + model.RoleId + ",");
			strSql.Append("[PermissionId]=" + model.PermissionId + "");
			strSql.Append(" WHERE [);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [AccountsRolePermissions] WHERE []=" + .ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [AccountsRolePermissions] WHERE []=" + .ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
