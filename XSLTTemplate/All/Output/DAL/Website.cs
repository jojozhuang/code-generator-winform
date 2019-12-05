using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Website is a DAL calss that represents seh_website
	/// </summary>
	public class Website
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Website> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Website> list = new List<Johnny.EEE.OM.Admin.Website>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [WebsiteId], [WebsiteName], [WebsiteCategoryId], [Description], [URL], [Hits], [IsDisplay], [CreatedTime], [CreatedById], [CreatedByName], [UpdatedTime], [UpdatedById], [UpdatedByName], [Sequence] ");
            strSql.Append(" FROM [seh_website] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Website item = new Johnny.EEE.OM.Admin.Website(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(5), sdr.GetBoolean(6), sdr.GetDateTime(7), sdr.GetInt32(8), sdr.GetString(9), sdr.GetDateTime(10), sdr.GetInt32(11), sdr.GetString(12), sdr.GetInt32(13));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Website GetModel(int websiteid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Website model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [WebsiteId], [WebsiteName], [WebsiteCategoryId], [Description], [URL], [Hits], [IsDisplay], [CreatedTime], [CreatedById], [CreatedByName], [UpdatedTime], [UpdatedById], [UpdatedByName], [Sequence] ");
            strSql.Append(" FROM [seh_website] ");
            strSql.Append(" WHERE [WebsiteId]=@websiteid");
            SqlParameter[] parameters = {
					new SqlParameter("@websiteid", SqlDbType.Int,4)};
            parameters[0].Value = websiteid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Website(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(5), sdr.GetBoolean(6), sdr.GetDateTime(7), sdr.GetInt32(8), sdr.GetString(9), sdr.GetDateTime(10), sdr.GetInt32(11), sdr.GetString(12), sdr.GetInt32(13));
				else
                    model = new Johnny.EEE.OM.Admin.Website();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Website model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [seh_website]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [seh_website](");
            strSql.Append("[WebsiteName],[WebsiteCategoryId],[Description],[URL],[Hits],[IsDisplay],[CreatedTime],[CreatedById],[CreatedByName],[UpdatedTime],[UpdatedById],[UpdatedByName],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@websitename,@websitecategoryid,@description,@url,@hits,@isdisplay,@createdtime,@createdbyid,@createdbyname,@updatedtime,@updatedbyid,@updatedbyname,@sequence");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@websitename", SqlDbType.NVarChar,50),
					new SqlParameter("@websitecategoryid", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.NVarChar,100),
					new SqlParameter("@url", SqlDbType.VarChar,200),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@isdisplay", SqlDbType.Bit),
					new SqlParameter("@createdtime", SqlDbType.DateTime),
					new SqlParameter("@createdbyid", SqlDbType.Int,4),
					new SqlParameter("@createdbyname", SqlDbType.VarChar,50),
					new SqlParameter("@updatedtime", SqlDbType.DateTime),
					new SqlParameter("@updatedbyid", SqlDbType.Int,4),
					new SqlParameter("@updatedbyname", SqlDbType.VarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4)};
			parameters[0].Value = model.WebsiteName;
            parameters[1].Value = model.WebsiteCategoryId;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.URL;
            parameters[4].Value = model.Hits;
            parameters[5].Value = model.IsDisplay;
            parameters[6].Value = model.CreatedTime;
            parameters[7].Value = model.CreatedById;
            parameters[8].Value = model.CreatedByName;
            parameters[9].Value = model.UpdatedTime;
            parameters[10].Value = model.UpdatedById;
            parameters[11].Value = model.UpdatedByName;
            parameters[12].Value = model.Sequence;
            
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
        public void Update(Johnny.EEE.OM.Admin.Website model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [seh_website] SET ");
            strSql.Append("[WebsiteName]=@websitename,");
			strSql.Append("[WebsiteCategoryId]=@websitecategoryid,");
			strSql.Append("[Description]=@description,");
			strSql.Append("[URL]=@url,");
			strSql.Append("[Hits]=@hits,");
			strSql.Append("[IsDisplay]=@isdisplay,");
			strSql.Append("[CreatedTime]=@createdtime,");
			strSql.Append("[CreatedById]=@createdbyid,");
			strSql.Append("[CreatedByName]=@createdbyname,");
			strSql.Append("[UpdatedTime]=@updatedtime,");
			strSql.Append("[UpdatedById]=@updatedbyid,");
			strSql.Append("[UpdatedByName]=@updatedbyname,");
			strSql.Append("[Sequence]=@sequence");
			strSql.Append(" WHERE [WebsiteId]=@websiteid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@websiteid", SqlDbType.Int,4),
					new SqlParameter("@websitename", SqlDbType.NVarChar,50),
					new SqlParameter("@websitecategoryid", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.NVarChar,100),
					new SqlParameter("@url", SqlDbType.VarChar,200),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@isdisplay", SqlDbType.Bit),
					new SqlParameter("@createdtime", SqlDbType.DateTime),
					new SqlParameter("@createdbyid", SqlDbType.Int,4),
					new SqlParameter("@createdbyname", SqlDbType.VarChar,50),
					new SqlParameter("@updatedtime", SqlDbType.DateTime),
					new SqlParameter("@updatedbyid", SqlDbType.Int,4),
					new SqlParameter("@updatedbyname", SqlDbType.VarChar,50),
			};
			parameters[0].Value = model.WebsiteId;
            parameters[1].Value = model.WebsiteName;
            parameters[2].Value = model.WebsiteCategoryId;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.URL;
            parameters[5].Value = model.Hits;
            parameters[6].Value = model.IsDisplay;
            parameters[7].Value = model.CreatedTime;
            parameters[8].Value = model.CreatedById;
            parameters[9].Value = model.CreatedByName;
            parameters[10].Value = model.UpdatedTime;
            parameters[11].Value = model.UpdatedById;
            parameters[12].Value = model.UpdatedByName;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int websiteid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [seh_website] WHERE [WebsiteId]=@websiteid");
            SqlParameter[] parameters = {
					new SqlParameter("@websiteid", SqlDbType.Int,4)};
            parameters[0].Value = websiteid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int websiteid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [seh_website] WHERE [WebsiteId]=@websiteid");
            SqlParameter[] parameters = {
					new SqlParameter("@websiteid", SqlDbType.Int,4)};
            parameters[0].Value = websiteid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
