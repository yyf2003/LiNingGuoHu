using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类EditShopInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class EditShopInfo
	{
		public EditShopInfo()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private string _posid;
		private string _shopname;
		private string _shopaddress;
		private string _shopopendate;
		private string _shopclosedate;
		private int? _closeuserid;
		private int? _provinceid;
		private int? _cityid;
		private int? _townid;
		private int? _shoplevelid;
		private int? _saletypeid;
		private string _linkman;
		private string _linkphone;
		private string _shopmaster;
		private string _shopmasterphone;
		private string _email;
		private string _postaddress;
		private string _postcode;
		private string _faxnumber;
		private int? _boolinstall;
		private string _dealerid;
		private string _fxid;
		private string _customergroupid;
		private string _customergroupname;
		private int? _shopstate;
		private int? _examstate;
		private string _vmmaster;
		private string _vmmasterphone;
		private string _dsrmaster;
		private string _dsrmasterphone;
		private decimal? _shoparea;
		private int? _shopvi;
		private int? _shoptype;
		private string _shopphone;
		private int? _areaid;
        private string _customerCard;
        private string _ShopOwnerShip;
        private string _ShopSampleName;

        //add by mhj 2012.12.13
        private int _ACL_Id;
        private int _TCL_Id;
        public int ACL_Id
        {
            set { _ACL_Id = value; }
            get { return _ACL_Id; }
        }
        public int TCL_Id
        {
            set { _TCL_Id = value; }
            get { return _TCL_Id; }
        }

        /// <summary>
        /// 客户身份
        /// </summary>
        public string CustomerCard
        {
            set { _customerCard = value; }
            get { return _customerCard; }
        }
        /// <summary>
        /// 店铺所有权
        /// </summary>
        public string ShopOwnerShip
        {
            set { _ShopOwnerShip = value; }
            get { return _ShopOwnerShip; }
        }
        /// <summary>
        /// 店铺简称
        /// </summary>
        public string ShopSampleName
        {
            set { _ShopSampleName = value; }
            get { return _ShopSampleName; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PosID
		{
			set{ _posid=value;}
			get{return _posid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Shopname
		{
			set{ _shopname=value;}
			get{return _shopname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShopAddress
		{
			set{ _shopaddress=value;}
			get{return _shopaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShopOpenDate
		{
			set{ _shopopendate=value;}
			get{return _shopopendate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShopCloseDate
		{
			set{ _shopclosedate=value;}
			get{return _shopclosedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CloseUserID
		{
			set{ _closeuserid=value;}
			get{return _closeuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TownID
		{
			set{ _townid=value;}
			get{return _townid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShopLevelID
		{
			set{ _shoplevelid=value;}
			get{return _shoplevelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SaleTypeID
		{
			set{ _saletypeid=value;}
			get{return _saletypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LinkMan
		{
			set{ _linkman=value;}
			get{return _linkman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LinkPhone
		{
			set{ _linkphone=value;}
			get{return _linkphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShopMaster
		{
			set{ _shopmaster=value;}
			get{return _shopmaster;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShopMasterPhone
		{
			set{ _shopmasterphone=value;}
			get{return _shopmasterphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostAddress
		{
			set{ _postaddress=value;}
			get{return _postaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostCode
		{
			set{ _postcode=value;}
			get{return _postcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FaxNumber
		{
			set{ _faxnumber=value;}
			get{return _faxnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Boolinstall
		{
			set{ _boolinstall=value;}
			get{return _boolinstall;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DealerID
		{
			set{ _dealerid=value;}
			get{return _dealerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FXID
		{
			set{ _fxid=value;}
			get{return _fxid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerGroupID
		{
			set{ _customergroupid=value;}
			get{return _customergroupid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerGroupName
		{
			set{ _customergroupname=value;}
			get{return _customergroupname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShopState
		{
			set{ _shopstate=value;}
			get{return _shopstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ExamState
		{
			set{ _examstate=value;}
			get{return _examstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VMMaster
		{
			set{ _vmmaster=value;}
			get{return _vmmaster;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VMMasterPhone
		{
			set{ _vmmasterphone=value;}
			get{return _vmmasterphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DSRMaster
		{
			set{ _dsrmaster=value;}
			get{return _dsrmaster;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DSRMasterPhone
		{
			set{ _dsrmasterphone=value;}
			get{return _dsrmasterphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ShopArea
		{
			set{ _shoparea=value;}
			get{return _shoparea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShopVI
		{
			set{ _shopvi=value;}
			get{return _shopvi;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShopType
		{
			set{ _shoptype=value;}
			get{return _shoptype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShopPhone
		{
			set{ _shopphone=value;}
			get{return _shopphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? areaid
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		#endregion Model

	}
}

