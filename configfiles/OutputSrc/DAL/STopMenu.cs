using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// STopMenu is a DAL calss that represents dbo.S_TopMenu
	/// </summary>
	public class DALSTopMenu
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLSTopMenu> GetList()
        {
            IList<MDLSTopMenu> list = new List<MDLSTopMenu>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [TopMenuId], [TopMenuName], [Sequence], [Tips], [PageLink], [Image] ");
            strSql.Append(" FROM [STopMenu] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLSTopMenu item = new MDLSTopMenu(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4), sdr.GetString(5));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLSTopMenu GetModel(int TopMenuId)
        {
			//Set up a return value
            MDLSTopMenu model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [TopMenuId], [TopMenuName], [Sequence], [Tips], [PageLink], [Image] ");
            strSql.Append(" FROM [STopMenu] ");
            strSql.Append(" WHERE [TopMenuId]=" + TopMenuId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLSTopMenu(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4), sdr.GetString(5));
				else
                    model = new MDLSTopMenu();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLSTopMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [STopMenu](");
            strSql.Append("[TopMenuName],[Sequence],[Tips],[PageLink],[Image]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.TopMenuName + "',");
			strSql.Append("" + model.Sequence + ",");
			strSql.Append("'" + model.Tips + "',");
			strSql.Append("'" + model.PageLink + "',");
			strSql.Append("'" + model.Image + "'");
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
        public void Update(MDLSTopMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [STopMenu] SET ");
            strSql.Append("[TopMenuName]='" + model.TopMenuName + "',");
			strSql.Append("[Sequence]=" + model.Sequence + ",");
			strSql.Append("[Tips]='" + model.Tips + "',");
			strSql.Append("[PageLink]='" + model.PageLink + "',");
			strSql.Append("[Image]='" + model.Image + "'");
			strSql.Append(" WHERE [TopMenuId]=" + model.TopMenuId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int TopMenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [STopMenu] WHERE [TopMenuId]=" + TopMenuId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int TopMenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [STopMenu] WHERE [TopMenuId]=" + TopMenuId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
