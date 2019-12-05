using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Software
	/// </summary>
	[Serializable]
	public class Software
	{
		#region declaration
		private string _TableName = "seh_software";
        private string _PrimaryKey = "SoftwareId";
        private bool _IsDesc = false;
		private int _softwareid;
		private string _softwarename;
		private string _shortdescription;
		private string _description;
		private string _image;
		private string _feature1;
		private string _feature2;
		private string _feature3;
		private string _feature4;
		private string _downloadurl;
		private string _documenttitle;
		private string _documentdescription;
		private string _documenturl;
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
		public Software() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Software(int softwareid, string softwarename, string shortdescription, string description, string image, string feature1, string feature2, string feature3, string feature4, string downloadurl, string documenttitle, string documentdescription, string documenturl, int hits, int downloads, bool isdisplay, DateTime createdtime, int createdbyid, string createdbyname, DateTime updatedtime, int updatedbyid, string updatedbyname, int sequence)
        {
			this._softwareid = softwareid;
			this._softwarename = softwarename;
			this._shortdescription = shortdescription;
			this._description = description;
			this._image = image;
			this._feature1 = feature1;
			this._feature2 = feature2;
			this._feature3 = feature3;
			this._feature4 = feature4;
			this._downloadurl = downloadurl;
			this._documenttitle = documenttitle;
			this._documentdescription = documentdescription;
			this._documenturl = documenturl;
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
		/// Software Id
		/// </summary>
		public int SoftwareId
		{
			get	{ return _softwareid; }
			set	{ _softwareid = value; }
		}
		/// <summary>
		/// Software Name
		/// </summary>
		public string SoftwareName
		{
			get	{ return _softwarename; }
			set	{ _softwarename = value; }
		}
		/// <summary>
		/// Short Description
		/// </summary>
		public string ShortDescription
		{
			get	{ return _shortdescription; }
			set	{ _shortdescription = value; }
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
		/// Image
		/// </summary>
		public string Image
		{
			get	{ return _image; }
			set	{ _image = value; }
		}
		/// <summary>
		/// Feature1
		/// </summary>
		public string Feature1
		{
			get	{ return _feature1; }
			set	{ _feature1 = value; }
		}
		/// <summary>
		/// Feature2
		/// </summary>
		public string Feature2
		{
			get	{ return _feature2; }
			set	{ _feature2 = value; }
		}
		/// <summary>
		/// Feature3
		/// </summary>
		public string Feature3
		{
			get	{ return _feature3; }
			set	{ _feature3 = value; }
		}
		/// <summary>
		/// Feature4
		/// </summary>
		public string Feature4
		{
			get	{ return _feature4; }
			set	{ _feature4 = value; }
		}
		/// <summary>
		/// Download Url
		/// </summary>
		public string DownloadUrl
		{
			get	{ return _downloadurl; }
			set	{ _downloadurl = value; }
		}
		/// <summary>
		/// Document Title
		/// </summary>
		public string DocumentTitle
		{
			get	{ return _documenttitle; }
			set	{ _documenttitle = value; }
		}
		/// <summary>
		/// Document Description
		/// </summary>
		public string DocumentDescription
		{
			get	{ return _documentdescription; }
			set	{ _documentdescription = value; }
		}
		/// <summary>
		/// Document Url
		/// </summary>
		public string DocumentUrl
		{
			get	{ return _documenturl; }
			set	{ _documenturl = value; }
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
