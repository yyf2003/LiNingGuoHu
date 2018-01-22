using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;

namespace LN.BLL
{
    public class RackInShop
    {
        private readonly LN.DAL.RackInShop dal = new LN.DAL.RackInShop();

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
        public int Add(LN.Model.RackInShop model)
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

        public void Delete(string whereStr)
        {
            dal.Delete(whereStr);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.RackInShop GetModel(int id)
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

        public DataSet GetJoinList(int PromotionId, int StoryBagId, string where)
        {
            return dal.GetJoinList(PromotionId,StoryBagId,where);
        }

        //public DataSet GetJoinList1(int PromotionId, string StoryBagIds, string where)
        //{
        //    return dal.GetJoinList1(PromotionId, StoryBagIds, where);
        //}

        public DataSet GetJoinList1(int PromotionId, string StoryBagIds, int shopLevelId)
        {
            return dal.GetJoinList1(PromotionId, StoryBagIds, shopLevelId);
        }

        public DataSet GetJoinList2(int PromotionId, string StoryBagIds)
        {
            return dal.GetJoinList2(PromotionId, StoryBagIds);
        }

        public List<LN.Model.RackInShop> GetRackList(string where)
        {
            return dal.GetRackList(where);
        }

        public DataSet GetFinalRackList(int PromotionId, int StoryBagId, string where)
        {
            return dal.GetFinalRackList(PromotionId, StoryBagId, where);
        }

        public DataSet GetFinalRackList1(int PromotionId, string StoryBagIds, string where,string rackIds=null)
        {
            return dal.GetFinalRackList1(PromotionId, StoryBagIds, where, rackIds);
        }

        public DataSet GetPomosionRackList(int PromotionId, string StoryBagIds, string rackIds)
        {
            return dal.GetPomosionRackList(PromotionId, StoryBagIds, rackIds);
        }

        public DataSet GetJoinRackList(string where)
        {
            return dal.GetJoinRackList(where);
        }
    }
}
