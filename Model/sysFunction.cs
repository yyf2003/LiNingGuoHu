using System;

namespace LN.Model
{
    /// <summary>
    /// ʵ����sysFunction ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class sysFunction
    {
        public sysFunction(){ }

        #region Model
        private int _id;
        private string _funcname;
        private string _callformclass;
        private int _upid;
        private string _upname;
        private string _foldername;
        private int _levelnum;
        /// <summary>
        /// ���ܱ��
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string funcName
        {
            set { _funcname = value; }
            get { return _funcname; }
        }
        /// <summary>
        /// ����ҳ��
        /// </summary>
        public string callFormClass
        {
            set { _callformclass = value; }
            get { return _callformclass; }
        }
        /// <summary>
        /// �����ϼ����
        /// </summary>
        public int upId
        {
            set { _upid = value; }
            get { return _upid; }
        }

        /// <summary>
        /// �����ϼ�����
        /// </summary>
        public string upName
        {
            set { _upname = value; }
            get { return _upname; }
        }
        /// <summary>
        /// �����ļ�������
        /// </summary>
        public string FolderName
        {
            set { _foldername = value; }
            get { return _foldername; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int LevelNum
        {
            set { _levelnum = value; }
            get { return _levelnum; }
        }
        #endregion Model
    }
}
