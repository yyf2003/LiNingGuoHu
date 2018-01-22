using System;

namespace LN.Model
{
    /// <summary>
    /// ʵ����ProductLineType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class ProductLineType
    {
        public ProductLineType(){ }

        #region Model

        private int _producttypeid;
        private string _producttypename;
        private int _isdelete;

        /// <summary>
        /// ���°�Ʒ����
        /// </summary>
        public int ProductTypeID
        {
            set { _producttypeid = value; }
            get { return _producttypeid; }
        }
        /// <summary>
        /// ���°�Ʒ������
        /// </summary>
        public string ProductTypeName
        {
            set { _producttypename = value; }
            get { return _producttypename; }
        }

        /// <summary>
        /// �Ƿ�ɾ�� 0����ɾ����1��δɾ��
        /// </summary>
        public int IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }

        #endregion Model

    }
}
