using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Bestpractice
	/// </summary>
	[Serializable]
	public class Bestpractice
	{
		#region declaration
		private string _TableName = "seh_bestpractice";
        private string _PrimaryKey = "BestPracticeId";
        private bool _IsDesc = false;
		private int _bestpracticeid;
		private string _bestpracticename;
		private string _shortdescription;
		private string _description;
		private int _hits;
		private bool _isdisplay;
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
		public Bestpractice() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Bestpractice(int bestpracticeid, string bestpracticename, string shortdescription, string description, int hits, bool isdisplay, DateTime createdtime, int createdbyid, string createdbyname, DateTime updatedtime, int updatedbyid, string updatedbyname, int sequence)
        {
			this._bestpracticeid = bestpracticeid;
			this._bestpracticename = bestpracticename;
			this._shortdescription = shortdescription;
			this._description = description;
			this._hits = hits;
			this._isdisplay = isdisplay;
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
		/// Best Practice Id
		/// </summary>
		public int BestPracticeId
		{
			get	{ return _bestpracticeid; }
			set	{ _bestpracticeid = value; }
		}
		/// <summary>
		/// Best Practice Name
		/// </summary>
		public string BestPracticeName
		{
			get	{ return _bestpracticename; }
			set	{ _bestpracticename = value; }
		}
		/// <summary>
		/// Short Description
		/// </summary>
		public string ShortDescription
		{
			get	{ return _shortdescription; }
			set	{ _shortdescription = value; }
		}
		/// <summary>
		/// Description
		/// </summary>
		public string Description
		{
			get	{ return _description; }
			set	{ _description = value; }
		}
		/// <summary>
		/// Hits
		/// </summary>
		public int Hits
		{
			get	{ return _hits; }
			set	{ _hits = value; }
		}
		/// <summary>
		/// Is Display
		/// </summary>
		public bool IsDisplay
		{
			get	{ return _isdisplay; }
			set	{ _isdisplay = value; }
		}
		/// <summary>
		/// CreatedTime
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
