using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;

namespace LN.BLL
{
    public class OrderUpdateLog
    {
        private readonly LN.DAL.OrderUpdateLogDAL dal = new LN.DAL.OrderUpdateLogDAL();

        public int Add(LN.Model.OrderUpdateLog model)
        {
            return dal.Add(model);
        }

        public void delete(int promotionId, int storyBagId, string bigArea)
        {
            dal.delete(promotionId, storyBagId, bigArea);
        }

        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }
    }
}
