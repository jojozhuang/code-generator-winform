using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Blogcategory
	/// </summary>
	[Serializable]
	public class Blogcategory
	{
		#region declaration
		private string _TableName = "seh_blogcategory";
        private string _PrimaryKey = "BlogCategoryId";
        private bool _IsDesc = false;
		private int _blogcategoryid;
		private string _blogcategoryname;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Blogcategory() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Blogcategory(int blogcategoryid, string blogcategoryname, int sequence)
        {
			this._blogcategoryid = blogcategoryid;
			this._blogcategoryname = blogcategoryname;
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
		/// Blog Category Id
		/// </summary>
		public int BlogCategoryId
		{
			get	{ return _blogcategoryid; }
			set	{ _blogcategoryid = value; }
		}
		/// <summary>
		/// Blog Category Name
		/// </summary>
		public string BlogCategoryName
		{
			get	{ return _blogcategoryname; }
			set	{ _blogcategoryname = value; }
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
