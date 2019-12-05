using System;

namespace Johnny.EEE.OM.Admin
{
	/// <summary>
	/// Entity Class Mailsettings
	/// </summary>
	[Serializable]
	public class Mailsettings
	{
		#region declaration
		private string _TableName = "cms_mailsettings";
        private string _PrimaryKey = "Id";
        private bool _IsDesc = false;
		private int _id;
		private string _smtpserverip;
		private int _smtpserverport;
		private string _mailid;
		private string _mailpassword;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public Mailsettings() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public Mailsettings(int id, string smtpserverip, int smtpserverport, string mailid, string mailpassword)
        {
			this._id = id;
			this._smtpserverip = smtpserverip;
			this._smtpserverport = smtpserverport;
			this._mailid = mailid;
			this._mailpassword = mailpassword;
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
		/// 编号（自动加1）
		/// </summary>
		public int Id
		{
			get	{ return _id; }
			set	{ _id = value; }
		}
		/// <summary>
		/// IP
		/// </summary>
		public string SmtpServerIP
		{
			get	{ return _smtpserverip; }
			set	{ _smtpserverip = value; }
		}
		/// <summary>
		/// Port
		/// </summary>
		public int SmtpServerPort
		{
			get	{ return _smtpserverport; }
			set	{ _smtpserverport = value; }
		}
		/// <summary>
		/// 邮件地址
		/// </summary>
		public string MailId
		{
			get	{ return _mailid; }
			set	{ _mailid = value; }
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string MailPassword
		{
			get	{ return _mailpassword; }
			set	{ _mailpassword = value; }
		}
		#endregion		
	}
}
