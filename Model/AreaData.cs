using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类AreaData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class AreaData
	{
		public AreaData()
		{}
		#region Model
		private int _areaid;
		private string _areaname;
        private string _dept;
		/// <summary>
		/// 区域主键，自动增长
		/// </summary>
		public int AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 区域名称
		/// </summary>
		public string AreaName
		{
			set{ _areaname=value;}
			get{return _areaname;}
		}
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartMent
        {
            set { _dept = value; }
            get { return _dept; }
        }
		#endregion Model

	}
}

