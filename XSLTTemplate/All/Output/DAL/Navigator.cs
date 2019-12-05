using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Navigator is a DAL calss that represents cms_navigator
	/// </summary>
	public class Navigator
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Navigator> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Navigator> list = new List<Johnny.EEE.OM.Admin.Navigator>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [NavigatorId], [NavigatorName], [Url], [ParentId] ");
            strSql.Append(" FROM [cms_navigator] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Navigator item = new Johnny.EEE.OM.Admin.Navigator(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetInt32(3));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Navigator GetModel(int navigatorid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Navigator model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [NavigatorId], [NavigatorName], [Url], [ParentId] ");
            strSql.Append(" FROM [cms_navigator] ");
            strSql.Append(" WHERE [NavigatorId]=@navigatorid");
            SqlParameter[] parameters = {
					new SqlParameter("@navigatorid", SqlDbType.Int,4)};
            parameters[0].Value = navigatorid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Navigator(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetInt32(3));
				else
                    model = new Johnny.EEE.OM.Admin.Navigator();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Navigator model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [cms_navigator]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [cms_navigator](");
            strSql.Append("[NavigatorId],[NavigatorName],[Url],[ParentId]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@navigatorid,@navigatorname,@url,@parentid");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@navigatorid", SqlDbType.Int,4),
					new SqlParameter("@navigatorname", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.VarChar,200),
					new SqlParameter("@parentid", SqlDbType.Int,4)};
			parameters[-1].Value = model.NavigatorId;
            parameters[0].Value = model.NavigatorName;
            parameters[1].Value = model.Url;
            parameters[2].Value = model.ParentId;
            
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
        public void Update(Johnny.EEE.OM.Admin.Navigator model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [cms_navigator] SET ");
            strSql.Append("[NavigatorId]=@navigatorid,");
			strSql.Append("[NavigatorName]=@navigatorname,");
			strSql.Append("[Url]=@url,");
			strSql.Append("[ParentId]=@parentid");
			strSql.Append(" WHERE [NavigatorId]=@navigatorid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@navigatorid", SqlDbType.Int,4),
					new SqlParameter("@navigatorname", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.VarChar,200),
					new SqlParameter("@parentid", SqlDbType.Int,4)};
			parameters[0].Value = model.NavigatorId;
            parameters[1].Value = model.NavigatorName;
            parameters[2].Value = model.Url;
            parameters[3].Value = model.ParentId;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int navigatorid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [cms_navigator] WHERE [NavigatorId]=@navigatorid");
            SqlParameter[] parameters = {
					new SqlParameter("@navigatorid", SqlDbType.Int,4)};
            parameters[0].Value = navigatorid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int navigatorid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [cms_navigator] WHERE [NavigatorId]=@navigatorid");
            SqlParameter[] parameters = {
					new SqlParameter("@navigatorid", SqlDbType.Int,4)};
            parameters[0].Value = navigatorid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
