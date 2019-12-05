using System.Collections.Generic;

using Johnny.CMS.OM;
using Johnny.CMS.DAL;

namespace Johnny.EEE.BLL.Admin
{

	/// <summary>
	/// A business component to manage Permission
	/// </summary>
	public class Permission
	{
		// Get an instance of the Permission DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly Johnny.EEE.DAL.Admin.Permission dal = new Johnny.EEE.DAL.Admin.Permission();
	    
		/// <summary>
        /// Method to get records with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Permission> GetList()
        {
            return dal.GetList();
        }
        
		/// <summary>
        /// Method to get one record by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Permission GetModel(int permissionid)
        {
			return dal.GetModel(permissionid);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Permission model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(Johnny.EEE.OM.Admin.Permission model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int permissionid)
        {
            dal.Delete(permissionid);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int permissionid)
        {
            return dal.IsExist(permissionid);
        }
	}
}
	