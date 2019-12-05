using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Permission
	/// </summary>
	[Serializable]
	public class Permission
	{
		#region declaration
		private string _TableName = "cms_permission";
        private string _PrimaryKey = "PermissionId";
        private bool _IsDesc = false;
		private int _permissionid;
		private string _permissionname;
		private int _permissioncategoryid;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Permission() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Permission(int permissionid, string permissionname, int permissioncategoryid, int sequence)
        {
			this._permissionid = permissionid;
			this._permissionname = permissionname;
			this._permissioncategoryid = permissioncategoryid;
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
		/// Permission Id
		/// </summary>
		public int PermissionId
		{
			get	{ return _permissionid; }
			set	{ _permissionid = value; }
		}
		/// <summary>
		/// Permission Name
		/// </summary>
		public string PermissionName
		{
			get	{ return _permissionname; }
			set	{ _permissionname = value; }
		}
		/// <summary>
		/// Permission Category
		/// </summary>
		public int PermissionCategoryId
		{
			get	{ return _permissioncategoryid; }
			set	{ _permissioncategoryid = value; }
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
