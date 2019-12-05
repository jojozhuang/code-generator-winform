using System.Collections.Generic;

using Johnny.CMS.OM;
using Johnny.CMS.DAL;

namespace Johnny.EEE.BLL.Admin
{

	/// <summary>
	/// A business component to manage Rolepermission
	/// </summary>
	public class Rolepermission
	{
		// Get an instance of the Rolepermission DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly Johnny.EEE.DAL.Admin.Rolepermission dal = new Johnny.EEE.DAL.Admin.Rolepermission();
	    
		/// <summary>
        /// Method to get records with condition
        /// </summary>    	 
        public IList<Johnny.EEE.OM.Admin.Rolepermission> GetList()
        {
            return dal.GetList();
        }
        
		/// <summary>
        /// Method to get one record by primary key
        /// </summary>    	 
        public Johnny.EEE.OM.Admin.Rolepermission GetModel(int )
        {
			return dal.GetModel();
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(Johnny.EEE.OM.Admin.Rolepermission model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(Johnny.EEE.OM.Admin.Rolepermission model)
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
	