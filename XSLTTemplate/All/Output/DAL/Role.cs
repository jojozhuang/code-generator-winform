using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Role is a DAL calss that represents cms_role
	/// </summary>
	public class Role
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Role> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Role> list = new List<Johnny.EEE.OM.Admin.Role>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RoleId], [RoleName], [Description], [Sequence] ");
            strSql.Append(" FROM [cms_role] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Role item = new Johnny.EEE.OM.Admin.Role(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetInt32(3));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Role GetModel(int roleid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Role model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RoleId], [RoleName], [Description], [Sequence] ");
            strSql.Append(" FROM [cms_role] ");
            strSql.Append(" WHERE [RoleId]=@roleid");
            SqlParameter[] parameters = {
					new SqlParameter("@roleid", SqlDbType.Int,4)};
            parameters[0].Value = roleid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Role(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetInt32(3));
				else
                    model = new Johnny.EEE.OM.Admin.Role();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [cms_role]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [cms_role](");
            strSql.Append("[RoleName],[Description],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@rolename,@description,@sequence");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@rolename", SqlDbType.NVarChar,50),
					new SqlParameter("@description", SqlDbType.NVarChar,200),
					new SqlParameter("@sequence", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.Sequence;
            
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public void Update(Johnny.EEE.OM.Admin.Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [cms_role] SET ");
            strSql.Append("[RoleName]=@rolename,");
			strSql.Append("[Description]=@description,");
			strSql.Append("[Sequence]=@sequence");
			strSql.Append(" WHERE [RoleId]=@roleid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@roleid", SqlDbType.Int,4),
					new SqlParameter("@rolename", SqlDbType.NVarChar,50),
					new SqlParameter("@description", SqlDbType.NVarChar,200),
			};
			parameters[0].Value = model.RoleId;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = model.Description;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [cms_role] WHERE [RoleId]=@roleid");
            SqlParameter[] parameters = {
					new SqlParameter("@roleid", SqlDbType.Int,4)};
            parameters[0].Value = roleid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int roleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [cms_role] WHERE [RoleId]=@roleid");
            SqlParameter[] parameters = {
					new SqlParameter("@roleid", SqlDbType.Int,4)};
            parameters[0].Value = roleid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
