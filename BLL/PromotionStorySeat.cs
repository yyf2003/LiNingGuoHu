using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LN.Model;
using System.Data;

namespace LN.BLL
{
    public class PromotionStorySeat
    {
        private readonly LN.DAL.PromotionStorySeat dal = new LN.DAL.PromotionStorySeat();

        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.PromotionStorySeat model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            dal.Delete(id);
        }

        public void DeleteByPromotionId(int pid)
        {
            dal.DeleteByPromotionId(pid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.PromotionStorySeat GetModel(int id)
        {
           return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetStoryBags(int promotionId)
        {
            return dal.GetStoryBags(promotionId);
        }
    }
}
