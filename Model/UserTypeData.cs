using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����UserTypeData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��������,����
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �Զ��� ����ID
		/// </summary>
		public int UserTypeID
		{
			set{ _usertypeid=value;}
			get{return _usertypeid;}
		}
		/// <summary>
		/// ��Ա����
		/// </summary>
		public string Usertype
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		#endregion Model

	}
}

