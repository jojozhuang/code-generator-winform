using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Permission is a DAL calss that represents cms_permission
	/// </summary>
	public class Permission
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Permission> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Permission> list = new List<Johnny.EEE.OM.Admin.Permission>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [PermissionId], [PermissionName], [PermissionCategoryId], [Sequence] ");
            strSql.Append(" FROM [cms_permission] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Permission item = new Johnny.EEE.OM.Admin.Permission(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetInt32(3));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Permission GetModel(int permissionid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Permission model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [PermissionId], [PermissionName], [PermissionCategoryId], [Sequence] ");
            strSql.Append(" FROM [cms_permission] ");
            strSql.Append(" WHERE [PermissionId]=@permissionid");
            SqlParameter[] parameters = {
					new SqlParameter("@permissionid", SqlDbType.Int,4)};
            parameters[0].Value = permissionid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Permission(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetInt32(3));
				else
                    model = new Johnny.EEE.OM.Admin.Permission();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Permission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [cms_permission]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [cms_permission](");
            strSql.Append("[PermissionName],[PermissionCategoryId],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@permissionname,@permissioncategoryid,@sequence");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@permissionname", SqlDbType.NVarChar,50),
					new SqlParameter("@permissioncategoryid", SqlDbType.Int,4),
					new SqlParameter("@sequence", SqlDbType.Int,4)};
			parameters[0].Value = model.PermissionName;
            parameters[1].Value = model.PermissionCategoryId;
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
        public void Update(Johnny.EEE.OM.Admin.Permission model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [cms_permission] SET ");
            strSql.Append("[PermissionName]=@permissionname,");
			strSql.Append("[PermissionCategoryId]=@permissioncategoryid,");
			strSql.Append("[Sequence]=@sequence");
			strSql.Append(" WHERE [PermissionId]=@permissionid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@permissionid", SqlDbType.Int,4),
					new SqlParameter("@permissionname", SqlDbType.NVarChar,50),
					new SqlParameter("@permissioncategoryid", SqlDbType.Int,4),
			};
			parameters[0].Value = model.PermissionId;
            parameters[1].Value = model.PermissionName;
            parameters[2].Value = model.PermissionCategoryId;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int permissionid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [cms_permission] WHERE [PermissionId]=@permissionid");
            SqlParameter[] parameters = {
					new SqlParameter("@permissionid", SqlDbType.Int,4)};
            parameters[0].Value = permissionid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int permissionid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [cms_permission] WHERE [PermissionId]=@permissionid");
            SqlParameter[] parameters = {
					new SqlParameter("@permissionid", SqlDbType.Int,4)};
            parameters[0].Value = permissionid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
