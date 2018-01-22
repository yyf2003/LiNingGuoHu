using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类POPMaterialPrice 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class POPMaterialPrice
	{
		public POPMaterialPrice()
		{}
		#region Model
		private int _priceid;
		private int _supplierid;
        private int? _materiaID;
		private decimal? _popprice;
		private int? _userid;
		private DateTime? _systime;
		/// <summary>
		/// 
		/// </summary>
		public int PriceID
		{
			set{ _priceid=value;}
			get{return _priceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// 
		/// </summary>
        public int? MateriaID
		{
            set {_materiaID = value; }
            get { return _materiaID; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? POPprice
		{
			set{ _popprice=value;}
			get{return _popprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SysTime
		{
			set{ _systime=value;}
			get{return _systime;}
		}
		#endregion Model

	}
}

