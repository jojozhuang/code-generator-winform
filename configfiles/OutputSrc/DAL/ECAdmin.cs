using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// ECAdmin is a DAL calss that represents dbo.EC_Admin
	/// </summary>
	public class DALECAdmin
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLECAdmin> GetList()
        {
            IList<MDLECAdmin> list = new List<MDLECAdmin>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID], [AdminName], [PassWord], [note], [Popedom], [CDT], [LDT], [loginTimes], [Lock], [Rights] ");
            strSql.Append(" FROM [ECAdmin] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLECAdmin item = new MDLECAdmin(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetString(3), sdr.GetInt32(4), sdr.GetDateTime(5), sdr.GetDateTime(6), sdr.GetInt32(7), sdr.GetBoolean(8), sdr.GetString(9));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLECAdmin GetModel(int ID)
        {
			//Set up a return value
            MDLECAdmin model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID], [AdminName], [PassWord], [note], [Popedom], [CDT], [LDT], [loginTimes], [Lock], [Rights] ");
            strSql.Append(" FROM [ECAdmin] ");
            strSql.Append(" WHERE [ID]=" + ID.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLECAdmin(sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetString(3), sdr.GetInt32(4), sdr.GetDateTime(5), sdr.GetDateTime(6), sdr.GetInt32(7), sdr.GetBoolean(8), sdr.GetString(9));
				else
                    model = new MDLECAdmin();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLECAdmin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [ECAdmin](");
            strSql.Append("[AdminName],[PassWord],[note],[Popedom],[CDT],[LDT],[loginTimes],[Lock],[Rights]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.AdminName + "',");
			strSql.Append("'" + model.PassWord + "',");
			strSql.Append("'" + model.note + "',");
			strSql.Append("" + model.Popedom + ",");
			strSql.Append("'" + model.CDT + "',");
			strSql.Append("'" + model.LDT + "',");
			strSql.Append("" + model.loginTimes + ",");
			strSql.Append("" + (model.Lock == true ? "1" : "0") + ",");
			strSql.Append("'" + model.Rights + "'");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        public void Update(MDLECAdmin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [ECAdmin] SET ");
            strSql.Append("[AdminName]='" + model.AdminName + "',");
			strSql.Append("[PassWord]='" + model.PassWord + "',");
			strSql.Append("[note]='" + model.note + "',");
			strSql.Append("[Popedom]=" + model.Popedom + ",");
			strSql.Append("[CDT]='" + model.CDT + "',");
			strSql.Append("[LDT]='" + model.LDT + "',");
			strSql.Append("[loginTimes]=" + model.loginTimes + ",");
			strSql.Append("[Lock]=" + (model.Lock == true ? "1" : "0") + ",");
			strSql.Append("[Rights]='" + model.Rights + "'");
			strSql.Append(" WHERE [ID]=" + model.ID + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [ECAdmin] WHERE [ID]=" + ID.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [ECAdmin] WHERE [ID]=" + ID.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
