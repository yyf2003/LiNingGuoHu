using System;

namespace LN.Model
{
    /// <summary>
    /// 实体类tb_POPInfo_Img 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class tb_POPInfo_Img
    {
        public tb_POPInfo_Img()
        { }
        #region Model
        private int _img_id;
        private int _img_shopid;
        private int _img_popinfoid;
        private string _img_url;
        private string _img_describe;
        private DateTime _img_createtime;
        /// <summary>
        /// 图片编号（递增）
        /// </summary>
        public int Img_ID
        {
            set { _img_id = value; }
            get { return _img_id; }
        }
        /// <summary>
        /// 所属店铺编号
        /// </summary>
        public int Img_ShopID
        {
            set { _img_shopid = value; }
            get { return _img_shopid; }
        }
        /// <summary>
        /// 所属POP编号
        /// </summary>
        public int Img_POPInfoID
        {
            set { _img_popinfoid = value; }
            get { return _img_popinfoid; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string Img_URL
        {
            set { _img_url = value; }
            get { return _img_url; }
        }
        /// <summary>
        /// 图片描述
        /// </summary>
        public string Img_Describe
        {
            set { _img_describe = value; }
            get { return _img_describe; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Img_CreateTime
        {
            set { _img_createtime = value; }
            get { return _img_createtime; }
        }
        #endregion Model
    }
}
