using System;
namespace LN.Model
{
    /// <summary>
    /// 实体类SetUpConfirm 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SetUpConfirm
    {
        public SetUpConfirm()
        { }
        #region Model
        private int _id;
        private string _dealerid;
        private int _shopid;
        private int _supplierid;
        private string _fxid;
        private string _popid;
        private int _setupcount;
        private int _setupstate;
        private int _operatorid;
        private string _operatordate;
        private string _setupdesc;
        private string _picurl;
        private int _boolinstall;
        /// <summary>
        /// 自动增长列,主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 一级客户ID
        /// </summary>
        public string DealerID
        {
            set { _dealerid = value; }
            get { return _dealerid; }
        }
        /// <summary>
        /// shopID
        /// </summary>
        public int Shopid
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int SupplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
        /// <summary>
        /// 直属客户ID
        /// </summary>
        public string FXID
        {
            set { _fxid = value; }
            get { return _fxid; }
        }
        /// <summary>
        /// POP发起ID
        /// </summary>
        public string POPID
        {
            set { _popid = value; }
            get { return _popid; }
        }
        /// <summary>
        /// 安装数量
        /// </summary>
        public int SetUpCount
        {
            set { _setupcount = value; }
            get { return _setupcount; }
        }
        /// <summary>
        /// 安装状态 1 完毕 0未完
        /// </summary>
        public int SetUpState
        {
            set { _setupstate = value; }
            get { return _setupstate; }
        }
        /// <summary>
        /// 店铺操作人ID
        /// </summary>
        public int OperatorID
        {
            set { _operatorid = value; }
            get { return _operatorid; }
        }
        /// <summary>
        /// 确认时间
        /// </summary>
        public string OperatorDate
        {
            set { _operatordate = value; }
            get { return _operatordate; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string SetUpDesc
        {
            set { _setupdesc = value; }
            get { return _setupdesc; }
        }
        /// <summary>
        /// 图片说明
        /// </summary>
        public string PicUrl
        {
            set { _picurl = value; }
            get { return _picurl; }
        }
        /// <summary>
        /// 自主安装
        /// </summary>
        public int Boolinstall
        {
            set { _boolinstall = value; }
            get { return _boolinstall; }
        }
        #endregion Model

    }
}

