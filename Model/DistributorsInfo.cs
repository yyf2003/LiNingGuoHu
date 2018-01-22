using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����DistributorsInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class DistributorsInfo
	{
		public DistributorsInfo()
		{}
		#region Model
		private int _id;
		private string _fxid;
		private string _fxname;
		private string _fxcontactor;
		private string _fxphone;
		private string _fxtel;
		private string _dealerid;
		private string _fxaddress;
		private int? _areaid;
		private int? _provinceid;
		private int? _cityid;
        private string _newdealerID;
        private int _examstate;
        private int _examuserid;
        private string _examdate;

        public string NewDealerID
        {
            set { _newdealerID = value; }
            get { return _newdealerID; }
        }
        /// <summary>
        /// ���ž������״̬ 1 ͨ�� 0δ��� -1 δͨ��
        /// </summary>
        public int ExamState
        {
            set { _examstate = value; }
            get { return _examstate; }
        }
        /// <summary>
        /// ���ž��������ID
        /// </summary>
        public int ExamUserID
        {
            set { _examuserid = value; }
            get { return _examuserid; }
        }
        /// <summary>
        /// ���ž������ʱ��
        /// </summary>
        public string ExamDate
        {
            set { _examdate = value; }
            get { return _examdate; }
                
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
		/// ������ID
		/// </summary>
		public string FXID
		{
			set{ _fxid=value;}
			get{return _fxid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string FXName
		{
			set{ _fxname=value;}
			get{return _fxname;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string FXContactor
		{
			set{ _fxcontactor=value;}
			get{return _fxcontactor;}
		}
		/// <summary>
		/// ��ϵ�˵绰
		/// </summary>
		public string FXPhone
		{
			set{ _fxphone=value;}
			get{return _fxphone;}
		}
		/// <summary>
		/// �����̵绰
		/// </summary>
		public string FXtel
		{
			set{ _fxtel=value;}
			get{return _fxtel;}
		}
		/// <summary>
		/// ��Ӧ�ľ�����ID
		/// </summary>
		public string DealerID
		{
			set{ _dealerid=value;}
			get{return _dealerid;}
		}
		/// <summary>
		/// ���͵�ַ
		/// </summary>
		public string FXAddress
		{
			set{ _fxaddress=value;}
			get{return _fxaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
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
		#endregion Model

	}
}

