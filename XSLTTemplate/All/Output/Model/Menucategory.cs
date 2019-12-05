using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Menucategory
	/// </summary>
	[Serializable]
	public class Menucategory
	{
		#region declaration
		private string _TableName = "cms_menucategory";
        private string _PrimaryKey = "MenuCategoryId";
        private bool _IsDesc = false;
		private int _menucategoryid;
		private string _menucategoryname;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Menucategory() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Menucategory(int menucategoryid, string menucategoryname, int sequence)
        {
			this._menucategoryid = menucategoryid;
			this._menucategoryname = menucategoryname;
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
		/// Menu Category Id
		/// </summary>
		public int MenuCategoryId
		{
			get	{ return _menucategoryid; }
			set	{ _menucategoryid = value; }
		}
		/// <summary>
		/// Menu Category Name
		/// </summary>
		public string MenuCategoryName
		{
			get	{ return _menucategoryname; }
			set	{ _menucategoryname = value; }
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
