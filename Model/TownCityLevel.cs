using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����TownCityLevel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class TownCityLevel
	{
		public TownCityLevel()
		{}
		#region Model
		private int _tcl_id;
		private string _tcl_name;
		/// <summary>
		/// ���м����м����г�������
		/// </summary>
		public int TCL_Id
		{
			set{ _tcl_id=value;}
			get{return _tcl_id;}
		}
		/// <summary>
		/// ���м����м����г���������
		/// </summary>
		public string TCL_Name
		{
			set{ _tcl_name=value;}
			get{return _tcl_name;}
		}
		#endregion Model

	}
}

