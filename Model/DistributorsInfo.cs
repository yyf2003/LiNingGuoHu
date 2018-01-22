using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类DistributorsInfo 。(属性说明自动提取数据库字段的描述信息)
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
        /// 部门经理审核状态 1 通过 0未审核 -1 未通过
        /// </summary>
        public int ExamState
        {
            set { _examstate = value; }
            get { return _examstate; }
        }
        /// <summary>
        /// 部门经理审核人ID
        /// </summary>
        public int ExamUserID
        {
            set { _examuserid = value; }
            get { return _examuserid; }
        }
        /// <summary>
        /// 部门经理审核时间
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
		/// 分销商ID
		/// </summary>
		public string FXID
		{
			set{ _fxid=value;}
			get{return _fxid;}
		}
		/// <summary>
		/// 分销名称
		/// </summary>
		public string FXName
		{
			set{ _fxname=value;}
			get{return _fxname;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string FXContactor
		{
			set{ _fxcontactor=value;}
			get{return _fxcontactor;}
		}
		/// <summary>
		/// 联系人电话
		/// </summary>
		public string FXPhone
		{
			set{ _fxphone=value;}
			get{return _fxphone;}
		}
		/// <summary>
		/// 分销商电话
		/// </summary>
		public string FXtel
		{
			set{ _fxtel=value;}
			get{return _fxtel;}
		}
		/// <summary>
		/// 相应的经销商ID
		/// </summary>
		public string DealerID
		{
			set{ _dealerid=value;}
			get{return _dealerid;}
		}
		/// <summary>
		/// 配送地址
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

