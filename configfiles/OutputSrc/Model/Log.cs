using System;

namespace SouEi.Model
{

	/// <summary>
	/// Log is an entity class that represents dbo.Log
	/// </summary>
	[Serializable]
	public class MDLLog
	{
		#region declaration
		private string _TableName = "Log";
        private string _PrimaryKey = "";
		private  _id;
		private  _date;
		private  _thread;
		private  _level;
		private  _logger;
		private  _message;
		private  _exception;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLLog() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLLog( id,  date,  thread,  level,  logger,  message,  exception)
        {
			this._id = id;
			this._date = date;
			this._thread = thread;
			this._level = level;
			this._logger = logger;
			this._message = message;
			this._exception = exception;
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
		/// Id is a  property that represents column of dbo.Log.Id
		/// </summary>
		public  Id
		{
			get	{ return _id; }
			set	{ _id = value; }
		}
		/// <summary>
		/// Date is a  property that represents column of dbo.Log.Date
		/// </summary>
		public  Date
		{
			get	{ return _date; }
			set	{ _date = value; }
		}
		/// <summary>
		/// Thread is a  property that represents column of dbo.Log.Thread
		/// </summary>
		public  Thread
		{
			get	{ return _thread; }
			set	{ _thread = value; }
		}
		/// <summary>
		/// Level is a  property that represents column of dbo.Log.Level
		/// </summary>
		public  Level
		{
			get	{ return _level; }
			set	{ _level = value; }
		}
		/// <summary>
		/// Logger is a  property that represents column of dbo.Log.Logger
		/// </summary>
		public  Logger
		{
			get	{ return _logger; }
			set	{ _logger = value; }
		}
		/// <summary>
		/// Message is a  property that represents column of dbo.Log.Message
		/// </summary>
		public  Message
		{
			get	{ return _message; }
			set	{ _message = value; }
		}
		/// <summary>
		/// Exception is a  property that represents column of dbo.Log.Exception
		/// </summary>
		public  Exception
		{
			get	{ return _exception; }
			set	{ _exception = value; }
		}
		#endregion		
	}
}
