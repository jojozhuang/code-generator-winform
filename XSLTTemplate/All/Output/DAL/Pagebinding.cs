using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Pagebinding is a DAL calss that represents cms_pagebinding
	/// </summary>
	public class Pagebinding
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Pagebinding> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Pagebinding> list = new List<Johnny.EEE.OM.Admin.Pagebinding>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [PageBindingId], [Title], [MenuCategoryId], [ListMenuId], [AddMenuId] ");
            strSql.Append(" FROM [cms_pagebinding] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Pagebinding item = new Johnny.EEE.OM.Admin.Pagebinding(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetInt32(3), sdr.GetInt32(4));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Pagebinding GetModel(int pagebindingid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Pagebinding model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [PageBindingId], [Title], [MenuCategoryId], [ListMenuId], [AddMenuId] ");
            strSql.Append(" FROM [cms_pagebinding] ");
            strSql.Append(" WHERE [PageBindingId]=@pagebindingid");
            SqlParameter[] parameters = {
					new SqlParameter("@pagebindingid", SqlDbType.Int,4)};
            parameters[0].Value = pagebindingid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Pagebinding(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetInt32(3), sdr.GetInt32(4));
				else
                    model = new Johnny.EEE.OM.Admin.Pagebinding();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Pagebinding model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [cms_pagebinding]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [cms_pagebinding](");
            strSql.Append("[Title],[MenuCategoryId],[ListMenuId],[AddMenuId]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@title,@menucategoryid,@listmenuid,@addmenuid");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@menucategoryid", SqlDbType.Int,4),
					new SqlParameter("@listmenuid", SqlDbType.Int,4),
					new SqlParameter("@addmenuid", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
            parameters[1].Value = model.MenuCategoryId;
            parameters[2].Value = model.ListMenuId;
            parameters[3].Value = model.AddMenuId;
            
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
        public void Update(Johnny.EEE.OM.Admin.Pagebinding model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [cms_pagebinding] SET ");
            strSql.Append("[Title]=@title,");
			strSql.Append("[MenuCategoryId]=@menucategoryid,");
			strSql.Append("[ListMenuId]=@listmenuid,");
			strSql.Append("[AddMenuId]=@addmenuid");
			strSql.Append(" WHERE [PageBindingId]=@pagebindingid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@pagebindingid", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@menucategoryid", SqlDbType.Int,4),
					new SqlParameter("@listmenuid", SqlDbType.Int,4),
					new SqlParameter("@addmenuid", SqlDbType.Int,4)};
			parameters[0].Value = model.PageBindingId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.MenuCategoryId;
            parameters[3].Value = model.ListMenuId;
            parameters[4].Value = model.AddMenuId;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int pagebindingid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [cms_pagebinding] WHERE [PageBindingId]=@pagebindingid");
            SqlParameter[] parameters = {
					new SqlParameter("@pagebindingid", SqlDbType.Int,4)};
            parameters[0].Value = pagebindingid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int pagebindingid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [cms_pagebinding] WHERE [PageBindingId]=@pagebindingid");
            SqlParameter[] parameters = {
					new SqlParameter("@pagebindingid", SqlDbType.Int,4)};
            parameters[0].Value = pagebindingid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
