using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LN.DAL;

namespace LN.BLL
{
    public class SupplierArea
    {
        private readonly LN.DAL.SupplierArea dal = new LN.DAL.SupplierArea();

        public int Add(LN.Model.SupplierArea model)
        {
            return dal.Add(model);
        }

        public DataSet GetList(string whereStr)
        {
            return dal.GetList(whereStr);
        }

        public bool DeleteBySuppliterId(int supplierId)
        {
            return dal.DeleteBySuppliterId(supplierId);
        }


        public DataSet GetAreaBySupplierId(int id)
        {
            return dal.GetAreaBySupplierId(id);
        }

    }
}
