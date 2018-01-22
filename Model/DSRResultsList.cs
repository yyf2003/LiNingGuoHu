using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����DSRResultsList ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class DSRResultsList
	{
		public DSRResultsList()
		{}
		#region Model
		private int _id;
		private string _dataid;
		private int? _checkrulesid;
		private int? _checkresults;
		private string _remarks;
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
		public string DataID
		{
			set{ _dataid=value;}
			get{return _dataid;}
		}
		/// <summary>
		/// ���Ĺ����ID
		/// </summary>
		public int? CheckRulesID
		{
			set{ _checkrulesid=value;}
			get{return _checkrulesid;}
		}
		/// <summary>
		/// �������� 1 Ϊ�� 2 Ϊ��
		/// </summary>
		public int? CheckResults
		{
			set{ _checkresults=value;}
			get{return _checkresults;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

