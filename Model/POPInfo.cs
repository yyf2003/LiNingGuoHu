using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类POPInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class POPInfo
	{
		public POPInfo()
		{}
		#region Model
        private int _id;
		private int _shopid;
		private string _seatnum;
        private string _popseat;
		private string _seatdesc;
		private decimal _popheight;
		private decimal _popwith;
		private decimal _poparea;
		private string _popmaterial;
		private int _productlineid;
		private string _sexarea;
		private int _twosided;
		private int _glass;
		private decimal _platformwith;
		private decimal _platformheight;
		private decimal _platformlong;
		private int _examstate;
        private string _systime;
        private string _productline;
        private int _examuserid;
        private string _examdesc;
        private string _addstate;
        private string _POPPlwz;
        private int _POPPljd;
        private decimal _RealHeight;
        private decimal _RealWith;
        private int _VMexamstate;
        private int _VmexamUserId;
        private string _VMExamdate;
        private int _issubmit;
        private string _popmaterialremark;
        private int _ishide;

        /// <summary>
        /// 省区VM审核状态 1 通过 0 未审核 -1 未通过
        /// </summary>
        public int VMExamState
        {
            set { _VMexamstate = value; }
            get { return _VMexamstate; }
        }
        /// <summary>
        ///省区VM经理审核人员
        /// </summary>
        public int VMExamUserId
        {
            set { _VmexamUserId = value; }
            get { return _VmexamUserId; }
        }
        /// <summary>
        /// 省区VM经理审核时间
        /// </summary>
        public string VMExamDate
        {
            set { _VMExamdate = value; }
            get { return _VMExamdate; }
        }
        /// <summary>
        /// POP实际制作高
        /// </summary>
        public decimal RealHeight
        {
            set { _RealHeight = value;}
            get { return _RealHeight; }
        }
        /// <summary>
        /// POP实际制作宽
        /// </summary>
        public decimal RealWith
        {
            set { _RealWith = value; }
            get { return _RealWith; }
        }
        /// <summary>
        /// POP偏离位置
        /// </summary>
        public string POPPlwz
        {
            set { _POPPlwz = value; }
            get { return _POPPlwz; }
        }
        /// <summary>
        /// POP偏离的极端 1-15 度
        /// </summary>
        public int POPPljd
        {
            set { _POPPljd = value; }
            get { return _POPPljd; }
        }
		/// <summary>
		/// 自增长列,主键ID
		/// </summary>
        public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 店铺ID
		/// </summary>
		public int ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 位置编号
		/// </summary>
		public string SeatNum
		{
			set{ _seatnum=value;}
			get{return _seatnum;}
		}
        /// <summary>
        /// pop 位置 例如 橱窗 等等
        /// </summary>
        public string POPSeat
        {
            set { _popseat = value; }
            get { return _popseat; }
        }
		/// <summary>
		/// 位置描述
		/// </summary>
		public string SeatDesc
		{
			set{ _seatdesc=value;}
			get{return _seatdesc;}
		}
		/// <summary>
        /// POP可视画面高
		/// </summary>
		public decimal POPHeight
		{
			set{ _popheight=value;}
			get{return _popheight;}
		}
		/// <summary>
		/// POP可视画面宽
		/// </summary>
		public decimal POPWith
		{
			set{ _popwith=value;}
			get{return _popwith;}
		}
		/// <summary>
		/// POP面积
		/// </summary>
		public decimal POPArea
		{
            set { _poparea = value; }
			get{return _poparea;}
		}
		/// <summary>
		/// 材质ID
		/// </summary>
		public string POPMaterial
		{
			set{ _popmaterial=value;}
			get{return _popmaterial;}
		}
		/// <summary>
		/// 产品系列ID
		/// </summary>
		public int ProductLineID
		{
			set{ _productlineid=value;}
			get{return _productlineid;}
		}
		/// <summary>
		/// 男/女区域 1 男2 女 3 男女不限
		/// </summary>
		public string Sexarea
		{
			set{ _sexarea=value;}
			get{return _sexarea;}
		}
		/// <summary>
		/// 双面 1 是 2 否
		/// </summary>
		public int TwoSided
		{
			set{ _twosided=value;}
			get{return _twosided;}
		}
		/// <summary>
		/// 玻璃 1 是 0 否
		/// </summary>
		public int Glass
		{
			set{ _glass=value;}
			get{return _glass;}
		}
		/// <summary>
		/// 地台宽度
		/// </summary>
		public decimal PlatformWith
		{
			set{ _platformwith=value;}
			get{return _platformwith;}
		}
		/// <summary>
		/// 地台高度
		/// </summary>
		public decimal PlatformHeight
		{
			set{ _platformheight=value;}
			get{return _platformheight;}
		}
		/// <summary>
		/// 地台长度
		/// </summary>
		public decimal PlatformLong
		{
			set{ _platformlong=value;}
			get{return _platformlong;}
		}
		/// <summary>
		/// 部门经理审批状态1通过， 0 未审批 -1 未通过
		/// </summary>
		public int ExamState
		{
			set{ _examstate=value;}
			get{return _examstate;}
		}
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public string SysTime
        {
            set { _systime = value; }
            get { return _systime; }
        }
        /// <summary>
        /// 产品故事包
        /// </summary>
        public string ProductLine
        {
            set { _productline = value; }
            get { return _productline; }
        }
        /// <summary>
        /// 部门经理审核人员
        /// </summary>
        public int ExamUserID
        {
            set { _examuserid = value; }
            get { return _examuserid; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string ExamDesc
        {
            set { _examdesc = value; }
            get { return _examdesc; }
        }
		
        /// <summary>
        /// 表示是否为店主或者省区vm新增
        /// </summary>
        public string AddState
        {
            set { _addstate = value; }
            get { return _addstate; }
        }

        /// <summary>
        /// 是否提交订单
        /// </summary>
        public int IsSubmit
        {
            set { _issubmit = value; }
            get { return _issubmit; }
        }

        /// <summary>
        /// POP材质描述
        /// </summary>
        public string POPMaterialRemark
        {
            set { _popmaterialremark = value; }
            get { return _popmaterialremark; }
        }

        /// <summary>
        /// 是否提交订单
        /// </summary>
        public int IsHide
        {
            set { _ishide = value; }
            get { return _ishide; }
        }

        #endregion Model
    }
}

