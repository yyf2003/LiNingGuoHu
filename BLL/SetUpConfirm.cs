using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类SetUpConfirm 的摘要说明。
    /// </summary>
    public class SetUpConfirm
    {
        private readonly LN.DAL.SetUpConfirm dal = new LN.DAL.SetUpConfirm();
        public SetUpConfirm()
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
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.SetUpConfirm model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.SetUpConfirm model)
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
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.SetUpConfirm GetModel(int ID)
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
        /// 从视图里返回数据结果
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetListFromView(string strWhere)
        {
            return dal.GetListFromView(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.SetUpConfirm> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.SetUpConfirm> modelList = new List<LN.Model.SetUpConfirm>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.SetUpConfirm model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.SetUpConfirm();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["DealerID"].ToString() != "")
                    {
                        model.DealerID = ds.Tables[0].Rows[n]["DealerID"].ToString();
                    }
                    if (ds.Tables[0].Rows[n]["Shopid"].ToString() != "")
                    {
                        model.Shopid = int.Parse(ds.Tables[0].Rows[n]["Shopid"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["SupplierID"].ToString() != "")
                    {
                        model.SupplierID = int.Parse(ds.Tables[0].Rows[n]["SupplierID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["POPID"].ToString() != "")
                    {
                        model.POPID = ds.Tables[0].Rows[n]["POPID"].ToString();
                    }
                    if (ds.Tables[0].Rows[n]["SetUpCount"].ToString() != "")
                    {
                        model.SetUpCount = int.Parse(ds.Tables[0].Rows[n]["SetUpCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["SetUpState"].ToString() != "")
                    {
                        model.SetUpState = int.Parse(ds.Tables[0].Rows[n]["SetUpState"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["OperatorID"].ToString() != "")
                    {
                        model.OperatorID = int.Parse(ds.Tables[0].Rows[n]["OperatorID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Boolinstall"].ToString() != "")
                    {
                        model.Boolinstall = int.Parse(ds.Tables[0].Rows[n]["Boolinstall"].ToString());
                    }
                    model.OperatorDate = ds.Tables[0].Rows[n]["OperatorDate"].ToString();
                    model.SetUpDesc = ds.Tables[0].Rows[n]["SetUpDesc"].ToString();
                    model.PicUrl = ds.Tables[0].Rows[n]["PicUrl"].ToString();
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
        /// 返回查询的安装店铺数量
        /// </summary>
        /// <param name="SupplierID">供应商ID</param>
        /// <param name="DealerID">一级客户ID</param>
        /// <param name="AreaID">区域ID</param>
        /// <param name="ProviceID">省份ID</param>
        /// <param name="CityID">市ID</param>
        /// <param name="Boolinstall">是否支持安装  1 支持 0 ，不支持，自主安装</param>
        /// <returns></returns>
        public DataTable GetSetUpConfirmSearch(int SupplierID, string DealerID,string FXID, int AreaID, int ProviceID, int CityID,string popid,string begindate,string enddate,string department,int boolinstall)
        {
            return dal.GetSetUpConfirmSearch(SupplierID, DealerID, FXID, AreaID, ProviceID, CityID, popid,begindate, enddate, department, boolinstall);
        }
        /// <summary>
        /// 查询已经完成安装的数据
        /// </summary>
        /// <param name="DealerID">一级客户ID</param>
        /// <param name="SupplierID">供应商ID</param>
        /// <param name="POPID">POPID</param>
        /// <param name="Boolinstall">安装类型</param>
        /// <returns></returns>
        public DataTable GetSetUpConfirmSearch2(string DealerID, int SupplierID, string POPID, int Boolinstall)
        {
            return dal.GetSetUpConfirmSearch2(DealerID, SupplierID, POPID, Boolinstall);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
    }
}

