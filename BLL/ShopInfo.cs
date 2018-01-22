using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类ShopInfo 的摘要说明。
    /// </summary>
    public class ShopInfo
    {
        private readonly LN.DAL.ShopInfo dal = new LN.DAL.ShopInfo();
        public ShopInfo()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.ShopInfo model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// 更新部分数据
        /// </summary>
        /// <param name="model"></param>
        public void UpdateSub(LN.Model.ShopInfo model)
        {
            dal.UpdateSub(model);
        }
        public void Update(LN.Model.EditShopInfo model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {

            dal.Delete(ID);
        }
        /// <summary>
        /// 店铺负责人确认店铺信息
        /// </summary>
        /// <returns></returns>
        public bool ConfirmShopInfo(int ShopID)
        {
            return dal.ConfirmShopInfo(ShopID);
        }
        /// <summary>
        /// 关闭店铺
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public bool CloseShopState(int ShopID, int CloseUserID)
        {
            return dal.CloseShopState(ShopID, CloseUserID);
        }
        /// <summary>
        /// 关闭/新开 店铺
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public bool ChangeShopState(int ShopID, int CloseUserID, int ShopState)
        {
            return dal.ChangeShopState(ShopID, CloseUserID, ShopState);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.ShopInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得一部分数据列表
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataSet GetSublist(string StrWhere)
        {
            return dal.GetSublist(StrWhere);
        }
        /// <summary>
        /// 得到自动完成列表的店铺名称
        /// </summary>
        /// <param name="strShopName"></param>
        /// <returns></returns>
        public DataSet GetAutoComplateShopname(string strShopName)
        {
            return dal.GetAutoComplateShopname(strShopName);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.ShopInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.ShopInfo> modelList = new List<LN.Model.ShopInfo>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.ShopInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.ShopInfo();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ShopID"].ToString() != "")
                    {
                        model.ShopID = int.Parse(ds.Tables[0].Rows[n]["ShopID"].ToString());
                    }
                    model.PosID = ds.Tables[0].Rows[n]["PosID"].ToString();
                    model.Shopname = ds.Tables[0].Rows[n]["Shopname"].ToString();
                    model.ShopAddress = ds.Tables[0].Rows[n]["ShopAddress"].ToString();
                    model.ShopOpenDate = ds.Tables[0].Rows[n]["ShopOpenDate"].ToString();
                    model.ShopCloseDate = ds.Tables[0].Rows[n]["ShopCloseDate"].ToString();
                    if (ds.Tables[0].Rows[n]["CloseUserID"].ToString() != "")
                    {
                        model.CloseUserID = int.Parse(ds.Tables[0].Rows[n]["CloseUserID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ProvinceID"].ToString() != "")
                    {
                        model.ProvinceID = int.Parse(ds.Tables[0].Rows[n]["ProvinceID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["CityID"].ToString() != "")
                    {
                        model.CityID = int.Parse(ds.Tables[0].Rows[n]["CityID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ShopLevelID"].ToString() != "")
                    {
                        model.ShopLevelID = int.Parse(ds.Tables[0].Rows[n]["ShopLevelID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["SaleTypeID"].ToString() != "")
                    {
                        model.SaleTypeID = int.Parse(ds.Tables[0].Rows[n]["SaleTypeID"].ToString());
                    }
                    model.LinkMan = ds.Tables[0].Rows[n]["LinkMan"].ToString();
                    model.LinkPhone = ds.Tables[0].Rows[n]["LinkPhone"].ToString();
                    model.ShopMaster = ds.Tables[0].Rows[n]["ShopMaster"].ToString();
                    model.ShopMasterPhone = ds.Tables[0].Rows[n]["ShopMasterPhone"].ToString();
                    model.Email = ds.Tables[0].Rows[n]["Email"].ToString();
                    model.PostAddress = ds.Tables[0].Rows[n]["PostAddress"].ToString();
                    model.PostCode = ds.Tables[0].Rows[n]["PostCode"].ToString();
                    model.FaxNumber = ds.Tables[0].Rows[n]["FaxNumber"].ToString();
                    if (ds.Tables[0].Rows[n]["Boolinstall"].ToString() != "")
                    {
                        model.Boolinstall = int.Parse(ds.Tables[0].Rows[n]["Boolinstall"].ToString());
                    }
                    model.DealerID = ds.Tables[0].Rows[n]["DealerID"].ToString();
                    model.Fxid = ds.Tables[0].Rows[n]["FXID"].ToString();
                    if (ds.Tables[0].Rows[n]["ShopState"].ToString() != "")
                    {
                        model.ShopState = int.Parse(ds.Tables[0].Rows[n]["ShopState"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ExamState"].ToString() != "")
                    {
                        model.ExamState = int.Parse(ds.Tables[0].Rows[n]["ExamState"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        /// <summary>
        /// 得到店铺和pop信息
        /// </summary>
        /// <param name="hdt"></param>
        /// <returns></returns>
        public DataTable GetShop_POP_infolist(Hashtable hdt)
        {
            return dal.GetShop_POP_infolist(hdt);
        }

        /// <summary>
        /// 得到店铺信息
        /// </summary>
        /// <param name="hdt"></param>
        /// <returns></returns>
        public DataTable GetShop_infolist(Hashtable hdt)
        {
            return dal.GetShop_infolist(hdt);
        }
        /// <summary>
        /// 得到 店铺数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetInfolist(Hashtable hdt, ref int TotalNumber)
        {
            return dal.GetInfolist(hdt, ref TotalNumber);
        }

        /// <summary>
        /// 得到 店铺数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetShopInfoByPOPIDAndShopID(Hashtable hdt, ref int TotalNumber)
        {
            return dal.GetShopInfoByPOPIDAndShopID(hdt, ref TotalNumber);
        }

        /// <summary>
        /// 得到店铺列表
        /// </summary>
        /// <param name="hdt"></param>
        /// <param name="TotalNumber">记录总数目</param>
        /// <returns></returns>
        public DataTable GetShopPOPSetupList(Hashtable hdt, ref int TotalNumber)
        {
            return dal.GetShopPOPSetupList(hdt, ref TotalNumber);
        }

        /// <summary>
        /// 得到店铺列表
        /// </summary>
        /// <param name="hdt"></param>
        /// <param name="TotalNumber">记录总数目</param>
        /// <returns></returns>
        public DataTable GetShopPOPSetupJudgeList(Hashtable hdt, ref int TotalNumber)
        {
            return dal.GetShopPOPSetupJudgeList(hdt, ref TotalNumber);
        }

        /// <summary>
        /// 根据登录人信息.得到管理的店铺
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public DataTable GetShopInfoWithShopMaster(string User)
        {
            return dal.GetShopInfoWithShopMaster(User);
        }
        /// <summary>
        /// 获得数据AJAX分页列表
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回获取店铺列表集合</returns>
        public DataTable GetShopListBySupplierID(LN.Model.PageModel model, out int TotalNumber)
        {
            return dal.GetShopListBySupplierID(model, out TotalNumber);
        }

        /// <summary>
        /// 获取供应商负责的店铺列表（不分页）不排序
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回获取店铺列表集合</returns>
        public DataTable GetAllShopListBySupplierID(string hidSupplierID, string strWhere)
        {
            return dal.GetAllShopListBySupplierID(hidSupplierID, strWhere);
        }

        /// <summary>
        /// 获取供应商负责的店铺列表（不分页）排序
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回获取店铺列表集合</returns>
        public DataTable GetAllShopListBySuppliersID(string hidSupplierID, string strWhere)
        {
            return dal.GetAllShopListBySuppliersID(hidSupplierID, strWhere);
        }

        /// <summary>
        /// 得到店铺信息根据供应商ID
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetShopInfoWithSupplierID(string strWhere)
        {
            return dal.GetShopInfoWithSupplierID(strWhere);
        }

        /// <summary>
        /// 获取指定编号的名称
        /// </summary>
        /// <param name="ShopID">店铺编号</param>
        /// <param name="SupplierID">供应商编号</param>
        /// <param name="POPID">POP发起ID</param>
        /// <param name="DealreID">一级客户编号</param>
        /// <returns>返回各项名称集合</returns>
        public DataTable GetInfoByID(int ShopID, int SupplierID, string POPID, string DealreID)
        {
            return dal.GetInfoByID(ShopID, SupplierID, POPID, DealreID);
        }
        /// <summary>
        /// 更新店铺的审核状态
        /// </summary>
        /// <param name="StrWhere"></param>
        public void UpdateExamState(int examState, string UserID, string StrWhere)
        {
            dal.UpdateExamState(examState, UserID, StrWhere);
        }
        /// <summary>
        /// 省区VM审核新增店铺
        /// </summary>
        /// <param name="examState"></param>
        /// <param name="UserID"></param>
        /// <param name="StrWhere"></param>
        public void VMUpdateExamState(int examState, string UserID, string StrWhere)
        {
            dal.VMUpdateExamState(examState, UserID, StrWhere);
        }
        /// <summary>
        /// 通过PosID得到相应的店铺名称
        /// </summary>
        /// <param name="PosID"></param>
        /// <returns></returns>
        public DataTable GetShopNameByPosID(string PosID)
        {
            return dal.GetShopNameByPosID(PosID);
        }

        /// <summary>
        /// 判断指定店铺是否是FOS店
        /// </summary>
        /// <param name="ShopID">店铺编号</param>
        /// <returns>返回1：是，0：否</returns>
        public int GetSaleTypeID(int ShopID)
        {
            return dal.GetSaleTypeID(ShopID);
        }
        #endregion  成员方法
    }
}

