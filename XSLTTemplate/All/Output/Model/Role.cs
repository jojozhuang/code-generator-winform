using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Role
	/// </summary>
	[Serializable]
	public class Role
	{
		#region declaration
		private string _TableName = "cms_role";
        private string _PrimaryKey = "RoleId";
        private bool _IsDesc = false;
		private int _roleid;
		private string _rolename;
		private string _description;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Role() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Role(int roleid, string rolename, string description, int sequence)
        {
			this._roleid = roleid;
			this._rolename = rolename;
			this._description = description;
			this._sequence = sequence;
        }        
		#endregion

		#region property
		/// <summary>
        /// TableName
        /// </summary>
        public string TableName
        {
            get { return _TableName; }
        }
        /// <summary>
        /// PrimaryKey
        /// </summary>
        public string PrimaryKey
        {
            get { return _PrimaryKey; }
        }       
        /// <summary>
        /// IsDesc
        /// </summary>
        public bool IsDesc
        {
            get { return _IsDesc; }
        }
		/// <summary>
		/// Role Id
		/// </summary>
		public int RoleId
		{
			get	{ return _roleid; }
			set	{ _roleid = value; }
		}
		/// <summary>
		/// Role Name
		/// </summary>
		public string RoleName
		{
			get	{ return _rolename; }
			set	{ _rolename = value; }
		}
		/// <summary>
		/// Description
		/// </summary>
		public string Description
		{
			get	{ return _description; }
			set	{ _description = value; }
		}
		/// <summary>
		/// Sequence
		/// </summary>
		public int Sequence
		{
			get	{ return _sequence; }
			set	{ _sequence = value; }
		}
		#endregion		
	}
}
