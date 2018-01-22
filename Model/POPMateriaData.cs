using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类POPMateriaData 。(属性说明自动提取数据库字段的描述信息)
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
		/// 材质表主键
		/// </summary>
		public int MateriaID
		{
			set{ _materiaid=value;}
			get{return _materiaid;}
		}
		/// <summary>
		/// 材质名称
		/// </summary>
		public string MateriaPro
		{
			set{ _materiapro=value;}
			get{return _materiapro;}
		}
        /// <summary>
        /// 材料所属供应商
        /// </summary>
        public int SupplierID
        {
            set { _supplierID = value; }
            get { return _supplierID; }
        }

        /// <summary>
        /// 是否被弃用
        /// </summary>
        public int IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
		#endregion Model

	}
}

