using System;

namespace SouEi.Model
{

	/// <summary>
	/// AccountsPermissionCategories is an entity class that represents dbo.Accounts_PermissionCategories
	/// </summary>
	[Serializable]
	public class MDLAccountsPermissionCategories
	{
		#region declaration
		private string _TableName = "AccountsPermissionCategories";
        private string _PrimaryKey = "PermissionCategoryId";
		private int _PermissionCategoryId;
		private string _Description;
		private int _Sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLAccountsPermissionCategories() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLAccountsPermissionCategories(int permissioncategoryid, string description, int sequence)
        {
			this._PermissionCategoryId = permissioncategoryid;
			this._Description = description;
			this._Sequence = sequence;
        }        
		#endregion

		#region property
		/// <summary>
        /// TableName of dbo.Province
        /// </summary>
        public string TableName
        {
            get { return _TableName; }
        }
        /// <summary>
        /// PrimaryKey of dbo.Province
        /// </summary>
        public string PrimaryKey
        {
            get { return _PrimaryKey; }
        }
		
		/// <summary>
		/// PermissionCategoryId is a int property that represents column of dbo.Accounts_PermissionCategories.PermissionCategoryId (PermissionCategoryId)
		/// </summary>
		public int PermissionCategoryId
		{
			get	{ return _PermissionCategoryId; }
			set	{ _PermissionCategoryId = value; }
		}
		/// <summary>
		/// Description is a string property that represents column of dbo.Accounts_PermissionCategories.Description (Description)
		/// </summary>
		public string Description
		{
			get	{ return _Description; }
			set	{ _Description = value; }
		}
		/// <summary>
		/// Sequence is a int property that represents column of dbo.Accounts_PermissionCategories.Sequence (Sequence)
		/// </summary>
		public int Sequence
		{
			get	{ return _Sequence; }
			set	{ _Sequence = value; }
		}
		#endregion		
	}
}
