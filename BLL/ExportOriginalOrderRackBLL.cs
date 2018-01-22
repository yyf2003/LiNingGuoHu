using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LN.Model;

namespace LN.BLL
{
    public class ExportOriginalOrderRackBLL
    {
        private readonly LN.DAL.ExportOriginalOrderRackDAL dal = new LN.DAL.ExportOriginalOrderRackDAL();

        public int Add(ExportOriginalOrderRack model)
        {
            return dal.Add(model);
        }

        public void Delete(int promitionId, int stortBagId, int shopLevelId)
        {
            dal.Delete(promitionId, stortBagId, shopLevelId);
        }

        public ExportOriginalOrderRack GetModel(string where)
        {
            return dal.GetModel(where);
        }
    }
}
