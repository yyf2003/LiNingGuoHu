using System;
using System.Collections.Generic;
using System.Text;

namespace LN.Model
{
    /// <summary>
    /// ʵ����UpLoadEffectImg ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class UpLoadEffectImg
    {
        public UpLoadEffectImg(){ }

        #region Model
        private int _id;
        private int _supplierid;
        private string _popid;
        private string _imgurl;
        private int _userid;
        private DateTime _createdate;
        /// <summary>
        /// ͼƬ���
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ������Ӧ��
        /// </summary>
        public int SupplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
        /// <summary>
        /// ����POP����ID
        /// </summary>
        public string POPID
        {
            set { _popid = value; }
            get { return _popid; }
        }
        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string ImgURL
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// �ϴ���
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// �ϴ�ʱ��
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model
    }
}
