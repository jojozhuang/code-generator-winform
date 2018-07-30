using System;

namespace SouEi.Model
{

	/// <summary>
	/// AccountsPermissions is an entity class that represents dbo.Accounts_Permissions
	/// </summary>
	[Serializable]
	public class MDLAccountsPermissions
	{
		#region declaration
		private string _TableName = "AccountsPermissions";
        private string _PrimaryKey = "PermissionId";
		private int _PermissionId;
		private string _PermissionName;
		private int _PermissionCategoryId;
		private int _Sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLAccountsPermissions() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLAccountsPermissions(int permissionid, string permissionname, int permissioncategoryid, int sequence)
        {
			this._PermissionId = permissionid;
			this._PermissionName = permissionname;
			this._PermissionCategoryId = permissioncategoryid;
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
		/// PermissionId is a int property that represents column of dbo.Accounts_Permissions.PermissionId (PermissionId)
		/// </summary>
		public int PermissionId
		{
			get	{ return _PermissionId; }
			set	{ _PermissionId = value; }
		}
		/// <summary>
		/// PermissionName is a string property that represents column of dbo.Accounts_Permissions.PermissionName (PermissionName)
		/// </summary>
		public string PermissionName
		{
			get	{ return _PermissionName; }
			set	{ _PermissionName = value; }
		}
		/// <summary>
		/// PermissionCategoryId is a int property that represents column of dbo.Accounts_Permissions.PermissionCategoryId (PermissionCategoryId)
		/// </summary>
		public int PermissionCategoryId
		{
			get	{ return _PermissionCategoryId; }
			set	{ _PermissionCategoryId = value; }
		}
		/// <summary>
		/// Sequence is a int property that represents column of dbo.Accounts_Permissions.Sequence (Sequence)
		/// </summary>
		public int Sequence
		{
			get	{ return _Sequence; }
			set	{ _Sequence = value; }
		}
		#endregion		
	}
}
