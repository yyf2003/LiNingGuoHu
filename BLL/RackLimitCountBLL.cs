using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
using LN.DAL;

namespace LN.BLL
{
    public class RackLimitCountBLL
    {
        private readonly LN.DAL.RackLimitCountDAL dal = new LN.DAL.RackLimitCountDAL();

        public int Add(RackLimitCount model)
        {
            return dal.Add(model);
        }

        public void Update(RackLimitCount model)
        {
            dal.Update(model);
        }

        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }

        public RackLimitCount GetModel(string where)
        {
            return dal.GetModel(where);
        }
    }
}
