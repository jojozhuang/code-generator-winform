using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage AccountsRolePermissions
	/// </summary>
	public class BLLAccountsRolePermissions
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALAccountsRolePermissions dal = new DAL.DALAccountsRolePermissions();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsRolePermissions> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsRolePermissions GetModel(int )
        {
			return dal.GetModel();
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsRolePermissions model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLAccountsRolePermissions model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int )
        {
            dal.Delete();
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int )
        {
            return dal.IsExist();
        }
	}
}
	