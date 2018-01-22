using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类sysFunction 的摘要说明。
    /// </summary>
    public class sysFunction
    {
        private readonly LN.DAL.sysFunction dal = new LN.DAL.sysFunction();

        public sysFunction()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.sysFunction model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.sysFunction model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            dal.Delete(id);
        }

        /// <summary>
        /// 获取上级功能编号
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回编号集合</returns>
        public IList<int> GetupIdGroup(string strWhere)
        {
            return dal.GetupIdGroup(strWhere);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.sysFunction GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.sysFunction> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
       
        #endregion  成员方法
    }
}

