using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����SaleTypeInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class SaleTypeInfo
	{
		public SaleTypeInfo()
		{}
		#region Model
		private int _saletypeid;
		private string _saletype;
		/// <summary>
		/// 
		/// </summary>
		public int SaleTypeID
		{
			set{ _saletypeid=value;}
			get{return _saletypeid;}
		}
		/// <summary>
		/// ������ʽ ��������ֱ��
		/// </summary>
		public string SaleType
		{
			set{ _saletype=value;}
			get{return _saletype;}
		}
		#endregion Model

	}
}

