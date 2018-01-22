using System;
using System.Data;
using System.Collections.Generic;
using System.Data;


namespace LN.BLL
{
    public class Promotion
    {
        private readonly LN.DAL.Promotion dal = new LN.DAL.Promotion();
        public int Add(LN.Model.Promotion model)
        {
            return dal.Add(model);
        }

        public bool Update(LN.Model.Promotion model)
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

        public DataSet GetList(string whereStr, int currPage, int pageSize)
        {
            return dal.GetList(whereStr, currPage, pageSize);
        }

        public int GetPageCount(string whereStr)
        {
            return dal.GetPageCount(whereStr);
        }

        public LN.Model.Promotion GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public DataSet GetRackInfo(int promotionId, int? storyBagId = null)
        {
            return dal.GetRackInfo(promotionId, storyBagId);
        }

        public DataSet GetRackInfo(string where)
        {
            return dal.GetRackInfo(where);
        }

        public DataSet GetExportRackInfo(int promotionId, int storyBagId)
        {
            return dal.GetExportRackInfo(promotionId, storyBagId);
        }

        public DataSet GetExportRackInfo(int promotionId, string storyBagIds)
        {
            return dal.GetExportRackInfo(promotionId, storyBagIds);
        }
    }
}
