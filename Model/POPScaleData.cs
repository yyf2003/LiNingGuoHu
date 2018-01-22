using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类POPScaleData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class POPScaleData
	{
		public POPScaleData()
		{}
		#region Model
		private int _photoscaleid;
		private string _photoscale;
		/// <summary>
		/// 主键，自动增长
		/// </summary>
		public int PhotoScaleID
		{
			set{ _photoscaleid=value;}
			get{return _photoscaleid;}
		}
		/// <summary>
		/// 比例名称
		/// </summary>
		public string PhotoScale
		{
			set{ _photoscale=value;}
			get{return _photoscale;}
		}
		#endregion Model

	}
}

