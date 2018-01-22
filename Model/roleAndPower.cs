using System;
namespace LN.Model
{
    /// <summary>
    /// 实体类roleAndPower 。(属性说明自动提取数据库字段的描述信息)
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
        /// 编号(递增)
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 权限编号
        /// </summary>
        public int roleId
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 功能编号集合
        /// </summary>
        public string functionId
        {
            set { _functionid = value; }
            get { return _functionid; }
        }
        #endregion Model

    }
}

