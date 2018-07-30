using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace aaa.SmartMoney.BLL
{

	/// <summary>
	/// A business component to manage C_Blog
	/// </summary>
	public class BLLC_Blog
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALC_Blog dal = new DAL.DALC_Blog();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLC_Blog> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLC_Blog GetModel(int BlogId)
        {
			return dal.GetModel(BlogId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLC_Blog model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLC_Blog model)
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
	