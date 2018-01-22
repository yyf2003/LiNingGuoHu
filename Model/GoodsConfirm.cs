using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类GoodsConfirm 。(属性说明自动提取数据库字段的描述信息)
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
		/// 自动增长列
		/// </summary>
        public int g_ID
		{
            set { _g_id = value; }
            get { return _g_id; }
		}
		/// <summary>
		/// 发货单
		/// </summary>
        public string g_GoodsOrderNO
		{
            set { _g_goodsorderno = value; }
            get { return _g_goodsorderno; }
		}
		
		/// <summary>
		/// 收货人ID
		/// </summary>
        public int g_ReceiveUserID
		{
            set { _g_receiveuserid = value; }
            get { return _g_receiveuserid; }
		}
		/// <summary>
		/// 接收状态 1 正常 2 非正常
		/// </summary>
        public int g_receiveState
		{
            set { _g_receivestate = value; }
            get { return _g_receivestate; }
		}
		/// <summary>
		/// 收货时间
		/// </summary>
        public DateTime g_ReceiveDate
		{
            set { _g_receivedate = value; }
            get { return _g_receivedate; }
		}
		/// <summary>
		/// 备注
		/// </summary>
        public string g_Remarks
		{
            set { _g_remarks = value; }
            get { return _g_remarks; }
		}
		#endregion Model

	}
}

