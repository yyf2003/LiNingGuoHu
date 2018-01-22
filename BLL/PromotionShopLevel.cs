using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LN.BLL
{
    public class PromotionShopLevel
    {
        private readonly LN.DAL.PromotionShopLevel dal = new LN.DAL.PromotionShopLevel();
        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }

        public void Update(LN.Model.PromotionShopLevel model)
        {
            dal.Update(model);
        }
    }
}
