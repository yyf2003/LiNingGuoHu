using System;
namespace LN.Model
{
    /// <summary>
    /// ʵ����LoginLog ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class LoginLog
    {
        public LoginLog()
        { }
        #region Model
        private int _id;
        private string _loginuserid;
        private string _logintime;
        private string _loginip;
        private string _result;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ��¼��ID
        /// </summary>
        public string LoginUserID
        {
            set { _loginuserid = value; }
            get { return _loginuserid; }
        }
        /// <summary>
        /// ��¼ʱ��
        /// </summary>
        public string LoginTime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        /// <summary>
        /// ��¼IP
        /// </summary>
        public string LoginIP
        {
            set { _loginip = value; }
            get { return _loginip; }
        }
        /// <summary>
        /// ��¼���
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        #endregion Model

    }
}

