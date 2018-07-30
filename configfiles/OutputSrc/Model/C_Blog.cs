using System;

namespace aaa.SmartMoney.Model
{

	/// <summary>
	/// C_Blog is an entity class that represents dbo.C_Blog
	/// </summary>
	[Serializable]
	public class MDLC_Blog
	{
		#region declaration
		private string _TableName = "C_Blog";
        private string _PrimaryKey = "BlogId";
		private  _blogid;
		private  _blogtitle;
		private  _blogcategory;
		private  _tag;
		private  _content;
		private  _hits;
		private  _isdisplay;
		private  _sequence;
		private  _addedtime;
		private  _addedby;
		private  _updatedtime;
		private  _updatedby;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLC_Blog() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLC_Blog( blogid,  blogtitle,  blogcategory,  tag,  content,  hits,  isdisplay,  sequence,  addedtime,  addedby,  updatedtime,  updatedby)
        {
			this._blogid = blogid;
			this._blogtitle = blogtitle;
			this._blogcategory = blogcategory;
			this._tag = tag;
			this._content = content;
			this._hits = hits;
			this._isdisplay = isdisplay;
			this._sequence = sequence;
			this._addedtime = addedtime;
			this._addedby = addedby;
			this._updatedtime = updatedtime;
			this._updatedby = updatedby;
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
		/// BlogId is a  property that represents column of dbo.C_Blog.BlogId
		/// </summary>
		public  BlogId
		{
			get	{ return _blogid; }
			set	{ _blogid = value; }
		}
		/// <summary>
		/// BlogTitle is a  property that represents column of dbo.C_Blog.BlogTitle
		/// </summary>
		public  BlogTitle
		{
			get	{ return _blogtitle; }
			set	{ _blogtitle = value; }
		}
		/// <summary>
		/// BlogCategory is a  property that represents column of dbo.C_Blog.BlogCategory
		/// </summary>
		public  BlogCategory
		{
			get	{ return _blogcategory; }
			set	{ _blogcategory = value; }
		}
		/// <summary>
		/// Tag is a  property that represents column of dbo.C_Blog.Tag
		/// </summary>
		public  Tag
		{
			get	{ return _tag; }
			set	{ _tag = value; }
		}
		/// <summary>
		/// Content is a  property that represents column of dbo.C_Blog.Content
		/// </summary>
		public  Content
		{
			get	{ return _content; }
			set	{ _content = value; }
		}
		/// <summary>
		/// Hits is a  property that represents column of dbo.C_Blog.Hits
		/// </summary>
		public  Hits
		{
			get	{ return _hits; }
			set	{ _hits = value; }
		}
		/// <summary>
		/// IsDisplay is a  property that represents column of dbo.C_Blog.IsDisplay
		/// </summary>
		public  IsDisplay
		{
			get	{ return _isdisplay; }
			set	{ _isdisplay = value; }
		}
		/// <summary>
		/// Sequence is a  property that represents column of dbo.C_Blog.Sequence
		/// </summary>
		public  Sequence
		{
			get	{ return _sequence; }
			set	{ _sequence = value; }
		}
		/// <summary>
		/// AddedTime is a  property that represents column of dbo.C_Blog.AddedTime
		/// </summary>
		public  AddedTime
		{
			get	{ return _addedtime; }
			set	{ _addedtime = value; }
		}
		/// <summary>
		/// AddedBy is a  property that represents column of dbo.C_Blog.AddedBy
		/// </summary>
		public  AddedBy
		{
			get	{ return _addedby; }
			set	{ _addedby = value; }
		}
		/// <summary>
		/// UpdatedTime is a  property that represents column of dbo.C_Blog.UpdatedTime
		/// </summary>
		public  UpdatedTime
		{
			get	{ return _updatedtime; }
			set	{ _updatedtime = value; }
		}
		/// <summary>
		/// UpdatedBy is a  property that represents column of dbo.C_Blog.UpdatedBy
		/// </summary>
		public  UpdatedBy
		{
			get	{ return _updatedby; }
			set	{ _updatedby = value; }
		}
		#endregion		
	}
}
