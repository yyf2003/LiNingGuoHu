using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����SupplierInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��Ӧ��ID
		/// </summary>
		public int SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// ��Ӧ������
		/// </summary>
		public string SupplierName
		{
			set{ _suppliername=value;}
			get{return _suppliername;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string Contacter
		{
			set{ _contacter=value;}
			get{return _contacter;}
		}
		/// <summary>
		/// ��ϵ��ʽ
		/// </summary>
		public string ContactPhone
		{
			set{ _contactphone=value;}
			get{return _contactphone;}
		}
		/// <summary>
		/// ��ϵ��ְλ
		/// </summary>
		public string ContacterRole
		{
			set{ _contacterrole=value;}
			get{return _contacterrole;}
		}
		/// <summary>
		/// ��Ӧ��״̬1����0����
		/// </summary>
		public int SupplierState
		{
			set{ _supplierstate=value;}
			get{return _supplierstate;}
		}
        /// <summary>
        /// ��������
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// ������ַ
        /// </summary>
        public string PostAddress
        {
            set { _postaddress = value; }
            get { return _postaddress; }
        }
        /// <summary>
        /// ��Ӧ��ID
        /// </summary>
        public int StaffNum
        {
            set { _staffnum = value; }
            get { return _staffnum; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string LicensePath
        {
            set { _licensepath = value; }
            get { return _licensepath; }
        }
		/// <summary>
		/// ��ע
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
        /// <summary>
        /// ���ʱ��
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

