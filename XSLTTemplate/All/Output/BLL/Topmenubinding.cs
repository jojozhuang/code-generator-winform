using System.Collections.Generic;

using Johnny.CMS.OM;
using Johnny.CMS.DAL;

namespace Johnny.EEE.BLL.Admin
{

	/// <summary>
	/// A business component to manage Topmenubinding
	/// </summary>
	public class Topmenubinding
	{
		// Get an instance of the Topmenubinding DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly Johnny.EEE.DAL.Admin.Topmenubinding dal = new Johnny.EEE.DAL.Admin.Topmenubinding();
	    
		/// <summary>
        /// Method to get records with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Topmenubinding> GetList()
        {
            return dal.GetList();
        }
        
		/// <summary>
        /// Method to get one record by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Topmenubinding GetModel(int )
        {
			return dal.GetModel();
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Topmenubinding model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(Johnny.EEE.OM.Admin.Topmenubinding model)
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
	