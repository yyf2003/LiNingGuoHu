using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类ProductLineType 的摘要说明。
    /// </summary>
    public class ProductLineType
    {
        private readonly LN.DAL.ProductLineType dal = new LN.DAL.ProductLineType();
        public ProductLineType()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(string typeName, int isDelete)
        {
            return dal.Add(typeName,isDelete);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.ProductLineType model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ProductTypeID)
        {

            dal.Delete(ProductTypeID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.ProductLineType GetModel(int ProductTypeID)
        {

            return dal.GetModel(ProductTypeID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.ProductLineType> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        #endregion  成员方法
    }
}

