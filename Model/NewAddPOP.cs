using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类NewAddPOP 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class NewAddPOP
	{
		public NewAddPOP()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private string _popid;
		private int? _popinfoid;
		private int? _imageid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 店铺id
		/// </summary>
		public int? shopid
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 发起的POP的ID
		/// </summary>
		public string POPID
		{
			set{ _popid=value;}
			get{return _popid;}
		}
		/// <summary>
		/// 店铺pop的编号（系统分配的）
		/// </summary>
		public int? POPinfoID
		{
			set{ _popinfoid=value;}
			get{return _popinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? imageID
		{
			set{ _imageid=value;}
			get{return _imageid;}
		}
		#endregion Model

	}
}

