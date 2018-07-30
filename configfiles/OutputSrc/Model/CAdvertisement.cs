using System;

namespace SouEi.Model
{

	/// <summary>
	/// CAdvertisement is an entity class that represents dbo.C_Advertisement
	/// </summary>
	[Serializable]
	public class MDLCAdvertisement
	{
		#region declaration
		private string _TableName = "CAdvertisement";
        private string _PrimaryKey = "AdId";
		private  _adid;
		private  _title;
		private  _image;
		private  _url;
		private  _isvalid;
		private  _sequence;
		#endregion

		#region constructors
		/// <summary>
        /// Default constructor
        /// </summary>
		public MDLCAdvertisement() { }
		
		/// <summary>
        /// Full constructor
        /// </summary>
		public MDLCAdvertisement( adid,  title,  image,  url,  isvalid,  sequence)
        {
			this._adid = adid;
			this._title = title;
			this._image = image;
			this._url = url;
			this._isvalid = isvalid;
			this._sequence = sequence;
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
		/// AdId is a  property that represents column of dbo.C_Advertisement.AdId
		/// </summary>
		public  AdId
		{
			get	{ return _adid; }
			set	{ _adid = value; }
		}
		/// <summary>
		/// Title is a  property that represents column of dbo.C_Advertisement.Title
		/// </summary>
		public  Title
		{
			get	{ return _title; }
			set	{ _title = value; }
		}
		/// <summary>
		/// Image is a  property that represents column of dbo.C_Advertisement.Image
		/// </summary>
		public  Image
		{
			get	{ return _image; }
			set	{ _image = value; }
		}
		/// <summary>
		/// Url is a  property that represents column of dbo.C_Advertisement.Url
		/// </summary>
		public  Url
		{
			get	{ return _url; }
			set	{ _url = value; }
		}
		/// <summary>
		/// IsValid is a  property that represents column of dbo.C_Advertisement.IsValid
		/// </summary>
		public  IsValid
		{
			get	{ return _isvalid; }
			set	{ _isvalid = value; }
		}
		/// <summary>
		/// Sequence is a  property that represents column of dbo.C_Advertisement.Sequence
		/// </summary>
		public  Sequence
		{
			get	{ return _sequence; }
			set	{ _sequence = value; }
		}
		#endregion		
	}
}
