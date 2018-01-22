using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ShopStateInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ShopStateInfo
	{
		public ShopStateInfo()
		{}
		#region Model
		private int _id;
		private string _shopstate;
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
		public string ShopState
		{
			set{ _shopstate=value;}
			get{return _shopstate;}
		}
		#endregion Model

	}
}

