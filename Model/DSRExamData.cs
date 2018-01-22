using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类DSRExamData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class DSRExamData
	{
		public DSRExamData()
		{}
		#region Model
		private int _id;
		private string _popid;
		private int? _checkuserid;
		private string _areaid;
		private int? _provinceid;
		private int? _cityid;
		private int? _shopid;
        private int? _SupplierID;
		private DateTime? _checkdate;
		private DateTime? _sysdatetime;
		private int? _yescount;
		private int? _nocount;
		private string _dataid;
		/// <summary>
		/// 自动增长列,主键
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// POP发起ID
		/// </summary>
        public string POPID
		{
			set{ _popid=value;}
			get{return _popid;}
		}
		/// <summary>
		/// 检查人员ID
		/// </summary>
		public int? CheckUserID
		{
			set{ _checkuserid=value;}
			get{return _checkuserid;}
		}
		/// <summary>
		/// 所管辖区域ID
		/// </summary>
		public string AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 所管辖省份ID
		/// </summary>
		public int? ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 所管辖城市ID
		/// </summary>
		public int? CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 所检查店铺ID
		/// </summary>
		public int? ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
        /// <summary>
        /// 所检查店铺所属的供应商
        /// </summary>
        public int? SupplierID
        {
            set { _SupplierID = value; }
            get { return _SupplierID; }
        }
		/// <summary>
		/// 检查时间
		/// </summary>
		public DateTime? CheckDate
		{
			set{ _checkdate=value;}
			get{return _checkdate;}
		}
		/// <summary>
		/// 数据录入时间
		/// </summary>
		public DateTime? SysDateTime
		{
			set{ _sysdatetime=value;}
			get{return _sysdatetime;}
		}
		/// <summary>
		/// 检查结果为是的数目
		/// </summary>
		public int? YesCount
		{
			set{ _yescount=value;}
			get{return _yescount;}
		}
		/// <summary>
		/// 检查结果为否的数目
		/// </summary>
		public int? NoCount
		{
			set{ _nocount=value;}
			get{return _nocount;}
		}
		/// <summary>
		/// 与DSRResultsList的DataID为关联
		/// </summary>
		public string DataID
		{
			set{ _dataid=value;}
			get{return _dataid;}
		}
		#endregion Model

	}
}

