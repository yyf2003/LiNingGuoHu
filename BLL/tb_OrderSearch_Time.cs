using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;

namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类tb_OrderSearch_Time 的摘要说明。
    /// </summary>
    public class tb_OrderSearch_Time
    {
        private readonly LN.DAL.tb_OrderSearch_Time dal = new LN.DAL.tb_OrderSearch_Time();

        public tb_OrderSearch_Time() { }

        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.tb_OrderSearch_Time model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 根据POPID获取最后下载订单的时间
        /// </summary>
        /// <param name="POPID">制定POPID</param>
        /// <returns>返回时间</returns>
        public string GetOrderSearchByPOPID(string POPID,int UserID)
        {
            return dal.GetOrderSearchByPOPID(POPID, UserID);
        }

        #endregion
    }
}
