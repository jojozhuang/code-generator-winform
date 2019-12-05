using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Adminrole is a DAL calss that represents cms_adminrole
	/// </summary>
	public class Adminrole
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Adminrole> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Adminrole> list = new List<Johnny.EEE.OM.Admin.Adminrole>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [AdminRoleId], [AdminId], [RoleId], [Sequence] ");
            strSql.Append(" FROM [cms_adminrole] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Adminrole item = new Johnny.EEE.OM.Admin.Adminrole(sdr.GetInt32(0), sdr.GetInt32(1), sdr.GetInt32(2), sdr.GetInt32(3));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Adminrole GetModel(int adminroleid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Adminrole model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [AdminRoleId], [AdminId], [RoleId], [Sequence] ");
            strSql.Append(" FROM [cms_adminrole] ");
            strSql.Append(" WHERE [AdminRoleId]=@adminroleid");
            SqlParameter[] parameters = {
					new SqlParameter("@adminroleid", SqlDbType.Int,4)};
            parameters[0].Value = adminroleid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Adminrole(sdr.GetInt32(0), sdr.GetInt32(1), sdr.GetInt32(2), sdr.GetInt32(3));
				else
                    model = new Johnny.EEE.OM.Admin.Adminrole();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Adminrole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [cms_adminrole]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [cms_adminrole](");
            strSql.Append("[AdminId],[RoleId],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@adminid,@roleid,@sequence");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@adminid", SqlDbType.Int,4),
					new SqlParameter("@roleid", SqlDbType.Int,4),
					new SqlParameter("@sequence", SqlDbType.Int,4)};
			parameters[0].Value = model.AdminId;
            parameters[1].Value = model.RoleId;
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
        public void Update(Johnny.EEE.OM.Admin.Adminrole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [cms_adminrole] SET ");
            strSql.Append("[AdminId]=@adminid,");
			strSql.Append("[RoleId]=@roleid,");
			strSql.Append("[Sequence]=@sequence");
			strSql.Append(" WHERE [AdminRoleId]=@adminroleid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@adminroleid", SqlDbType.Int,4),
					new SqlParameter("@adminid", SqlDbType.Int,4),
					new SqlParameter("@roleid", SqlDbType.Int,4),
			};
			parameters[0].Value = model.AdminRoleId;
            parameters[1].Value = model.AdminId;
            parameters[2].Value = model.RoleId;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int adminroleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [cms_adminrole] WHERE [AdminRoleId]=@adminroleid");
            SqlParameter[] parameters = {
					new SqlParameter("@adminroleid", SqlDbType.Int,4)};
            parameters[0].Value = adminroleid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int adminroleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [cms_adminrole] WHERE [AdminRoleId]=@adminroleid");
            SqlParameter[] parameters = {
					new SqlParameter("@adminroleid", SqlDbType.Int,4)};
            parameters[0].Value = adminroleid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
