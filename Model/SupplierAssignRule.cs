using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����SupplierAssignRule ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��ע
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

