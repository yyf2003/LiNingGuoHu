using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����AssignUser ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �ϲ������ID
		/// </summary>
		public int? UpmanagerID
		{
			set{ _upmanagerid=value;}
			get{return _upmanagerid;}
		}
		/// <summary>
		/// ��������ID
		/// </summary>
		public int? ManagedID
		{
			set{ _managedid=value;}
			get{return _managedid;}
		}
		/// <summary>
		/// �������߽�ɫID
		/// </summary>
		public int? ManagedRole
		{
			set{ _managedrole=value;}
			get{return _managedrole;}
		}
		#endregion Model

	}
}

