using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Rolepermission
	/// </summary>
	[Serializable]
	public class Rolepermission
	{
		#region declaration
		private string _TableName = "cms_rolepermission";
        private string _PrimaryKey = "";
        private bool _IsDesc = false;
		private int _roleid;
		private int _permissionid;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Rolepermission() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Rolepermission(int roleid, int permissionid)
        {
			this._roleid = roleid;
			this._permissionid = permissionid;
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
		/// Role
		/// </summary>
		public int RoleId
		{
			get	{ return _roleid; }
			set	{ _roleid = value; }
		}
		/// <summary>
		/// Permission
		/// </summary>
		public int PermissionId
		{
			get	{ return _permissionid; }
			set	{ _permissionid = value; }
		}
		#endregion		
	}
}
