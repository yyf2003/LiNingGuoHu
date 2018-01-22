using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ShippingSpeedData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ShippingSpeedData
	{
		public ShippingSpeedData()
		{}
		#region Model
		private int _id;
        private string _popid;
        private string _goodsorderno;
        private int _popcount;
		private int _companyid;
        private string _companyname;
		private DateTime _fhdate;
		private int _operatorid;
		private string _dealerid;
        private string _dealername;
        private int _supplierid;
        private string _suppliername;
        private int _shopid;
        private string _shopname;
        private string _isstate;
		private string _remars;
        private int _getinuserid;
        private string _getinusername;
        private string _getinstate;
        private string _getinfeedback;
		/// <summary>
		/// 自动增长列,主键
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
        /// <summary>
        /// 发货单号
        /// </summary>
        public string POPID
        {
            set { _popid = value; }
            get { return _popid; }
        }
        /// <summary>
        /// 发货单号
        /// </summary>
        public string GoodsOrderNO
        {
            set { _goodsorderno = value; }
            get { return _goodsorderno; }
        }
		/// <summary>
        /// POP数量
		/// </summary>
        public int POPCount
		{
            set { _popcount = value; }
            get { return _popcount; }
		}
		/// <summary>
		/// 物流公司ID
		/// </summary>
		public int CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
        /// <summary>
        /// 物流公司名称
        /// </summary>
        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
		/// <summary>
		/// 发货时间
		/// </summary>
		public DateTime FHDate
		{
			set{ _fhdate=value;}
			get{return _fhdate;}
		}
		/// <summary>
		/// 操作员
		/// </summary>
		public int OperatorID
		{
			set{ _operatorid=value;}
			get{return _operatorid;}
		}
		/// <summary>
		/// 收货一级客户ID
		/// </summary>
		public string DealerID
		{
			set{ _dealerid=value;}
			get{return _dealerid;}
		}
        /// <summary>
        /// 收货一级客户名称
        /// </summary>
        public string DealerName
        {
            set { _dealername = value; }
            get { return _dealername; }
        }
		/// <summary>
		/// 所属供应商编号
		/// </summary>
        public int SupplierID
		{
            set { _supplierid = value; }
            get { return _supplierid; }
		}
        /// <summary>
        /// 所属供应商名称
        /// </summary>
        public string SupplierName
        {
            set { _suppliername = value; }
            get { return _suppliername; }
        }
        /// <summary>
        /// 所属店铺编号
        /// </summary>
        public int ShopID
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        /// <summary>
        /// 所属店铺名称
        /// </summary>
        public string ShopName
        {
            set { _shopname = value; }
            get { return _shopname; }
        }
        /// <summary>
        /// 发货类型
        /// </summary>
        public string IsState
        {
            set { _isstate = value; }
            get { return _isstate; }
        }
		/// <summary>
		/// 备注 主要写货物详细
		/// </summary>
		public string Remars
		{
			set{ _remars=value;}
			get{return _remars;}
		}
        /// <summary>
        /// 收货人编号
        /// </summary>
        public int GetInUserID
        {
            set { _getinuserid = value; }
            get { return _getinuserid; }
        }
        /// <summary>
        /// 收货人名称
        /// </summary>
        public string GetInUserName
        {
            set { _getinusername = value; }
            get { return _getinusername; }
        }
        /// <summary>
        /// 收获状态
        /// </summary>
        public string GetInState
        {
            set { _getinstate = value; }
            get { return _getinstate; }
        }
        /// <summary>
        /// 收获反馈
        /// </summary>
        public string GetInFeedBack
        {
            set { _getinfeedback = value; }
            get { return _getinfeedback; }
        }

		#endregion Model

	}
}

