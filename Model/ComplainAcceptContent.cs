using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ComplainAcceptContent 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ComplainAcceptContent
	{
		public ComplainAcceptContent()
		{}
		#region Model
		private int _aid;
		private int _cid;
		private int _acceptuserid;
		private string _ainfo;
		private string _attachmentinfo;
		private DateTime _createtime;
		/// <summary>
		/// 问题回复编号
		/// </summary>
		public int aID
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 问题编号
		/// </summary>
		public int cID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 回复人编号
		/// </summary>
		public int acceptUserID
		{
			set{ _acceptuserid=value;}
			get{return _acceptuserid;}
		}
		/// <summary>
		/// 回复内容
		/// </summary>
		public string aInfo
		{
			set{ _ainfo=value;}
			get{return _ainfo;}
		}
		/// <summary>
		/// 附件信息
		/// </summary>
		public string AttachmentInfo
		{
			set{ _attachmentinfo=value;}
			get{return _attachmentinfo;}
		}
		/// <summary>
		/// 受理时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

