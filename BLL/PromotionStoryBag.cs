using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LN.Model;
using System.Data;

namespace LN.BLL
{
    public class PromotionStoryBag
    {
        private readonly LN.DAL.PromotionStoryBag dal = new LN.DAL.PromotionStoryBag();
        public int Add(LN.Model.PromotionStoryBag model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
    }
}
