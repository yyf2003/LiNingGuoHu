using System;
namespace LN.Model
{
	/// <summary>
	/// ʵ����GoodsConfirm ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class GoodsConfirm
	{
		public GoodsConfirm()
		{}
		#region Model
        private int _g_id;
        private string _g_goodsorderno;
        private int _g_receiveuserid;
        private int _g_receivestate;
        private DateTime _g_receivedate;
        private string _g_remarks;
		/// <summary>
		/// �Զ�������
		/// </summary>
        public int g_ID
		{
            set { _g_id = value; }
            get { return _g_id; }
		}
		/// <summary>
		/// ������
		/// </summary>
        public string g_GoodsOrderNO
		{
            set { _g_goodsorderno = value; }
            get { return _g_goodsorderno; }
		}
		
		/// <summary>
		/// �ջ���ID
		/// </summary>
        public int g_ReceiveUserID
		{
            set { _g_receiveuserid = value; }
            get { return _g_receiveuserid; }
		}
		/// <summary>
		/// ����״̬ 1 ���� 2 ������
		/// </summary>
        public int g_receiveState
		{
            set { _g_receivestate = value; }
            get { return _g_receivestate; }
		}
		/// <summary>
		/// �ջ�ʱ��
		/// </summary>
        public DateTime g_ReceiveDate
		{
            set { _g_receivedate = value; }
            get { return _g_receivedate; }
		}
		/// <summary>
		/// ��ע
		/// </summary>
        public string g_Remarks
		{
            set { _g_remarks = value; }
            get { return _g_remarks; }
		}
		#endregion Model

	}
}

