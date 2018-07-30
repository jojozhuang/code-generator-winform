using System;

namespace SouEi.Model
{

	/// <summary>
	/// AccountsRoles is an entity class that represents dbo.Accounts_Roles
	/// </summary>
	[Serializable]
	public class MDLAccountsRoles
	{
		#region declaration
		private string _TableName = "AccountsRoles";
        private string _PrimaryKey = "RoleId";
		private int _RoleId;
		private string _RoleName;
		private int _Sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLAccountsRoles() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLAccountsRoles(int roleid, string rolename, int sequence)
        {
			this._RoleId = roleid;
			this._RoleName = rolename;
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
		/// RoleId is a int property that represents column of dbo.Accounts_Roles.RoleId (RoleId)
		/// </summary>
		public int RoleId
		{
			get	{ return _RoleId; }
			set	{ _RoleId = value; }
		}
		/// <summary>
		/// RoleName is a string property that represents column of dbo.Accounts_Roles.RoleName (RoleName)
		/// </summary>
		public string RoleName
		{
			get	{ return _RoleName; }
			set	{ _RoleName = value; }
		}
		/// <summary>
		/// Sequence is a int property that represents column of dbo.Accounts_Roles.Sequence (Sequence)
		/// </summary>
		public int Sequence
		{
			get	{ return _Sequence; }
			set	{ _Sequence = value; }
		}
		#endregion		
	}
}
