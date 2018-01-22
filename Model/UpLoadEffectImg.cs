using System;
using System.Collections.Generic;
using System.Text;

namespace LN.Model
{
    /// <summary>
    /// 实体类UpLoadEffectImg 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class UpLoadEffectImg
    {
        public UpLoadEffectImg(){ }

        #region Model
        private int _id;
        private int _supplierid;
        private string _popid;
        private string _imgurl;
        private int _userid;
        private DateTime _createdate;
        /// <summary>
        /// 图片编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 所属供应商
        /// </summary>
        public int SupplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
        /// <summary>
        /// 所属POP发起ID
        /// </summary>
        public string POPID
        {
            set { _popid = value; }
            get { return _popid; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgURL
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 上传人
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model
    }
}
