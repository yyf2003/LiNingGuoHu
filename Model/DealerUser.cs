using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类DealerUser 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class DealerUser
	{
		public DealerUser()
		{}
		#region Model
		private int _id;
		private int _userid;
		private string _dealerid;
		/// <summary>
		/// 主键
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 一级客户ID
		/// </summary>
		public string DealerID
		{
			set{ _dealerid=value;}
			get{return _dealerid;}
		}
		#endregion Model

	}
}

