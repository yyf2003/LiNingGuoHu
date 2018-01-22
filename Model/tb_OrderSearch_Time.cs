using System;

namespace LN.Model
{
    /// <summary>
    /// ʵ����tb_OrderSearch_Time ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �������
        /// </summary>
        public int TIME_ID
        {
            set { _time_id = value; }
            get { return _time_id; }
        }
        /// <summary>
        /// ����POP���
        /// </summary>
        public string TIME_POPID
        {
            set { _time_popid = value; }
            get { return _time_popid; }
        }
        /// <summary>
        /// �ϴ�����ʱ��
        /// </summary>
        public DateTime TIME_SearchTime
        {
            set { _time_searchtime = value; }
            get { return _time_searchtime; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public int TIME_USERID
        {
            set { _time_userid = value; }
            get { return _time_userid; }
        }

        #endregion Model
    }
}
