using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类POPChangeSet 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class POPChangeSet
	{
		public POPChangeSet()
		{}
		#region Model
		private int _id;
		private string _popid;
		private int? _areaid;
		private int? _provinceid;
		private int? _cityid;
		private int? _catenaproid;
		private string _changesetdesc;
        private int? _shopid;
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
		/// 区域id
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 所在省份ID
		/// </summary>
		public int? ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 所在市ID
		/// </summary>
		public int? CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
        /// <summary>
        /// 参加POP发起的ID
        /// </summary>
        public int? ShopID
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
		/// <summary>
		/// 所替换的产品系列
		/// </summary>
		public int? CatenaProID
		{
			set{ _catenaproid=value;}
			get{return _catenaproid;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string ChangeSetDesc
		{
			set{ _changesetdesc=value;}
			get{return _changesetdesc;}
		}
		#endregion Model

	}
}

