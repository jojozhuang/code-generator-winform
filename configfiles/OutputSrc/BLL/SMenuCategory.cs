using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage SMenuCategory
	/// </summary>
	public class BLLSMenuCategory
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALSMenuCategory dal = new DAL.DALSMenuCategory();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLSMenuCategory> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLSMenuCategory GetModel(int MenuCategoryId)
        {
			return dal.GetModel(MenuCategoryId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLSMenuCategory model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLSMenuCategory model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int MenuCategoryId)
        {
            dal.Delete(MenuCategoryId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int MenuCategoryId)
        {
            return dal.IsExist(MenuCategoryId);
        }
	}
}
	