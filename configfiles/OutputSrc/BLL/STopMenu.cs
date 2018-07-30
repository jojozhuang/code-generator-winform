using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage STopMenu
	/// </summary>
	public class BLLSTopMenu
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALSTopMenu dal = new DAL.DALSTopMenu();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLSTopMenu> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLSTopMenu GetModel(int TopMenuId)
        {
			return dal.GetModel(TopMenuId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLSTopMenu model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLSTopMenu model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int TopMenuId)
        {
            dal.Delete(TopMenuId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int TopMenuId)
        {
            return dal.IsExist(TopMenuId);
        }
	}
}
	