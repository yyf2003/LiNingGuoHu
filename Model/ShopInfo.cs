using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ShopInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �ͻ����
        /// </summary>
        public string CustomerCard
        {
            set { _customerCard = value; }
            get { return _customerCard; }
        }
        /// <summary>
        /// ��������Ȩ
        /// </summary>
        public string ShopOwnerShip
        {
            set { _ShopOwnerShip = value; }
            get { return _ShopOwnerShip; }
        }
        /// <summary>
        /// ���̼��
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
        ///  ֱ���ͻ�
        /// </summary>
        public string Fxid
        {
            set { _Fxid = value; }
            get { return _Fxid; }
        }
        /// <summary>
        /// һ���ͻ�����
        /// </summary>
        public string ShopPhone
        {
            set { _ShopPhone = value; }
            get { return _ShopPhone; }
        }
		/// <summary>
		/// ����ID���Զ�����
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����ID(�������ظ�)
		/// </summary>
		public int ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// ���̿ɲ�ID(�����ڲ�ID)
		/// </summary>
		public string PosID
		{
			set{ _posid=value;}
			get{return _posid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string Shopname
		{
			set{ _shopname=value;}
			get{return _shopname;}
		}
		/// <summary>
		/// ���̵�ַ
		/// </summary>
		public string ShopAddress
		{
			set{ _shopaddress=value;}
			get{return _shopaddress;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public string ShopOpenDate
		{
			set{ _shopopendate=value;}
			get{return _shopopendate;}
		}
		/// <summary>
		/// �ص�ʱ��
		/// </summary>
		public string ShopCloseDate
		{
			set{ _shopclosedate=value;}
			get{return _shopclosedate;}
		}
		/// <summary>
		/// �ص����ԱID
		/// </summary>
		public int CloseUserID
		{
			set{ _closeuserid=value;}
			get{return _closeuserid;}
		}
		/// <summary>
		/// ����ʡID
		/// </summary>
		public int ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// ���ڳ���ID
		/// </summary>
		public int CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
        /// <summary>
        /// �������ڵؼ���ID
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
		/// ���̼���ID
		/// </summary>
		public int ShopLevelID
		{
			set{ _shoplevelid=value;}
			get{return _shoplevelid;}
		}
		/// <summary>
		/// ������ʽ ��������ֱӪ�����ǻ�������
		/// </summary>
		public int SaleTypeID
		{
			set{ _saletypeid=value;}
			get{return _saletypeid;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string LinkMan
		{
			set{ _linkman=value;}
			get{return _linkman;}
		}
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		public string LinkPhone
		{
			set{ _linkphone=value;}
			get{return _linkphone;}
		}
        /// <summary>
        /// ���̸�����
        /// </summary>
        public string ShopMaster
        {
            set { _shopmaster = value; }
            get { return _shopmaster; }
        }
        /// <summary>
        /// ���̸����˵绰
        /// </summary>
        public string ShopMasterPhone
        {
            set { _shopmasterphone = value; }
            get { return _shopmasterphone; }
        }
		/// <summary>
		/// ��������
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// �ջ���ַ
		/// </summary>
		public string PostAddress
		{
			set{ _postaddress=value;}
			get{return _postaddress;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string PostCode
		{
			set{ _postcode=value;}
			get{return _postcode;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public string FaxNumber
		{
			set{ _faxnumber=value;}
			get{return _faxnumber;}
		}
		/// <summary>
		/// �Ƿ�װ 1 ��װ 0 ����װ
		/// </summary>
		public int Boolinstall
		{
			set{ _boolinstall=value;}
			get{return _boolinstall;}
		}
		/// <summary>
		/// һ���ͻ�ID
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
        /// VM������
        /// </summary>
        public string VMMaster
        {
            set { _vmmaster = value; }
            get { return _vmmaster; }
        }
        /// <summary>
        /// VM��ϵ�绰
        /// </summary>
        public string VMMasterPhone
        {
            set { _vmmasterphone = value; }
            get { return _vmmasterphone; }
        }
        /// <summary>
        /// DSR�����
        /// </summary>
        public string DSRMaster
        {
            set { _dsrmaster = value; }
            get { return _dsrmaster; }
        }
        /// <summary>
        /// DSR��ϵ�绰
        /// </summary>
        public string DSRMasterPhone
        {
            set { _dsrmasterphone = value; }
            get { return _dsrmasterphone; }
        }
        /// <summary>
        /// �������
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
        /// ��������
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
        /// ���ؼ����м����г�������
        /// </summary>
        public int ACL_ID
        {
            set { _acl_id = value; }
            get { return _acl_id; }
        }

        /// <summary>
        /// ���м����м����г�������
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

