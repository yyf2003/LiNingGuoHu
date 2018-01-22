using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LN.DAL;

namespace LN.BLL
{
    public class FinalPromotionShops
    {
        private readonly LN.DAL.FinalPromotionShops dal = new LN.DAL.FinalPromotionShops();

        public int Add(LN.Model.FinalPromotionShops model)
        {
            return dal.Add(model);
        }

        public bool DeleteByPromotionId(int promotionId)
        {
            return dal.DeleteByPromotionId(promotionId);
        }

        public bool DeleteByStoryBagApplyId(int promotionId, int storyBagApplyId, string bigArea)
        {
            return dal.DeleteByStoryBagApplyId(promotionId, storyBagApplyId, bigArea);
        }

        public bool DeleteByStoryBagApplyIds(int promotionId, string storyBagApplyIds, string bigArea)
        {
            return dal.DeleteByStoryBagApplyIds(promotionId, storyBagApplyIds, bigArea);
        }

        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }

        public DataSet GetJoinList(string where)
        {
            return dal.GetJoinList(where);
        }

        public DataSet GetJoinShopList(string where)
        {
            return dal.GetJoinShopList(where); 
        }

        public void Update(LN.Model.FinalPromotionShops model)
        {
            dal.Update(model);
        }

        public void DeleteAll()
        {
            dal.DeleteAll();
        }

        public List<LN.Model.PromotionShopInfo> GetShopList(string where)
        {
            return dal.GetShopList(where);
        }

        public void Delete(string where)
        {
            dal.Delete(where);
        }
    }
}
