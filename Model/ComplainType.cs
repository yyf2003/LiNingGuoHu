using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ComplainType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class ComplainType
	{
		public ComplainType()
		{}
		#region Model
		private int _tid;
		private string _tname;
		/// <summary>
		/// ���������
		/// </summary>
		public int tID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// �����������
		/// </summary>
		public string tName
		{
			set{ _tname=value;}
			get{return _tname;}
		}
		#endregion Model

	}
}

