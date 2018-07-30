using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage AccountsRoles
	/// </summary>
	public class BLLAccountsRoles
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALAccountsRoles dal = new DAL.DALAccountsRoles();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsRoles> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsRoles GetModel(int RoleId)
        {
			return dal.GetModel(RoleId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsRoles model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLAccountsRoles model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int RoleId)
        {
            dal.Delete(RoleId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int RoleId)
        {
            return dal.IsExist(RoleId);
        }
	}
}
	