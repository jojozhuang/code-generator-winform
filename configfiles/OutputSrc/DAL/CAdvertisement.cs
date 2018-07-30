using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// CAdvertisement is a DAL calss that represents dbo.C_Advertisement
	/// </summary>
	public class DALCAdvertisement
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLCAdvertisement> GetList()
        {
            IList<MDLCAdvertisement> list = new List<MDLCAdvertisement>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [AdId], [Title], [Image], [Url], [IsValid], [Sequence] ");
            strSql.Append(" FROM [CAdvertisement] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLCAdvertisement item = new MDLCAdvertisement(sdr.(0), sdr.(1), sdr.(2), sdr.(3), sdr.(4), sdr.(5));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLCAdvertisement GetModel(int AdId)
        {
			//Set up a return value
            MDLCAdvertisement model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [AdId], [Title], [Image], [Url], [IsValid], [Sequence] ");
            strSql.Append(" FROM [CAdvertisement] ");
            strSql.Append(" WHERE [AdId]=" + AdId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLCAdvertisement(sdr.(0), sdr.(1), sdr.(2), sdr.(3), sdr.(4), sdr.(5));
				else
                    model = new MDLCAdvertisement();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLCAdvertisement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [CAdvertisement](");
            strSql.Append("[AdId],[Title],[Image],[Url],[IsValid],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("" + model.AdId + ",");
			strSql.Append("" + model.Title + ",");
			strSql.Append("" + model.Image + ",");
			strSql.Append("" + model.Url + ",");
			strSql.Append("" + model.IsValid + ",");
			strSql.Append("" + model.Sequence + "");
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
        public void Update(MDLCAdvertisement model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [CAdvertisement] SET ");
            strSql.Append("[AdId]=" + model.AdId + ",");
			strSql.Append("[Title]=" + model.Title + ",");
			strSql.Append("[Image]=" + model.Image + ",");
			strSql.Append("[Url]=" + model.Url + ",");
			strSql.Append("[IsValid]=" + model.IsValid + ",");
			strSql.Append("[Sequence]=" + model.Sequence + "");
			strSql.Append(" WHERE [AdId]=" + model.AdId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int AdId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [CAdvertisement] WHERE [AdId]=" + AdId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int AdId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [CAdvertisement] WHERE [AdId]=" + AdId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
