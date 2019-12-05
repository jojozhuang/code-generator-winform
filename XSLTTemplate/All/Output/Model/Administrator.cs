using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Administrator
	/// </summary>
	[Serializable]
	public class Administrator
	{
		#region declaration
		private string _TableName = "cms_administrator";
        private string _PrimaryKey = "AdminId";
        private bool _IsDesc = false;
		private int _adminid;
		private string _adminname;
		private string _password;
		private string _fullname;
		private bool _gender;
		private string _tel;
		private string _email;
		private DateTime _validfrom;
		private DateTime _validto;
		private bool _isactivated;
		private int _logintimes;
		private DateTime _createdtime;
		private int _createdbyid;
		private string _createdbyname;
		private DateTime _updatedtime;
		private int _updatedbyid;
		private string _updatedbyname;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Administrator() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Administrator(int adminid, string adminname, string password, string fullname, bool gender, string tel, string email, DateTime validfrom, DateTime validto, bool isactivated, int logintimes, DateTime createdtime, int createdbyid, string createdbyname, DateTime updatedtime, int updatedbyid, string updatedbyname, int sequence)
        {
			this._adminid = adminid;
			this._adminname = adminname;
			this._password = password;
			this._fullname = fullname;
			this._gender = gender;
			this._tel = tel;
			this._email = email;
			this._validfrom = validfrom;
			this._validto = validto;
			this._isactivated = isactivated;
			this._logintimes = logintimes;
			this._createdtime = createdtime;
			this._createdbyid = createdbyid;
			this._createdbyname = createdbyname;
			this._updatedtime = updatedtime;
			this._updatedbyid = updatedbyid;
			this._updatedbyname = updatedbyname;
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
		/// AdminId
		/// </summary>
		public int AdminId
		{
			get	{ return _adminid; }
			set	{ _adminid = value; }
		}
		/// <summary>
		/// AdminName
		/// </summary>
		public string AdminName
		{
			get	{ return _adminname; }
			set	{ _adminname = value; }
		}
		/// <summary>
		/// Password
		/// </summary>
		public string Password
		{
			get	{ return _password; }
			set	{ _password = value; }
		}
		/// <summary>
		/// Full Name
		/// </summary>
		public string FullName
		{
			get	{ return _fullname; }
			set	{ _fullname = value; }
		}
		/// <summary>
		/// Gender
		/// </summary>
		public bool Gender
		{
			get	{ return _gender; }
			set	{ _gender = value; }
		}
		/// <summary>
		/// Tel
		/// </summary>
		public string Tel
		{
			get	{ return _tel; }
			set	{ _tel = value; }
		}
		/// <summary>
		/// Email
		/// </summary>
		public string Email
		{
			get	{ return _email; }
			set	{ _email = value; }
		}
		/// <summary>
		/// Valid From
		/// </summary>
		public DateTime ValidFrom
		{
			get	{ return _validfrom; }
			set	{ _validfrom = value; }
		}
		/// <summary>
		/// Valid To
		/// </summary>
		public DateTime ValidTo
		{
			get	{ return _validto; }
			set	{ _validto = value; }
		}
		/// <summary>
		/// Is Activated
		/// </summary>
		public bool IsActivated
		{
			get	{ return _isactivated; }
			set	{ _isactivated = value; }
		}
		/// <summary>
		/// Login Times
		/// </summary>
		public int LoginTimes
		{
			get	{ return _logintimes; }
			set	{ _logintimes = value; }
		}
		/// <summary>
		/// Created Time
		/// </summary>
		public DateTime CreatedTime
		{
			get	{ return _createdtime; }
			set	{ _createdtime = value; }
		}
		/// <summary>
		/// Created By Id
		/// </summary>
		public int CreatedById
		{
			get	{ return _createdbyid; }
			set	{ _createdbyid = value; }
		}
		/// <summary>
		/// Created By Name
		/// </summary>
		public string CreatedByName
		{
			get	{ return _createdbyname; }
			set	{ _createdbyname = value; }
		}
		/// <summary>
		/// Updated Time
		/// </summary>
		public DateTime UpdatedTime
		{
			get	{ return _updatedtime; }
			set	{ _updatedtime = value; }
		}
		/// <summary>
		/// Updated By Id
		/// </summary>
		public int UpdatedById
		{
			get	{ return _updatedbyid; }
			set	{ _updatedbyid = value; }
		}
		/// <summary>
		/// Updated By Name
		/// </summary>
		public string UpdatedByName
		{
			get	{ return _updatedbyname; }
			set	{ _updatedbyname = value; }
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
