using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Website
	/// </summary>
	[Serializable]
	public class Website
	{
		#region declaration
		private string _TableName = "seh_website";
        private string _PrimaryKey = "WebsiteId";
        private bool _IsDesc = false;
		private int _websiteid;
		private string _websitename;
		private int _websitecategoryid;
		private string _description;
		private string _url;
		private int _hits;
		private bool _isdisplay;
		private DateTime _createdtime;
		private int _createdbyid;
		private string _createdbyname;
		private DateTime _updatedtime;
		private int _updatedbyid;
		private string _updatedbyname;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Website() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Website(int websiteid, string websitename, int websitecategoryid, string description, string url, int hits, bool isdisplay, DateTime createdtime, int createdbyid, string createdbyname, DateTime updatedtime, int updatedbyid, string updatedbyname, int sequence)
        {
			this._websiteid = websiteid;
			this._websitename = websitename;
			this._websitecategoryid = websitecategoryid;
			this._description = description;
			this._url = url;
			this._hits = hits;
			this._isdisplay = isdisplay;
			this._createdtime = createdtime;
			this._createdbyid = createdbyid;
			this._createdbyname = createdbyname;
			this._updatedtime = updatedtime;
			this._updatedbyid = updatedbyid;
			this._updatedbyname = updatedbyname;
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
		/// Website Id
		/// </summary>
		public int WebsiteId
		{
			get	{ return _websiteid; }
			set	{ _websiteid = value; }
		}
		/// <summary>
		/// Website Name
		/// </summary>
		public string WebsiteName
		{
			get	{ return _websitename; }
			set	{ _websitename = value; }
		}
		/// <summary>
		/// Website Category
		/// </summary>
		public int WebsiteCategoryId
		{
			get	{ return _websitecategoryid; }
			set	{ _websitecategoryid = value; }
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
		/// URL
		/// </summary>
		public string URL
		{
			get	{ return _url; }
			set	{ _url = value; }
		}
		/// <summary>
		/// Hits
		/// </summary>
		public int Hits
		{
			get	{ return _hits; }
			set	{ _hits = value; }
		}
		/// <summary>
		/// Is Display
		/// </summary>
		public bool IsDisplay
		{
			get	{ return _isdisplay; }
			set	{ _isdisplay = value; }
		}
		/// <summary>
		/// Created Time
		/// </summary>
		public DateTime CreatedTime
		{
			get	{ return _createdtime; }
			set	{ _createdtime = value; }
		}
		/// <summary>
		/// Created By Id
		/// </summary>
		public int CreatedById
		{
			get	{ return _createdbyid; }
			set	{ _createdbyid = value; }
		}
		/// <summary>
		/// Created By Name
		/// </summary>
		public string CreatedByName
		{
			get	{ return _createdbyname; }
			set	{ _createdbyname = value; }
		}
		/// <summary>
		/// Updated Time
		/// </summary>
		public DateTime UpdatedTime
		{
			get	{ return _updatedtime; }
			set	{ _updatedtime = value; }
		}
		/// <summary>
		/// Updated By Id
		/// </summary>
		public int UpdatedById
		{
			get	{ return _updatedbyid; }
			set	{ _updatedbyid = value; }
		}
		/// <summary>
		/// Updated By Name
		/// </summary>
		public string UpdatedByName
		{
			get	{ return _updatedbyname; }
			set	{ _updatedbyname = value; }
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
