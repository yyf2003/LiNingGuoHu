using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����tb_FOSPOP ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ��ţ�������
		/// </summary>
		public int FOS_ID
		{
			set{ _fos_id=value;}
			get{return _fos_id;}
		}
		/// <summary>
		/// FOS��POPλ��
		/// </summary>
		public string FOS_POPSeat
		{
			set{ _fos_popseat=value;}
			get{return _fos_popseat;}
		}
		/// <summary>
		/// FOS��POP����
		/// </summary>
		public string FOS_POPMateria
		{
			set{ _fos_popmateria=value;}
			get{return _fos_popmateria;}
		}
		/// <summary>
		/// FOS��POPʵ��������
		/// </summary>
		public decimal FOS_POPRealHeight
		{
			set{ _fos_poprealheight=value;}
			get{return _fos_poprealheight;}
		}
		/// <summary>
		/// FOS��POPʵ��������
		/// </summary>
		public decimal FOS_POPRealWith
		{
			set{ _fos_poprealwith=value;}
			get{return _fos_poprealwith;}
		}
		/// <summary>
		/// FOS��POP���ӻ����
		/// </summary>
		public decimal FOS_POPHeight
		{
			set{ _fos_popheight=value;}
			get{return _fos_popheight;}
		}
		/// <summary>
		/// FOS��POP���ӻ����
		/// </summary>
		public decimal FOS_POPWith
		{
			set{ _fos_popwith=value;}
			get{return _fos_popwith;}
		}

        /// <summary>
        /// �Ƿ�ɾ����0��δɾ����1��ɾ��
        /// </summary>
        public int FOS_IsDelete
        {
            set { _fos_isdelete = value; }
            get { return _fos_isdelete; }
        }

		#endregion Model

	}
}

