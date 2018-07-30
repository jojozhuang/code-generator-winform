using System;

namespace SouEi.Model
{

	/// <summary>
	/// CNewsComment is an entity class that represents dbo.C_NewsComment
	/// </summary>
	[Serializable]
	public class MDLCNewsComment
	{
		#region declaration
		private string _TableName = "CNewsComment";
        private string _PrimaryKey = "";
		private int _Id;
		private int _NewsId;
		private string _Content;
		private DateTime _IssueDate;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLCNewsComment() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLCNewsComment(int id, int newsid, string content, DateTime issuedate)
        {
			this._Id = id;
			this._NewsId = newsid;
			this._Content = content;
			this._IssueDate = issuedate;
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
		/// Id is a int property that represents column of dbo.C_NewsComment.Id (Id)
		/// </summary>
		public int Id
		{
			get	{ return _Id; }
			set	{ _Id = value; }
		}
		/// <summary>
		/// NewsId is a int property that represents column of dbo.C_NewsComment.NewsId (NewsId)
		/// </summary>
		public int NewsId
		{
			get	{ return _NewsId; }
			set	{ _NewsId = value; }
		}
		/// <summary>
		/// Content is a string property that represents column of dbo.C_NewsComment.Content (Content)
		/// </summary>
		public string Content
		{
			get	{ return _Content; }
			set	{ _Content = value; }
		}
		/// <summary>
		/// IssueDate is a DateTime property that represents column of dbo.C_NewsComment.IssueDate (IssueDate)
		/// </summary>
		public DateTime IssueDate
		{
			get	{ return _IssueDate; }
			set	{ _IssueDate = value; }
		}
		#endregion		
	}
}
