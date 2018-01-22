using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ErrLog 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ErrLog
	{
		public ErrLog()
		{}
		#region Model
		private int _id;
		private string _errid;
		private string _errdec;
		private DateTime? _errtime;
		private string _errpage;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 错误ID
		/// </summary>
		public string ErrID
		{
			set{ _errid=value;}
			get{return _errid;}
		}
		/// <summary>
		/// 错误描述
		/// </summary>
		public string ErrDec
		{
			set{ _errdec=value;}
			get{return _errdec;}
		}
		/// <summary>
		/// 错误时间
		/// </summary>
		public DateTime? ErrTime
		{
			set{ _errtime=value;}
			get{return _errtime;}
		}
		/// <summary>
		/// 错误页面
		/// </summary>
		public string ErrPage
		{
			set{ _errpage=value;}
			get{return _errpage;}
		}
		#endregion Model

	}
}

