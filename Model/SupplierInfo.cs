using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类SupplierInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class SupplierInfo
	{
		public SupplierInfo()
		{}
		#region Model
		private int _supplierid;
		private string _suppliername;
		private string _contacter;
		private string _contactphone;
		private string _contacterrole;
		private int _supplierstate;
        private string _postcode;
        private string _postaddress;
        private int _staffnum;
        private string _licensepath;
		private string _remarks;
        private DateTime _createdate;
		/// <summary>
		/// 供应商ID
		/// </summary>
		public int SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// 供应商名称
		/// </summary>
		public string SupplierName
		{
			set{ _suppliername=value;}
			get{return _suppliername;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string Contacter
		{
			set{ _contacter=value;}
			get{return _contacter;}
		}
		/// <summary>
		/// 联系方式
		/// </summary>
		public string ContactPhone
		{
			set{ _contactphone=value;}
			get{return _contactphone;}
		}
		/// <summary>
		/// 联系人职位
		/// </summary>
		public string ContacterRole
		{
			set{ _contacterrole=value;}
			get{return _contacterrole;}
		}
		/// <summary>
		/// 供应商状态1正常0过期
		/// </summary>
		public int SupplierState
		{
			set{ _supplierstate=value;}
			get{return _supplierstate;}
		}
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 邮政地址
        /// </summary>
        public string PostAddress
        {
            set { _postaddress = value; }
            get { return _postaddress; }
        }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int StaffNum
        {
            set { _staffnum = value; }
            get { return _staffnum; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string LicensePath
        {
            set { _licensepath = value; }
            get { return _licensepath; }
        }
		/// <summary>
		/// 备注
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }

        public string ShortName { get; set; }
        public int? IsPromotion { get; set; }
		#endregion Model

	}
}

