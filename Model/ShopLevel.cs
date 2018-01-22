using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ShopLevel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ShopLevel
	{
		public ShopLevel()
		{}
		#region Model
		private int _levelid;
		private string _shoplevel;
		/// <summary>
		/// 店铺主键
		/// </summary>
		public int LevelID
		{
			set{ _levelid=value;}
			get{return _levelid;}
		}
		/// <summary>
		/// 店铺级别
		/// </summary>
		public string ShopLevelName
		{
			set{ _shoplevel=value;}
			get{return _shoplevel;}
		}
		#endregion Model

	}
}

