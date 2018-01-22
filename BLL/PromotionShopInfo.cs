using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LN.BLL
{
    public class PromotionShopInfo
    {
        private readonly LN.DAL.PromotionShopInfo dal = new LN.DAL.PromotionShopInfo();
        public int Add(LN.Model.PromotionShopInfo model)
        {
            return dal.Add(model);
        }

        public bool Update(LN.Model.PromotionShopInfo model)
        {
            return dal.Update(model);
        }

        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public DataSet GetList(string whereStr)
        {
            return dal.GetList(whereStr);
        }

        public DataSet GetJoinList(string whereStr)
        {
            return dal.GetJoinList(whereStr);
        }

        public DataSet GetList(string whereStr, int currPage, int pageSize)
        {
            return dal.GetList(whereStr, currPage, pageSize);
        }

        public int GetPageCount(string whereStr)
        {
            return dal.GetPageCount(whereStr);
        }

        public LN.Model.PromotionShopInfo GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public LN.Model.PromotionShopInfo GetModel(string whereStr)
        {
            return dal.GetModel(whereStr);
        }

        public DataSet GetJoinList(string whereStr, string rackType, string rackOperater, int rackNum, int currPage, int pageSize, out int totalRecord)
        { 
            return dal.GetJoinList(whereStr, rackType, rackOperater, rackNum, currPage, pageSize, out totalRecord);
        }

        public List<LN.Model.PromotionShopInfo> GetDataList(string whereStr)
        {
            return dal.GetDataList(whereStr);
        }
    }
}
