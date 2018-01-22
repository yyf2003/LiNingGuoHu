using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ProvinceData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ProvinceData
	{
		public ProvinceData()
		{}
		#region Model
		private int _provinceid;
		private int? _areaid;
		private string _provincename;
        private string _VMmaster;
        private string _VMPhone;
		/// <summary>
		/// 省份主键，自动增长
		/// </summary>
		public int ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 所在区域ID
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 省名称
		/// </summary>
		public string ProvinceName
		{
			set{ _provincename=value;}
			get{return _provincename;}
		}

        public string VMmaster
        {
            set{_VMmaster=value;}
            get{return _VMmaster;}
        }
        public string VMphone
        {
            set { _VMPhone = value; }
            get { return _VMPhone; }
        }
		#endregion Model

	}
}

