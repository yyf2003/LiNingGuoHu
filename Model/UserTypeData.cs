using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类UserTypeData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class UserTypeData
	{
		public UserTypeData()
		{}
		#region Model
		private int _id;
		private int _usertypeid;
		private string _usertype;
		/// <summary>
		/// 自增长列,主键
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 自定义 类型ID
		/// </summary>
		public int UserTypeID
		{
			set{ _usertypeid=value;}
			get{return _usertypeid;}
		}
		/// <summary>
		/// 人员类型
		/// </summary>
		public string Usertype
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		#endregion Model

	}
}

