using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����DealerUser ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �û�ID
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// һ���ͻ�ID
		/// </summary>
		public string DealerID
		{
			set{ _dealerid=value;}
			get{return _dealerid;}
		}
		#endregion Model

	}
}

