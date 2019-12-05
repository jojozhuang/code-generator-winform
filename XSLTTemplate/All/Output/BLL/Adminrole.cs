using System.Collections.Generic;

using Johnny.CMS.OM;
using Johnny.CMS.DAL;

namespace Johnny.EEE.BLL.Admin
{

	/// <summary>
	/// A business component to manage Adminrole
	/// </summary>
	public class Adminrole
	{
		// Get an instance of the Adminrole DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly Johnny.EEE.DAL.Admin.Adminrole dal = new Johnny.EEE.DAL.Admin.Adminrole();
	    
		/// <summary>
        /// Method to get records with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Adminrole> GetList()
        {
            return dal.GetList();
        }
        
		/// <summary>
        /// Method to get one record by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Adminrole GetModel(int adminroleid)
        {
			return dal.GetModel(adminroleid);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Adminrole model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(Johnny.EEE.OM.Admin.Adminrole model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int adminroleid)
        {
            dal.Delete(adminroleid);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int adminroleid)
        {
            return dal.IsExist(adminroleid);
        }
	}
}
	