using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类POPPrice 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class POPPrice
	{
		public POPPrice()
		{}
		#region Model
		private int _priceid;
		private string _popid;
		private int _supplierid;
        private string _suppliername;
		private int _popmaterial;
        private string _popmaterialname;
		private decimal _popprice;
		private int _examstate;
		private string _remark;
        private int _userid;
		/// <summary>
		/// 主键ID，自动增长
		/// </summary>
		public int PriceID
		{
			set{ _priceid=value;}
			get{return _priceid;}
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
		/// 设置价格的供应商ID
		/// </summary>
		public int SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}

        public string SupplierName
        {
            set { _suppliername = value; }
            get { return _suppliername; }
        }
		/// <summary>
		/// 材料编号
		/// </summary>
		public int POPMaterial
		{
			set{ _popmaterial=value;}
			get{return _popmaterial;}
		}

        /// <summary>
        /// 材料名称
        /// </summary>
        public string POPMaterialName
        {
            set { _popmaterialname = value; }
            get { return _popmaterialname; }
        }
		/// <summary>
		/// 报价
		/// </summary>
		public decimal POPprice
		{
			set{ _popprice=value;}
			get{return _popprice;}
		}
		/// <summary>
        /// 审核状态 ，-1:未审核；0:审核未通过；1:审核通过
		/// </summary>
		public int ExamState
		{
			set{ _examstate=value;}
			get{return _examstate;}
		}
		/// <summary>
		/// 备注 说明
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}

        /// <summary>
        /// 报价人用户编号
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

		#endregion Model

	}
}

