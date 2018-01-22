using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ComplainContent ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �������
		/// </summary>
		public int cID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// ������������
		/// </summary>
		public string cInfo
		{
			set{ _cinfo=value;}
			get{return _cinfo;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public int tID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// �����˱��
		/// </summary>
		public int userID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �ظ��˱��
		/// </summary>
		public string acceptUserID
		{
			set{ _acceptuserid=value;}
			get{return _acceptuserid;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public int acceptNumber
		{
			set{ _acceptnumber=value;}
			get{return _acceptnumber;}
		}
		/// <summary>
		/// ������Ϣ
		/// </summary>
		public string AttachmentInfo
		{
			set{ _attachmentinfo=value;}
			get{return _attachmentinfo;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

