using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����DealerInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class DealerInfo
	{
		public DealerInfo()
		{}
		#region Model
		private int _id;
		private string _dealerid;
		private string _dealername;
		private int? _areaid;
		private int? _provinceid;
		private int? _cityid;
		private string _contactor;
		private string _contactorphone;
		private string _address;
		private string _postaddress;
		private string _dealerchannel;
        private int? _examState;
        private int? _examuserid;
        private int? _vmexamState;
        private int? _vmexamUserID;

        /// <summary>
        /// ʡ��VM���״̬ 1 ͨ��  0 δ��� -1 δͨ��
        /// </summary>
        public int? VMExamState
        {
            set { _vmexamState = value; }
            get { return _vmexamState; }
        }
        /// <summary>
        /// ʡ��VM�����Ա
        /// </summary>
        public int? VMExamUserID
        {
            set { _vmexamUserID = value; }
            get { return _vmexamUserID; }
        }

        /// <summary>
        /// ����VM���״̬ 1 ͨ��  0 δ��� -1 δͨ��
        /// </summary>

        public int? ExamState
        {
            set { _examState = value; }
            get { return _examState; }
        }
        /// <summary>
        /// ����VM�����Ա
        /// </summary>

        public int? ExamUserID
        {
            set { _examuserid = value; }
            get { return _examState; }
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
		/// һ���ͻ�ID
		/// </summary>
        public string DealerID
		{
			set{ _dealerid=value;}
			get{return _dealerid;}
		}
		/// <summary>
		/// һ���ͻ�����
		/// </summary>
		public string DealerName
		{
			set{ _dealername=value;}
			get{return _dealername;}
		}
		/// <summary>
		/// ��������ID
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// ����ʡ��ID
		/// </summary>
		public int? ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// ���ڳ���ID
		/// </summary>
		public int? CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string Contactor
		{
			set{ _contactor=value;}
			get{return _contactor;}
		}
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		public string ContactorPhone
		{
			set{ _contactorphone=value;}
			get{return _contactorphone;}
		}
		/// <summary>
		/// ��˾��ַ
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// �ͻ���ַ
		/// </summary>
		public string PostAddress
		{
			set{ _postaddress=value;}
			get{return _postaddress;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string DealerChannel
		{
			set{ _dealerchannel=value;}
			get{return _dealerchannel;}
		}
		#endregion Model

	}
}

