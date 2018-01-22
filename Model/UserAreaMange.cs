using System;
namespace LN.Model
{
    /// <summary>
    /// 实体类UserAreaMange 。(属性说明自动提取数据库字段的描述信息)
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
        /// 自动增长列,主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 人员ID
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 所管辖区域ID
        /// </summary>
        public int? AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 所管辖省份ID
        /// </summary>
        public int? ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 所管辖城市ID
        /// </summary>
        public int? CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 所管城镇ID
        /// </summary>
        public int? TownID
        {
            set { _townid = value; }
            get { return _townid; }
        }
        #endregion Model

    }
}

