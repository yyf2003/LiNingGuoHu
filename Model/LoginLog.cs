using System;
namespace LN.Model
{
    /// <summary>
    /// 实体类LoginLog 。(属性说明自动提取数据库字段的描述信息)
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
        /// 登录人ID
        /// </summary>
        public string LoginUserID
        {
            set { _loginuserid = value; }
            get { return _loginuserid; }
        }
        /// <summary>
        /// 登录时间
        /// </summary>
        public string LoginTime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIP
        {
            set { _loginip = value; }
            get { return _loginip; }
        }
        /// <summary>
        /// 登录结果
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        #endregion Model

    }
}

