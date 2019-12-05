using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Topmenubinding is a DAL calss that represents cms_topmenubinding
	/// </summary>
	public class Topmenubinding
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Topmenubinding> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Topmenubinding> list = new List<Johnny.EEE.OM.Admin.Topmenubinding>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [TopMenuId], [MenuCategoryId] ");
            strSql.Append(" FROM [cms_topmenubinding] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Topmenubinding item = new Johnny.EEE.OM.Admin.Topmenubinding(sdr.GetInt32(0), sdr.GetInt32(1));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Topmenubinding GetModel(int )
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Topmenubinding model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [TopMenuId], [MenuCategoryId] ");
            strSql.Append(" FROM [cms_topmenubinding] ");
            strSql.Append(" WHERE []=@");
            SqlParameter[] parameters = {
					new SqlParameter("@", )};
            parameters[0].Value = ;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Topmenubinding(sdr.GetInt32(0), sdr.GetInt32(1));
				else
                    model = new Johnny.EEE.OM.Admin.Topmenubinding();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Topmenubinding model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [cms_topmenubinding]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [cms_topmenubinding](");
            strSql.Append("[TopMenuId],[MenuCategoryId]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@topmenuid,@menucategoryid");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@topmenuid", SqlDbType.Int,4),
					new SqlParameter("@menucategoryid", SqlDbType.Int,4)};
			parameters[-1].Value = model.TopMenuId;
            parameters[0].Value = model.MenuCategoryId;
            
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
        public void Update(Johnny.EEE.OM.Admin.Topmenubinding model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [cms_topmenubinding] SET ");
            strSql.Append("[TopMenuId]=@topmenuid,");
			strSql.Append("[MenuCategoryId]=@menucategoryid");
			strSql.Append(" WHERE []=@ ");
            SqlParameter[] parameters = {
            		new SqlParameter("@topmenuid", SqlDbType.Int,4),
					new SqlParameter("@menucategoryid", SqlDbType.Int,4)};
			parameters[0].Value = model.TopMenuId;
            parameters[1].Value = model.MenuCategoryId;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [cms_topmenubinding] WHERE []=@");
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
            strSql.Append("SELECT COUNT(1) FROM [cms_topmenubinding] WHERE []=@");
            SqlParameter[] parameters = {
					new SqlParameter("@", )};
            parameters[0].Value = ;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
