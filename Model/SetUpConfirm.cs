using System;
namespace LN.Model
{
    /// <summary>
    /// ʵ����SetUpConfirm ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �Զ�������,����
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// һ���ͻ�ID
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
        /// ��Ӧ��ID
        /// </summary>
        public int SupplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
        /// <summary>
        /// ֱ���ͻ�ID
        /// </summary>
        public string FXID
        {
            set { _fxid = value; }
            get { return _fxid; }
        }
        /// <summary>
        /// POP����ID
        /// </summary>
        public string POPID
        {
            set { _popid = value; }
            get { return _popid; }
        }
        /// <summary>
        /// ��װ����
        /// </summary>
        public int SetUpCount
        {
            set { _setupcount = value; }
            get { return _setupcount; }
        }
        /// <summary>
        /// ��װ״̬ 1 ��� 0δ��
        /// </summary>
        public int SetUpState
        {
            set { _setupstate = value; }
            get { return _setupstate; }
        }
        /// <summary>
        /// ���̲�����ID
        /// </summary>
        public int OperatorID
        {
            set { _operatorid = value; }
            get { return _operatorid; }
        }
        /// <summary>
        /// ȷ��ʱ��
        /// </summary>
        public string OperatorDate
        {
            set { _operatordate = value; }
            get { return _operatordate; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string SetUpDesc
        {
            set { _setupdesc = value; }
            get { return _setupdesc; }
        }
        /// <summary>
        /// ͼƬ˵��
        /// </summary>
        public string PicUrl
        {
            set { _picurl = value; }
            get { return _picurl; }
        }
        /// <summary>
        /// ������װ
        /// </summary>
        public int Boolinstall
        {
            set { _boolinstall = value; }
            get { return _boolinstall; }
        }
        #endregion Model

    }
}

