using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ShopVI 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ShopVI
	{
		public ShopVI()
		{}
		#region Model
		private int _shopviid;
		private string _shopviname;
		/// <summary>
		/// 
		/// </summary>
		public int ShopVIID
		{
			set{ _shopviid=value;}
			get{return _shopviid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShopVIName
		{
			set{ _shopviname=value;}
			get{return _shopviname;}
		}
		#endregion Model

	}
}

