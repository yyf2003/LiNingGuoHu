using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����ProductLineData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �������Զ�����
		/// </summary>
		public int ProductLineID
		{
			set{ _productlineid=value;}
			get{return _productlineid;}
		}
		/// <summary>
		/// ��Ʒϵ������
		/// </summary>
		public string ProductLine
		{
			set{ _productline=value;}
			get{return _productline;}
		}
        /// <summary>
        /// �������°�Ʒ����
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

