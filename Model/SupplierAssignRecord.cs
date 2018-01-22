using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类AssignRecord 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SupplierAssignRecord
	{
		public SupplierAssignRecord()
		{}
		#region Model
		private int _id;
		private int? _supplierid;
		private int? _assignruleid;
		private int? _assignproid;
		private int? _assigncityid;
		private int? _assignshopid;
		private string _remarks;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 供应商ID
		/// </summary>
		public int? SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// 分配原则ID
		/// </summary>
		public int? AssignRuleID
		{
			set{ _assignruleid=value;}
			get{return _assignruleid;}
		}
		/// <summary>
		/// 分配的省ID
		/// </summary>
		public int? AssignProID
		{
			set{ _assignproid=value;}
			get{return _assignproid;}
		}
		/// <summary>
		/// 分配的市ID
		/// </summary>
		public int? AssignCityID
		{
			set{ _assigncityid=value;}
			get{return _assigncityid;}
		}
		/// <summary>
		/// 分配的店铺ID
		/// </summary>
		public int? AssignShopID
		{
			set{ _assignshopid=value;}
			get{return _assignshopid;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

