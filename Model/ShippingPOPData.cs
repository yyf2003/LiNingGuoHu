using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ShippingPOPData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ShippingPOPData
	{
		public ShippingPOPData()
		{}
		#region Model
		private int _id;
		private int? _popinfoid;
		private string _fhid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// POP��Ϣ��ʾID
		/// </summary>
		public int? POPinfoID
		{
			set{ _popinfoid=value;}
			get{return _popinfoid;}
		}
		/// <summary>
		/// ����id  �� ShippingSpeedData Ϊ�����ϵ
		/// </summary>
        public string FHID
		{
			set{ _fhid=value;}
			get{return _fhid;}
		}
		#endregion Model

	}
}

