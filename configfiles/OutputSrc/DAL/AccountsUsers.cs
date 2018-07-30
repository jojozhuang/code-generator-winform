using System;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

using SouEi.Model;
using SouEi.DBUtility;

namespace SouEi.DAL
{

	/// <summary>
	/// AccountsUsers is a DAL calss that represents dbo.Accounts_Users
	/// </summary>
	public class DALAccountsUsers
	{
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsUsers> GetList()
        {
            IList<MDLAccountsUsers> list = new List<MDLAccountsUsers>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserId], [UserName], [Password], [RealName], [Email], [Gender], [Birthday], [Address], [CityId], [PostalCode], [Sequence], [LoginTimes], [LastLogin], [AddedTime], [AddedBy], [UpdatedTime], [UpdatedBy] ");
            strSql.Append(" FROM [AccountsUsers] ");            

            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (sdr.Read())
                {
                    MDLAccountsUsers item = new MDLAccountsUsers(sdr.(0), sdr.(1), sdr.(2), sdr.(3), sdr.(4), sdr.(5), sdr.(6), sdr.(7), sdr.(8), sdr.(9), sdr.(10), sdr.(11), sdr.(12), sdr.(13), sdr.(14), sdr.(15), sdr.(16));
                    list.Add(item);
                }
            }
            return list;
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsUsers GetModel(int UserId)
        {
			//Set up a return value
            MDLAccountsUsers model = null;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [UserId], [UserName], [Password], [RealName], [Email], [Gender], [Birthday], [Address], [CityId], [PostalCode], [Sequence], [LoginTimes], [LastLogin], [AddedTime], [AddedBy], [UpdatedTime], [UpdatedBy] ");
            strSql.Append(" FROM [AccountsUsers] ");
            strSql.Append(" WHERE [UserId]=" + UserId.ToString());
            using (SqlDataReader sdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (sdr.Read())
                    model = new MDLAccountsUsers(sdr.(0), sdr.(1), sdr.(2), sdr.(3), sdr.(4), sdr.(5), sdr.(6), sdr.(7), sdr.(8), sdr.(9), sdr.(10), sdr.(11), sdr.(12), sdr.(13), sdr.(14), sdr.(15), sdr.(16));
				else
                    model = new MDLAccountsUsers();                
            }
            return model;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsUsers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO [AccountsUsers](");
            strSql.Append("[UserId],[UserName],[Password],[RealName],[Email],[Gender],[Birthday],[Address],[CityId],[PostalCode],[Sequence],[LoginTimes],[LastLogin],[AddedTime],[AddedBy],[UpdatedTime],[UpdatedBy]");
            strSql.Append(")");
            strSql.Append(" VALUES (");
            strSql.Append("" + model.UserId + ",");
			strSql.Append("" + model.UserName + ",");
			strSql.Append("" + model.Password + ",");
			strSql.Append("" + model.RealName + ",");
			strSql.Append("" + model.Email + ",");
			strSql.Append("" + model.Gender + ",");
			strSql.Append("" + model.Birthday + ",");
			strSql.Append("" + model.Address + ",");
			strSql.Append("" + model.CityId + ",");
			strSql.Append("" + model.PostalCode + ",");
			strSql.Append("" + model.Sequence + ",");
			strSql.Append("" + model.LoginTimes + ",");
			strSql.Append("" + model.LastLogin + ",");
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
        public void Update(MDLAccountsUsers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE [AccountsUsers] SET ");
            strSql.Append("[UserId]=" + model.UserId + ",");
			strSql.Append("[UserName]=" + model.UserName + ",");
			strSql.Append("[Password]=" + model.Password + ",");
			strSql.Append("[RealName]=" + model.RealName + ",");
			strSql.Append("[Email]=" + model.Email + ",");
			strSql.Append("[Gender]=" + model.Gender + ",");
			strSql.Append("[Birthday]=" + model.Birthday + ",");
			strSql.Append("[Address]=" + model.Address + ",");
			strSql.Append("[CityId]=" + model.CityId + ",");
			strSql.Append("[PostalCode]=" + model.PostalCode + ",");
			strSql.Append("[Sequence]=" + model.Sequence + ",");
			strSql.Append("[LoginTimes]=" + model.LoginTimes + ",");
			strSql.Append("[LastLogin]=" + model.LastLogin + ",");
			strSql.Append("[AddedTime]=" + model.AddedTime + ",");
			strSql.Append("[AddedBy]=" + model.AddedBy + ",");
			strSql.Append("[UpdatedTime]=" + model.UpdatedTime + ",");
			strSql.Append("[UpdatedBy]=" + model.UpdatedBy + "");
			strSql.Append(" WHERE [UserId]=" + model.UserId + "");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM [AccountsUsers] WHERE [UserId]=" + UserId.ToString());
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM [AccountsUsers] WHERE [UserId]=" + UserId.ToString() + "");
            return DbHelperSQL.Exists(strSql.ToString());
        }
	}
}
