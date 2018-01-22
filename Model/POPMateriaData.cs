using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����POPMateriaData ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class POPMateriaData
	{
		public POPMateriaData()
		{}
		#region Model
		private int _materiaid;
		private string _materiapro;
        private int _supplierID;
        private int _isdelete;
		/// <summary>
		/// ���ʱ�����
		/// </summary>
		public int MateriaID
		{
			set{ _materiaid=value;}
			get{return _materiaid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string MateriaPro
		{
			set{ _materiapro=value;}
			get{return _materiapro;}
		}
        /// <summary>
        /// ����������Ӧ��
        /// </summary>
        public int SupplierID
        {
            set { _supplierID = value; }
            get { return _supplierID; }
        }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public int IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
		#endregion Model

	}
}

