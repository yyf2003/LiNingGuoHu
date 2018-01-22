using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类imageToPOPTemp 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class imageToPOPTemp
	{
		public imageToPOPTemp()
		{}
		#region Model
		private int _id;
		private string _popid;
		private int _popinfoid;
		private int _imageid;
		private int _prolineid;
		private int _shopid;
		private DateTime _systime;
		private int _popyear;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string POPID
		{
			set{ _popid=value;}
			get{return _popid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int POPinfoID
		{
			set{ _popinfoid=value;}
			get{return _popinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int imageID
		{
			set{ _imageid=value;}
			get{return _imageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int prolineID
		{
			set{ _prolineid=value;}
			get{return _prolineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime sysTime
		{
			set{ _systime=value;}
			get{return _systime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int POPyear
		{
			set{ _popyear=value;}
			get{return _popyear;}
		}
		#endregion Model

	}
}

