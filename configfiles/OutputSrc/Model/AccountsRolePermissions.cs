using System;

namespace SouEi.Model
{

	/// <summary>
	/// AccountsRolePermissions is an entity class that represents dbo.Accounts_RolePermissions
	/// </summary>
	[Serializable]
	public class MDLAccountsRolePermissions
	{
		#region declaration
		private string _TableName = "AccountsRolePermissions";
        private string _PrimaryKey = "";
		private int _RoleId;
		private int _PermissionId;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLAccountsRolePermissions() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLAccountsRolePermissions(int roleid, int permissionid)
        {
			this._RoleId = roleid;
			this._PermissionId = permissionid;
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
		/// RoleId is a int property that represents column of dbo.Accounts_RolePermissions.RoleId (RoleId)
		/// </summary>
		public int RoleId
		{
			get	{ return _RoleId; }
			set	{ _RoleId = value; }
		}
		/// <summary>
		/// PermissionId is a int property that represents column of dbo.Accounts_RolePermissions.PermissionId (PermissionId)
		/// </summary>
		public int PermissionId
		{
			get	{ return _PermissionId; }
			set	{ _PermissionId = value; }
		}
		#endregion		
	}
}
