using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����AreaCityLevel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class AreaCityLevel
	{
		public AreaCityLevel()
		{}
		#region Model
		private int _acl_id;
		private string _acl_name;
		/// <summary>
		/// ���ؼ����м����г�������
		/// </summary>
		public int ACL_Id
		{
			set{ _acl_id=value;}
			get{return _acl_id;}
		}
		/// <summary>
		/// ���ؼ����м����г���������
		/// </summary>
		public string ACL_Name
		{
			set{ _acl_name=value;}
			get{return _acl_name;}
		}
		#endregion Model

	}
}

