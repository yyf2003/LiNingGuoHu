using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类PhysicalCompanyData 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PhysicalCompanyData
	{
		public PhysicalCompanyData()
		{}
		#region Model
		private int _id;
		private int _companyid;
		private string _companyname;
		private string _contactor;
		private string _contactorphone;
		private string _companynamedesc;
        private int _supplierid;
		/// <summary>
		/// 自动增长列,主键
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 物流公司ID
		/// </summary>
		public int CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 物流公司名称
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string Contactor
		{
			set{ _contactor=value;}
			get{return _contactor;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string ContactorPhone
		{
			set{ _contactorphone=value;}
			get{return _contactorphone;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string CompanyNameDesc
		{
			set{ _companynamedesc=value;}
			get{return _companynamedesc;}
		}
        /// <summary>
        /// 所属供应商编号
        /// </summary>
        public int SupplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
		#endregion Model

	}
}

