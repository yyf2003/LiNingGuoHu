using System;
namespace LN.Model
{
    /// <summary>
    /// ʵ����POPAddition ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ������ԭ��  ������������Ӫ��������������
        /// </summary>
        public string Addtype
        {
            set { _addtype = value; }
            get { return _addtype; }
        }
        /// <summary>
        /// �����ĸ���ɫ����ӵ�����
        /// </summary>
        public string AddObject
        {
            set { _addObject = value; }
            get { return _addObject; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int AddID
        {
            set { _addid = value; }
            get { return _addid; }
        }
        /// <summary>
        /// ����POPID
        /// </summary>
        public string POPID
        {
            set { _popid = value; }
            get { return _popid; }
        }
        /// <summary>
        /// ��Ҫ���ӵĵ���ID
        /// </summary>
        public int? Shopid
        {
            set { _shopid = value; }
            get { return _shopid; }
        }
        /// <summary>
        /// Ҫ���ӵĵ���POP��Ϣ��ID
        /// </summary>
        public int? POPinfoID
        {
            set { _popinfoid = value; }
            get { return _popinfoid; }
        }
        /// <summary>
        /// ͼƬ·��
        /// </summary>
        public string PhotoUrl
        {
            set { _photourl = value; }
            get { return _photourl; }
        }
        /// <summary>
        /// �ϱ�ʱ��
        /// </summary>
        public string AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// �ϱ���
        /// </summary>
        public int? AddUserID
        {
            set { _adduserid = value; }
            get { return _adduserid; }
        }
        /// <summary>
        /// ����״̬ 0:δ��� 1:���ͨ�� 2:δͨ�����
        /// </summary>
        public int? ExamState
        {
            set { _examstate = value; }
            get { return _examstate; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int? ExamUserID
        {
            set { _examuserid = value; }
            get { return _examuserid; }
        }
        /// <summary>
        /// ������Ƭ����
        /// </summary>
        public string Des
        {
            set { _des = value; }
            get { return _des; }
        }
        /// <summary>
        /// ��˲�ͨ���ı�ע˵��
        /// </summary>
        public string UnDes
        {
            set { _undes = value; }
            get { return _undes; }
        }
        /// <summary>
        /// ������ID
        /// </summary>
        public int? SendUser
        {
            set { _senduser = value; }
            get { return _senduser; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string SendTime
        {
            set { _sendtime = value; }
            get { return _sendtime; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string GoodsOrderNo
        {
            set { _goodsorderno = value; }
            get { return _goodsorderno; }
        }
        /// <summary>
        /// ������˾ID
        /// </summary>
        public int? CompanyID
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string SendDes
        {
            set { _senddes = value; }
            get { return _senddes; }
        }
        /// <summary>
        /// ����״̬ Ĭ�ϣ�0 �Ѿ�������1 �Ѿ��ջ���2
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// �ջ���ID
        /// </summary>
        public int? AcceptUser
        {
            set { _acceptuser = value; }
            get { return _acceptuser; }
        }
        /// <summary>
        /// �ջ�ʱ��
        /// </summary>
        public string AcceptTime
        {
            set { _accepttime = value; }
            get { return _accepttime; }
        }
        /// <summary>
        /// �ջ�����
        /// </summary>
        public string AcceptDes
        {
            set { _acceptdes = value; }
            get { return _acceptdes; }
        }
        #endregion Model

    }
}

