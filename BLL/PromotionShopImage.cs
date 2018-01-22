using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LN.Model;
using System.Data;

namespace LN.BLL
{
    public class PromotionShopImage
    {
        private readonly LN.DAL.PromotionShopImage dal = new LN.DAL.PromotionShopImage();
        public DataSet GetList(string whereStr)
        {
            return dal.GetList(whereStr);
        }

    }
}
