using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类TownData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class TownData
	{
		public TownData()
		{}
		#region Model
		private int _id;
		private int? _townid;
		private string _townname;
		private int? _cityid;
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
		public int? TownID
		{
			set{ _townid=value;}
			get{return _townid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TownName
		{
			set{ _townname=value;}
			get{return _townname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		#endregion Model

	}
}

