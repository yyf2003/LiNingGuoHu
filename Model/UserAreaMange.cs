using System;
namespace LN.Model
{
    /// <summary>
    /// ʵ����UserAreaMange ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class UserAreaMange
    {
        public UserAreaMange()
        { }
        #region Model
        private int _id;
        private int? _userid;
        private int? _areaid;
        private int? _provinceid;
        private int? _cityid;
        private int? _townid;
        /// <summary>
        /// �Զ�������,����
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ��ԱID
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// ����Ͻ����ID
        /// </summary>
        public int? AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// ����Ͻʡ��ID
        /// </summary>
        public int? ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// ����Ͻ����ID
        /// </summary>
        public int? CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// ���ܳ���ID
        /// </summary>
        public int? TownID
        {
            set { _townid = value; }
            get { return _townid; }
        }
        #endregion Model

    }
}

