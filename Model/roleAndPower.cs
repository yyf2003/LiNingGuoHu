using System;
namespace LN.Model
{
    /// <summary>
    /// ʵ����roleAndPower ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class roleAndPower
    {
        public roleAndPower()
        { }
        #region Model
        private int _id;
        private int _roleid;
        private string _functionid;
        /// <summary>
        /// ���(����)
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// Ȩ�ޱ��
        /// </summary>
        public int roleId
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// ���ܱ�ż���
        /// </summary>
        public string functionId
        {
            set { _functionid = value; }
            get { return _functionid; }
        }
        #endregion Model

    }
}

