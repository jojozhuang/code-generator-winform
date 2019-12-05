using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Permissioncategory
	/// </summary>
	[Serializable]
	public class Permissioncategory
	{
		#region declaration
		private string _TableName = "cms_permissioncategory";
        private string _PrimaryKey = "PermissionCategoryId";
        private bool _IsDesc = false;
		private int _permissioncategoryid;
		private string _permissioncategoryname;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Permissioncategory() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Permissioncategory(int permissioncategoryid, string permissioncategoryname, int sequence)
        {
			this._permissioncategoryid = permissioncategoryid;
			this._permissioncategoryname = permissioncategoryname;
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
		/// Permission Category Id
		/// </summary>
		public int PermissionCategoryId
		{
			get	{ return _permissioncategoryid; }
			set	{ _permissioncategoryid = value; }
		}
		/// <summary>
		/// Permission Category Name
		/// </summary>
		public string PermissionCategoryName
		{
			get	{ return _permissioncategoryname; }
			set	{ _permissioncategoryname = value; }
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
