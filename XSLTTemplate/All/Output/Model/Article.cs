using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Article
	/// </summary>
	[Serializable]
	public class Article
	{
		#region declaration
		private string _TableName = "seh_article";
        private string _PrimaryKey = "ArticleId";
        private bool _IsDesc = false;
		private long _articleid;
		private int _channelid;
		private string _title;
		private string _subtitle;
		private string _keyword;
		private string _subcontent;
		private string _content;
		private string _firstimage;
		private string _copyfrom;
		private int _hits;
		private bool _istop;
		private bool _iselite;
		private bool _ispic;
		private bool _ispagetype;
		private bool _isverified;
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
		public Article() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Article(long articleid, int channelid, string title, string subtitle, string keyword, string subcontent, string content, string firstimage, string copyfrom, int hits, bool istop, bool iselite, bool ispic, bool ispagetype, bool isverified, DateTime createdtime, int createdbyid, string createdbyname, DateTime updatedtime, int updatedbyid, string updatedbyname, int sequence)
        {
			this._articleid = articleid;
			this._channelid = channelid;
			this._title = title;
			this._subtitle = subtitle;
			this._keyword = keyword;
			this._subcontent = subcontent;
			this._content = content;
			this._firstimage = firstimage;
			this._copyfrom = copyfrom;
			this._hits = hits;
			this._istop = istop;
			this._iselite = iselite;
			this._ispic = ispic;
			this._ispagetype = ispagetype;
			this._isverified = isverified;
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
		/// Article Id
		/// </summary>
		public long ArticleId
		{
			get	{ return _articleid; }
			set	{ _articleid = value; }
		}
		/// <summary>
		/// Channel Id
		/// </summary>
		public int ChannelId
		{
			get	{ return _channelid; }
			set	{ _channelid = value; }
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
		/// Sub Title
		/// </summary>
		public string SubTitle
		{
			get	{ return _subtitle; }
			set	{ _subtitle = value; }
		}
		/// <summary>
		/// KeyWord
		/// </summary>
		public string KeyWord
		{
			get	{ return _keyword; }
			set	{ _keyword = value; }
		}
		/// <summary>
		/// Sub Content
		/// </summary>
		public string SubContent
		{
			get	{ return _subcontent; }
			set	{ _subcontent = value; }
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
		/// First Image
		/// </summary>
		public string FirstImage
		{
			get	{ return _firstimage; }
			set	{ _firstimage = value; }
		}
		/// <summary>
		/// Copy From
		/// </summary>
		public string CopyFrom
		{
			get	{ return _copyfrom; }
			set	{ _copyfrom = value; }
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
		/// Is Top
		/// </summary>
		public bool IsTop
		{
			get	{ return _istop; }
			set	{ _istop = value; }
		}
		/// <summary>
		/// Is Elite
		/// </summary>
		public bool IsElite
		{
			get	{ return _iselite; }
			set	{ _iselite = value; }
		}
		/// <summary>
		/// Is Picture
		/// </summary>
		public bool IsPic
		{
			get	{ return _ispic; }
			set	{ _ispic = value; }
		}
		/// <summary>
		/// Is Page Type
		/// </summary>
		public bool IsPageType
		{
			get	{ return _ispagetype; }
			set	{ _ispagetype = value; }
		}
		/// <summary>
		/// Is Verified
		/// </summary>
		public bool IsVerified
		{
			get	{ return _isverified; }
			set	{ _isverified = value; }
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
