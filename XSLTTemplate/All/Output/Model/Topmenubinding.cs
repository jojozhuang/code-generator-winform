using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Topmenubinding
	/// </summary>
	[Serializable]
	public class Topmenubinding
	{
		#region declaration
		private string _TableName = "cms_topmenubinding";
        private string _PrimaryKey = "";
        private bool _IsDesc = false;
		private int _topmenuid;
		private int _menucategoryid;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Topmenubinding() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Topmenubinding(int topmenuid, int menucategoryid)
        {
			this._topmenuid = topmenuid;
			this._menucategoryid = menucategoryid;
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
		/// Top Menu
		/// </summary>
		public int TopMenuId
		{
			get	{ return _topmenuid; }
			set	{ _topmenuid = value; }
		}
		/// <summary>
		/// Menu Category
		/// </summary>
		public int MenuCategoryId
		{
			get	{ return _menucategoryid; }
			set	{ _menucategoryid = value; }
		}
		#endregion		
	}
}
