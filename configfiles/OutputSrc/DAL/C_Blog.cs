using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace aaa.SmartMoney.DAL
{

	/// <summary>
	/// C_Blog is a DAL calss that represents dbo.C_Blog
	/// </summary>
	public class DALC_Blog
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLC_Blog> GetList()
        {
            IList<MDLC_Blog> list = new List<MDLC_Blog>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [BlogId], [BlogTitle], [BlogCategory], [Tag], [Content], [Hits], [IsDisplay], [Sequence], [AddedTime], [AddedBy], [UpdatedTime], [UpdatedBy] ");
            strSql.Append(" FROM [C_Blog] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLC_Blog item = new MDLC_Blog(sdr.(0), sdr.(1), sdr.(2), sdr.(3), sdr.(4), sdr.(5), sdr.(6), sdr.(7), sdr.(8), sdr.(9), sdr.(10), sdr.(11));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLC_Blog GetModel(int BlogId)
        {
			//Set up a return value
            MDLC_Blog model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [BlogId], [BlogTitle], [BlogCategory], [Tag], [Content], [Hits], [IsDisplay], [Sequence], [AddedTime], [AddedBy], [UpdatedTime], [UpdatedBy] ");
            strSql.Append(" FROM [C_Blog] ");
            strSql.Append(" WHERE [BlogId]=" + BlogId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLC_Blog(sdr.(0), sdr.(1), sdr.(2), sdr.(3), sdr.(4), sdr.(5), sdr.(6), sdr.(7), sdr.(8), sdr.(9), sdr.(10), sdr.(11));
				else
                    model = new MDLC_Blog();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLC_Blog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [C_Blog](");
            strSql.Append("[BlogId],[BlogTitle],[BlogCategory],[Tag],[Content],[Hits],[IsDisplay],[Sequence],[AddedTime],[AddedBy],[UpdatedTime],[UpdatedBy]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("" + model.BlogId + ",");
			strSql.Append("" + model.BlogTitle + ",");
			strSql.Append("" + model.BlogCategory + ",");
			strSql.Append("" + model.Tag + ",");
			strSql.Append("" + model.Content + ",");
			strSql.Append("" + model.Hits + ",");
			strSql.Append("" + model.IsDisplay + ",");
			strSql.Append("" + model.Sequence + ",");
			strSql.Append("" + model.AddedTime + ",");
			strSql.Append("" + model.AddedBy + ",");
			strSql.Append("" + model.UpdatedTime + ",");
			strSql.Append("" + model.UpdatedBy + "");
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
        public void Update(MDLC_Blog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [C_Blog] SET ");
            strSql.Append("[BlogId]=" + model.BlogId + ",");
			strSql.Append("[BlogTitle]=" + model.BlogTitle + ",");
			strSql.Append("[BlogCategory]=" + model.BlogCategory + ",");
			strSql.Append("[Tag]=" + model.Tag + ",");
			strSql.Append("[Content]=" + model.Content + ",");
			strSql.Append("[Hits]=" + model.Hits + ",");
			strSql.Append("[IsDisplay]=" + model.IsDisplay + ",");
			strSql.Append("[Sequence]=" + model.Sequence + ",");
			strSql.Append("[AddedTime]=" + model.AddedTime + ",");
			strSql.Append("[AddedBy]=" + model.AddedBy + ",");
			strSql.Append("[UpdatedTime]=" + model.UpdatedTime + ",");
			strSql.Append("[UpdatedBy]=" + model.UpdatedBy + "");
			strSql.Append(" WHERE [BlogId]=" + model.BlogId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int BlogId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [C_Blog] WHERE [BlogId]=" + BlogId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int BlogId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [C_Blog] WHERE [BlogId]=" + BlogId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
