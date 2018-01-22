using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����AfficheData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �������ݱ��
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �����˱��
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public string TypeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string Main
		{
			set{ _main=value;}
			get{return _main;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int? Click
		{
			set{ _click=value;}
			get{return _click;}
		}
		/// <summary>
		/// �Ƿ����  Ĭ�ϣ�0  ������1
		/// </summary>
		public int? IsScroll
		{
			set{ _isscroll=value;}
			get{return _isscroll;}
		}
		/// <summary>
		/// �Ƿ�ɾ�� Ĭ�� ��0 ɾ����1
		/// </summary>
		public int? IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// ������Url��ַ
		/// </summary>
		public string FileUrl
		{
			set{ _fileurl=value;}
			get{return _fileurl;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public string Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		#endregion Model

	}
}

