using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类POPLaunch 。(属性说明自动提取数据库字段的描述信息)
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
        /// 是否重新报价
        /// </summary>
        public int BoolPrice
        {
            set { _boolPrice = value; }
            get { return _boolPrice; }
        }
		/// <summary>
		/// 自动增长列,主键
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// POP发起ID
		/// </summary>
        public string POPID
		{
			set{ _popid=value;}
			get{return _popid;}
		}
		/// <summary>
		/// 发起时间
		/// </summary>
		public DateTime BeginDate
		{
			set{ _begindate=value;}
			get{return _begindate;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// POP主题
		/// </summary>
		public string POPTitle
		{
			set{ _poptitle=value;}
			get{return _poptitle;}
		}
		/// <summary>
		/// 发起人ID
		/// </summary>
		public int OrganigerID
		{
			set{ _organigerid=value;}
			get{return _organigerid;}
		}

        /// <summary>
        /// 发起人用户名
        /// </summary>
        public string OrganigerName
        {
            set { _organigername = value; }
            get { return _organigername; }
        }
		/// <summary>
		/// 所涉及的产品系列ID 用逗号分开
		/// </summary>
		public string ProductLineDatas
		{
			set{ _productlinedatas=value;}
			get{return _productlinedatas;}
		}
		/// <summary>
		/// 录入时间
		/// </summary>
		public DateTime InputDate
		{
			set{ _inputdate=value;}
			get{return _inputdate;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string LaunchDesc
		{
			set{ _launchdesc=value;}
			get{return _launchdesc;}
		}
        /// <summary>
        /// 文件说明 上传的文件路径
        /// </summary>
        public string UploadFileUrl
        {
            set { _UploadfileUrl = value; }
            get { return _UploadfileUrl; }
        }
        /// <summary>
        /// POP发起完成的步骤 0为全部完成  1，2，3，4 表示完成第几步了
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

