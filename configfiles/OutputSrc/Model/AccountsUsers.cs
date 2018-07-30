using System;

namespace SouEi.Model
{

	/// <summary>
	/// AccountsUsers is an entity class that represents dbo.Accounts_Users
	/// </summary>
	[Serializable]
	public class MDLAccountsUsers
	{
		#region declaration
		private string _TableName = "AccountsUsers";
        private string _PrimaryKey = "UserId";
		private  _userid;
		private  _username;
		private  _password;
		private  _realname;
		private  _email;
		private  _gender;
		private  _birthday;
		private  _address;
		private  _cityid;
		private  _postalcode;
		private  _sequence;
		private  _logintimes;
		private  _lastlogin;
		private  _addedtime;
		private  _addedby;
		private  _updatedtime;
		private  _updatedby;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLAccountsUsers() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLAccountsUsers( userid,  username,  password,  realname,  email,  gender,  birthday,  address,  cityid,  postalcode,  sequence,  logintimes,  lastlogin,  addedtime,  addedby,  updatedtime,  updatedby)
        {
			this._userid = userid;
			this._username = username;
			this._password = password;
			this._realname = realname;
			this._email = email;
			this._gender = gender;
			this._birthday = birthday;
			this._address = address;
			this._cityid = cityid;
			this._postalcode = postalcode;
			this._sequence = sequence;
			this._logintimes = logintimes;
			this._lastlogin = lastlogin;
			this._addedtime = addedtime;
			this._addedby = addedby;
			this._updatedtime = updatedtime;
			this._updatedby = updatedby;
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
		/// UserId is a  property that represents column of dbo.Accounts_Users.UserId
		/// </summary>
		public  UserId
		{
			get	{ return _userid; }
			set	{ _userid = value; }
		}
		/// <summary>
		/// UserName is a  property that represents column of dbo.Accounts_Users.UserName
		/// </summary>
		public  UserName
		{
			get	{ return _username; }
			set	{ _username = value; }
		}
		/// <summary>
		/// Password is a  property that represents column of dbo.Accounts_Users.Password
		/// </summary>
		public  Password
		{
			get	{ return _password; }
			set	{ _password = value; }
		}
		/// <summary>
		/// RealName is a  property that represents column of dbo.Accounts_Users.RealName
		/// </summary>
		public  RealName
		{
			get	{ return _realname; }
			set	{ _realname = value; }
		}
		/// <summary>
		/// Email is a  property that represents column of dbo.Accounts_Users.Email
		/// </summary>
		public  Email
		{
			get	{ return _email; }
			set	{ _email = value; }
		}
		/// <summary>
		/// Gender is a  property that represents column of dbo.Accounts_Users.Gender
		/// </summary>
		public  Gender
		{
			get	{ return _gender; }
			set	{ _gender = value; }
		}
		/// <summary>
		/// Birthday is a  property that represents column of dbo.Accounts_Users.Birthday
		/// </summary>
		public  Birthday
		{
			get	{ return _birthday; }
			set	{ _birthday = value; }
		}
		/// <summary>
		/// Address is a  property that represents column of dbo.Accounts_Users.Address
		/// </summary>
		public  Address
		{
			get	{ return _address; }
			set	{ _address = value; }
		}
		/// <summary>
		/// CityId is a  property that represents column of dbo.Accounts_Users.CityId
		/// </summary>
		public  CityId
		{
			get	{ return _cityid; }
			set	{ _cityid = value; }
		}
		/// <summary>
		/// PostalCode is a  property that represents column of dbo.Accounts_Users.PostalCode
		/// </summary>
		public  PostalCode
		{
			get	{ return _postalcode; }
			set	{ _postalcode = value; }
		}
		/// <summary>
		/// Sequence is a  property that represents column of dbo.Accounts_Users.Sequence
		/// </summary>
		public  Sequence
		{
			get	{ return _sequence; }
			set	{ _sequence = value; }
		}
		/// <summary>
		/// LoginTimes is a  property that represents column of dbo.Accounts_Users.LoginTimes
		/// </summary>
		public  LoginTimes
		{
			get	{ return _logintimes; }
			set	{ _logintimes = value; }
		}
		/// <summary>
		/// LastLogin is a  property that represents column of dbo.Accounts_Users.LastLogin
		/// </summary>
		public  LastLogin
		{
			get	{ return _lastlogin; }
			set	{ _lastlogin = value; }
		}
		/// <summary>
		/// AddedTime is a  property that represents column of dbo.Accounts_Users.AddedTime
		/// </summary>
		public  AddedTime
		{
			get	{ return _addedtime; }
			set	{ _addedtime = value; }
		}
		/// <summary>
		/// AddedBy is a  property that represents column of dbo.Accounts_Users.AddedBy
		/// </summary>
		public  AddedBy
		{
			get	{ return _addedby; }
			set	{ _addedby = value; }
		}
		/// <summary>
		/// UpdatedTime is a  property that represents column of dbo.Accounts_Users.UpdatedTime
		/// </summary>
		public  UpdatedTime
		{
			get	{ return _updatedtime; }
			set	{ _updatedtime = value; }
		}
		/// <summary>
		/// UpdatedBy is a  property that represents column of dbo.Accounts_Users.UpdatedBy
		/// </summary>
		public  UpdatedBy
		{
			get	{ return _updatedby; }
			set	{ _updatedby = value; }
		}
		#endregion		
	}
}
