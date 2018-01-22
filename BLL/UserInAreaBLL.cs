using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LN.BLL
{
    public class UserInAreaBLL
    {
        private readonly LN.DAL.UserInAreaDAL dal = new LN.DAL.UserInAreaDAL();

        public int Add(LN.Model.UserInArea model)
        {
            return dal.Add(model);
        }

        public void DeleteByUserId(int userid)
        {
            dal.DeleteByUserId(userid);
        }

        public DataSet GetList(int userId)
        {
            return dal.GetList(userId);
        }

        public DataTable GetAreaByUserId(string userid)
        {
            return dal.GetAreaByUserId(userid);
        }
    }
}
