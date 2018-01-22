using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类POPStage 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class POPStage
	{
		public POPStage()
		{}
		#region Model
		private int _stageid;
		private int? _supplierid;
		private int? _popid;
		private string _popmaterial;
		private decimal? _popprice;
		private int? _examuserid;
		private string _examdate;
		/// <summary>
		/// 主键，自动增长
		/// </summary>
		public int StageID
		{
			set{ _stageid=value;}
			get{return _stageid;}
		}
		/// <summary>
		/// 设置价格的供应商ID
		/// </summary>
		public int? SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// POPID
		/// </summary>
		public int? POPID
		{
			set{ _popid=value;}
			get{return _popid;}
		}
		/// <summary>
		/// 材质
		/// </summary>
		public string POPMaterial
		{
			set{ _popmaterial=value;}
			get{return _popmaterial;}
		}
		/// <summary>
		/// 报价
		/// </summary>
		public decimal? POPprice
		{
			set{ _popprice=value;}
			get{return _popprice;}
		}
		/// <summary>
		/// 审批人ID
		/// </summary>
		public int? ExamUserID
		{
			set{ _examuserid=value;}
			get{return _examuserid;}
		}
		/// <summary>
		/// 审批时间
		/// </summary>
		public string ExamDate
		{
			set{ _examdate=value;}
			get{return _examdate;}
		}
		#endregion Model

	}
}

