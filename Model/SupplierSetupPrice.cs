using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����SupplierSetupPrice ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��Ӧ�̰�װ���� ��ÿƽ��������
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
		/// �۸�ά����
		/// </summary>
		public int? SubmitUserID
		{
			set{ _submituserid=value;}
			get{return _submituserid;}
		}
		#endregion Model

	}
}

