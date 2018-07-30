using System;

namespace SouEi.Model
{

	/// <summary>
	/// CNewsCategory is an entity class that represents dbo.C_NewsCategory
	/// </summary>
	[Serializable]
	public class MDLCNewsCategory
	{
		#region declaration
		private string _TableName = "CNewsCategory";
        private string _PrimaryKey = "NewsCategoryId";
		private int _NewsCategoryId;
		private string _NewsCategoryName;
		private int _Sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLCNewsCategory() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLCNewsCategory(int newscategoryid, string newscategoryname, int sequence)
        {
			this._NewsCategoryId = newscategoryid;
			this._NewsCategoryName = newscategoryname;
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
		/// NewsCategoryId is a int property that represents column of dbo.C_NewsCategory.NewsCategoryId (NewsCategoryId)
		/// </summary>
		public int NewsCategoryId
		{
			get	{ return _NewsCategoryId; }
			set	{ _NewsCategoryId = value; }
		}
		/// <summary>
		/// NewsCategoryName is a string property that represents column of dbo.C_NewsCategory.NewsCategoryName (NewsCategoryName)
		/// </summary>
		public string NewsCategoryName
		{
			get	{ return _NewsCategoryName; }
			set	{ _NewsCategoryName = value; }
		}
		/// <summary>
		/// Sequence is a int property that represents column of dbo.C_NewsCategory.Sequence (Sequence)
		/// </summary>
		public int Sequence
		{
			get	{ return _Sequence; }
			set	{ _Sequence = value; }
		}
		#endregion		
	}
}
