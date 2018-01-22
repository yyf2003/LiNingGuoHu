using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ShopInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ShopInfo
	{
		public ShopInfo()
		{}
		#region Model
		private int _id;
		private int _shopid;
		private string _posid;
		private string _shopname;
		private string _shopaddress;
		private string _shopopendate;
		private string _shopclosedate;
		private int _closeuserid;
		private int _provinceid;
		private int _cityid;
        private int _townid;
		private int _shoplevelid;
		private int _saletypeid;
		private string _linkman;
		private string _linkphone;
        private string _shopmaster;
        private string _shopmasterphone;
		private string _email;
		private string _postaddress;
		private string _postcode;
		private string _faxnumber;
		private int _boolinstall;
		private string _dealerid;
		private int _shopstate;
		private int _examstate;
        private string _vmmaster;
        private string _vmmasterphone;
        private string _dsrmaster;
        private string _dsrmasterphone;
        private decimal? _shoparea;
        private int _shopvi;
        private int _shoptype;
        private string _Fxid;
        private string _ShopPhone;
        private int _areaid;
        private string _customerGroupID;
        private string _customergroupname;
        private string _customerCard;
        private string _ShopOwnerShip;
        private string _ShopSampleName;
        private int _acl_id;
        private int _tcl_id;

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
        public string CustomerGroupID
        {
            set { _customerGroupID = value; }
            get { return _customerGroupID; }
        }
        public string CustomerGroupName
        {
            set { _customergroupname = value; }
            get { return _customergroupname; }
        }
        /// <summary>
        ///  直属客户
        /// </summary>
        public string Fxid
        {
            set { _Fxid = value; }
            get { return _Fxid; }
        }
        /// <summary>
        /// 一级客户（）
        /// </summary>
        public string ShopPhone
        {
            set { _ShopPhone = value; }
            get { return _ShopPhone; }
        }
		/// <summary>
		/// 主键ID，自动增长
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 店铺ID(不允许重复)
		/// </summary>
		public int ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 店铺可查ID(李宁内部ID)
		/// </summary>
		public string PosID
		{
			set{ _posid=value;}
			get{return _posid;}
		}
		/// <summary>
		/// 店铺名称
		/// </summary>
		public string Shopname
		{
			set{ _shopname=value;}
			get{return _shopname;}
		}
		/// <summary>
		/// 店铺地址
		/// </summary>
		public string ShopAddress
		{
			set{ _shopaddress=value;}
			get{return _shopaddress;}
		}
		/// <summary>
		/// 开店时间
		/// </summary>
		public string ShopOpenDate
		{
			set{ _shopopendate=value;}
			get{return _shopopendate;}
		}
		/// <summary>
		/// 关店时间
		/// </summary>
		public string ShopCloseDate
		{
			set{ _shopclosedate=value;}
			get{return _shopclosedate;}
		}
		/// <summary>
		/// 关店操作员ID
		/// </summary>
		public int CloseUserID
		{
			set{ _closeuserid=value;}
			get{return _closeuserid;}
		}
		/// <summary>
		/// 所在省ID
		/// </summary>
		public int ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 所在城市ID
		/// </summary>
		public int CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
        /// <summary>
        /// 店铺所在地级市ID
        /// </summary>
        public int TownID
        {
            set
            {
                _townid = value;
            }
            get
            {
                return _townid;
            }
        }
		/// <summary>
		/// 店铺级别ID
		/// </summary>
		public int ShopLevelID
		{
			set{ _shoplevelid=value;}
			get{return _shoplevelid;}
		}
		/// <summary>
		/// 销售形式 分销还是直营或者是还有其他
		/// </summary>
		public int SaleTypeID
		{
			set{ _saletypeid=value;}
			get{return _saletypeid;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string LinkMan
		{
			set{ _linkman=value;}
			get{return _linkman;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string LinkPhone
		{
			set{ _linkphone=value;}
			get{return _linkphone;}
		}
        /// <summary>
        /// 店铺负责人
        /// </summary>
        public string ShopMaster
        {
            set { _shopmaster = value; }
            get { return _shopmaster; }
        }
        /// <summary>
        /// 店铺负责人电话
        /// </summary>
        public string ShopMasterPhone
        {
            set { _shopmasterphone = value; }
            get { return _shopmasterphone; }
        }
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 收货地址
		/// </summary>
		public string PostAddress
		{
			set{ _postaddress=value;}
			get{return _postaddress;}
		}
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string PostCode
		{
			set{ _postcode=value;}
			get{return _postcode;}
		}
		/// <summary>
		/// 传真号码
		/// </summary>
		public string FaxNumber
		{
			set{ _faxnumber=value;}
			get{return _faxnumber;}
		}
		/// <summary>
		/// 是否安装 1 安装 0 不安装
		/// </summary>
		public int Boolinstall
		{
			set{ _boolinstall=value;}
			get{return _boolinstall;}
		}
		/// <summary>
		/// 一级客户ID
		/// </summary>
		public string DealerID
		{
			set{ _dealerid=value;}
			get{return _dealerid;}
		}
		/// <summary>
		/// ShopState
		/// </summary>
		public int ShopState
		{
			set{ _shopstate=value;}
			get{return _shopstate;}
		}
		/// <summary>
		/// ExamState
		/// </summary>
		public int ExamState
		{
			set{ _examstate=value;}
			get{return _examstate;}
		}
        /// <summary>
        /// VM负责人
        /// </summary>
        public string VMMaster
        {
            set { _vmmaster = value; }
            get { return _vmmaster; }
        }
        /// <summary>
        /// VM联系电话
        /// </summary>
        public string VMMasterPhone
        {
            set { _vmmasterphone = value; }
            get { return _vmmasterphone; }
        }
        /// <summary>
        /// DSR检查人
        /// </summary>
        public string DSRMaster
        {
            set { _dsrmaster = value; }
            get { return _dsrmaster; }
        }
        /// <summary>
        /// DSR联系电话
        /// </summary>
        public string DSRMasterPhone
        {
            set { _dsrmasterphone = value; }
            get { return _dsrmasterphone; }
        }
        /// <summary>
        /// 店铺面积
        /// </summary>
        public decimal? ShopArea
        {
            set { _shoparea = value; }
            get { return _shoparea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ShopVI
        {
            set { _shopvi = value; }
            get { return _shopvi; }
        }
        /// <summary>
        /// 店铺类型
        /// </summary>
        public int ShopType
        {
            set { _shoptype = value; }
            get { return _shoptype; }
        }

        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }

        /// <summary>
        /// 区县级城市级别—市场定义编号
        /// </summary>
        public int ACL_ID
        {
            set { _acl_id = value; }
            get { return _acl_id; }
        }

        /// <summary>
        /// 地市级城市级别—市场定义编号
        /// </summary>
        public int TCL_ID
        {
            set { _tcl_id = value; }
            get { return _tcl_id; }
        }

        public string BigArea { get; set; }

		#endregion Model

	}
}

