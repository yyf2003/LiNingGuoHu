using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ShopType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ShopType
	{
		public ShopType()
		{}
		#region Model
		private int _id;
		private string _shoptypename;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 店铺类型名称
		/// </summary>
		public string ShopTypename
		{
			set{ _shoptypename=value;}
			get{return _shoptypename;}
		}
		#endregion Model

	}
}

