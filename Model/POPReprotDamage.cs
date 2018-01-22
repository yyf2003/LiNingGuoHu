using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����POPReprotDamage ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class POPReprotDamage
	{
		public POPReprotDamage()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private int? _supplierid;
		private int? _upuserid;
        private string  _uppopdate;
		private string _photopath;
		private string _shopdesc;
		private int? _dsrstate;
		private string _dsrdesc;
        private string  _dsrdate;
		private int? _vmstate;
        private string  _vmdate;
		private string _vmdesc;
		/// <summary>
		/// ����
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ShopID
		/// </summary>
		public int? ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// ��Ӧ��ID
		/// </summary>
		public int? SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// �ύ��ID
		/// </summary>
		public int? UpUserID
		{
			set{ _upuserid=value;}
			get{return _upuserid;}
		}
		/// <summary>
		/// �ύ����
		/// </summary>
        public string UpPOPDate
		{
			set{ _uppopdate=value;}
			get{return _uppopdate;}
		}
		/// <summary>
		/// ͼƬ
		/// </summary>
		public string PhotoPath
		{
			set{ _photopath=value;}
			get{return _photopath;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string ShopDesc
		{
			set{ _shopdesc=value;}
			get{return _shopdesc;}
		}
		/// <summary>
		/// Dsr����1 ��� 0δ��
		/// </summary>
		public int? DSRState
		{
			set{ _dsrstate=value;}
			get{return _dsrstate;}
		}
		/// <summary>
		/// DSR����
		/// </summary>
		public string DSRDesc
		{
			set{ _dsrdesc=value;}
			get{return _dsrdesc;}
		}
		/// <summary>
		/// DSR����ʱ��
		/// </summary>
        public string DSRDate
		{
			set{ _dsrdate=value;}
			get{return _dsrdate;}
		}
		/// <summary>
		/// VM����״̬ 1 ��� 0δ��
		/// </summary>
		public int? VMState
		{
			set{ _vmstate=value;}
			get{return _vmstate;}
		}
		/// <summary>
		/// VM����ʱ��
		/// </summary>
        public string VMDate
		{
			set{ _vmdate=value;}
			get{return _vmdate;}
		}
		/// <summary>
		/// VM����
		/// </summary>
		public string VMDesc
		{
			set{ _vmdesc=value;}
			get{return _vmdesc;}
		}
		#endregion Model

	}
}

