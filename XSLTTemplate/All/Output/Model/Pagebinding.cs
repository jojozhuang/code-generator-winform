using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Pagebinding
	/// </summary>
	[Serializable]
	public class Pagebinding
	{
		#region declaration
		private string _TableName = "cms_pagebinding";
        private string _PrimaryKey = "PageBindingId";
        private bool _IsDesc = false;
		private int _pagebindingid;
		private string _title;
		private int _menucategoryid;
		private int _listmenuid;
		private int _addmenuid;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Pagebinding() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Pagebinding(int pagebindingid, string title, int menucategoryid, int listmenuid, int addmenuid)
        {
			this._pagebindingid = pagebindingid;
			this._title = title;
			this._menucategoryid = menucategoryid;
			this._listmenuid = listmenuid;
			this._addmenuid = addmenuid;
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
		/// Page Binding Id
		/// </summary>
		public int PageBindingId
		{
			get	{ return _pagebindingid; }
			set	{ _pagebindingid = value; }
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
		/// Menu Category
		/// </summary>
		public int MenuCategoryId
		{
			get	{ return _menucategoryid; }
			set	{ _menucategoryid = value; }
		}
		/// <summary>
		/// List Page
		/// </summary>
		public int ListMenuId
		{
			get	{ return _listmenuid; }
			set	{ _listmenuid = value; }
		}
		/// <summary>
		/// Add Page
		/// </summary>
		public int AddMenuId
		{
			get	{ return _addmenuid; }
			set	{ _addmenuid = value; }
		}
		#endregion		
	}
}
