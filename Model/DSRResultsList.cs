using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类DSRResultsList 。(属性说明自动提取数据库字段的描述信息)
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
		/// 检查的规则的ID
		/// </summary>
		public int? CheckRulesID
		{
			set{ _checkrulesid=value;}
			get{return _checkrulesid;}
		}
		/// <summary>
		/// 规则检查结果 1 为是 2 为否
		/// </summary>
		public int? CheckResults
		{
			set{ _checkresults=value;}
			get{return _checkresults;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

