using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ShopVI ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ShopVI
	{
		public ShopVI()
		{}
		#region Model
		private int _shopviid;
		private string _shopviname;
		/// <summary>
		/// 
		/// </summary>
		public int ShopVIID
		{
			set{ _shopviid=value;}
			get{return _shopviid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShopVIName
		{
			set{ _shopviname=value;}
			get{return _shopviname;}
		}
		#endregion Model

	}
}

