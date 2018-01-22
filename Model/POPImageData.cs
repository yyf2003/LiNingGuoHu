using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����POPImageData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class POPImageData
	{
		public POPImageData()
		{}
		#region Model
		private int _imageid;
        private string _popid;
		private int? _shoplevelid;
		private string _productline;
		private string _imageurl;
		private string _imagelevel;
		private string _popscaledata;
		private string _imagedesc;
		private string _uploaddate;
        private string _smallimageUrl;
        private string _productlinename;
        private string _productTypename;
        private int?  _productlevel;

        public string AreaIDs { get; set; }
        public string ACL_IDs { get; set; }

        public string ProductLineName
        {
            set { _productlinename = value; }
            get { return _productlinename; }
        }

        public string ProductTypeName
        {
            set { _productTypename = value; }
            get { return _productTypename; }
        }
		/// <summary>
		/// ��������,����
		/// </summary>
		public int ImageID
		{
			set{ _imageid=value;}
			get{return _imageid;}
		}
        /// <summary>
        /// �����POPID
        /// </summary>
        public string POPID
        {
            set { _popid = value; }
            get { return _popid; }
        }
		/// <summary>
		/// ���̼���
		/// </summary>
		public int? ShopLevelID
		{
			set{ _shoplevelid=value;}
			get{return _shoplevelid;}
		}
		/// <summary>
		/// ��Ʒϵ��
		/// </summary>
        public string ProductLine
		{
			set{ _productline=value;}
			get{return _productline;}
		}
		/// <summary>
		/// �ϴ�ͼƬ��·��
		/// </summary>
		public string ImageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
        /// <summary>
        /// ͼƬ���ȼ�
        /// </summary>
        public int? productlevel
        {
            set { _productlevel = value; }
            get { return _productlevel; }
        }
		/// <summary>
		/// ͼƬ���ȼ�
		/// </summary>
        public string ImageLevel
		{
			set{ _imagelevel=value;}
			get{return _imagelevel;}
		}
		/// <summary>
		/// ͼƬ����
		/// </summary>
		public string POPScaleData
		{
			set{ _popscaledata=value;}
			get{return _popscaledata;}
		}
		/// <summary>
		/// ͼƬ����
		/// </summary>
		public string ImageDesc
		{
			set{ _imagedesc=value;}
			get{return _imagedesc;}
		}
		/// <summary>
		/// �ϴ�ʱ��
		/// </summary>
		public string UploadDate
		{
			set{ _uploaddate=value;}
			get{return _uploaddate;}
		}
        /// <summary>
        /// ѹ�����ͼƬλ��
        /// </summary>
        public string SmallImageUrl
        {
            set { _smallimageUrl = value; }
            get { return _smallimageUrl; }
        }
		#endregion Model

	}
}

