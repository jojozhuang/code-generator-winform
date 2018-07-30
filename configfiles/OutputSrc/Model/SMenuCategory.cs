using System;

namespace SouEi.Model
{

	/// <summary>
	/// SMenuCategory is an entity class that represents dbo.S_MenuCategory
	/// </summary>
	[Serializable]
	public class MDLSMenuCategory
	{
		#region declaration
		private string _TableName = "SMenuCategory";
        private string _PrimaryKey = "MenuCategoryId";
		private int _MenuCategoryId;
		private string _MenuCategoryName;
		private int _Sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLSMenuCategory() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLSMenuCategory(int menucategoryid, string menucategoryname, int sequence)
        {
			this._MenuCategoryId = menucategoryid;
			this._MenuCategoryName = menucategoryname;
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
		/// MenuCategoryId is a int property that represents column of dbo.S_MenuCategory.MenuCategoryId (MenuCategoryId)
		/// </summary>
		public int MenuCategoryId
		{
			get	{ return _MenuCategoryId; }
			set	{ _MenuCategoryId = value; }
		}
		/// <summary>
		/// MenuCategoryName is a string property that represents column of dbo.S_MenuCategory.MenuCategoryName (MenuCategoryName)
		/// </summary>
		public string MenuCategoryName
		{
			get	{ return _MenuCategoryName; }
			set	{ _MenuCategoryName = value; }
		}
		/// <summary>
		/// Sequence is a int property that represents column of dbo.S_MenuCategory.Sequence (Sequence)
		/// </summary>
		public int Sequence
		{
			get	{ return _Sequence; }
			set	{ _Sequence = value; }
		}
		#endregion		
	}
}
