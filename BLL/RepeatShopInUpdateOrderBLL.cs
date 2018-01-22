using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LN.Model;

namespace LN.BLL
{
    public class RepeatShopInUpdateOrderBLL
    {
        private readonly LN.DAL.RepeatShopInUpdateOrderDAL dal = new LN.DAL.RepeatShopInUpdateOrderDAL();

        public int Add(RepeatShopInUpdateOrder model)
        {
            return dal.Add(model);
        }

        
        public void Delete(int promitionId, int stortBagId)
        {
            dal.Delete(promitionId, stortBagId);
        }

        public DataSet GetList(int PromitionId, int StoryBagId)
        {
            return dal.GetList(PromitionId, StoryBagId);
        }

        public DataSet GetList1(int PromitionId, string StoryBagIds)
        {
            return dal.GetList1(PromitionId, StoryBagIds);
        }
    }
}
