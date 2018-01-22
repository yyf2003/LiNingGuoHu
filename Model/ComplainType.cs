using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ComplainType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ComplainType
	{
		public ComplainType()
		{}
		#region Model
		private int _tid;
		private string _tname;
		/// <summary>
		/// 问题类别编号
		/// </summary>
		public int tID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 问题类别名称
		/// </summary>
		public string tName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		#endregion Model

	}
}

