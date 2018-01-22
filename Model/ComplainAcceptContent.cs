using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ComplainAcceptContent ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����ظ����
		/// </summary>
		public int aID
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public int cID
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// �ظ��˱��
		/// </summary>
		public int acceptUserID
		{
			set{ _acceptuserid=value;}
			get{return _acceptuserid;}
		}
		/// <summary>
		/// �ظ�����
		/// </summary>
		public string aInfo
		{
			set{ _ainfo=value;}
			get{return _ainfo;}
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

