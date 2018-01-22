using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类AssignUser 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class AssignUser
	{
		public AssignUser()
		{}
		#region Model
		private int _id;
		private int? _upmanagerid;
		private int? _managedid;
		private int? _managedrole;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 上层管理者ID
		/// </summary>
		public int? UpmanagerID
		{
			set{ _upmanagerid=value;}
			get{return _upmanagerid;}
		}
		/// <summary>
		/// 被管理者ID
		/// </summary>
		public int? ManagedID
		{
			set{ _managedid=value;}
			get{return _managedid;}
		}
		/// <summary>
		/// 被管理者角色ID
		/// </summary>
		public int? ManagedRole
		{
			set{ _managedrole=value;}
			get{return _managedrole;}
		}
		#endregion Model

	}
}

