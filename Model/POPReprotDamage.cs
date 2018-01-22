using System;
namespace LN.Model
{
	/// <summary>
	/// 实体类POPReprotDamage 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class POPReprotDamage
	{
		public POPReprotDamage()
		{}
		#region Model
		private int _id;
		private int? _shopid;
		private int? _supplierid;
		private int? _upuserid;
        private string  _uppopdate;
		private string _photopath;
		private string _shopdesc;
		private int? _dsrstate;
		private string _dsrdesc;
        private string  _dsrdate;
		private int? _vmstate;
        private string  _vmdate;
		private string _vmdesc;
		/// <summary>
		/// 主键
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ShopID
		/// </summary>
		public int? ShopID
		{
			set{ _shopid=value;}
			get{return _shopid;}
		}
		/// <summary>
		/// 供应商ID
		/// </summary>
		public int? SupplierID
		{
			set{ _supplierid=value;}
			get{return _supplierid;}
		}
		/// <summary>
		/// 提交人ID
		/// </summary>
		public int? UpUserID
		{
			set{ _upuserid=value;}
			get{return _upuserid;}
		}
		/// <summary>
		/// 提交日期
		/// </summary>
        public string UpPOPDate
		{
			set{ _uppopdate=value;}
			get{return _uppopdate;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string PhotoPath
		{
			set{ _photopath=value;}
			get{return _photopath;}
		}
		/// <summary>
		/// 店铺描述
		/// </summary>
		public string ShopDesc
		{
			set{ _shopdesc=value;}
			get{return _shopdesc;}
		}
		/// <summary>
		/// Dsr审批1 完毕 0未完
		/// </summary>
		public int? DSRState
		{
			set{ _dsrstate=value;}
			get{return _dsrstate;}
		}
		/// <summary>
		/// DSR描述
		/// </summary>
		public string DSRDesc
		{
			set{ _dsrdesc=value;}
			get{return _dsrdesc;}
		}
		/// <summary>
		/// DSR审批时间
		/// </summary>
        public string DSRDate
		{
			set{ _dsrdate=value;}
			get{return _dsrdate;}
		}
		/// <summary>
		/// VM审批状态 1 完毕 0未完
		/// </summary>
		public int? VMState
		{
			set{ _vmstate=value;}
			get{return _vmstate;}
		}
		/// <summary>
		/// VM审批时间
		/// </summary>
        public string VMDate
		{
			set{ _vmdate=value;}
			get{return _vmdate;}
		}
		/// <summary>
		/// VM描述
		/// </summary>
		public string VMDesc
		{
			set{ _vmdesc=value;}
			get{return _vmdesc;}
		}
		#endregion Model

	}
}

