using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����DSRCheckRules ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class DSRCheckRules
	{
		public DSRCheckRules()
		{}
		#region Model
		private int _rulesid;
		private string _dsrchecktype;
		private string _dsrrules;
		private int? _rulesstate;
		/// <summary>
		/// 
		/// </summary>
		public int RulesID
		{
			set{ _rulesid=value;}
			get{return _rulesid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DSRCheckType
		{
			set{ _dsrchecktype=value;}
			get{return _dsrchecktype;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string DSRRules
		{
			set{ _dsrrules=value;}
			get{return _dsrrules;}
		}
		/// <summary>
		/// �������״̬ 1Ϊ���� 0Ϊ������
		/// </summary>
		public int? RulesState
		{
			set{ _rulesstate=value;}
			get{return _rulesstate;}
		}
		#endregion Model

	}
}

