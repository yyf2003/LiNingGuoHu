using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类DealerInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class DealerInfo
	{
		public DealerInfo()
		{}
		#region Model
		private int _id;
		private string _dealerid;
		private string _dealername;
		private int? _areaid;
		private int? _provinceid;
		private int? _cityid;
		private string _contactor;
		private string _contactorphone;
		private string _address;
		private string _postaddress;
		private string _dealerchannel;
        private int? _examState;
        private int? _examuserid;
        private int? _vmexamState;
        private int? _vmexamUserID;

        /// <summary>
        /// 省区VM审核状态 1 通过  0 未审核 -1 未通过
        /// </summary>
        public int? VMExamState
        {
            set { _vmexamState = value; }
            get { return _vmexamState; }
        }
        /// <summary>
        /// 省区VM审核人员
        /// </summary>
        public int? VMExamUserID
        {
            set { _vmexamUserID = value; }
            get { return _vmexamUserID; }
        }

        /// <summary>
        /// 部门VM审核状态 1 通过  0 未审核 -1 未通过
        /// </summary>

        public int? ExamState
        {
            set { _examState = value; }
            get { return _examState; }
        }
        /// <summary>
        /// 部门VM审核人员
        /// </summary>

        public int? ExamUserID
        {
            set { _examuserid = value; }
            get { return _examState; }
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
		/// 一级客户ID
		/// </summary>
        public string DealerID
		{
			set{ _dealerid=value;}
			get{return _dealerid;}
		}
		/// <summary>
		/// 一级客户名称
		/// </summary>
		public string DealerName
		{
			set{ _dealername=value;}
			get{return _dealername;}
		}
		/// <summary>
		/// 所在区域ID
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 所在省份ID
		/// </summary>
		public int? ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 所在城市ID
		/// </summary>
		public int? CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string Contactor
		{
			set{ _contactor=value;}
			get{return _contactor;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string ContactorPhone
		{
			set{ _contactorphone=value;}
			get{return _contactorphone;}
		}
		/// <summary>
		/// 公司地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 送货地址
		/// </summary>
		public string PostAddress
		{
			set{ _postaddress=value;}
			get{return _postaddress;}
		}
		/// <summary>
		/// 渠道
		/// </summary>
		public string DealerChannel
		{
			set{ _dealerchannel=value;}
			get{return _dealerchannel;}
		}
		#endregion Model

	}
}

