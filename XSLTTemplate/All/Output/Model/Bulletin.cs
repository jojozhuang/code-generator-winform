using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Bulletin
	/// </summary>
	[Serializable]
	public class Bulletin
	{
		#region declaration
		private string _TableName = "seh_bulletin";
        private string _PrimaryKey = "BulletinId";
        private bool _IsDesc = false;
		private int _bulletinid;
		private string _title;
		private string _content;
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
		public Bulletin() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Bulletin(int bulletinid, string title, string content, string url, int hits, bool isdisplay, DateTime createdtime, int createdbyid, string createdbyname, DateTime updatedtime, int updatedbyid, string updatedbyname, int sequence)
        {
			this._bulletinid = bulletinid;
			this._title = title;
			this._content = content;
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
		/// Bulletin Id
		/// </summary>
		public int BulletinId
		{
			get	{ return _bulletinid; }
			set	{ _bulletinid = value; }
		}
		/// <summary>
		/// Title
		/// </summary>
		public string Title
		{
			get	{ return _title; }
			set	{ _title = value; }
		}
		/// <summary>
		/// Content
		/// </summary>
		public string Content
		{
			get	{ return _content; }
			set	{ _content = value; }
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
		/// IsDisplay
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
