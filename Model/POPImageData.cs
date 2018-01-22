using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类POPImageData 。(属性说明自动提取数据库字段的描述信息)
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
		/// 自增长列,主键
		/// </summary>
		public int ImageID
		{
			set{ _imageid=value;}
			get{return _imageid;}
		}
        /// <summary>
        /// 发起的POPID
        /// </summary>
        public string POPID
        {
            set { _popid = value; }
            get { return _popid; }
        }
		/// <summary>
		/// 店铺级别
		/// </summary>
		public int? ShopLevelID
		{
			set{ _shoplevelid=value;}
			get{return _shoplevelid;}
		}
		/// <summary>
		/// 产品系列
		/// </summary>
        public string ProductLine
		{
			set{ _productline=value;}
			get{return _productline;}
		}
		/// <summary>
		/// 上传图片的路径
		/// </summary>
		public string ImageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
        /// <summary>
        /// 图片优先级
        /// </summary>
        public int? productlevel
        {
            set { _productlevel = value; }
            get { return _productlevel; }
        }
		/// <summary>
		/// 图片优先级
		/// </summary>
        public string ImageLevel
		{
			set{ _imagelevel=value;}
			get{return _imagelevel;}
		}
		/// <summary>
		/// 图片比例
		/// </summary>
		public string POPScaleData
		{
			set{ _popscaledata=value;}
			get{return _popscaledata;}
		}
		/// <summary>
		/// 图片描述
		/// </summary>
		public string ImageDesc
		{
			set{ _imagedesc=value;}
			get{return _imagedesc;}
		}
		/// <summary>
		/// 上传时间
		/// </summary>
		public string UploadDate
		{
			set{ _uploaddate=value;}
			get{return _uploaddate;}
		}
        /// <summary>
        /// 压缩后的图片位置
        /// </summary>
        public string SmallImageUrl
        {
            set { _smallimageUrl = value; }
            get { return _smallimageUrl; }
        }
		#endregion Model

	}
}

