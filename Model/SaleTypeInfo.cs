using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类SaleTypeInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SaleTypeInfo
	{
		public SaleTypeInfo()
		{}
		#region Model
		private int _saletypeid;
		private string _saletype;
		/// <summary>
		/// 
		/// </summary>
		public int SaleTypeID
		{
			set{ _saletypeid=value;}
			get{return _saletypeid;}
		}
		/// <summary>
		/// 销售形式 分销还是直销
		/// </summary>
		public string SaleType
		{
			set{ _saletype=value;}
			get{return _saletype;}
		}
		#endregion Model

	}
}

