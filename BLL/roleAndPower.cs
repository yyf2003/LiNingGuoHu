using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类roleAndPower 的摘要说明。
    /// </summary>
    public class roleAndPower
    {
        private readonly LN.DAL.roleAndPower dal = new LN.DAL.roleAndPower();
        public roleAndPower()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.roleAndPower model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(LN.Model.roleAndPower model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.roleAndPower GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.roleAndPower> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        #endregion  成员方法
    }
}

