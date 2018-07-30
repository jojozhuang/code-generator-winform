using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage STopMainMenu
	/// </summary>
	public class BLLSTopMainMenu
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALSTopMainMenu dal = new DAL.DALSTopMainMenu();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLSTopMainMenu> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLSTopMainMenu GetModel(int )
        {
			return dal.GetModel();
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLSTopMainMenu model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLSTopMainMenu model)
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
	