using System;

namespace SouEi.Model
{

	/// <summary>
	/// ECAdmin is an entity class that represents dbo.EC_Admin
	/// </summary>
	[Serializable]
	public class MDLECAdmin
	{
		#region declaration
		private string _TableName = "ECAdmin";
        private string _PrimaryKey = "ID";
		private int _ID;
		private string _AdminName;
		private string _PassWord;
		private string _note;
		private int _Popedom;
		private DateTime _CDT;
		private DateTime _LDT;
		private int _loginTimes;
		private bool _Lock;
		private string _Rights;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLECAdmin() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLECAdmin(int id, string adminname, string password, string note, int popedom, DateTime cdt, DateTime ldt, int logintimes, bool lock, string rights)
        {
			this._ID = id;
			this._AdminName = adminname;
			this._PassWord = password;
			this._note = note;
			this._Popedom = popedom;
			this._CDT = cdt;
			this._LDT = ldt;
			this._loginTimes = logintimes;
			this._Lock = lock;
			this._Rights = rights;
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
		/// ID is a int property that represents column of dbo.EC_Admin.ID (ID)
		/// </summary>
		public int ID
		{
			get	{ return _ID; }
			set	{ _ID = value; }
		}
		/// <summary>
		/// AdminName is a string property that represents column of dbo.EC_Admin.AdminName (AdminName)
		/// </summary>
		public string AdminName
		{
			get	{ return _AdminName; }
			set	{ _AdminName = value; }
		}
		/// <summary>
		/// PassWord is a string property that represents column of dbo.EC_Admin.PassWord (PassWord)
		/// </summary>
		public string PassWord
		{
			get	{ return _PassWord; }
			set	{ _PassWord = value; }
		}
		/// <summary>
		/// note is a string property that represents column of dbo.EC_Admin.note (note)
		/// </summary>
		public string note
		{
			get	{ return _note; }
			set	{ _note = value; }
		}
		/// <summary>
		/// Popedom is a int property that represents column of dbo.EC_Admin.Popedom (Popedom)
		/// </summary>
		public int Popedom
		{
			get	{ return _Popedom; }
			set	{ _Popedom = value; }
		}
		/// <summary>
		/// CDT is a DateTime property that represents column of dbo.EC_Admin.CDT (CDT)
		/// </summary>
		public DateTime CDT
		{
			get	{ return _CDT; }
			set	{ _CDT = value; }
		}
		/// <summary>
		/// LDT is a DateTime property that represents column of dbo.EC_Admin.LDT (LDT)
		/// </summary>
		public DateTime LDT
		{
			get	{ return _LDT; }
			set	{ _LDT = value; }
		}
		/// <summary>
		/// loginTimes is a int property that represents column of dbo.EC_Admin.loginTimes (loginTimes)
		/// </summary>
		public int loginTimes
		{
			get	{ return _loginTimes; }
			set	{ _loginTimes = value; }
		}
		/// <summary>
		/// Lock is a bool property that represents column of dbo.EC_Admin.Lock (Lock)
		/// </summary>
		public bool Lock
		{
			get	{ return _Lock; }
			set	{ _Lock = value; }
		}
		/// <summary>
		/// Rights is a string property that represents column of dbo.EC_Admin.Rights (Rights)
		/// </summary>
		public string Rights
		{
			get	{ return _Rights; }
			set	{ _Rights = value; }
		}
		#endregion		
	}
}
