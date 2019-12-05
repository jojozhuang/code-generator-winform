using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Rolepermission is a DAL calss that represents cms_rolepermission
	/// </summary>
	public class Rolepermission
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Rolepermission> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Rolepermission> list = new List<Johnny.EEE.OM.Admin.Rolepermission>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RoleId], [PermissionId] ");
            strSql.Append(" FROM [cms_rolepermission] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Rolepermission item = new Johnny.EEE.OM.Admin.Rolepermission(sdr.GetInt32(0), sdr.GetInt32(1));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Rolepermission GetModel(int )
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Rolepermission model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [RoleId], [PermissionId] ");
            strSql.Append(" FROM [cms_rolepermission] ");
            strSql.Append(" WHERE []=@");
            SqlParameter[] parameters = {
					new SqlParameter("@", )};
            parameters[0].Value = ;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Rolepermission(sdr.GetInt32(0), sdr.GetInt32(1));
				else
                    model = new Johnny.EEE.OM.Admin.Rolepermission();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Rolepermission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [cms_rolepermission]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [cms_rolepermission](");
            strSql.Append("[RoleId],[PermissionId]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@roleid,@permissionid");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@roleid", SqlDbType.Int,4),
					new SqlParameter("@permissionid", SqlDbType.Int,4)};
			parameters[-1].Value = model.RoleId;
            parameters[0].Value = model.PermissionId;
            
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
        public void Update(Johnny.EEE.OM.Admin.Rolepermission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [cms_rolepermission] SET ");
            strSql.Append("[RoleId]=@roleid,");
			strSql.Append("[PermissionId]=@permissionid");
			strSql.Append(" WHERE []=@ ");
            SqlParameter[] parameters = {
            		new SqlParameter("@roleid", SqlDbType.Int,4),
					new SqlParameter("@permissionid", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleId;
            parameters[1].Value = model.PermissionId;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [cms_rolepermission] WHERE []=@");
            SqlParameter[] parameters = {
					new SqlParameter("@", )};
            parameters[0].Value = ;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [cms_rolepermission] WHERE []=@");
            SqlParameter[] parameters = {
					new SqlParameter("@", )};
            parameters[0].Value = ;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
