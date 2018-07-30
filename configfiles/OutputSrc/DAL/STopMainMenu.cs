using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// STopMainMenu is a DAL calss that represents dbo.S_TopMainMenu
	/// </summary>
	public class DALSTopMainMenu
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLSTopMainMenu> GetList()
        {
            IList<MDLSTopMainMenu> list = new List<MDLSTopMainMenu>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [TopMenuId], [MenuCategoryId] ");
            strSql.Append(" FROM [STopMainMenu] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLSTopMainMenu item = new MDLSTopMainMenu(sdr.GetInt32(0), sdr.GetInt32(1));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLSTopMainMenu GetModel(int )
        {
			//Set up a return value
            MDLSTopMainMenu model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [TopMenuId], [MenuCategoryId] ");
            strSql.Append(" FROM [STopMainMenu] ");
            strSql.Append(" WHERE []=" + .ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLSTopMainMenu(sdr.GetInt32(0), sdr.GetInt32(1));
				else
                    model = new MDLSTopMainMenu();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLSTopMainMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [STopMainMenu](");
            strSql.Append("[TopMenuId],[MenuCategoryId]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("" + model.TopMenuId + ",");
			strSql.Append("" + model.MenuCategoryId + "");
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
        public void Update(MDLSTopMainMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [STopMainMenu] SET ");
            strSql.Append("[TopMenuId]=" + model.TopMenuId + ",");
			strSql.Append("[MenuCategoryId]=" + model.MenuCategoryId + "");
			strSql.Append(" WHERE [);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [STopMainMenu] WHERE []=" + .ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [STopMainMenu] WHERE []=" + .ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
