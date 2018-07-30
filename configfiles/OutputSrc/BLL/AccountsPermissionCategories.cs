using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage AccountsPermissionCategories
	/// </summary>
	public class BLLAccountsPermissionCategories
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALAccountsPermissionCategories dal = new DAL.DALAccountsPermissionCategories();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsPermissionCategories> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsPermissionCategories GetModel(int PermissionCategoryId)
        {
			return dal.GetModel(PermissionCategoryId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsPermissionCategories model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLAccountsPermissionCategories model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int PermissionCategoryId)
        {
            dal.Delete(PermissionCategoryId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int PermissionCategoryId)
        {
            return dal.IsExist(PermissionCategoryId);
        }
	}
}
	