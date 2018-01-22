using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;

namespace LN.BLL
{
    public class RackInfo
    {
        private readonly LN.DAL.RackInfo dal = new LN.DAL.RackInfo();

        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.RackInfo model)
        {
            return dal.Add(model);
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
        public LN.Model.RackInfo GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetJoinList(string where)
        {
            return dal.GetJoinList(where);
        }

        public DataSet GetJoinListPage(string where, int currPage, int pageSize)
        { 
           return dal.GetJoinListPage(where, currPage,pageSize);
        }

        public int GetPageCount(string where)
        { 
           return dal.GetPageCount(where);
        }

        public int Update(LN.Model.RackInfo model)
        {
            return dal.Update(model);
        }


        public DataSet GetPropType()
        {
            return dal.GetPropType();
        }

        public List<LN.Model.RackInfo> GetRackList(string strWhere)
        {
            return dal.GetRackList(strWhere);
        }
    }
}
