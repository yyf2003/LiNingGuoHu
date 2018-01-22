using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ShippingSpeedData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �Զ�������,����
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
        /// <summary>
        /// ��������
        /// </summary>
        public string POPID
        {
            set { _popid = value; }
            get { return _popid; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string GoodsOrderNO
        {
            set { _goodsorderno = value; }
            get { return _goodsorderno; }
        }
		/// <summary>
        /// POP����
		/// </summary>
        public int POPCount
		{
            set { _popcount = value; }
            get { return _popcount; }
		}
		/// <summary>
		/// ������˾ID
		/// </summary>
		public int CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
        /// <summary>
        /// ������˾����
        /// </summary>
        public string CompanyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime FHDate
		{
			set{ _fhdate=value;}
			get{return _fhdate;}
		}
		/// <summary>
		/// ����Ա
		/// </summary>
		public int OperatorID
		{
			set{ _operatorid=value;}
			get{return _operatorid;}
		}
		/// <summary>
		/// �ջ�һ���ͻ�ID
		/// </summary>
		public string DealerID
		{
			set{ _dealerid=value;}
			get{return _dealerid;}
		}
        /// <summary>
        /// �ջ�һ���ͻ�����
        /// </summary>
        public string DealerName
        {
            set { _dealername = value; }
            get { return _dealername; }
        }
		/// <summary>
		/// ������Ӧ�̱��
		/// </summary>
        public int SupplierID
		{
            set { _supplierid = value; }
            get { return _supplierid; }
		}
        /// <summary>
        /// ������Ӧ������
        /// </summary>
        public string SupplierName
        {
            set { _suppliername = value; }
            get { return _suppliername; }
        }
        /// <summary>
        /// �������̱��
        /// </summary>
        public int ShopID
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        /// <summary>
        /// ������������
        /// </summary>
        public string ShopName
        {
            set { _shopname = value; }
            get { return _shopname; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string IsState
        {
            set { _isstate = value; }
            get { return _isstate; }
        }
		/// <summary>
		/// ��ע ��Ҫд������ϸ
		/// </summary>
		public string Remars
		{
			set{ _remars=value;}
			get{return _remars;}
		}
        /// <summary>
        /// �ջ��˱��
        /// </summary>
        public int GetInUserID
        {
            set { _getinuserid = value; }
            get { return _getinuserid; }
        }
        /// <summary>
        /// �ջ�������
        /// </summary>
        public string GetInUserName
        {
            set { _getinusername = value; }
            get { return _getinusername; }
        }
        /// <summary>
        /// �ջ�״̬
        /// </summary>
        public string GetInState
        {
            set { _getinstate = value; }
            get { return _getinstate; }
        }
        /// <summary>
        /// �ջ���
        /// </summary>
        public string GetInFeedBack
        {
            set { _getinfeedback = value; }
            get { return _getinfeedback; }
        }

		#endregion Model

	}
}

