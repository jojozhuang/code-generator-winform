using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage CBlogCategory
	/// </summary>
	public class BLLCBlogCategory
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALCBlogCategory dal = new DAL.DALCBlogCategory();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLCBlogCategory> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLCBlogCategory GetModel(int BlogCategoryId)
        {
			return dal.GetModel(BlogCategoryId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLCBlogCategory model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLCBlogCategory model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int BlogCategoryId)
        {
            dal.Delete(BlogCategoryId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int BlogCategoryId)
        {
            return dal.IsExist(BlogCategoryId);
        }
	}
}
	