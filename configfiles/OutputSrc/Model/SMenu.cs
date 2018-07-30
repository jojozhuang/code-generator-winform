using System;

namespace SouEi.Model
{

	/// <summary>
	/// SMenu is an entity class that represents dbo.S_Menu
	/// </summary>
	[Serializable]
	public class MDLSMenu
	{
		#region declaration
		private string _TableName = "SMenu";
        private string _PrimaryKey = "MenuId";
		private int _MenuId;
		private string _MenuName;
		private int _CategoryId;
		private string _PageLink;
		private string _ToolTip;
		private string _Image;
		private int _PermissionId;
		private bool _IsDisplay;
		private int _Sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLSMenu() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLSMenu(int menuid, string menuname, int categoryid, string pagelink, string tooltip, string image, int permissionid, bool isdisplay, int sequence)
        {
			this._MenuId = menuid;
			this._MenuName = menuname;
			this._CategoryId = categoryid;
			this._PageLink = pagelink;
			this._ToolTip = tooltip;
			this._Image = image;
			this._PermissionId = permissionid;
			this._IsDisplay = isdisplay;
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
		/// MenuId is a int property that represents column of dbo.S_Menu.MenuId (MenuId)
		/// </summary>
		public int MenuId
		{
			get	{ return _MenuId; }
			set	{ _MenuId = value; }
		}
		/// <summary>
		/// MenuName is a string property that represents column of dbo.S_Menu.MenuName (MenuName)
		/// </summary>
		public string MenuName
		{
			get	{ return _MenuName; }
			set	{ _MenuName = value; }
		}
		/// <summary>
		/// CategoryId is a int property that represents column of dbo.S_Menu.CategoryId (CategoryId)
		/// </summary>
		public int CategoryId
		{
			get	{ return _CategoryId; }
			set	{ _CategoryId = value; }
		}
		/// <summary>
		/// PageLink is a string property that represents column of dbo.S_Menu.PageLink (PageLink)
		/// </summary>
		public string PageLink
		{
			get	{ return _PageLink; }
			set	{ _PageLink = value; }
		}
		/// <summary>
		/// ToolTip is a string property that represents column of dbo.S_Menu.ToolTip (ToolTip)
		/// </summary>
		public string ToolTip
		{
			get	{ return _ToolTip; }
			set	{ _ToolTip = value; }
		}
		/// <summary>
		/// Image is a string property that represents column of dbo.S_Menu.Image (Image)
		/// </summary>
		public string Image
		{
			get	{ return _Image; }
			set	{ _Image = value; }
		}
		/// <summary>
		/// PermissionId is a int property that represents column of dbo.S_Menu.PermissionId (PermissionId)
		/// </summary>
		public int PermissionId
		{
			get	{ return _PermissionId; }
			set	{ _PermissionId = value; }
		}
		/// <summary>
		/// IsDisplay is a bool property that represents column of dbo.S_Menu.IsDisplay (IsDisplay)
		/// </summary>
		public bool IsDisplay
		{
			get	{ return _IsDisplay; }
			set	{ _IsDisplay = value; }
		}
		/// <summary>
		/// Sequence is a int property that represents column of dbo.S_Menu.Sequence (Sequence)
		/// </summary>
		public int Sequence
		{
			get	{ return _Sequence; }
			set	{ _Sequence = value; }
		}
		#endregion		
	}
}
