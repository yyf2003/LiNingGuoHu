using System;
using System.Data;
using System.Collections.Generic;

namespace LN.BLL
{
    public class ProvinceInDepartment
    {
        private readonly LN.DAL.ProvinceInDepartment dal = new LN.DAL.ProvinceInDepartment();

        public DataSet GetProvincesByDid(int id)
        {
            return dal.GetProvincesByDid(id);
        }

        public DataSet GetList(string where)
        {
            return dal.GetList(where);
        }
    }
}
