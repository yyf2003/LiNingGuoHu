using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类AfficheData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class AfficheData
	{
		public AfficheData()
		{}
		#region Model
		private int _id;
		private string _userid;
		private string _typeid;
		private string _title;
		private string _main;
		private int? _click;
		private int? _isscroll;
		private int? _isdel;
		private string _fileurl;
		private string _time;
		/// <summary>
		/// 公告内容编号
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 发表人编号
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 所属类别
		/// </summary>
		public string TypeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 公告标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 公告内容
		/// </summary>
		public string Main
		{
			set{ _main=value;}
			get{return _main;}
		}
		/// <summary>
		/// 点击率
		/// </summary>
		public int? Click
		{
			set{ _click=value;}
			get{return _click;}
		}
		/// <summary>
		/// 是否滚动  默认：0  滚动：1
		/// </summary>
		public int? IsScroll
		{
			set{ _isscroll=value;}
			get{return _isscroll;}
		}
		/// <summary>
		/// 是否删除 默认 ：0 删除：1
		/// </summary>
		public int? IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 附件的Url地址
		/// </summary>
		public string FileUrl
		{
			set{ _fileurl=value;}
			get{return _fileurl;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public string Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		#endregion Model

	}
}

