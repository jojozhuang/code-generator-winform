using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Release
	/// </summary>
	[Serializable]
	public class Release
	{
		#region declaration
		private string _TableName = "seh_release";
        private string _PrimaryKey = "ReleaseId";
        private bool _IsDesc = false;
		private int _releaseid;
		private int _softwareid;
		private string _releasename;
		private DateTime _releasedate;
		private string _description;
		private int _hits;
		private int _downloads;
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
		public Release() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Release(int releaseid, int softwareid, string releasename, DateTime releasedate, string description, int hits, int downloads, bool isdisplay, DateTime createdtime, int createdbyid, string createdbyname, DateTime updatedtime, int updatedbyid, string updatedbyname, int sequence)
        {
			this._releaseid = releaseid;
			this._softwareid = softwareid;
			this._releasename = releasename;
			this._releasedate = releasedate;
			this._description = description;
			this._hits = hits;
			this._downloads = downloads;
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
		/// Release Id
		/// </summary>
		public int ReleaseId
		{
			get	{ return _releaseid; }
			set	{ _releaseid = value; }
		}
		/// <summary>
		/// Software
		/// </summary>
		public int SoftwareId
		{
			get	{ return _softwareid; }
			set	{ _softwareid = value; }
		}
		/// <summary>
		/// Release Name
		/// </summary>
		public string ReleaseName
		{
			get	{ return _releasename; }
			set	{ _releasename = value; }
		}
		/// <summary>
		/// Release Date
		/// </summary>
		public DateTime ReleaseDate
		{
			get	{ return _releasedate; }
			set	{ _releasedate = value; }
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
		/// Hits
		/// </summary>
		public int Hits
		{
			get	{ return _hits; }
			set	{ _hits = value; }
		}
		/// <summary>
		/// Downloads
		/// </summary>
		public int Downloads
		{
			get	{ return _downloads; }
			set	{ _downloads = value; }
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
