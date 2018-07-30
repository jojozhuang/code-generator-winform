using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage SMenu
	/// </summary>
	public class BLLSMenu
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALSMenu dal = new DAL.DALSMenu();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLSMenu> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLSMenu GetModel(int MenuId)
        {
			return dal.GetModel(MenuId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLSMenu model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLSMenu model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int MenuId)
        {
            dal.Delete(MenuId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int MenuId)
        {
            return dal.IsExist(MenuId);
        }
	}
}
	