using System.Collections.Generic;

using Johnny.CMS.OM;
using Johnny.CMS.DAL;

namespace Johnny.EEE.BLL.Admin
{

	/// <summary>
	/// A business component to manage Opensource
	/// </summary>
	public class Opensource
	{
		// Get an instance of the Opensource DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly Johnny.EEE.DAL.Admin.Opensource dal = new Johnny.EEE.DAL.Admin.Opensource();
	    
		/// <summary>
        /// Method to get records with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Opensource> GetList()
        {
            return dal.GetList();
        }
        
		/// <summary>
        /// Method to get one record by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Opensource GetModel(int opensourceid)
        {
			return dal.GetModel(opensourceid);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Opensource model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(Johnny.EEE.OM.Admin.Opensource model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int opensourceid)
        {
            dal.Delete(opensourceid);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int opensourceid)
        {
            return dal.IsExist(opensourceid);
        }
	}
}
	