using System.Collections.Generic;

using SouEi.Model;
using SouEi.DAL;

namespace SouEi.BLL
{

	/// <summary>
	/// A business component to manage AccountsUsers
	/// </summary>
	public class BLLAccountsUsers
	{
		// Get an instance of the User DAL
	    // Making this static will cache the DAL instance after the initial load
	    private static readonly DAL.DALAccountsUsers dal = new DAL.DALAccountsUsers();
	    
		/// <summary>
        /// Method to get recoders with condition
        /// </summary>    	 
        public IList<MDLAccountsUsers> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
		/// <summary>
        /// Method to get one recoder by primary key
        /// </summary>    	 
        public MDLAccountsUsers GetModel(int UserId)
        {
			return dal.GetModel(UserId);
        }

        /// <summary>
        /// Add one record
        /// </summary>
        public int Add(MDLAccountsUsers model)
        {
            return dal.Add(model);
        }
        
        /// <summary>
        /// Update one record
        /// </summary>
        public void Update(MDLAccountsUsers model)
        {
        	dal.Update(model);
        }
        
        /// <summary>
		/// Delete record by primary key
		/// </summary>
        public void Delete(int UserId)
        {
            dal.Delete(UserId);
        }
        
        /// <summary>
		/// Check exist by primary key
		/// </summary>
        public bool IsExist(int UserId)
        {
            return dal.IsExist(UserId);
        }
	}
}
	