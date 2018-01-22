using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;

namespace LN.BLL
{
    public class PromotionPOPOrder
    {
        private readonly LN.DAL.PromotionPOPOrder dal = new LN.DAL.PromotionPOPOrder();
        public int Add(LN.Model.PromotionPOPOrder model)
        {
            return dal.Add(model);
        }

        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }

        public DataSet LoadOut(string where)
        {
            return dal.LoadOut(where);
        }

        public bool DeleteByPromotionId(int pid)
        {
            return dal.DeleteByPromotionId(pid);
        }

        public bool DeleteById(int id)
        {
            return dal.DeleteById(id);
        }

        public int GetPageCount(string where)
        {
            return dal.GetPageCount(where);
        }

        public DataSet GetPage(string where, int currPage, int pageSize)
        {
            return dal.GetPage(where, currPage, pageSize);
        }

        public bool Update(LN.Model.PromotionPOPOrder model)
        {
            return dal.Update(model);
        }
    }
}
