using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LN.DAL;

namespace LN.BLL
{
    public class PromotionSonStoryBag
    {
        private readonly LN.DAL.PromotionSonStoryBag dal = new LN.DAL.PromotionSonStoryBag();

        public int Add(LN.Model.PromotionSonStoryBag model)
        {
            return dal.Add(model);
        }

        public DataSet GetList(int promotionId)
        {
            return dal.GetList(promotionId);
        }

        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }

        public bool DeleteByPromotionId(int promotionId)
        {
            return dal.DeleteByPromotionId(promotionId);
        }

        public Model.PromotionSonStoryBag GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public List<Model.PromotionSonStoryBag> GetDataList(string whereStr)
        {
            return dal.GetDataList(whereStr);
        }

    }
}
