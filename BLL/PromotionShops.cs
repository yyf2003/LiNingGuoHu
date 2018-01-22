using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LN.BLL
{
    public class PromotionShops
    {
        private readonly LN.DAL.PromotionShops dal = new LN.DAL.PromotionShops();

        public int Add(LN.Model.PromotionShops model)
        {
            return dal.Add(model);
        }

        public bool DeleteByPromotionId(int pid)
        {
            return dal.DeleteByPromotionId(pid);
        }

        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }

        public DataSet GetJoinList(string where)
        {
            return dal.GetJoinList(where);
        }


        public bool Update(LN.Model.PromotionShops model)
        {
            return dal.Update(model);
        }

        public IList<LN.Model.PromotionShops> GetDataList(string where)
        {
            return dal.GetDataList(where);
        }

        public int GetPageCount(string where)
        {
            return dal.GetPageCount(where);
        }

        public DataSet GetPageList(string where, int currPage, int pageSize)
        {
            return dal.GetPageList(where, currPage, pageSize);
        }

        public LN.Model.PromotionShops GetModel(int id)
        {
            return dal.GetModel(id);
        }
    }
}
