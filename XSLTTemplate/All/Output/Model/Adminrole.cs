using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Adminrole
	/// </summary>
	[Serializable]
	public class Adminrole
	{
		#region declaration
		private string _TableName = "cms_adminrole";
        private string _PrimaryKey = "AdminRoleId";
        private bool _IsDesc = false;
		private int _adminroleid;
		private int _adminid;
		private int _roleid;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Adminrole() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Adminrole(int adminroleid, int adminid, int roleid, int sequence)
        {
			this._adminroleid = adminroleid;
			this._adminid = adminid;
			this._roleid = roleid;
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
		/// AdminRoleId
		/// </summary>
		public int AdminRoleId
		{
			get	{ return _adminroleid; }
			set	{ _adminroleid = value; }
		}
		/// <summary>
		/// Admin Id
		/// </summary>
		public int AdminId
		{
			get	{ return _adminid; }
			set	{ _adminid = value; }
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
