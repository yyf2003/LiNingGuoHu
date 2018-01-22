using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类CityData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class CityData
	{
		public CityData()
		{}
		#region Model
		private int _cityid;
		private int? _areaid;
		private int? _provinceid;
		private string _cityname;
		private string _citylevel;
		/// <summary>
		/// 主键 自动增长
		/// </summary>
		public int CItyID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 所在区域ID
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 所在省份ID
		/// </summary>
		public int? ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 城市名称
		/// </summary>
		public string CityName
		{
			set{ _cityname=value;}
			get{return _cityname;}
		}
		/// <summary>
		/// 城市级别
		/// </summary>
		public string CityLevel
		{
			set{ _citylevel=value;}
			get{return _citylevel;}
		}
		#endregion Model

	}
}

