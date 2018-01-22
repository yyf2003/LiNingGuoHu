using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类imageToPOPTemp 的摘要说明。
    /// </summary>
    public class imageToPOPTemp
    {
        private readonly LN.DAL.imageToPOPTemp dal = new LN.DAL.imageToPOPTemp();
        public imageToPOPTemp()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.imageToPOPTemp model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string str)
        {

            dal.Delete(str);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 判断店铺POP是否全部提交订单
        /// </summary>
        /// <param name="POPID">指定POP发起编号</param>
        /// <param name="ShopID">店铺编号</param>
        /// <returns>返回是否全部提交订单</returns>
        public int POPUniformSubmit(string ShopID)
        {
            return dal.POPUniformSubmit(ShopID);
        }


        #endregion  成员方法
    }
}

