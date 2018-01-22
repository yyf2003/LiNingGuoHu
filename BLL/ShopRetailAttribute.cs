using System;
using System.Collections.Generic;
using System.Text;

namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类ShopVI 的摘要说明。
    /// </summary>
    public class ShopRetailAttribute
    {
        private readonly LN.DAL.ShopRetailAttribute dal = new LN.DAL.ShopRetailAttribute();

        public ShopRetailAttribute(){}

        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.ShopRetailAttribute GetModel(int SA_Id)
        {
            return dal.GetModel(SA_Id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.ShopRetailAttribute> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<LN.Model.ShopRetailAttribute> GetList(int TopNum, string strWhere, string filedOrder)
        {
            return dal.GetList(TopNum, strWhere, filedOrder);
        }

        #endregion
    }
}
