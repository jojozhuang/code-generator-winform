using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage ECAdmin
	/// </summary>
	public class BLLECAdmin
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALECAdmin dal = new DAL.DALECAdmin();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLECAdmin> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLECAdmin GetModel(int ID)
        {
			return dal.GetModel(ID);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLECAdmin model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLECAdmin model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int ID)
        {
            dal.Delete(ID);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int ID)
        {
            return dal.IsExist(ID);
        }
	}
}
	