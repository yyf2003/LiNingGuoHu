using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ShopType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ShopType
	{
		public ShopType()
		{}
		#region Model
		private int _id;
		private string _shoptypename;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ������������
		/// </summary>
		public string ShopTypename
		{
			set{ _shoptypename=value;}
			get{return _shoptypename;}
		}
		#endregion Model

	}
}

