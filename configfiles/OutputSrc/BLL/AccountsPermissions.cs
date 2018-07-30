using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage AccountsPermissions
	/// </summary>
	public class BLLAccountsPermissions
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALAccountsPermissions dal = new DAL.DALAccountsPermissions();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsPermissions> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsPermissions GetModel(int PermissionId)
        {
			return dal.GetModel(PermissionId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsPermissions model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLAccountsPermissions model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int PermissionId)
        {
            dal.Delete(PermissionId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int PermissionId)
        {
            return dal.IsExist(PermissionId);
        }
	}
}
	