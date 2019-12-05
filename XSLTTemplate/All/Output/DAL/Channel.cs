using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Channel is a DAL calss that represents seh_channel
	/// </summary>
	public class Channel
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Channel> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Channel> list = new List<Johnny.EEE.OM.Admin.Channel>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ChannelId], [ChannelName], [Sequence] ");
            strSql.Append(" FROM [seh_channel] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Channel item = new Johnny.EEE.OM.Admin.Channel(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Channel GetModel(int channelid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Channel model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ChannelId], [ChannelName], [Sequence] ");
            strSql.Append(" FROM [seh_channel] ");
            strSql.Append(" WHERE [ChannelId]=@channelid");
            SqlParameter[] parameters = {
					new SqlParameter("@channelid", SqlDbType.Int,4)};
            parameters[0].Value = channelid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Channel(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2));
				else
                    model = new Johnny.EEE.OM.Admin.Channel();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Channel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [seh_channel]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [seh_channel](");
            strSql.Append("[ChannelName],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@channelname,@sequence");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@channelname", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4)};
			parameters[0].Value = model.ChannelName;
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
        public void Update(Johnny.EEE.OM.Admin.Channel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [seh_channel] SET ");
            strSql.Append("[ChannelName]=@channelname,");
			strSql.Append("[Sequence]=@sequence");
			strSql.Append(" WHERE [ChannelId]=@channelid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@channelid", SqlDbType.Int,4),
					new SqlParameter("@channelname", SqlDbType.NVarChar,50),
			};
			parameters[0].Value = model.ChannelId;
            parameters[1].Value = model.ChannelName;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int channelid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [seh_channel] WHERE [ChannelId]=@channelid");
            SqlParameter[] parameters = {
					new SqlParameter("@channelid", SqlDbType.Int,4)};
            parameters[0].Value = channelid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int channelid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [seh_channel] WHERE [ChannelId]=@channelid");
            SqlParameter[] parameters = {
					new SqlParameter("@channelid", SqlDbType.Int,4)};
            parameters[0].Value = channelid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
