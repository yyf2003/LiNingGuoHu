using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����AfficheType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class AfficheType
	{
		public AfficheType()
		{}
		#region Model
		private int _id;
		private string _type;
		private int? _isdel;
		/// <summary>
		/// ���������
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// �����������
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// �Ƿ�ɾ�� 0��û�� 1��ɾ��
		/// </summary>
		public int? IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		#endregion Model

	}
}

