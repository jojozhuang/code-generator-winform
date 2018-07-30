using System;

namespace SouEi.Model
{

	/// <summary>
	/// CBlog is an entity class that represents dbo.C_Blog
	/// </summary>
	[Serializable]
	public class MDLCBlog
	{
		#region declaration
		private string _TableName = "CBlog";
        private string _PrimaryKey = "BlogId";
		private int _BlogId;
		private string _BlogTitle;
		private int _BlogCategory;
		private string _Tag;
		private string _Content;
		private int _Hits;
		private bool _IsDisplay;
		private int _Sequence;
		private DateTime _AddedTime;
		private int _AddedBy;
		private DateTime _UpdatedTime;
		private int _UpdatedBy;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLCBlog() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLCBlog(int blogid, string blogtitle, int blogcategory, string tag, string content, int hits, bool isdisplay, int sequence, DateTime addedtime, int addedby, DateTime updatedtime, int updatedby)
        {
			this._BlogId = blogid;
			this._BlogTitle = blogtitle;
			this._BlogCategory = blogcategory;
			this._Tag = tag;
			this._Content = content;
			this._Hits = hits;
			this._IsDisplay = isdisplay;
			this._Sequence = sequence;
			this._AddedTime = addedtime;
			this._AddedBy = addedby;
			this._UpdatedTime = updatedtime;
			this._UpdatedBy = updatedby;
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
		/// BlogId is a int property that represents column of dbo.C_Blog.BlogId (BlogId)
		/// </summary>
		public int BlogId
		{
			get	{ return _BlogId; }
			set	{ _BlogId = value; }
		}
		/// <summary>
		/// BlogTitle is a string property that represents column of dbo.C_Blog.BlogTitle (BlogTitle)
		/// </summary>
		public string BlogTitle
		{
			get	{ return _BlogTitle; }
			set	{ _BlogTitle = value; }
		}
		/// <summary>
		/// BlogCategory is a int property that represents column of dbo.C_Blog.BlogCategory (BlogCategory)
		/// </summary>
		public int BlogCategory
		{
			get	{ return _BlogCategory; }
			set	{ _BlogCategory = value; }
		}
		/// <summary>
		/// Tag is a string property that represents column of dbo.C_Blog.Tag (Tag)
		/// </summary>
		public string Tag
		{
			get	{ return _Tag; }
			set	{ _Tag = value; }
		}
		/// <summary>
		/// Content is a string property that represents column of dbo.C_Blog.Content (Content)
		/// </summary>
		public string Content
		{
			get	{ return _Content; }
			set	{ _Content = value; }
		}
		/// <summary>
		/// Hits is a int property that represents column of dbo.C_Blog.Hits (Hits)
		/// </summary>
		public int Hits
		{
			get	{ return _Hits; }
			set	{ _Hits = value; }
		}
		/// <summary>
		/// IsDisplay is a bool property that represents column of dbo.C_Blog.IsDisplay (IsDisplay)
		/// </summary>
		public bool IsDisplay
		{
			get	{ return _IsDisplay; }
			set	{ _IsDisplay = value; }
		}
		/// <summary>
		/// Sequence is a int property that represents column of dbo.C_Blog.Sequence (Sequence)
		/// </summary>
		public int Sequence
		{
			get	{ return _Sequence; }
			set	{ _Sequence = value; }
		}
		/// <summary>
		/// AddedTime is a DateTime property that represents column of dbo.C_Blog.AddedTime (AddedTime)
		/// </summary>
		public DateTime AddedTime
		{
			get	{ return _AddedTime; }
			set	{ _AddedTime = value; }
		}
		/// <summary>
		/// AddedBy is a int property that represents column of dbo.C_Blog.AddedBy (AddedBy)
		/// </summary>
		public int AddedBy
		{
			get	{ return _AddedBy; }
			set	{ _AddedBy = value; }
		}
		/// <summary>
		/// UpdatedTime is a DateTime property that represents column of dbo.C_Blog.UpdatedTime (UpdatedTime)
		/// </summary>
		public DateTime UpdatedTime
		{
			get	{ return _UpdatedTime; }
			set	{ _UpdatedTime = value; }
		}
		/// <summary>
		/// UpdatedBy is a int property that represents column of dbo.C_Blog.UpdatedBy (UpdatedBy)
		/// </summary>
		public int UpdatedBy
		{
			get	{ return _UpdatedBy; }
			set	{ _UpdatedBy = value; }
		}
		#endregion		
	}
}
