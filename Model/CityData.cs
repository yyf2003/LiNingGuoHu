using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����CityData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class CityData
	{
		public CityData()
		{}
		#region Model
		private int _cityid;
		private int? _areaid;
		private int? _provinceid;
		private string _cityname;
		private string _citylevel;
		/// <summary>
		/// ���� �Զ�����
		/// </summary>
		public int CItyID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// ��������ID
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// ����ʡ��ID
		/// </summary>
		public int? ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string CityName
		{
			set{ _cityname=value;}
			get{return _cityname;}
		}
		/// <summary>
		/// ���м���
		/// </summary>
		public string CityLevel
		{
			set{ _citylevel=value;}
			get{return _citylevel;}
		}
		#endregion Model

	}
}

