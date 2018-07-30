using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// SMenu is a DAL calss that represents dbo.S_Menu
	/// </summary>
	public class DALSMenu
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLSMenu> GetList()
        {
            IList<MDLSMenu> list = new List<MDLSMenu>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [MenuId], [MenuName], [CategoryId], [PageLink], [ToolTip], [Image], [PermissionId], [IsDisplay], [Sequence] ");
            strSql.Append(" FROM [SMenu] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLSMenu item = new MDLSMenu(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4), sdr.GetString(5), sdr.GetInt32(6), sdr.GetBoolean(7), sdr.GetInt32(8));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLSMenu GetModel(int MenuId)
        {
			//Set up a return value
            MDLSMenu model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [MenuId], [MenuName], [CategoryId], [PageLink], [ToolTip], [Image], [PermissionId], [IsDisplay], [Sequence] ");
            strSql.Append(" FROM [SMenu] ");
            strSql.Append(" WHERE [MenuId]=" + MenuId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLSMenu(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4), sdr.GetString(5), sdr.GetInt32(6), sdr.GetBoolean(7), sdr.GetInt32(8));
				else
                    model = new MDLSMenu();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLSMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [SMenu](");
            strSql.Append("[MenuName],[CategoryId],[PageLink],[ToolTip],[Image],[PermissionId],[IsDisplay],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("'" + model.MenuName + "',");
			strSql.Append("" + model.CategoryId + ",");
			strSql.Append("'" + model.PageLink + "',");
			strSql.Append("'" + model.ToolTip + "',");
			strSql.Append("'" + model.Image + "',");
			strSql.Append("" + model.PermissionId + ",");
			strSql.Append("" + (model.IsDisplay == true ? "1" : "0") + ",");
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
        public void Update(MDLSMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [SMenu] SET ");
            strSql.Append("[MenuName]='" + model.MenuName + "',");
			strSql.Append("[CategoryId]=" + model.CategoryId + ",");
			strSql.Append("[PageLink]='" + model.PageLink + "',");
			strSql.Append("[ToolTip]='" + model.ToolTip + "',");
			strSql.Append("[Image]='" + model.Image + "',");
			strSql.Append("[PermissionId]=" + model.PermissionId + ",");
			strSql.Append("[IsDisplay]=" + (model.IsDisplay == true ? "1" : "0") + ",");
			strSql.Append("[Sequence]=" + model.Sequence + "");
			strSql.Append(" WHERE [MenuId]=" + model.MenuId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int MenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [SMenu] WHERE [MenuId]=" + MenuId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int MenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [SMenu] WHERE [MenuId]=" + MenuId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
