using System;

namespace LN.Model
{
    /// <summary>
    /// ʵ����tb_POPInfo_Img ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class tb_POPInfo_Img
    {
        public tb_POPInfo_Img()
        { }
        #region Model
        private int _img_id;
        private int _img_shopid;
        private int _img_popinfoid;
        private string _img_url;
        private string _img_describe;
        private DateTime _img_createtime;
        /// <summary>
        /// ͼƬ��ţ�������
        /// </summary>
        public int Img_ID
        {
            set { _img_id = value; }
            get { return _img_id; }
        }
        /// <summary>
        /// �������̱��
        /// </summary>
        public int Img_ShopID
        {
            set { _img_shopid = value; }
            get { return _img_shopid; }
        }
        /// <summary>
        /// ����POP���
        /// </summary>
        public int Img_POPInfoID
        {
            set { _img_popinfoid = value; }
            get { return _img_popinfoid; }
        }
        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string Img_URL
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string Img_Describe
        {
            set { _img_describe = value; }
            get { return _img_describe; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime Img_CreateTime
        {
            set { _img_createtime = value; }
            get { return _img_createtime; }
        }
        #endregion Model
    }
}
