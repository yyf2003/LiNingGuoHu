using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ProvinceData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class ProvinceData
	{
		public ProvinceData()
		{}
		#region Model
		private int _provinceid;
		private int? _areaid;
		private string _provincename;
        private string _VMmaster;
        private string _VMPhone;
		/// <summary>
		/// ʡ���������Զ�����
		/// </summary>
		public int ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
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
		/// ʡ����
		/// </summary>
		public string ProvinceName
		{
			set{ _provincename=value;}
			get{return _provincename;}
		}

        public string VMmaster
        {
            set{_VMmaster=value;}
            get{return _VMmaster;}
        }
        public string VMphone
        {
            set { _VMPhone = value; }
            get { return _VMPhone; }
        }
		#endregion Model

	}
}

