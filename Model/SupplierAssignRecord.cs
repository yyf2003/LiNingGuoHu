using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����AssignRecord ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��Ӧ��ID
		/// </summary>
		public int? SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// ����ԭ��ID
		/// </summary>
		public int? AssignRuleID
		{
			set{ _assignruleid=value;}
			get{return _assignruleid;}
		}
		/// <summary>
		/// �����ʡID
		/// </summary>
		public int? AssignProID
		{
			set{ _assignproid=value;}
			get{return _assignproid;}
		}
		/// <summary>
		/// �������ID
		/// </summary>
		public int? AssignCityID
		{
			set{ _assigncityid=value;}
			get{return _assigncityid;}
		}
		/// <summary>
		/// ����ĵ���ID
		/// </summary>
		public int? AssignShopID
		{
			set{ _assignshopid=value;}
			get{return _assignshopid;}
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

