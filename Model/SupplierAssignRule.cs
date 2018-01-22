using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类SupplierAssignRule 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SupplierAssignRule
	{
		public SupplierAssignRule()
		{}
		#region Model
		private int _assignruleid;
		private string _assignrule;
		private string _remarks;
		/// <summary>
		/// 
		/// </summary>
		public int AssignRuleID
		{
			set{ _assignruleid=value;}
			get{return _assignruleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AssignRule
		{
			set{ _assignrule=value;}
			get{return _assignrule;}
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

