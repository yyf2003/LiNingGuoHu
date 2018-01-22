using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����POPPrice ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����ID���Զ�����
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
		/// ���ü۸�Ĺ�Ӧ��ID
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
		/// ���ϱ��
		/// </summary>
		public int POPMaterial
		{
			set{ _popmaterial=value;}
			get{return _popmaterial;}
		}

        /// <summary>
        /// ��������
        /// </summary>
        public string POPMaterialName
        {
            set { _popmaterialname = value; }
            get { return _popmaterialname; }
        }
		/// <summary>
		/// ����
		/// </summary>
		public decimal POPprice
		{
			set{ _popprice=value;}
			get{return _popprice;}
		}
		/// <summary>
        /// ���״̬ ��-1:δ��ˣ�0:���δͨ����1:���ͨ��
		/// </summary>
		public int ExamState
		{
			set{ _examstate=value;}
			get{return _examstate;}
		}
		/// <summary>
		/// ��ע ˵��
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}

        /// <summary>
        /// �������û����
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

		#endregion Model

	}
}

