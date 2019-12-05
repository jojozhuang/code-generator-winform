using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Channel
	/// </summary>
	[Serializable]
	public class Channel
	{
		#region declaration
		private string _TableName = "seh_channel";
        private string _PrimaryKey = "ChannelId";
        private bool _IsDesc = false;
		private int _channelid;
		private string _channelname;
		private int _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Channel() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Channel(int channelid, string channelname, int sequence)
        {
			this._channelid = channelid;
			this._channelname = channelname;
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
		/// Channel Id
		/// </summary>
		public int ChannelId
		{
			get	{ return _channelid; }
			set	{ _channelid = value; }
		}
		/// <summary>
		/// Channel Name
		/// </summary>
		public string ChannelName
		{
			get	{ return _channelname; }
			set	{ _channelname = value; }
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
