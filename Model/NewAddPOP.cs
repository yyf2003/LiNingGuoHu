using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����NewAddPOP ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class NewAddPOP
	{
		public NewAddPOP()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private string _popid;
		private int? _popinfoid;
		private int? _imageid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ����id
		/// </summary>
		public int? shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// �����POP��ID
		/// </summary>
		public string POPID
		{
			set{ _popid=value;}
			get{return _popid;}
		}
		/// <summary>
		/// ����pop�ı�ţ�ϵͳ����ģ�
		/// </summary>
		public int? POPinfoID
		{
			set{ _popinfoid=value;}
			get{return _popinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? imageID
		{
			set{ _imageid=value;}
			get{return _imageid;}
		}
		#endregion Model

	}
}

