using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Opensource is a DAL calss that represents seh_opensource
	/// </summary>
	public class Opensource
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Opensource> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Opensource> list = new List<Johnny.EEE.OM.Admin.Opensource>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [OpenSourceId], [OpenSourceName], [ShortDescription], [Description], [URL], [Hits], [IsDisplay], [CreatedTime], [CreatedById], [CreatedByName], [UpdatedTime], [UpdatedById], [UpdatedByName], [Sequence] ");
            strSql.Append(" FROM [seh_opensource] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Opensource item = new Johnny.EEE.OM.Admin.Opensource(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(5), sdr.GetBoolean(6), sdr.GetDateTime(7), sdr.GetInt32(8), sdr.GetString(9), sdr.GetDateTime(10), sdr.GetInt32(11), sdr.GetString(12), sdr.GetInt32(13));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Opensource GetModel(int opensourceid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Opensource model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [OpenSourceId], [OpenSourceName], [ShortDescription], [Description], [URL], [Hits], [IsDisplay], [CreatedTime], [CreatedById], [CreatedByName], [UpdatedTime], [UpdatedById], [UpdatedByName], [Sequence] ");
            strSql.Append(" FROM [seh_opensource] ");
            strSql.Append(" WHERE [OpenSourceId]=@opensourceid");
            SqlParameter[] parameters = {
					new SqlParameter("@opensourceid", SqlDbType.Int,4)};
            parameters[0].Value = opensourceid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Opensource(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetString(3), sdr.GetString(4), sdr.GetInt32(5), sdr.GetBoolean(6), sdr.GetDateTime(7), sdr.GetInt32(8), sdr.GetString(9), sdr.GetDateTime(10), sdr.GetInt32(11), sdr.GetString(12), sdr.GetInt32(13));
				else
                    model = new Johnny.EEE.OM.Admin.Opensource();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Opensource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [seh_opensource]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [seh_opensource](");
            strSql.Append("[OpenSourceName],[ShortDescription],[Description],[URL],[Hits],[IsDisplay],[CreatedTime],[CreatedById],[CreatedByName],[UpdatedTime],[UpdatedById],[UpdatedByName],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@opensourcename,@shortdescription,@description,@url,@hits,@isdisplay,@createdtime,@createdbyid,@createdbyname,@updatedtime,@updatedbyid,@updatedbyname,@sequence");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@opensourcename", SqlDbType.NVarChar,50),
					new SqlParameter("@shortdescription", SqlDbType.NVarChar,200),
					new SqlParameter("@description", SqlDbType.Text),
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
			parameters[0].Value = model.OpenSourceName;
            parameters[1].Value = model.ShortDescription;
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
        public void Update(Johnny.EEE.OM.Admin.Opensource model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [seh_opensource] SET ");
            strSql.Append("[OpenSourceName]=@opensourcename,");
			strSql.Append("[ShortDescription]=@shortdescription,");
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
			strSql.Append(" WHERE [OpenSourceId]=@opensourceid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@opensourceid", SqlDbType.Int,4),
					new SqlParameter("@opensourcename", SqlDbType.NVarChar,50),
					new SqlParameter("@shortdescription", SqlDbType.NVarChar,200),
					new SqlParameter("@description", SqlDbType.Text),
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
			parameters[0].Value = model.OpenSourceId;
            parameters[1].Value = model.OpenSourceName;
            parameters[2].Value = model.ShortDescription;
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
        public void Delete(int opensourceid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [seh_opensource] WHERE [OpenSourceId]=@opensourceid");
            SqlParameter[] parameters = {
					new SqlParameter("@opensourceid", SqlDbType.Int,4)};
            parameters[0].Value = opensourceid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int opensourceid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [seh_opensource] WHERE [OpenSourceId]=@opensourceid");
            SqlParameter[] parameters = {
					new SqlParameter("@opensourceid", SqlDbType.Int,4)};
            parameters[0].Value = opensourceid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
