using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace LN.BLL
{
    public class PromotionProductLines
    {
        private readonly LN.DAL.PromotionProductLines dal = new LN.DAL.PromotionProductLines();
        
        public PromotionProductLines() { }

        public int Add(LN.Model.PromotionProductLines model)
        {
            return dal.Add(model);
        }

        public void DeleteByPromotionId(string PromotionId)
        {
            dal.DeleteByPromotionId(PromotionId);
        }

        public void DeleteById(int Id)
        {
            dal.DeleteById(Id);
        }

        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }


        
    }
}
