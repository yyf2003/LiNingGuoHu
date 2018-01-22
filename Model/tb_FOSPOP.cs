using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类tb_FOSPOP 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class tb_FOSPOP
	{
		public tb_FOSPOP()
		{}
		#region Model
		private int _fos_id;
		private string _fos_popseat;
		private string _fos_popmateria;
		private decimal _fos_poprealheight;
		private decimal _fos_poprealwith;
		private decimal _fos_popheight;
		private decimal _fos_popwith;
        private int _fos_isdelete;
		/// <summary>
		/// 编号（递增）
		/// </summary>
		public int FOS_ID
		{
			set{ _fos_id=value;}
			get{return _fos_id;}
		}
		/// <summary>
		/// FOS店POP位置
		/// </summary>
		public string FOS_POPSeat
		{
			set{ _fos_popseat=value;}
			get{return _fos_popseat;}
		}
		/// <summary>
		/// FOS店POP材质
		/// </summary>
		public string FOS_POPMateria
		{
			set{ _fos_popmateria=value;}
			get{return _fos_popmateria;}
		}
		/// <summary>
		/// FOS店POP实际制作高
		/// </summary>
		public decimal FOS_POPRealHeight
		{
			set{ _fos_poprealheight=value;}
			get{return _fos_poprealheight;}
		}
		/// <summary>
		/// FOS店POP实际制作宽
		/// </summary>
		public decimal FOS_POPRealWith
		{
			set{ _fos_poprealwith=value;}
			get{return _fos_poprealwith;}
		}
		/// <summary>
		/// FOS店POP可视画面高
		/// </summary>
		public decimal FOS_POPHeight
		{
			set{ _fos_popheight=value;}
			get{return _fos_popheight;}
		}
		/// <summary>
		/// FOS店POP可视画面宽
		/// </summary>
		public decimal FOS_POPWith
		{
			set{ _fos_popwith=value;}
			get{return _fos_popwith;}
		}

        /// <summary>
        /// 是否删除。0：未删除，1：删除
        /// </summary>
        public int FOS_IsDelete
        {
            set { _fos_isdelete = value; }
            get { return _fos_isdelete; }
        }

		#endregion Model

	}
}

