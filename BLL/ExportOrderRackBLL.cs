using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LN.Model;
namespace LN.BLL
{
    public class ExportOrderRackBLL
    {
        private readonly LN.DAL.ExportOrderRackDAL dal = new LN.DAL.ExportOrderRackDAL();

        public int Add(ExportOrderRack model)
        {
            return dal.Add(model);
        }

        public void Delete(int promitionId, int stortBagId, int shopLevelId)
        {
            dal.Delete(promitionId, stortBagId, shopLevelId);
        }

        public void Delete1(int promitionId, string stortBagIds, int shopLevelId)
        {
            dal.Delete1(promitionId, stortBagIds, shopLevelId);
        }

        public ExportOrderRack GetModel(string where)
        {
            return dal.GetModel(where);
        }
    }
}
