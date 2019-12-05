using System.Collections.Generic;

using Johnny.CMS.OM;
using Johnny.CMS.DAL;

namespace Johnny.EEE.BLL.Admin
{

	/// <summary>
	/// A business component to manage Menucategory
	/// </summary>
	public class Menucategory
	{
		// Get an instance of the Menucategory DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly Johnny.EEE.DAL.Admin.Menucategory dal = new Johnny.EEE.DAL.Admin.Menucategory();
	    
		/// <summary>
        /// Method to get records with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Menucategory> GetList()
        {
            return dal.GetList();
        }
        
		/// <summary>
        /// Method to get one record by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Menucategory GetModel(int menucategoryid)
        {
			return dal.GetModel(menucategoryid);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Menucategory model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(Johnny.EEE.OM.Admin.Menucategory model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int menucategoryid)
        {
            dal.Delete(menucategoryid);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int menucategoryid)
        {
            return dal.IsExist(menucategoryid);
        }
	}
}
	