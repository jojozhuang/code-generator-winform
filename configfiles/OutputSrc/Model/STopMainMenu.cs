using System;

namespace SouEi.Model
{

	/// <summary>
	/// STopMainMenu is an entity class that represents dbo.S_TopMainMenu
	/// </summary>
	[Serializable]
	public class MDLSTopMainMenu
	{
		#region declaration
		private string _TableName = "STopMainMenu";
        private string _PrimaryKey = "";
		private int _TopMenuId;
		private int _MenuCategoryId;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLSTopMainMenu() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLSTopMainMenu(int topmenuid, int menucategoryid)
        {
			this._TopMenuId = topmenuid;
			this._MenuCategoryId = menucategoryid;
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
		/// TopMenuId is a int property that represents column of dbo.S_TopMainMenu.TopMenuId (TopMenuId)
		/// </summary>
		public int TopMenuId
		{
			get	{ return _TopMenuId; }
			set	{ _TopMenuId = value; }
		}
		/// <summary>
		/// MenuCategoryId is a int property that represents column of dbo.S_TopMainMenu.MenuCategoryId (MenuCategoryId)
		/// </summary>
		public int MenuCategoryId
		{
			get	{ return _MenuCategoryId; }
			set	{ _MenuCategoryId = value; }
		}
		#endregion		
	}
}
