using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Mailsettings is a DAL calss that represents cms_mailsettings
	/// </summary>
	public class Mailsettings
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Mailsettings> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Mailsettings> list = new List<Johnny.EEE.OM.Admin.Mailsettings>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [Id], [SmtpServerIP], [SmtpServerPort], [MailId], [MailPassword] ");
            strSql.Append(" FROM [cms_mailsettings] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Mailsettings item = new Johnny.EEE.OM.Admin.Mailsettings(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Mailsettings GetModel(int id)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Mailsettings model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [Id], [SmtpServerIP], [SmtpServerPort], [MailId], [MailPassword] ");
            strSql.Append(" FROM [cms_mailsettings] ");
            strSql.Append(" WHERE [Id]=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Mailsettings(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4));
				else
                    model = new Johnny.EEE.OM.Admin.Mailsettings();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Mailsettings model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [cms_mailsettings]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [cms_mailsettings](");
            strSql.Append("[SmtpServerIP],[SmtpServerPort],[MailId],[MailPassword]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@smtpserverip,@smtpserverport,@mailid,@mailpassword");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@smtpserverip", SqlDbType.VarChar,50),
					new SqlParameter("@smtpserverport", SqlDbType.Int,4),
					new SqlParameter("@mailid", SqlDbType.VarChar,100),
					new SqlParameter("@mailpassword", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SmtpServerIP;
            parameters[1].Value = model.SmtpServerPort;
            parameters[2].Value = model.MailId;
            parameters[3].Value = model.MailPassword;
            
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
        public void Update(Johnny.EEE.OM.Admin.Mailsettings model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [cms_mailsettings] SET ");
            strSql.Append("[SmtpServerIP]=@smtpserverip,");
			strSql.Append("[SmtpServerPort]=@smtpserverport,");
			strSql.Append("[MailId]=@mailid,");
			strSql.Append("[MailPassword]=@mailpassword");
			strSql.Append(" WHERE [Id]=@id ");
            SqlParameter[] parameters = {
            		new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@smtpserverip", SqlDbType.VarChar,50),
					new SqlParameter("@smtpserverport", SqlDbType.Int,4),
					new SqlParameter("@mailid", SqlDbType.VarChar,100),
					new SqlParameter("@mailpassword", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Id;
            parameters[1].Value = model.SmtpServerIP;
            parameters[2].Value = model.SmtpServerPort;
            parameters[3].Value = model.MailId;
            parameters[4].Value = model.MailPassword;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [cms_mailsettings] WHERE [Id]=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [cms_mailsettings] WHERE [Id]=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
