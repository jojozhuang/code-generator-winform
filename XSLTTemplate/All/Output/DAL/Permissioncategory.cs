using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Permissioncategory is a DAL calss that represents cms_permissioncategory
	/// </summary>
	public class Permissioncategory
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Permissioncategory> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Permissioncategory> list = new List<Johnny.EEE.OM.Admin.Permissioncategory>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [PermissionCategoryId], [PermissionCategoryName], [Sequence] ");
            strSql.Append(" FROM [cms_permissioncategory] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Permissioncategory item = new Johnny.EEE.OM.Admin.Permissioncategory(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Permissioncategory GetModel(int permissioncategoryid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Permissioncategory model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [PermissionCategoryId], [PermissionCategoryName], [Sequence] ");
            strSql.Append(" FROM [cms_permissioncategory] ");
            strSql.Append(" WHERE [PermissionCategoryId]=@permissioncategoryid");
            SqlParameter[] parameters = {
					new SqlParameter("@permissioncategoryid", SqlDbType.Int,4)};
            parameters[0].Value = permissioncategoryid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Permissioncategory(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
				else
                    model = new Johnny.EEE.OM.Admin.Permissioncategory();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Permissioncategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [cms_permissioncategory]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [cms_permissioncategory](");
            strSql.Append("[PermissionCategoryName],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@permissioncategoryname,@sequence");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@permissioncategoryname", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4)};
			parameters[0].Value = model.PermissionCategoryName;
            parameters[1].Value = model.Sequence;
            
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
        public void Update(Johnny.EEE.OM.Admin.Permissioncategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [cms_permissioncategory] SET ");
            strSql.Append("[PermissionCategoryName]=@permissioncategoryname,");
			strSql.Append("[Sequence]=@sequence");
			strSql.Append(" WHERE [PermissionCategoryId]=@permissioncategoryid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@permissioncategoryid", SqlDbType.Int,4),
					new SqlParameter("@permissioncategoryname", SqlDbType.NVarChar,50),
			};
			parameters[0].Value = model.PermissionCategoryId;
            parameters[1].Value = model.PermissionCategoryName;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int permissioncategoryid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [cms_permissioncategory] WHERE [PermissionCategoryId]=@permissioncategoryid");
            SqlParameter[] parameters = {
					new SqlParameter("@permissioncategoryid", SqlDbType.Int,4)};
            parameters[0].Value = permissioncategoryid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int permissioncategoryid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [cms_permissioncategory] WHERE [PermissionCategoryId]=@permissioncategoryid");
            SqlParameter[] parameters = {
					new SqlParameter("@permissioncategoryid", SqlDbType.Int,4)};
            parameters[0].Value = permissioncategoryid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
