using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ShopStateInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ShopStateInfo
	{
		public ShopStateInfo()
		{}
		#region Model
		private int _id;
		private string _shopstate;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShopState
		{
			set{ _shopstate=value;}
			get{return _shopstate;}
		}
		#endregion Model

	}
}

