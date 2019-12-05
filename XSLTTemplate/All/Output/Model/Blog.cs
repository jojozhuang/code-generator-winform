using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Blog
	/// </summary>
	[Serializable]
	public class Blog
	{
		#region declaration
		private string _TableName = "seh_blog";
        private string _PrimaryKey = "BlogId";
        private bool _IsDesc = false;
		private int _blogid;
		private string _title;
		private int _blogcategoryid;
		private string _tag;
		private string _content;
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
		public Blog() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Blog(int blogid, string title, int blogcategoryid, string tag, string content, int hits, bool isdisplay, DateTime createdtime, int createdbyid, string createdbyname, DateTime updatedtime, int updatedbyid, string updatedbyname, int sequence)
        {
			this._blogid = blogid;
			this._title = title;
			this._blogcategoryid = blogcategoryid;
			this._tag = tag;
			this._content = content;
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
		/// Blog Id
		/// </summary>
		public int BlogId
		{
			get	{ return _blogid; }
			set	{ _blogid = value; }
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
		/// Blog Category
		/// </summary>
		public int BlogCategoryId
		{
			get	{ return _blogcategoryid; }
			set	{ _blogcategoryid = value; }
		}
		/// <summary>
		/// Tag
		/// </summary>
		public string Tag
		{
			get	{ return _tag; }
			set	{ _tag = value; }
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
