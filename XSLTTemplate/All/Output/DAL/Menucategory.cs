using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Menucategory is a DAL calss that represents cms_menucategory
	/// </summary>
	public class Menucategory
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Menucategory> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Menucategory> list = new List<Johnny.EEE.OM.Admin.Menucategory>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [MenuCategoryId], [MenuCategoryName], [Sequence] ");
            strSql.Append(" FROM [cms_menucategory] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Menucategory item = new Johnny.EEE.OM.Admin.Menucategory(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Menucategory GetModel(int menucategoryid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Menucategory model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [MenuCategoryId], [MenuCategoryName], [Sequence] ");
            strSql.Append(" FROM [cms_menucategory] ");
            strSql.Append(" WHERE [MenuCategoryId]=@menucategoryid");
            SqlParameter[] parameters = {
					new SqlParameter("@menucategoryid", SqlDbType.Int,4)};
            parameters[0].Value = menucategoryid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Menucategory(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
				else
                    model = new Johnny.EEE.OM.Admin.Menucategory();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Menucategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [cms_menucategory]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [cms_menucategory](");
            strSql.Append("[MenuCategoryName],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@menucategoryname,@sequence");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@menucategoryname", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4)};
			parameters[0].Value = model.MenuCategoryName;
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
        public void Update(Johnny.EEE.OM.Admin.Menucategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [cms_menucategory] SET ");
            strSql.Append("[MenuCategoryName]=@menucategoryname,");
			strSql.Append("[Sequence]=@sequence");
			strSql.Append(" WHERE [MenuCategoryId]=@menucategoryid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@menucategoryid", SqlDbType.Int,4),
					new SqlParameter("@menucategoryname", SqlDbType.NVarChar,50),
			};
			parameters[0].Value = model.MenuCategoryId;
            parameters[1].Value = model.MenuCategoryName;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int menucategoryid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [cms_menucategory] WHERE [MenuCategoryId]=@menucategoryid");
            SqlParameter[] parameters = {
					new SqlParameter("@menucategoryid", SqlDbType.Int,4)};
            parameters[0].Value = menucategoryid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int menucategoryid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [cms_menucategory] WHERE [MenuCategoryId]=@menucategoryid");
            SqlParameter[] parameters = {
					new SqlParameter("@menucategoryid", SqlDbType.Int,4)};
            parameters[0].Value = menucategoryid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
