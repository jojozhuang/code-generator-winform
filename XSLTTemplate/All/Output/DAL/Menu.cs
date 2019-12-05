using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Johnny.Library.Database;

namespace Johnny.EEE.DAL.Admin
{

	/// <summary>
	/// Menu is a DAL calss that represents cms_menu
	/// </summary>
	public class Menu
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Menu> GetList()
        {
            IList<Johnny.EEE.OM.Admin.Menu> list = new List<Johnny.EEE.OM.Admin.Menu>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [MenuId], [MenuName], [MenuCategoryId], [PageLink], [ToolTip], [Image], [PermissionId], [IsDisplay], [Sequence] ");
            strSql.Append(" FROM [cms_menu] ");   
            strSql.Append(" ORDER BY [Sequence]");

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    Johnny.EEE.OM.Admin.Menu item = new Johnny.EEE.OM.Admin.Menu(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4), sdr.GetString(5), sdr.GetInt32(6), sdr.GetBoolean(7), sdr.GetInt32(8));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Menu GetModel(int menuid)
        {
			//Set up a return value
            Johnny.EEE.OM.Admin.Menu model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [MenuId], [MenuName], [MenuCategoryId], [PageLink], [ToolTip], [Image], [PermissionId], [IsDisplay], [Sequence] ");
            strSql.Append(" FROM [cms_menu] ");
            strSql.Append(" WHERE [MenuId]=@menuid");
            SqlParameter[] parameters = {
					new SqlParameter("@menuid", SqlDbType.Int,4)};
            parameters[0].Value = menuid;
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString(), parameters))
            {
                if (sdr.Read())
                    model = new Johnny.EEE.OM.Admin.Menu(sdr.GetInt32(0), sdr.GetString(1), sdr.GetInt32(2), sdr.GetString(3), sdr.GetString(4), sdr.GetString(5), sdr.GetInt32(6), sdr.GetBoolean(7), sdr.GetInt32(8));
				else
                    model = new Johnny.EEE.OM.Admin.Menu();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DECLARE @Sequence int");
            strSql.Append(" SELECT @Sequence=(max(Sequence)+1) FROM [cms_menu]");
            strSql.Append(" if @Sequence is NULL");
            strSql.Append(" Set @Sequence=1");
            strSql.Append("INSERT INTO [cms_menu](");
            strSql.Append("[MenuName],[MenuCategoryId],[PageLink],[ToolTip],[Image],[PermissionId],[IsDisplay],[Sequence]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("@menuname,@menucategoryid,@pagelink,@tooltip,@image,@permissionid,@isdisplay,@sequence");
			strSql.Append(")");
            strSql.Append(";SELECT @@IDENTITY");
            SqlParameter[] parameters = {
            		new SqlParameter("@menuname", SqlDbType.NVarChar,50),
					new SqlParameter("@menucategoryid", SqlDbType.Int,4),
					new SqlParameter("@pagelink", SqlDbType.VarChar,100),
					new SqlParameter("@tooltip", SqlDbType.NVarChar,100),
					new SqlParameter("@image", SqlDbType.VarChar,200),
					new SqlParameter("@permissionid", SqlDbType.Int,4),
					new SqlParameter("@isdisplay", SqlDbType.Bit),
					new SqlParameter("@sequence", SqlDbType.Int,4)};
			parameters[0].Value = model.MenuName;
            parameters[1].Value = model.MenuCategoryId;
            parameters[2].Value = model.PageLink;
            parameters[3].Value = model.ToolTip;
            parameters[4].Value = model.Image;
            parameters[5].Value = model.PermissionId;
            parameters[6].Value = model.IsDisplay;
            parameters[7].Value = model.Sequence;
            
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
        public void Update(Johnny.EEE.OM.Admin.Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [cms_menu] SET ");
            strSql.Append("[MenuName]=@menuname,");
			strSql.Append("[MenuCategoryId]=@menucategoryid,");
			strSql.Append("[PageLink]=@pagelink,");
			strSql.Append("[ToolTip]=@tooltip,");
			strSql.Append("[Image]=@image,");
			strSql.Append("[PermissionId]=@permissionid,");
			strSql.Append("[IsDisplay]=@isdisplay,");
			strSql.Append("[Sequence]=@sequence");
			strSql.Append(" WHERE [MenuId]=@menuid ");
            SqlParameter[] parameters = {
            		new SqlParameter("@menuid", SqlDbType.Int,4),
					new SqlParameter("@menuname", SqlDbType.NVarChar,50),
					new SqlParameter("@menucategoryid", SqlDbType.Int,4),
					new SqlParameter("@pagelink", SqlDbType.VarChar,100),
					new SqlParameter("@tooltip", SqlDbType.NVarChar,100),
					new SqlParameter("@image", SqlDbType.VarChar,200),
					new SqlParameter("@permissionid", SqlDbType.Int,4),
					new SqlParameter("@isdisplay", SqlDbType.Bit),
			};
			parameters[0].Value = model.MenuId;
            parameters[1].Value = model.MenuName;
            parameters[2].Value = model.MenuCategoryId;
            parameters[3].Value = model.PageLink;
            parameters[4].Value = model.ToolTip;
            parameters[5].Value = model.Image;
            parameters[6].Value = model.PermissionId;
            parameters[7].Value = model.IsDisplay;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int menuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [cms_menu] WHERE [MenuId]=@menuid");
            SqlParameter[] parameters = {
					new SqlParameter("@menuid", SqlDbType.Int,4)};
            parameters[0].Value = menuid;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int menuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [cms_menu] WHERE [MenuId]=@menuid");
            SqlParameter[] parameters = {
					new SqlParameter("@menuid", SqlDbType.Int,4)};
            parameters[0].Value = menuid;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
	}
}
