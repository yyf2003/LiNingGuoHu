using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����imageToPOP ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class imageToPOP
	{
		public imageToPOP()
		{}
		#region Model
		private int _id;
		private string _popid;
		private int? _popinfoid;
		private int? _imageid;
		private int? _prolineid;
		private int? _shopid;
		private DateTime? _systime;

        //add by mhj 2012.2.5
        string _NewImageUrl_Small;
        string _NewImageUrl_Big;
        string _OldImageUrl_Small;
        string _OldImageUrl_Big;
        /// <summary>
        /// pop�������Ч��ͼ������ͼ��
        /// </summary>
        public string NewImageUrl_Small
        {
            set { _NewImageUrl_Small = value; }
            get { return _NewImageUrl_Small; }
        }
        /// <summary>
        /// pop�������Ч��ͼ��ԭͼ��
        /// </summary>
        public string NewImageUrl_Big
        {
            set { _NewImageUrl_Big = value; }
            get { return _NewImageUrl_Big; }
        }        
        /// <summary>
        /// pop����ǰ��Ч��ͼ������ͼ��
        /// </summary>
        public string OldImageUrl_Small
        {
            set { _OldImageUrl_Small = value; }
            get { return _OldImageUrl_Small; }
        }
        /// <summary>
        /// pop����ǰ��Ч��ͼ��ԭͼ��
        /// </summary>
        public string OldImageUrl_Big
        {
            set { _OldImageUrl_Big = value; }
            get { return _OldImageUrl_Big; }
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
		/// 
		/// </summary>
		public string POPID
		{
			set{ _popid=value;}
			get{return _popid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? POPinfoID
		{
			set{ _popinfoid=value;}
			get{return _popinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? imageID
		{
			set{ _imageid=value;}
			get{return _imageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? prolineID
		{
			set{ _prolineid=value;}
			get{return _prolineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? sysTime
		{
			set{ _systime=value;}
			get{return _systime;}
		}
		#endregion Model

	}
}

