using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage CNewsCategory
	/// </summary>
	public class BLLCNewsCategory
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALCNewsCategory dal = new DAL.DALCNewsCategory();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLCNewsCategory> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLCNewsCategory GetModel(int NewsCategoryId)
        {
			return dal.GetModel(NewsCategoryId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLCNewsCategory model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLCNewsCategory model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int NewsCategoryId)
        {
            dal.Delete(NewsCategoryId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int NewsCategoryId)
        {
            return dal.IsExist(NewsCategoryId);
        }
	}
}
	