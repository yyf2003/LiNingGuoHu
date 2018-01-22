using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����DSRExamData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class DSRExamData
	{
		public DSRExamData()
		{}
		#region Model
		private int _id;
		private string _popid;
		private int? _checkuserid;
		private string _areaid;
		private int? _provinceid;
		private int? _cityid;
		private int? _shopid;
        private int? _SupplierID;
		private DateTime? _checkdate;
		private DateTime? _sysdatetime;
		private int? _yescount;
		private int? _nocount;
		private string _dataid;
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
		/// �����ԱID
		/// </summary>
		public int? CheckUserID
		{
			set{ _checkuserid=value;}
			get{return _checkuserid;}
		}
		/// <summary>
		/// ����Ͻ����ID
		/// </summary>
		public string AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// ����Ͻʡ��ID
		/// </summary>
		public int? ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// ����Ͻ����ID
		/// </summary>
		public int? CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// ��������ID
		/// </summary>
		public int? ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
        /// <summary>
        /// �������������Ĺ�Ӧ��
        /// </summary>
        public int? SupplierID
        {
            set { _SupplierID = value; }
            get { return _SupplierID; }
        }
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime? CheckDate
		{
			set{ _checkdate=value;}
			get{return _checkdate;}
		}
		/// <summary>
		/// ����¼��ʱ��
		/// </summary>
		public DateTime? SysDateTime
		{
			set{ _sysdatetime=value;}
			get{return _sysdatetime;}
		}
		/// <summary>
		/// �����Ϊ�ǵ���Ŀ
		/// </summary>
		public int? YesCount
		{
			set{ _yescount=value;}
			get{return _yescount;}
		}
		/// <summary>
		/// �����Ϊ�����Ŀ
		/// </summary>
		public int? NoCount
		{
			set{ _nocount=value;}
			get{return _nocount;}
		}
		/// <summary>
		/// ��DSRResultsList��DataIDΪ����
		/// </summary>
		public string DataID
		{
			set{ _dataid=value;}
			get{return _dataid;}
		}
		#endregion Model

	}
}

