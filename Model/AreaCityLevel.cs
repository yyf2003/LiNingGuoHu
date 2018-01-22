using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类AreaCityLevel 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class AreaCityLevel
	{
		public AreaCityLevel()
		{}
		#region Model
		private int _acl_id;
		private string _acl_name;
		/// <summary>
		/// 区县级城市级别—市场定义编号
		/// </summary>
		public int ACL_Id
		{
			set{ _acl_id=value;}
			get{return _acl_id;}
		}
		/// <summary>
		/// 区县级城市级别—市场定义名称
		/// </summary>
		public string ACL_Name
		{
			set{ _acl_name=value;}
			get{return _acl_name;}
		}
		#endregion Model

	}
}

