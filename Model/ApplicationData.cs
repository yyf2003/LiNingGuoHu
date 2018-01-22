using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ApplicationData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ApplicationData
	{
		public ApplicationData()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private string _poscode;
		private string _popseatnum;
		private string _seatdesc;
		private decimal? _popheight;
		private decimal? _popwith;
		private decimal? _poparea;
		private string _popmaterial;
		private int? _productlineid;
		private string _sexarea;
		private int? _twosided;
		private int? _glass;
		private decimal? _platformwith;
		private decimal? _platformheight;
		private decimal? _platformlong;
		private int? _applyuserid;
		private string _applytype;
		private string _applydesc;
		private string _applydate;
		private string _photopath;
		private int? _areavmexamstate;
		private string _areavmexamdesc;
		private int? _areavmexamuseid;
		/// <summary>
		/// 自增长ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// Shop标示
		/// </summary>
		public int? ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 可查店铺号
		/// </summary>
		public string POSCode
		{
			set{ _poscode=value;}
			get{return _poscode;}
		}
		/// <summary>
		/// Pop位置编号
		/// </summary>
		public string POPSeatNum
		{
			set{ _popseatnum=value;}
			get{return _popseatnum;}
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
		/// POP高
		/// </summary>
		public decimal? POPHeight
		{
			set{ _popheight=value;}
			get{return _popheight;}
		}
		/// <summary>
		/// POP宽
		/// </summary>
		public decimal? POPWith
		{
			set{ _popwith=value;}
			get{return _popwith;}
		}
		/// <summary>
		/// POP面积
		/// </summary>
		public decimal? POPArea
		{
			set{ _poparea=value;}
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
		public int? ProductLineID
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
		public int? TwoSided
		{
			set{ _twosided=value;}
			get{return _twosided;}
		}
		/// <summary>
		/// 玻璃 1 是 0 否
		/// </summary>
		public int? Glass
		{
			set{ _glass=value;}
			get{return _glass;}
		}
		/// <summary>
		/// 地台宽度
		/// </summary>
		public decimal? PlatformWith
		{
			set{ _platformwith=value;}
			get{return _platformwith;}
		}
		/// <summary>
		/// 地台高度
		/// </summary>
		public decimal? PlatformHeight
		{
			set{ _platformheight=value;}
			get{return _platformheight;}
		}
		/// <summary>
		/// 地台长度
		/// </summary>
		public decimal? PlatformLong
		{
			set{ _platformlong=value;}
			get{return _platformlong;}
		}
		/// <summary>
		/// 申请人ID
		/// </summary>
		public int? ApplyUserID
		{
			set{ _applyuserid=value;}
			get{return _applyuserid;}
		}
		/// <summary>
		/// 申请类型：增加，减少，修改
		/// </summary>
		public string ApplyType
		{
			set{ _applytype=value;}
			get{return _applytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyDesc
		{
			set{ _applydesc=value;}
			get{return _applydesc;}
		}
		/// <summary>
		/// 申请时间
		/// </summary>
		public string ApplyDate
		{
			set{ _applydate=value;}
			get{return _applydate;}
		}
		/// <summary>
		/// 店铺图片路径
		/// </summary>
		public string PhotoPath
		{
			set{ _photopath=value;}
			get{return _photopath;}
		}
		/// <summary>
		/// 区域VM审批状态
		/// </summary>
		public int? AreaVMExamState
		{
			set{ _areavmexamstate=value;}
			get{return _areavmexamstate;}
		}
		/// <summary>
		/// 区域VM审批备注
		/// </summary>
		public string AreaVMExamDesc
		{
			set{ _areavmexamdesc=value;}
			get{return _areavmexamdesc;}
		}
		/// <summary>
		/// 区域VM审批人ID
		/// </summary>
		public int? AreaVMExamUseID
		{
			set{ _areavmexamuseid=value;}
			get{return _areavmexamuseid;}
		}
		#endregion Model

	}
}

