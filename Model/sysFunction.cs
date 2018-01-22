using System;

namespace LN.Model
{
    /// <summary>
    /// 实体类sysFunction 。(属性说明自动提取数据库字段的描述信息)
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
        /// 功能编号
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 功能名称
        /// </summary>
        public string funcName
        {
            set { _funcname = value; }
            get { return _funcname; }
        }
        /// <summary>
        /// 功能页面
        /// </summary>
        public string callFormClass
        {
            set { _callformclass = value; }
            get { return _callformclass; }
        }
        /// <summary>
        /// 所属上级编号
        /// </summary>
        public int upId
        {
            set { _upid = value; }
            get { return _upid; }
        }

        /// <summary>
        /// 所属上级名称
        /// </summary>
        public string upName
        {
            set { _upname = value; }
            get { return _upname; }
        }
        /// <summary>
        /// 所在文件夹名称
        /// </summary>
        public string FolderName
        {
            set { _foldername = value; }
            get { return _foldername; }
        }
        /// <summary>
        /// 级数
        /// </summary>
        public int LevelNum
        {
            set { _levelnum = value; }
            get { return _levelnum; }
        }
        #endregion Model
    }
}
