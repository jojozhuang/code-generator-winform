using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage CBlog
	/// </summary>
	public class BLLCBlog
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALCBlog dal = new DAL.DALCBlog();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLCBlog> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLCBlog GetModel(int BlogId)
        {
			return dal.GetModel(BlogId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLCBlog model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLCBlog model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int BlogId)
        {
            dal.Delete(BlogId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int BlogId)
        {
            return dal.IsExist(BlogId);
        }
	}
}
	