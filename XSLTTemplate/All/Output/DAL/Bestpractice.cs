using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Bestpractice is a DAL calss that represents seh_bestpractice
	/// </summary>
	public class Bestpractice
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Bestpractice> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Bestpractice> list = new List<Johnny.EEE.OM.Admin.Bestpractice>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [BestPracticeId], [BestPracticeName], [ShortDescription], [Description], [Hits], [IsDisplay], [CreatedTime], [CreatedById], [CreatedByName], [UpdatedTime], [UpdatedById], [UpdatedByName], [Sequence] ");
            strSql.Append(" FROM [seh_bestpractice] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Bestpractice item = new Johnny.EEE.OM.Admin.Bestpractice(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetString(3), sdr.GetInt32(4), sdr.GetBoolean(5), sdr.GetDateTime(6), sdr.GetInt32(7), sdr.GetString(8), sdr.GetDateTime(9), sdr.GetInt32(10), sdr.GetString(11), sdr.GetInt32(12));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Bestpractice GetModel(int bestpracticeid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Bestpractice model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [BestPracticeId], [BestPracticeName], [ShortDescription], [Description], [Hits], [IsDisplay], [CreatedTime], [CreatedById], [CreatedByName], [UpdatedTime], [UpdatedById], [UpdatedByName], [Sequence] ");
            strSql.Append(" FROM [seh_bestpractice] ");
            strSql.Append(" WHERE [BestPracticeId]=@bestpracticeid");
            SqlParameter[] parameters = {
					new SqlParameter("@bestpracticeid", SqlDbType.Int,4)};
            parameters[0].Value = bestpracticeid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Bestpractice(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetString(3), sdr.GetInt32(4), sdr.GetBoolean(5), sdr.GetDateTime(6), sdr.GetInt32(7), sdr.GetString(8), sdr.GetDateTime(9), sdr.GetInt32(10), sdr.GetString(11), sdr.GetInt32(12));
				else
                    model = new Johnny.EEE.OM.Admin.Bestpractice();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Bestpractice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [seh_bestpractice]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [seh_bestpractice](");
            strSql.Append("[BestPracticeName],[ShortDescription],[Description],[Hits],[IsDisplay],[CreatedTime],[CreatedById],[CreatedByName],[UpdatedTime],[UpdatedById],[UpdatedByName],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@bestpracticename,@shortdescription,@description,@hits,@isdisplay,@createdtime,@createdbyid,@createdbyname,@updatedtime,@updatedbyid,@updatedbyname,@sequence");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@bestpracticename", SqlDbType.NVarChar,50),
					new SqlParameter("@shortdescription", SqlDbType.NVarChar,200),
					new SqlParameter("@description", SqlDbType.Text),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@isdisplay", SqlDbType.Bit),
					new SqlParameter("@createdtime", SqlDbType.DateTime),
					new SqlParameter("@createdbyid", SqlDbType.Int,4),
					new SqlParameter("@createdbyname", SqlDbType.VarChar,50),
					new SqlParameter("@updatedtime", SqlDbType.DateTime),
					new SqlParameter("@updatedbyid", SqlDbType.Int,4),
					new SqlParameter("@updatedbyname", SqlDbType.VarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4)};
			parameters[0].Value = model.BestPracticeName;
            parameters[1].Value = model.ShortDescription;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.Hits;
            parameters[4].Value = model.IsDisplay;
            parameters[5].Value = model.CreatedTime;
            parameters[6].Value = model.CreatedById;
            parameters[7].Value = model.CreatedByName;
            parameters[8].Value = model.UpdatedTime;
            parameters[9].Value = model.UpdatedById;
            parameters[10].Value = model.UpdatedByName;
            parameters[11].Value = model.Sequence;
            
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
        public void Update(Johnny.EEE.OM.Admin.Bestpractice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [seh_bestpractice] SET ");
            strSql.Append("[BestPracticeName]=@bestpracticename,");
			strSql.Append("[ShortDescription]=@shortdescription,");
			strSql.Append("[Description]=@description,");
			strSql.Append("[Hits]=@hits,");
			strSql.Append("[IsDisplay]=@isdisplay,");
			strSql.Append("[CreatedTime]=@createdtime,");
			strSql.Append("[CreatedById]=@createdbyid,");
			strSql.Append("[CreatedByName]=@createdbyname,");
			strSql.Append("[UpdatedTime]=@updatedtime,");
			strSql.Append("[UpdatedById]=@updatedbyid,");
			strSql.Append("[UpdatedByName]=@updatedbyname,");
			strSql.Append("[Sequence]=@sequence");
			strSql.Append(" WHERE [BestPracticeId]=@bestpracticeid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@bestpracticeid", SqlDbType.Int,4),
					new SqlParameter("@bestpracticename", SqlDbType.NVarChar,50),
					new SqlParameter("@shortdescription", SqlDbType.NVarChar,200),
					new SqlParameter("@description", SqlDbType.Text),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@isdisplay", SqlDbType.Bit),
					new SqlParameter("@createdtime", SqlDbType.DateTime),
					new SqlParameter("@createdbyid", SqlDbType.Int,4),
					new SqlParameter("@createdbyname", SqlDbType.VarChar,50),
					new SqlParameter("@updatedtime", SqlDbType.DateTime),
					new SqlParameter("@updatedbyid", SqlDbType.Int,4),
					new SqlParameter("@updatedbyname", SqlDbType.VarChar,50),
			};
			parameters[0].Value = model.BestPracticeId;
            parameters[1].Value = model.BestPracticeName;
            parameters[2].Value = model.ShortDescription;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.Hits;
            parameters[5].Value = model.IsDisplay;
            parameters[6].Value = model.CreatedTime;
            parameters[7].Value = model.CreatedById;
            parameters[8].Value = model.CreatedByName;
            parameters[9].Value = model.UpdatedTime;
            parameters[10].Value = model.UpdatedById;
            parameters[11].Value = model.UpdatedByName;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int bestpracticeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [seh_bestpractice] WHERE [BestPracticeId]=@bestpracticeid");
            SqlParameter[] parameters = {
					new SqlParameter("@bestpracticeid", SqlDbType.Int,4)};
            parameters[0].Value = bestpracticeid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int bestpracticeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [seh_bestpractice] WHERE [BestPracticeId]=@bestpracticeid");
            SqlParameter[] parameters = {
					new SqlParameter("@bestpracticeid", SqlDbType.Int,4)};
            parameters[0].Value = bestpracticeid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
