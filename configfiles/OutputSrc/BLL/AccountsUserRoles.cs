using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage AccountsUserRoles
	/// </summary>
	public class BLLAccountsUserRoles
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALAccountsUserRoles dal = new DAL.DALAccountsUserRoles();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsUserRoles> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsUserRoles GetModel(int UserRoleId)
        {
			return dal.GetModel(UserRoleId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsUserRoles model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLAccountsUserRoles model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int UserRoleId)
        {
            dal.Delete(UserRoleId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int UserRoleId)
        {
            return dal.IsExist(UserRoleId);
        }
	}
}
	