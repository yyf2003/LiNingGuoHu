using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ComplainContent 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ComplainContent
	{
		public ComplainContent()
		{}
		#region Model
		private int _cid;
		private string _cinfo;
		private int _tid;
		private int _userid;
		private string _acceptuserid;
		private int _acceptnumber;
		private string _attachmentinfo;
		private DateTime _createtime;
		/// <summary>
		/// 问题序号
		/// </summary>
		public int cID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 问题事宜描述
		/// </summary>
		public string cInfo
		{
			set{ _cinfo=value;}
			get{return _cinfo;}
		}
		/// <summary>
		/// 所属分类
		/// </summary>
		public int tID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 提问人编号
		/// </summary>
		public int userID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 回复人编号
		/// </summary>
		public string acceptUserID
		{
			set{ _acceptuserid=value;}
			get{return _acceptuserid;}
		}
		/// <summary>
		/// 受理次数
		/// </summary>
		public int acceptNumber
		{
			set{ _acceptnumber=value;}
			get{return _acceptnumber;}
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
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

