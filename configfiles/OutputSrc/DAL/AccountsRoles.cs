using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// AccountsRoles is a DAL calss that represents dbo.Accounts_Roles
	/// </summary>
	public class DALAccountsRoles
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsRoles> GetList()
        {
            IList<MDLAccountsRoles> list = new List<MDLAccountsRoles>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RoleId], [RoleName], [Sequence] ");
            strSql.Append(" FROM [AccountsRoles] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLAccountsRoles item = new MDLAccountsRoles(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsRoles GetModel(int RoleId)
        {
			//Set up a return value
            MDLAccountsRoles model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RoleId], [RoleName], [Sequence] ");
            strSql.Append(" FROM [AccountsRoles] ");
            strSql.Append(" WHERE [RoleId]=" + RoleId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLAccountsRoles(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
				else
                    model = new MDLAccountsRoles();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsRoles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [AccountsRoles](");
            strSql.Append("[RoleName],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.RoleName + "',");
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
        public void Update(MDLAccountsRoles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [AccountsRoles] SET ");
            strSql.Append("[RoleName]='" + model.RoleName + "',");
			strSql.Append("[Sequence]=" + model.Sequence + "");
			strSql.Append(" WHERE [RoleId]=" + model.RoleId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int RoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [AccountsRoles] WHERE [RoleId]=" + RoleId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int RoleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [AccountsRoles] WHERE [RoleId]=" + RoleId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
