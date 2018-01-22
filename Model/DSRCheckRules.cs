using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类DSRCheckRules 。(属性说明自动提取数据库字段的描述信息)
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
		/// 规则
		/// </summary>
		public string DSRRules
		{
			set{ _dsrrules=value;}
			get{return _dsrrules;}
		}
		/// <summary>
		/// 规则可用状态 1为可用 0为不可用
		/// </summary>
		public int? RulesState
		{
			set{ _rulesstate=value;}
			get{return _rulesstate;}
		}
		#endregion Model

	}
}

