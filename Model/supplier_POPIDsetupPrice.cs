using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����supplier_POPIDsetupPrice ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class supplier_POPIDsetupPrice
	{
		public supplier_POPIDsetupPrice()
		{}
		#region Model
		private int _id;
		private string _popid;
		private int? _supplierid;
		private decimal? _setupmoney;
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
		public string POPID
		{
			set{ _popid=value;}
			get{return _popid;}
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
		/// 
		/// </summary>
		public decimal? setupMoney
		{
			set{ _setupmoney=value;}
			get{return _setupmoney;}
		}
		#endregion Model

	}
}

