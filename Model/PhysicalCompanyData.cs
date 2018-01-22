using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����PhysicalCompanyData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �Զ�������,����
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ������˾ID
		/// </summary>
		public int CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// ������˾����
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string Contactor
		{
			set{ _contactor=value;}
			get{return _contactor;}
		}
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		public string ContactorPhone
		{
			set{ _contactorphone=value;}
			get{return _contactorphone;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string CompanyNameDesc
		{
			set{ _companynamedesc=value;}
			get{return _companynamedesc;}
		}
        /// <summary>
        /// ������Ӧ�̱��
        /// </summary>
        public int SupplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
		#endregion Model

	}
}

