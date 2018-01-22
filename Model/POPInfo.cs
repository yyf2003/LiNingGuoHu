using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����POPInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class POPInfo
	{
		public POPInfo()
		{}
		#region Model
        private int _id;
		private int _shopid;
		private string _seatnum;
        private string _popseat;
		private string _seatdesc;
		private decimal _popheight;
		private decimal _popwith;
		private decimal _poparea;
		private string _popmaterial;
		private int _productlineid;
		private string _sexarea;
		private int _twosided;
		private int _glass;
		private decimal _platformwith;
		private decimal _platformheight;
		private decimal _platformlong;
		private int _examstate;
        private string _systime;
        private string _productline;
        private int _examuserid;
        private string _examdesc;
        private string _addstate;
        private string _POPPlwz;
        private int _POPPljd;
        private decimal _RealHeight;
        private decimal _RealWith;
        private int _VMexamstate;
        private int _VmexamUserId;
        private string _VMExamdate;
        private int _issubmit;
        private string _popmaterialremark;
        private int _ishide;

        /// <summary>
        /// ʡ��VM���״̬ 1 ͨ�� 0 δ��� -1 δͨ��
        /// </summary>
        public int VMExamState
        {
            set { _VMexamstate = value; }
            get { return _VMexamstate; }
        }
        /// <summary>
        ///ʡ��VM���������Ա
        /// </summary>
        public int VMExamUserId
        {
            set { _VmexamUserId = value; }
            get { return _VmexamUserId; }
        }
        /// <summary>
        /// ʡ��VM�������ʱ��
        /// </summary>
        public string VMExamDate
        {
            set { _VMExamdate = value; }
            get { return _VMExamdate; }
        }
        /// <summary>
        /// POPʵ��������
        /// </summary>
        public decimal RealHeight
        {
            set { _RealHeight = value;}
            get { return _RealHeight; }
        }
        /// <summary>
        /// POPʵ��������
        /// </summary>
        public decimal RealWith
        {
            set { _RealWith = value; }
            get { return _RealWith; }
        }
        /// <summary>
        /// POPƫ��λ��
        /// </summary>
        public string POPPlwz
        {
            set { _POPPlwz = value; }
            get { return _POPPlwz; }
        }
        /// <summary>
        /// POPƫ��ļ��� 1-15 ��
        /// </summary>
        public int POPPljd
        {
            set { _POPPljd = value; }
            get { return _POPPljd; }
        }
		/// <summary>
		/// ��������,����ID
		/// </summary>
        public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// λ�ñ��
		/// </summary>
		public string SeatNum
		{
			set{ _seatnum=value;}
			get{return _seatnum;}
		}
        /// <summary>
        /// pop λ�� ���� ���� �ȵ�
        /// </summary>
        public string POPSeat
        {
            set { _popseat = value; }
            get { return _popseat; }
        }
		/// <summary>
		/// λ������
		/// </summary>
		public string SeatDesc
		{
			set{ _seatdesc=value;}
			get{return _seatdesc;}
		}
		/// <summary>
        /// POP���ӻ����
		/// </summary>
		public decimal POPHeight
		{
			set{ _popheight=value;}
			get{return _popheight;}
		}
		/// <summary>
		/// POP���ӻ����
		/// </summary>
		public decimal POPWith
		{
			set{ _popwith=value;}
			get{return _popwith;}
		}
		/// <summary>
		/// POP���
		/// </summary>
		public decimal POPArea
		{
            set { _poparea = value; }
			get{return _poparea;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public string POPMaterial
		{
			set{ _popmaterial=value;}
			get{return _popmaterial;}
		}
		/// <summary>
		/// ��Ʒϵ��ID
		/// </summary>
		public int ProductLineID
		{
			set{ _productlineid=value;}
			get{return _productlineid;}
		}
		/// <summary>
		/// ��/Ů���� 1 ��2 Ů 3 ��Ů����
		/// </summary>
		public string Sexarea
		{
			set{ _sexarea=value;}
			get{return _sexarea;}
		}
		/// <summary>
		/// ˫�� 1 �� 2 ��
		/// </summary>
		public int TwoSided
		{
			set{ _twosided=value;}
			get{return _twosided;}
		}
		/// <summary>
		/// ���� 1 �� 0 ��
		/// </summary>
		public int Glass
		{
			set{ _glass=value;}
			get{return _glass;}
		}
		/// <summary>
		/// ��̨���
		/// </summary>
		public decimal PlatformWith
		{
			set{ _platformwith=value;}
			get{return _platformwith;}
		}
		/// <summary>
		/// ��̨�߶�
		/// </summary>
		public decimal PlatformHeight
		{
			set{ _platformheight=value;}
			get{return _platformheight;}
		}
		/// <summary>
		/// ��̨����
		/// </summary>
		public decimal PlatformLong
		{
			set{ _platformlong=value;}
			get{return _platformlong;}
		}
		/// <summary>
		/// ���ž�������״̬1ͨ���� 0 δ���� -1 δͨ��
		/// </summary>
		public int ExamState
		{
			set{ _examstate=value;}
			get{return _examstate;}
		}
        /// <summary>
        /// ������ʱ��
        /// </summary>
        public string SysTime
        {
            set { _systime = value; }
            get { return _systime; }
        }
        /// <summary>
        /// ��Ʒ���°�
        /// </summary>
        public string ProductLine
        {
            set { _productline = value; }
            get { return _productline; }
        }
        /// <summary>
        /// ���ž��������Ա
        /// </summary>
        public int ExamUserID
        {
            set { _examuserid = value; }
            get { return _examuserid; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string ExamDesc
        {
            set { _examdesc = value; }
            get { return _examdesc; }
        }
		
        /// <summary>
        /// ��ʾ�Ƿ�Ϊ��������ʡ��vm����
        /// </summary>
        public string AddState
        {
            set { _addstate = value; }
            get { return _addstate; }
        }

        /// <summary>
        /// �Ƿ��ύ����
        /// </summary>
        public int IsSubmit
        {
            set { _issubmit = value; }
            get { return _issubmit; }
        }

        /// <summary>
        /// POP��������
        /// </summary>
        public string POPMaterialRemark
        {
            set { _popmaterialremark = value; }
            get { return _popmaterialremark; }
        }

        /// <summary>
        /// �Ƿ��ύ����
        /// </summary>
        public int IsHide
        {
            set { _ishide = value; }
            get { return _ishide; }
        }

        #endregion Model
    }
}

