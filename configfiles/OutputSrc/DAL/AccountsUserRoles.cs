using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// AccountsUserRoles is a DAL calss that represents dbo.Accounts_UserRoles
	/// </summary>
	public class DALAccountsUserRoles
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsUserRoles> GetList()
        {
            IList<MDLAccountsUserRoles> list = new List<MDLAccountsUserRoles>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserRoleId], [UserId], [RoleId], [Sequence] ");
            strSql.Append(" FROM [AccountsUserRoles] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLAccountsUserRoles item = new MDLAccountsUserRoles(sdr.(0), sdr.(1), sdr.(2), sdr.(3));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsUserRoles GetModel(int UserRoleId)
        {
			//Set up a return value
            MDLAccountsUserRoles model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserRoleId], [UserId], [RoleId], [Sequence] ");
            strSql.Append(" FROM [AccountsUserRoles] ");
            strSql.Append(" WHERE [UserRoleId]=" + UserRoleId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLAccountsUserRoles(sdr.(0), sdr.(1), sdr.(2), sdr.(3));
				else
                    model = new MDLAccountsUserRoles();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsUserRoles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [AccountsUserRoles](");
            strSql.Append("[UserRoleId],[UserId],[RoleId],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("" + model.UserRoleId + ",");
			strSql.Append("" + model.UserId + ",");
			strSql.Append("" + model.RoleId + ",");
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
        public void Update(MDLAccountsUserRoles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [AccountsUserRoles] SET ");
            strSql.Append("[UserRoleId]=" + model.UserRoleId + ",");
			strSql.Append("[UserId]=" + model.UserId + ",");
			strSql.Append("[RoleId]=" + model.RoleId + ",");
			strSql.Append("[Sequence]=" + model.Sequence + "");
			strSql.Append(" WHERE [UserRoleId]=" + model.UserRoleId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int UserRoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [AccountsUserRoles] WHERE [UserRoleId]=" + UserRoleId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int UserRoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [AccountsUserRoles] WHERE [UserRoleId]=" + UserRoleId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
