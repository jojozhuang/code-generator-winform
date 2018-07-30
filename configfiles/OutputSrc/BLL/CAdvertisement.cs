using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage CAdvertisement
	/// </summary>
	public class BLLCAdvertisement
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALCAdvertisement dal = new DAL.DALCAdvertisement();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLCAdvertisement> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLCAdvertisement GetModel(int AdId)
        {
			return dal.GetModel(AdId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLCAdvertisement model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLCAdvertisement model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int AdId)
        {
            dal.Delete(AdId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int AdId)
        {
            return dal.IsExist(AdId);
        }
	}
}
	