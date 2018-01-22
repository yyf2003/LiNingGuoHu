using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类TownCityLevel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class TownCityLevel
	{
		public TownCityLevel()
		{}
		#region Model
		private int _tcl_id;
		private string _tcl_name;
		/// <summary>
		/// 地市级城市级别—市场定义编号
		/// </summary>
		public int TCL_Id
		{
			set{ _tcl_id=value;}
			get{return _tcl_id;}
		}
		/// <summary>
		/// 地市级城市级别—市场定义名称
		/// </summary>
		public string TCL_Name
		{
			set{ _tcl_name=value;}
			get{return _tcl_name;}
		}
		#endregion Model

	}
}

