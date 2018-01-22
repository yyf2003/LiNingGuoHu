using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ShippingPOPData 。(属性说明自动提取数据库字段的描述信息)
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
		/// POP信息表示ID
		/// </summary>
		public int? POPinfoID
		{
			set{ _popinfoid=value;}
			get{return _popinfoid;}
		}
		/// <summary>
		/// 发货id  和 ShippingSpeedData 为外键关系
		/// </summary>
        public string FHID
		{
			set{ _fhid=value;}
			get{return _fhid;}
		}
		#endregion Model

	}
}

