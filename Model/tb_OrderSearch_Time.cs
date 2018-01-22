using System;

namespace LN.Model
{
    /// <summary>
    /// 实体类tb_OrderSearch_Time 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class tb_OrderSearch_Time
    {
        public tb_OrderSearch_Time() { }

        #region Model
        private int _time_id;
        private string _time_popid;
        private DateTime _time_searchtime;
        private int _time_userid;
        /// <summary>
        /// 主键编号
        /// </summary>
        public int TIME_ID
        {
            set { _time_id = value; }
            get { return _time_id; }
        }
        /// <summary>
        /// 发起POP编号
        /// </summary>
        public string TIME_POPID
        {
            set { _time_popid = value; }
            get { return _time_popid; }
        }
        /// <summary>
        /// 上次搜索时间
        /// </summary>
        public DateTime TIME_SearchTime
        {
            set { _time_searchtime = value; }
            get { return _time_searchtime; }
        }

        /// <summary>
        /// 主键编号
        /// </summary>
        public int TIME_USERID
        {
            set { _time_userid = value; }
            get { return _time_userid; }
        }

        #endregion Model
    }
}
