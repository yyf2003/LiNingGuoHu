using System;
namespace LN.Model
{
    /// <summary>
    /// 实体类POPAddition 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class POPAddition
    {
        public POPAddition()
        { }
        #region Model
        private int _addid;
        private string _popid;
        private int? _shopid;
        private int? _popinfoid;
        private string _photourl;
        private string _adddate;
        private int? _adduserid;
        private int? _examstate;
        private int? _examuserid;
        private string _des;
        private string _undes;
        private int? _senduser;
        private string _sendtime;
        private string _goodsorderno;
        private int? _companyid;
        private string _senddes;
        private int? _state;
        private int? _acceptuser;
        private string _accepttime;
        private string _acceptdes;
        private string _addtype;
        private string _addObject;
        private int _prolineid;

        public int ProLineID
        {
            set { _prolineid = value; }
            get { return _prolineid; } 
                
        }
        /// <summary>
        /// 增补的原因  到货增补，运营增补，新增增补
        /// </summary>
        public string Addtype
        {
            set { _addtype = value; }
            get { return _addtype; }
        }
        /// <summary>
        /// 是由哪个角色来添加的增补
        /// </summary>
        public string AddObject
        {
            set { _addObject = value; }
            get { return _addObject; }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public int AddID
        {
            set { _addid = value; }
            get { return _addid; }
        }
        /// <summary>
        /// 发起POPID
        /// </summary>
        public string POPID
        {
            set { _popid = value; }
            get { return _popid; }
        }
        /// <summary>
        /// 需要增加的店铺ID
        /// </summary>
        public int? Shopid
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        /// <summary>
        /// 要增加的店铺POP信息的ID
        /// </summary>
        public int? POPinfoID
        {
            set { _popinfoid = value; }
            get { return _popinfoid; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string PhotoUrl
        {
            set { _photourl = value; }
            get { return _photourl; }
        }
        /// <summary>
        /// 上报时间
        /// </summary>
        public string AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 上报人
        /// </summary>
        public int? AddUserID
        {
            set { _adduserid = value; }
            get { return _adduserid; }
        }
        /// <summary>
        /// 审批状态 0:未检查 1:检查通过 2:未通过检查
        /// </summary>
        public int? ExamState
        {
            set { _examstate = value; }
            get { return _examstate; }
        }
        /// <summary>
        /// 审批人
        /// </summary>
        public int? ExamUserID
        {
            set { _examuserid = value; }
            get { return _examuserid; }
        }
        /// <summary>
        /// 报损照片描述
        /// </summary>
        public string Des
        {
            set { _des = value; }
            get { return _des; }
        }
        /// <summary>
        /// 审核不通过的备注说明
        /// </summary>
        public string UnDes
        {
            set { _undes = value; }
            get { return _undes; }
        }
        /// <summary>
        /// 发货人ID
        /// </summary>
        public int? SendUser
        {
            set { _senduser = value; }
            get { return _senduser; }
        }
        /// <summary>
        /// 发货时间
        /// </summary>
        public string SendTime
        {
            set { _sendtime = value; }
            get { return _sendtime; }
        }
        /// <summary>
        /// 发货单号
        /// </summary>
        public string GoodsOrderNo
        {
            set { _goodsorderno = value; }
            get { return _goodsorderno; }
        }
        /// <summary>
        /// 物流公司ID
        /// </summary>
        public int? CompanyID
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 发货描述
        /// </summary>
        public string SendDes
        {
            set { _senddes = value; }
            get { return _senddes; }
        }
        /// <summary>
        /// 发货状态 默认：0 已经发货：1 已经收货：2
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 收货人ID
        /// </summary>
        public int? AcceptUser
        {
            set { _acceptuser = value; }
            get { return _acceptuser; }
        }
        /// <summary>
        /// 收货时间
        /// </summary>
        public string AcceptTime
        {
            set { _accepttime = value; }
            get { return _accepttime; }
        }
        /// <summary>
        /// 收货描述
        /// </summary>
        public string AcceptDes
        {
            set { _acceptdes = value; }
            get { return _acceptdes; }
        }
        #endregion Model

    }
}

