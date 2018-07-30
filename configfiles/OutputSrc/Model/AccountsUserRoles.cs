using System;

namespace SouEi.Model
{

	/// <summary>
	/// AccountsUserRoles is an entity class that represents dbo.Accounts_UserRoles
	/// </summary>
	[Serializable]
	public class MDLAccountsUserRoles
	{
		#region declaration
		private string _TableName = "AccountsUserRoles";
        private string _PrimaryKey = "UserRoleId";
		private  _userroleid;
		private  _userid;
		private  _roleid;
		private  _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLAccountsUserRoles() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLAccountsUserRoles( userroleid,  userid,  roleid,  sequence)
        {
			this._userroleid = userroleid;
			this._userid = userid;
			this._roleid = roleid;
			this._sequence = sequence;
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
		/// UserRoleId is a  property that represents column of dbo.Accounts_UserRoles.UserRoleId
		/// </summary>
		public  UserRoleId
		{
			get	{ return _userroleid; }
			set	{ _userroleid = value; }
		}
		/// <summary>
		/// UserId is a  property that represents column of dbo.Accounts_UserRoles.UserId
		/// </summary>
		public  UserId
		{
			get	{ return _userid; }
			set	{ _userid = value; }
		}
		/// <summary>
		/// RoleId is a  property that represents column of dbo.Accounts_UserRoles.RoleId
		/// </summary>
		public  RoleId
		{
			get	{ return _roleid; }
			set	{ _roleid = value; }
		}
		/// <summary>
		/// Sequence is a  property that represents column of dbo.Accounts_UserRoles.Sequence
		/// </summary>
		public  Sequence
		{
			get	{ return _sequence; }
			set	{ _sequence = value; }
		}
		#endregion		
	}
}
