using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类CustomerInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CustomerInfo
	{
		public CustomerInfo()
		{}
		#region Model
		private int _id;
		private string _customerid;
		private string _customername;
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
		public string CustomerID
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		#endregion Model

	}
}

