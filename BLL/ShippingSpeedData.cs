using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类ShippingSpeedData 的摘要说明。
    /// </summary>
    public class ShippingSpeedData
    {
        private readonly LN.DAL.ShippingSpeedData dal = new LN.DAL.ShippingSpeedData();
        public ShippingSpeedData()
        { }
        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(List<string> strSql)
        {
            return dal.Add(strSql);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.ShippingSpeedData GetModel(int ID)
        {

            return dal.GetModel(ID);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.ShippingSpeedData> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
 
        
        /// <summary>
        /// 返回ShippingSpeedData中的数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetShippingPOPDataDone(string strWhere)
        {
            return dal.GetShippingPOPDataDone(strWhere);
        }
        /// <summary>
        /// 得到已经发送pop数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetShippingPOPData(int SupplierID)
        {
            return dal.GetShippingPOPData(SupplierID);
        }
            /// <summary>
        /// 收货操作
        /// </summary>
        /// <param name="POPID"></param>
        /// <param name="rdate"></param>
        /// <param name="userid"></param>
        /// <param name="fs"></param>
        /// <param name="pj"></param>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public int RecevieGoods(string POPID, string rdate, string userid, string fs, string pj, string shopid)
        {
            return dal.RecevieGoods(POPID,  rdate,  userid,  fs,  pj,  shopid);
        }

         /// <summary>
        /// 分析的POP列表
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public DataSet GetShippingPOPDataInfo(int shopid, string popid)
        {
            return dal.GetShippingPOPDataInfo(shopid, popid);
        }

        /// <summary>
        /// 一级客户查找已经安装的店铺列表
        /// </summary>
        /// <param name="DealerID">一级客户编号</param>
        /// <param name="FXID">直属客户编号</param>
        /// <param name="ShopID">店铺编号</param>
        /// <param name="ShopName">店铺名称</param>
        /// <param name="OrderField">排序字段</param>
        /// <param name="pageSize">每页显示店铺列表的个数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="TotalRecord">店铺数量</param>
        /// <returns>返回列表集合</returns>
        public DataTable GetConfirmShopListByDealerID(string DealerID, string FXID, string ShopID, string ShopName, string OrderField, int pageSize, int pageIndex, ref int TotalRecord)
        {
            return dal.GetConfirmShopListByDealerID(DealerID, FXID, ShopID, ShopName, OrderField, pageSize, pageIndex, ref TotalRecord);
        }

        /// <summary>
        /// 直属客户查找已经安装的店铺列表
        /// </summary>
        /// <param name="FXID">直属客户编号</param>
        /// <param name="ShopID">店铺POS_Code编号</param>
        /// <param name="ShopName">店铺名称</param>
        /// <param name="OrderField">排序字段</param>
        /// <param name="pageSize">每页显示店铺列表的个数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="TotalRecord">店铺数量</param>
        /// <returns>返回列表集合</returns>
        public DataTable GetConfirmShopListByFXID(string FXID, string ShopID, string ShopName, string OrderField, int pageSize, int pageIndex, ref int TotalNumber)
        {
            return dal.GetConfirmShopListByFXID(FXID, ShopID, ShopName, OrderField, pageSize, pageIndex, ref TotalNumber);
        }
             /// <summary>
        /// 得到收发货表中的店铺的基本信息
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetSubList(string StrWhere)
        {
            return dal.GetSubList(StrWhere);
        }

           /// <summary>
        /// 得到相应的发货单号
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetFHID(string strWhere)
        {
            return dal.GetFHID(strWhere);
        }

            /// <summary>
        /// 得到发货列表
        /// </summary>
        /// <param name="strwhere"></param>
        /// <param name="popid"></param>
        /// <param name="fhtype"></param>
        /// <returns></returns>
        public DataSet GetFHAnaysis(string strwhere, string popid, string fhtype,string beginDate,string endDate)
        {
            return dal.GetFHAnaysis(strwhere, popid, fhtype, beginDate,endDate);
        }

        /// <summary>
        /// 得到收货列表
        /// </summary>
        /// <param name="strwhere"></param>
        /// <param name="popid"></param>
        /// <param name="fhtype"></param>
        /// <returns></returns>
        public DataSet GetSHAnaysis(string strwhere)
        {
            return dal.GetSHAnaysis(strwhere);
        }
        #endregion  成员方法
    }
}

