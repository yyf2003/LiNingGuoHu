using System;

namespace LN.Model
{
    /// <summary>
    /// ʵ����SupplierUserManage ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class SupplierUserManage
    {
        private int _id;
        private int _supplierid;
        private int _userid;
        private int _typeid;

        /// <summary>
        /// ���
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        /// �û����
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// Ȩ��  --  2����Ӧ�̹���Ա ,   1����Ӧ��(���޸�) ,  0����Ӧ��(�ɲ鿴)
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
    }
}
