using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Software is a DAL calss that represents seh_software
	/// </summary>
	public class Software
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Software> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Software> list = new List<Johnny.EEE.OM.Admin.Software>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [SoftwareId], [SoftwareName], [ShortDescription], [Description], [Image], [Feature1], [Feature2], [Feature3], [Feature4], [DownloadUrl], [DocumentTitle], [DocumentDescription], [DocumentUrl], [Hits], [Downloads], [IsDisplay], [CreatedTime], [CreatedById], [CreatedByName], [UpdatedTime], [UpdatedById], [UpdatedByName], [Sequence] ");
            strSql.Append(" FROM [seh_software] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Software item = new Johnny.EEE.OM.Admin.Software(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetString(3), sdr.GetString(4), sdr.GetString(5), sdr.GetString(6), sdr.GetString(7), sdr.GetString(8), sdr.GetString(9), sdr.GetString(10), sdr.GetString(11), sdr.GetString(12), sdr.GetInt32(13), sdr.GetInt32(14), sdr.GetBoolean(15), sdr.GetDateTime(16), sdr.GetInt32(17), sdr.GetString(18), sdr.GetDateTime(19), sdr.GetInt32(20), sdr.GetString(21), sdr.GetInt32(22));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Software GetModel(int softwareid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Software model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [SoftwareId], [SoftwareName], [ShortDescription], [Description], [Image], [Feature1], [Feature2], [Feature3], [Feature4], [DownloadUrl], [DocumentTitle], [DocumentDescription], [DocumentUrl], [Hits], [Downloads], [IsDisplay], [CreatedTime], [CreatedById], [CreatedByName], [UpdatedTime], [UpdatedById], [UpdatedByName], [Sequence] ");
            strSql.Append(" FROM [seh_software] ");
            strSql.Append(" WHERE [SoftwareId]=@softwareid");
            SqlParameter[] parameters = {
					new SqlParameter("@softwareid", SqlDbType.Int,4)};
            parameters[0].Value = softwareid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Software(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetString(3), sdr.GetString(4), sdr.GetString(5), sdr.GetString(6), sdr.GetString(7), sdr.GetString(8), sdr.GetString(9), sdr.GetString(10), sdr.GetString(11), sdr.GetString(12), sdr.GetInt32(13), sdr.GetInt32(14), sdr.GetBoolean(15), sdr.GetDateTime(16), sdr.GetInt32(17), sdr.GetString(18), sdr.GetDateTime(19), sdr.GetInt32(20), sdr.GetString(21), sdr.GetInt32(22));
				else
                    model = new Johnny.EEE.OM.Admin.Software();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Software model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [seh_software]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [seh_software](");
            strSql.Append("[SoftwareName],[ShortDescription],[Description],[Image],[Feature1],[Feature2],[Feature3],[Feature4],[DownloadUrl],[DocumentTitle],[DocumentDescription],[DocumentUrl],[Hits],[Downloads],[IsDisplay],[CreatedTime],[CreatedById],[CreatedByName],[UpdatedTime],[UpdatedById],[UpdatedByName],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@softwarename,@shortdescription,@description,@image,@feature1,@feature2,@feature3,@feature4,@downloadurl,@documenttitle,@documentdescription,@documenturl,@hits,@downloads,@isdisplay,@createdtime,@createdbyid,@createdbyname,@updatedtime,@updatedbyid,@updatedbyname,@sequence");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@softwarename", SqlDbType.VarChar,200),
					new SqlParameter("@shortdescription", SqlDbType.VarChar,500),
					new SqlParameter("@description", SqlDbType.Text),
					new SqlParameter("@image", SqlDbType.VarChar,200),
					new SqlParameter("@feature1", SqlDbType.VarChar,100),
					new SqlParameter("@feature2", SqlDbType.VarChar,100),
					new SqlParameter("@feature3", SqlDbType.VarChar,100),
					new SqlParameter("@feature4", SqlDbType.VarChar,100),
					new SqlParameter("@downloadurl", SqlDbType.VarChar,500),
					new SqlParameter("@documenttitle", SqlDbType.VarChar,100),
					new SqlParameter("@documentdescription", SqlDbType.VarChar,500),
					new SqlParameter("@documenturl", SqlDbType.VarChar,500),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@downloads", SqlDbType.Int,4),
					new SqlParameter("@isdisplay", SqlDbType.Bit),
					new SqlParameter("@createdtime", SqlDbType.DateTime),
					new SqlParameter("@createdbyid", SqlDbType.Int,4),
					new SqlParameter("@createdbyname", SqlDbType.VarChar,50),
					new SqlParameter("@updatedtime", SqlDbType.DateTime),
					new SqlParameter("@updatedbyid", SqlDbType.Int,4),
					new SqlParameter("@updatedbyname", SqlDbType.VarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4)};
			parameters[0].Value = model.SoftwareName;
            parameters[1].Value = model.ShortDescription;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.Image;
            parameters[4].Value = model.Feature1;
            parameters[5].Value = model.Feature2;
            parameters[6].Value = model.Feature3;
            parameters[7].Value = model.Feature4;
            parameters[8].Value = model.DownloadUrl;
            parameters[9].Value = model.DocumentTitle;
            parameters[10].Value = model.DocumentDescription;
            parameters[11].Value = model.DocumentUrl;
            parameters[12].Value = model.Hits;
            parameters[13].Value = model.Downloads;
            parameters[14].Value = model.IsDisplay;
            parameters[15].Value = model.CreatedTime;
            parameters[16].Value = model.CreatedById;
            parameters[17].Value = model.CreatedByName;
            parameters[18].Value = model.UpdatedTime;
            parameters[19].Value = model.UpdatedById;
            parameters[20].Value = model.UpdatedByName;
            parameters[21].Value = model.Sequence;
            
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
        public void Update(Johnny.EEE.OM.Admin.Software model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [seh_software] SET ");
            strSql.Append("[SoftwareName]=@softwarename,");
			strSql.Append("[ShortDescription]=@shortdescription,");
			strSql.Append("[Description]=@description,");
			strSql.Append("[Image]=@image,");
			strSql.Append("[Feature1]=@feature1,");
			strSql.Append("[Feature2]=@feature2,");
			strSql.Append("[Feature3]=@feature3,");
			strSql.Append("[Feature4]=@feature4,");
			strSql.Append("[DownloadUrl]=@downloadurl,");
			strSql.Append("[DocumentTitle]=@documenttitle,");
			strSql.Append("[DocumentDescription]=@documentdescription,");
			strSql.Append("[DocumentUrl]=@documenturl,");
			strSql.Append("[Hits]=@hits,");
			strSql.Append("[Downloads]=@downloads,");
			strSql.Append("[IsDisplay]=@isdisplay,");
			strSql.Append("[CreatedTime]=@createdtime,");
			strSql.Append("[CreatedById]=@createdbyid,");
			strSql.Append("[CreatedByName]=@createdbyname,");
			strSql.Append("[UpdatedTime]=@updatedtime,");
			strSql.Append("[UpdatedById]=@updatedbyid,");
			strSql.Append("[UpdatedByName]=@updatedbyname,");
			strSql.Append("[Sequence]=@sequence");
			strSql.Append(" WHERE [SoftwareId]=@softwareid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@softwareid", SqlDbType.Int,4),
					new SqlParameter("@softwarename", SqlDbType.VarChar,200),
					new SqlParameter("@shortdescription", SqlDbType.VarChar,500),
					new SqlParameter("@description", SqlDbType.Text),
					new SqlParameter("@image", SqlDbType.VarChar,200),
					new SqlParameter("@feature1", SqlDbType.VarChar,100),
					new SqlParameter("@feature2", SqlDbType.VarChar,100),
					new SqlParameter("@feature3", SqlDbType.VarChar,100),
					new SqlParameter("@feature4", SqlDbType.VarChar,100),
					new SqlParameter("@downloadurl", SqlDbType.VarChar,500),
					new SqlParameter("@documenttitle", SqlDbType.VarChar,100),
					new SqlParameter("@documentdescription", SqlDbType.VarChar,500),
					new SqlParameter("@documenturl", SqlDbType.VarChar,500),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@downloads", SqlDbType.Int,4),
					new SqlParameter("@isdisplay", SqlDbType.Bit),
					new SqlParameter("@createdtime", SqlDbType.DateTime),
					new SqlParameter("@createdbyid", SqlDbType.Int,4),
					new SqlParameter("@createdbyname", SqlDbType.VarChar,50),
					new SqlParameter("@updatedtime", SqlDbType.DateTime),
					new SqlParameter("@updatedbyid", SqlDbType.Int,4),
					new SqlParameter("@updatedbyname", SqlDbType.VarChar,50),
			};
			parameters[0].Value = model.SoftwareId;
            parameters[1].Value = model.SoftwareName;
            parameters[2].Value = model.ShortDescription;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.Image;
            parameters[5].Value = model.Feature1;
            parameters[6].Value = model.Feature2;
            parameters[7].Value = model.Feature3;
            parameters[8].Value = model.Feature4;
            parameters[9].Value = model.DownloadUrl;
            parameters[10].Value = model.DocumentTitle;
            parameters[11].Value = model.DocumentDescription;
            parameters[12].Value = model.DocumentUrl;
            parameters[13].Value = model.Hits;
            parameters[14].Value = model.Downloads;
            parameters[15].Value = model.IsDisplay;
            parameters[16].Value = model.CreatedTime;
            parameters[17].Value = model.CreatedById;
            parameters[18].Value = model.CreatedByName;
            parameters[19].Value = model.UpdatedTime;
            parameters[20].Value = model.UpdatedById;
            parameters[21].Value = model.UpdatedByName;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int softwareid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [seh_software] WHERE [SoftwareId]=@softwareid");
            SqlParameter[] parameters = {
					new SqlParameter("@softwareid", SqlDbType.Int,4)};
            parameters[0].Value = softwareid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int softwareid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [seh_software] WHERE [SoftwareId]=@softwareid");
            SqlParameter[] parameters = {
					new SqlParameter("@softwareid", SqlDbType.Int,4)};
            parameters[0].Value = softwareid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
