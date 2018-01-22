using System;
namespace LN.Model
{
    /// <summary>
    /// ʵ����POPSetupImage ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class POPSetupImage
    {
        public POPSetupImage()
        { }
        #region Model
        private int _i_id;
        private string _i_popid;
        private int _i_shopid;
        private string _i_shopname;
        private int _i_supplierid;
        private string _i_suppliername;
        private int _i_popinfoid;
        private string _i_popinfoname;
        private string _i_photourl;
        private int _i_operatorid;
        private string _i_operatorname;
        private int _i_examuserid;
        private string _i_examusername;
        private int _i_score;
        private string _i_examremarks;
        private string _i_additional;
        /// <summary>
        /// ��ţ�������������
        /// </summary>
        public int i_Id
        {
            set { _i_id = value; }
            get { return _i_id; }
        }
        /// <summary>
        /// �����POP���
        /// </summary>
        public string i_POPID
        {
            set { _i_popid = value; }
            get { return _i_popid; }
        }
        /// <summary>
        /// ���̱��
        /// </summary>
        public int i_ShopId
        {
            set { _i_shopid = value; }
            get { return _i_shopid; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string i_ShopName
        {
            set { _i_shopname = value; }
            get { return _i_shopname; }
        }
        /// <summary>
        /// һ���ͻ����
        /// </summary>
        public int i_SupplierID
        {
            set { _i_supplierid = value; }
            get { return _i_supplierid; }
        }
        /// <summary>
        /// һ���ͻ�����
        /// </summary>
        public string i_SupplierName
        {
            set { _i_suppliername = value; }
            get { return _i_suppliername; }
        }
        /// <summary>
        /// POP��Ϣ���
        /// </summary>
        public int i_POPinfoID
        {
            set { _i_popinfoid = value; }
            get { return _i_popinfoid; }
        }
        /// <summary>
        /// POP��Ϣ����
        /// </summary>
        public string i_POPinfoName
        {
            set { _i_popinfoname = value; }
            get { return _i_popinfoname; }
        }
        /// <summary>
        /// �ϴ���ͼƬ·��
        /// </summary>
        public string i_PhotoUrl
        {
            set { _i_photourl = value; }
            get { return _i_photourl; }
        }
        /// <summary>
        /// �����˱��
        /// </summary>
        public int i_OperatorID
        {
            set { _i_operatorid = value; }
            get { return _i_operatorid; }
        }
        /// <summary>
        /// ����������
        /// </summary>
        public string i_OperatorName
        {
            set { _i_operatorname = value; }
            get { return _i_operatorname; }
        }
        /// <summary>
        /// �����Ա���
        /// </summary>
        public int i_ExamUserID
        {
            set { _i_examuserid = value; }
            get { return _i_examuserid; }
        }

        /// <summary>
        /// �����Ա����
        /// </summary>
        public string i_ExamUserName
        {
            set { _i_examusername = value; }
            get { return _i_examusername; }
        }

        /// <summary>
        /// ��˷���
        /// </summary>
        public int i_Score
        {
            set { _i_score = value; }
            get { return _i_score; }
        }
        /// <summary>
        /// ���������
        /// </summary>
        public string i_ExamRemarks
        {
            set { _i_examremarks = value; }
            get { return _i_examremarks; }
        }
        /// <summary>
        /// �ǳ��滹������
        /// </summary>
        public string i_Additional
        {
            set { _i_additional = value; }
            get { return _i_additional; }
        }
        #endregion Model

    }
}

