using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LN.DAL;

namespace LN.BLL
{
    public class UpdateOrderLogBLL
    {
        private readonly LN.DAL.UpdateOrderLogDAL dal = new LN.DAL.UpdateOrderLogDAL();
        public int Add(LN.Model.UpdateOrderLog model)
        {
            return dal.Add(model);
        }

        public void Update(LN.Model.UpdateOrderLog model)
        {
            dal.Update(model);
        }

        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }
    }
}
