using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类ProductLineData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ProductLineData
	{
		public ProductLineData()
		{}
		#region Model
		private int _productlineid;
		private string _productline;
        private int _typeid;
        private int _isdelete;
        private string _productTypename;
		/// <summary>
		/// 主键，自动增长
		/// </summary>
		public int ProductLineID
		{
			set{ _productlineid=value;}
			get{return _productlineid;}
		}
		/// <summary>
		/// 产品系列名称
		/// </summary>
		public string ProductLine
		{
			set{ _productline=value;}
			get{return _productline;}
		}
        /// <summary>
        /// 所属故事包品类编号
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        public int IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        public string ProductTypeName
        {
            set { _productTypename = value; }
            get { return _productTypename; }
        }
		#endregion Model

	}
}

