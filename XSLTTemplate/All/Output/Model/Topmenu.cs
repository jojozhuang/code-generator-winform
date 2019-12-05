using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Topmenu
	/// </summary>
	[Serializable]
	public class Topmenu
	{
		#region declaration
		private string _TableName = "cms_topmenu";
        private string _PrimaryKey = "TopMenuId";
        private bool _IsDesc = false;
		private int _topmenuid;
		private string _topmenuname;
		private string _tooltip;
		private string _pagelink;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Topmenu() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Topmenu(int topmenuid, string topmenuname, string tooltip, string pagelink, int sequence)
        {
			this._topmenuid = topmenuid;
			this._topmenuname = topmenuname;
			this._tooltip = tooltip;
			this._pagelink = pagelink;
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
		/// Top Menu Id
		/// </summary>
		public int TopMenuId
		{
			get	{ return _topmenuid; }
			set	{ _topmenuid = value; }
		}
		/// <summary>
		/// Top Menu Name
		/// </summary>
		public string TopMenuName
		{
			get	{ return _topmenuname; }
			set	{ _topmenuname = value; }
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
		/// Default Page
		/// </summary>
		public string PageLink
		{
			get	{ return _pagelink; }
			set	{ _pagelink = value; }
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
