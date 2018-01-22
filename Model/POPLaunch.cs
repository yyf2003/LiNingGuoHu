using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����POPLaunch ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class POPLaunch
	{
		public POPLaunch()
		{}
		#region Model
		private int _id;
		private string _popid;
		private DateTime _begindate;
		private DateTime _enddate;
		private string _poptitle;
		private int _organigerid;
        private string _organigername;
		private string _productlinedatas;
		private DateTime _inputdate;
		private string _launchdesc;
        private string _UploadfileUrl;
        private int? _steps;
        private string _producturl;
        private int _boolPrice;
        /// <summary>
        /// �Ƿ����±���
        /// </summary>
        public int BoolPrice
        {
            set { _boolPrice = value; }
            get { return _boolPrice; }
        }
		/// <summary>
		/// �Զ�������,����
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// POP����ID
		/// </summary>
        public string POPID
		{
			set{ _popid=value;}
			get{return _popid;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime BeginDate
		{
			set{ _begindate=value;}
			get{return _begindate;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// POP����
		/// </summary>
		public string POPTitle
		{
			set{ _poptitle=value;}
			get{return _poptitle;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		public int OrganigerID
		{
			set{ _organigerid=value;}
			get{return _organigerid;}
		}

        /// <summary>
        /// �������û���
        /// </summary>
        public string OrganigerName
        {
            set { _organigername = value; }
            get { return _organigername; }
        }
		/// <summary>
		/// ���漰�Ĳ�Ʒϵ��ID �ö��ŷֿ�
		/// </summary>
		public string ProductLineDatas
		{
			set{ _productlinedatas=value;}
			get{return _productlinedatas;}
		}
		/// <summary>
		/// ¼��ʱ��
		/// </summary>
		public DateTime InputDate
		{
			set{ _inputdate=value;}
			get{return _inputdate;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string LaunchDesc
		{
			set{ _launchdesc=value;}
			get{return _launchdesc;}
		}
        /// <summary>
        /// �ļ�˵�� �ϴ����ļ�·��
        /// </summary>
        public string UploadFileUrl
        {
            set { _UploadfileUrl = value; }
            get { return _UploadfileUrl; }
        }
        /// <summary>
        /// POP������ɵĲ��� 0Ϊȫ�����  1��2��3��4 ��ʾ��ɵڼ�����
        /// </summary>
        public int? steps
        {
            set { _steps = value; }
            get { return _steps; }
        }

        public string ProductUrl
        {
            set { _producturl = value; }
            get { return _producturl; }
        }
		#endregion Model

	}
}

