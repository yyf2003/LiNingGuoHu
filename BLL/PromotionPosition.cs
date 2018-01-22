using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace LN.BLL
{
    public class PromotionPosition
    {
        private readonly LN.DAL.PromotionPosition dal = new LN.DAL.PromotionPosition();

        public int Add(LN.Model.PromotionPosition model)
        {
            return dal.Add(model);
        }

        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }

        public bool Update(LN.Model.PromotionPosition model)
        {
            return dal.Update(model);
        }

    }
}
