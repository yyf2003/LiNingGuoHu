using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类AfficheType 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class AfficheType
	{
		public AfficheType()
		{}
		#region Model
		private int _id;
		private string _type;
		private int? _isdel;
		/// <summary>
		/// 公告类别编号
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 公告类别名称
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 是否删除 0：没有 1：删除
		/// </summary>
		public int? IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		#endregion Model

	}
}

