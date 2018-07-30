using System;

namespace SouEi.Model
{

	/// <summary>
	/// CNews is an entity class that represents dbo.C_News
	/// </summary>
	[Serializable]
	public class MDLCNews
	{
		#region declaration
		private string _TableName = "CNews";
        private string _PrimaryKey = "NewsId";
		private long _NewsId;
		private string _Title;
		private string _SubTitle;
		private int _NewsCategoryId;
		private string _FirstImage;
		private string _SubContent;
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
		public MDLCNews() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLCNews(long newsid, string title, string subtitle, int newscategoryid, string firstimage, string subcontent, string content, int hits, bool isdisplay, int sequence, DateTime addedtime, int addedby, DateTime updatedtime, int updatedby)
        {
			this._NewsId = newsid;
			this._Title = title;
			this._SubTitle = subtitle;
			this._NewsCategoryId = newscategoryid;
			this._FirstImage = firstimage;
			this._SubContent = subcontent;
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
		/// NewsId is a long property that represents column of dbo.C_News.NewsId (NewsId)
		/// </summary>
		public long NewsId
		{
			get	{ return _NewsId; }
			set	{ _NewsId = value; }
		}
		/// <summary>
		/// Title is a string property that represents column of dbo.C_News.Title (Title)
		/// </summary>
		public string Title
		{
			get	{ return _Title; }
			set	{ _Title = value; }
		}
		/// <summary>
		/// SubTitle is a string property that represents column of dbo.C_News.SubTitle (SubTitle)
		/// </summary>
		public string SubTitle
		{
			get	{ return _SubTitle; }
			set	{ _SubTitle = value; }
		}
		/// <summary>
		/// NewsCategoryId is a int property that represents column of dbo.C_News.NewsCategoryId (NewsCategoryId)
		/// </summary>
		public int NewsCategoryId
		{
			get	{ return _NewsCategoryId; }
			set	{ _NewsCategoryId = value; }
		}
		/// <summary>
		/// FirstImage is a string property that represents column of dbo.C_News.FirstImage (FirstImage)
		/// </summary>
		public string FirstImage
		{
			get	{ return _FirstImage; }
			set	{ _FirstImage = value; }
		}
		/// <summary>
		/// SubContent is a string property that represents column of dbo.C_News.SubContent (SubContent)
		/// </summary>
		public string SubContent
		{
			get	{ return _SubContent; }
			set	{ _SubContent = value; }
		}
		/// <summary>
		/// Content is a string property that represents column of dbo.C_News.Content (Content)
		/// </summary>
		public string Content
		{
			get	{ return _Content; }
			set	{ _Content = value; }
		}
		/// <summary>
		/// Hits is a int property that represents column of dbo.C_News.Hits (Hits)
		/// </summary>
		public int Hits
		{
			get	{ return _Hits; }
			set	{ _Hits = value; }
		}
		/// <summary>
		/// IsDisplay is a bool property that represents column of dbo.C_News.IsDisplay (IsDisplay)
		/// </summary>
		public bool IsDisplay
		{
			get	{ return _IsDisplay; }
			set	{ _IsDisplay = value; }
		}
		/// <summary>
		/// Sequence is a int property that represents column of dbo.C_News.Sequence (Sequence)
		/// </summary>
		public int Sequence
		{
			get	{ return _Sequence; }
			set	{ _Sequence = value; }
		}
		/// <summary>
		/// AddedTime is a DateTime property that represents column of dbo.C_News.AddedTime (AddedTime)
		/// </summary>
		public DateTime AddedTime
		{
			get	{ return _AddedTime; }
			set	{ _AddedTime = value; }
		}
		/// <summary>
		/// AddedBy is a int property that represents column of dbo.C_News.AddedBy (AddedBy)
		/// </summary>
		public int AddedBy
		{
			get	{ return _AddedBy; }
			set	{ _AddedBy = value; }
		}
		/// <summary>
		/// UpdatedTime is a DateTime property that represents column of dbo.C_News.UpdatedTime (UpdatedTime)
		/// </summary>
		public DateTime UpdatedTime
		{
			get	{ return _UpdatedTime; }
			set	{ _UpdatedTime = value; }
		}
		/// <summary>
		/// UpdatedBy is a int property that represents column of dbo.C_News.UpdatedBy (UpdatedBy)
		/// </summary>
		public int UpdatedBy
		{
			get	{ return _UpdatedBy; }
			set	{ _UpdatedBy = value; }
		}
		#endregion		
	}
}
