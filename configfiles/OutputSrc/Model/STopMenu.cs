using System;

namespace SouEi.Model
{

	/// <summary>
	/// STopMenu is an entity class that represents dbo.S_TopMenu
	/// </summary>
	[Serializable]
	public class MDLSTopMenu
	{
		#region declaration
		private string _TableName = "STopMenu";
        private string _PrimaryKey = "TopMenuId";
		private int _TopMenuId;
		private string _TopMenuName;
		private int _Sequence;
		private string _Tips;
		private string _PageLink;
		private string _Image;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLSTopMenu() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLSTopMenu(int topmenuid, string topmenuname, int sequence, string tips, string pagelink, string image)
        {
			this._TopMenuId = topmenuid;
			this._TopMenuName = topmenuname;
			this._Sequence = sequence;
			this._Tips = tips;
			this._PageLink = pagelink;
			this._Image = image;
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
		/// TopMenuId is a int property that represents column of dbo.S_TopMenu.TopMenuId (TopMenuId)
		/// </summary>
		public int TopMenuId
		{
			get	{ return _TopMenuId; }
			set	{ _TopMenuId = value; }
		}
		/// <summary>
		/// TopMenuName is a string property that represents column of dbo.S_TopMenu.TopMenuName (TopMenuName)
		/// </summary>
		public string TopMenuName
		{
			get	{ return _TopMenuName; }
			set	{ _TopMenuName = value; }
		}
		/// <summary>
		/// Sequence is a int property that represents column of dbo.S_TopMenu.Sequence (Sequence)
		/// </summary>
		public int Sequence
		{
			get	{ return _Sequence; }
			set	{ _Sequence = value; }
		}
		/// <summary>
		/// Tips is a string property that represents column of dbo.S_TopMenu.Tips (Tips)
		/// </summary>
		public string Tips
		{
			get	{ return _Tips; }
			set	{ _Tips = value; }
		}
		/// <summary>
		/// PageLink is a string property that represents column of dbo.S_TopMenu.PageLink (PageLink)
		/// </summary>
		public string PageLink
		{
			get	{ return _PageLink; }
			set	{ _PageLink = value; }
		}
		/// <summary>
		/// Image is a string property that represents column of dbo.S_TopMenu.Image (Image)
		/// </summary>
		public string Image
		{
			get	{ return _Image; }
			set	{ _Image = value; }
		}
		#endregion		
	}
}
