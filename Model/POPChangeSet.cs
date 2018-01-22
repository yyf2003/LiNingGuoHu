using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����POPChangeSet ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class POPChangeSet
	{
		public POPChangeSet()
		{}
		#region Model
		private int _id;
		private string _popid;
		private int? _areaid;
		private int? _provinceid;
		private int? _cityid;
		private int? _catenaproid;
		private string _changesetdesc;
        private int? _shopid;
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
		/// ����id
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
		/// ������ID
		/// </summary>
		public int? CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
        /// <summary>
        /// �μ�POP�����ID
        /// </summary>
        public int? ShopID
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
		/// <summary>
		/// ���滻�Ĳ�Ʒϵ��
		/// </summary>
		public int? CatenaProID
		{
			set{ _catenaproid=value;}
			get{return _catenaproid;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string ChangeSetDesc
		{
			set{ _changesetdesc=value;}
			get{return _changesetdesc;}
		}
		#endregion Model

	}
}

