using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类SupplierSetupPrice 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SupplierSetupPrice
	{
		public SupplierSetupPrice()
		{}
		#region Model
		private int _id;
		private int? _supplierid;
		private decimal? _setupmoney;
		private DateTime? _systime;
		private int? _submituserid;
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
		public int? supplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// 供应商安装费用 按每平米来计算
		/// </summary>
		public decimal? setupMoney
		{
			set{ _setupmoney=value;}
			get{return _setupmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SysTime
		{
			set{ _systime=value;}
			get{return _systime;}
		}
		/// <summary>
		/// 价格维护人
		/// </summary>
		public int? SubmitUserID
		{
			set{ _submituserid=value;}
			get{return _submituserid;}
		}
		#endregion Model

	}
}

