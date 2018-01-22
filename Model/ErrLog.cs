using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ErrLog ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����ID
		/// </summary>
		public string ErrID
		{
			set{ _errid=value;}
			get{return _errid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string ErrDec
		{
			set{ _errdec=value;}
			get{return _errdec;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? ErrTime
		{
			set{ _errtime=value;}
			get{return _errtime;}
		}
		/// <summary>
		/// ����ҳ��
		/// </summary>
		public string ErrPage
		{
			set{ _errpage=value;}
			get{return _errpage;}
		}
		#endregion Model

	}
}

