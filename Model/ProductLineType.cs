using System;

namespace LN.Model
{
    /// <summary>
    /// 实体类ProductLineType 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ProductLineType
    {
        public ProductLineType(){ }

        #region Model

        private int _producttypeid;
        private string _producttypename;
        private int _isdelete;

        /// <summary>
        /// 故事包品类编号
        /// </summary>
        public int ProductTypeID
        {
            set { _producttypeid = value; }
            get { return _producttypeid; }
        }
        /// <summary>
        /// 故事包品类名称
        /// </summary>
        public string ProductTypeName
        {
            set { _producttypename = value; }
            get { return _producttypename; }
        }

        /// <summary>
        /// 是否被删除 0：已删除，1：未删除
        /// </summary>
        public int IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }

        #endregion Model

    }
}
