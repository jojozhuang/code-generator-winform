using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Navigator
	/// </summary>
	[Serializable]
	public class Navigator
	{
		#region declaration
		private string _TableName = "cms_navigator";
        private string _PrimaryKey = "NavigatorId";
        private bool _IsDesc = false;
		private int _navigatorid;
		private string _navigatorname;
		private string _url;
		private int _parentid;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Navigator() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Navigator(int navigatorid, string navigatorname, string url, int parentid)
        {
			this._navigatorid = navigatorid;
			this._navigatorname = navigatorname;
			this._url = url;
			this._parentid = parentid;
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
		///  
		/// </summary>
		public int NavigatorId
		{
			get	{ return _navigatorid; }
			set	{ _navigatorid = value; }
		}
		/// <summary>
		///  
		/// </summary>
		public string NavigatorName
		{
			get	{ return _navigatorname; }
			set	{ _navigatorname = value; }
		}
		/// <summary>
		///  
		/// </summary>
		public string Url
		{
			get	{ return _url; }
			set	{ _url = value; }
		}
		/// <summary>
		///  
		/// </summary>
		public int ParentId
		{
			get	{ return _parentid; }
			set	{ _parentid = value; }
		}
		#endregion		
	}
}
