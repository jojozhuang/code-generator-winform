using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Menu
	/// </summary>
	[Serializable]
	public class Menu
	{
		#region declaration
		private string _TableName = "cms_menu";
        private string _PrimaryKey = "MenuId";
        private bool _IsDesc = false;
		private int _menuid;
		private string _menuname;
		private int _menucategoryid;
		private string _pagelink;
		private string _tooltip;
		private string _image;
		private int _permissionid;
		private bool _isdisplay;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Menu() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Menu(int menuid, string menuname, int menucategoryid, string pagelink, string tooltip, string image, int permissionid, bool isdisplay, int sequence)
        {
			this._menuid = menuid;
			this._menuname = menuname;
			this._menucategoryid = menucategoryid;
			this._pagelink = pagelink;
			this._tooltip = tooltip;
			this._image = image;
			this._permissionid = permissionid;
			this._isdisplay = isdisplay;
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
		/// Menu Id
		/// </summary>
		public int MenuId
		{
			get	{ return _menuid; }
			set	{ _menuid = value; }
		}
		/// <summary>
		/// Menu Name
		/// </summary>
		public string MenuName
		{
			get	{ return _menuname; }
			set	{ _menuname = value; }
		}
		/// <summary>
		/// Menu Category
		/// </summary>
		public int MenuCategoryId
		{
			get	{ return _menucategoryid; }
			set	{ _menucategoryid = value; }
		}
		/// <summary>
		/// Page Link
		/// </summary>
		public string PageLink
		{
			get	{ return _pagelink; }
			set	{ _pagelink = value; }
		}
		/// <summary>
		/// ToolTip
		/// </summary>
		public string ToolTip
		{
			get	{ return _tooltip; }
			set	{ _tooltip = value; }
		}
		/// <summary>
		/// Image
		/// </summary>
		public string Image
		{
			get	{ return _image; }
			set	{ _image = value; }
		}
		/// <summary>
		/// Permission
		/// </summary>
		public int PermissionId
		{
			get	{ return _permissionid; }
			set	{ _permissionid = value; }
		}
		/// <summary>
		/// Display in the Menu
		/// </summary>
		public bool IsDisplay
		{
			get	{ return _isdisplay; }
			set	{ _isdisplay = value; }
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
