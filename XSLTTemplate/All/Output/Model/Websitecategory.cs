using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Websitecategory
	/// </summary>
	[Serializable]
	public class Websitecategory
	{
		#region declaration
		private string _TableName = "seh_websitecategory";
        private string _PrimaryKey = "WebsiteCategoryId";
        private bool _IsDesc = false;
		private int _websitecategoryid;
		private string _websitecategoryname;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Websitecategory() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Websitecategory(int websitecategoryid, string websitecategoryname, int sequence)
        {
			this._websitecategoryid = websitecategoryid;
			this._websitecategoryname = websitecategoryname;
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
		/// Website Category Id
		/// </summary>
		public int WebsiteCategoryId
		{
			get	{ return _websitecategoryid; }
			set	{ _websitecategoryid = value; }
		}
		/// <summary>
		/// Website Category Name
		/// </summary>
		public string WebsiteCategoryName
		{
			get	{ return _websitecategoryname; }
			set	{ _websitecategoryname = value; }
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
