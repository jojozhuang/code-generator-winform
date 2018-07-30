using System;

namespace SouEi.Model
{

	/// <summary>
	/// CBlogCategory is an entity class that represents dbo.C_BlogCategory
	/// </summary>
	[Serializable]
	public class MDLCBlogCategory
	{
		#region declaration
		private string _TableName = "CBlogCategory";
        private string _PrimaryKey = "BlogCategoryId";
		private int _BlogCategoryId;
		private string _BlogCategoryName;
		private int _Sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLCBlogCategory() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLCBlogCategory(int blogcategoryid, string blogcategoryname, int sequence)
        {
			this._BlogCategoryId = blogcategoryid;
			this._BlogCategoryName = blogcategoryname;
			this._Sequence = sequence;
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
		/// BlogCategoryId is a int property that represents column of dbo.C_BlogCategory.BlogCategoryId (BlogCategoryId)
		/// </summary>
		public int BlogCategoryId
		{
			get	{ return _BlogCategoryId; }
			set	{ _BlogCategoryId = value; }
		}
		/// <summary>
		/// BlogCategoryName is a string property that represents column of dbo.C_BlogCategory.BlogCategoryName (BlogCategoryName)
		/// </summary>
		public string BlogCategoryName
		{
			get	{ return _BlogCategoryName; }
			set	{ _BlogCategoryName = value; }
		}
		/// <summary>
		/// Sequence is a int property that represents column of dbo.C_BlogCategory.Sequence (Sequence)
		/// </summary>
		public int Sequence
		{
			get	{ return _Sequence; }
			set	{ _Sequence = value; }
		}
		#endregion		
	}
}
