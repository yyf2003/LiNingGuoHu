using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ShopLevel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class ShopLevel
	{
		public ShopLevel()
		{}
		#region Model
		private int _levelid;
		private string _shoplevel;
		/// <summary>
		/// ��������
		/// </summary>
		public int LevelID
		{
			set{ _levelid=value;}
			get{return _levelid;}
		}
		/// <summary>
		/// ���̼���
		/// </summary>
		public string ShopLevelName
		{
			set{ _shoplevel=value;}
			get{return _shoplevel;}
		}
		#endregion Model

	}
}

