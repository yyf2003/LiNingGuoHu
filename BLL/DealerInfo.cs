using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类DealerInfo 的摘要说明。
    /// </summary>
    public class DealerInfo
    {
        private readonly LN.DAL.DealerInfo dal = new LN.DAL.DealerInfo();
        public DealerInfo()
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
        public int Add(LN.Model.DealerInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.DealerInfo model)
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
        public LN.Model.DealerInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 从店铺表中城市的ID筛选得到一级客户的列表
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerInfoListBy(string CityID)
        {
            return dal.GetDealerInfoListBy(CityID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.DealerInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.DealerInfo> modelList = new List<LN.Model.DealerInfo>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.DealerInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.DealerInfo();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["DealerID"].ToString() != "")
                    {
                        model.DealerID = ds.Tables[0].Rows[n]["DealerID"].ToString();
                    }
                    model.DealerName = ds.Tables[0].Rows[n]["DealerName"].ToString();
                    if (ds.Tables[0].Rows[n]["AreaID"].ToString() != "")
                    {
                        model.AreaID = int.Parse(ds.Tables[0].Rows[n]["AreaID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ProvinceID"].ToString() != "")
                    {
                        model.ProvinceID = int.Parse(ds.Tables[0].Rows[n]["ProvinceID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["CityID"].ToString() != "")
                    {
                        model.CityID = int.Parse(ds.Tables[0].Rows[n]["CityID"].ToString());
                    }
                    model.Contactor = ds.Tables[0].Rows[n]["Contactor"].ToString();
                    model.ContactorPhone = ds.Tables[0].Rows[n]["ContactorPhone"].ToString();
                    model.Address = ds.Tables[0].Rows[n]["Address"].ToString();
                    model.PostAddress = ds.Tables[0].Rows[n]["PostAddress"].ToString();
                    model.DealerChannel = ds.Tables[0].Rows[n]["DealerChannel"].ToString();
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
        /// 得到一级客户的列表
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerInfoList(string StrWhere)
        {
            return dal.GetDealerInfoList(StrWhere);
        }
        /// <summary>
        /// 得到一级客户ID和一级客户名称
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerName(string StrWhere)
        {
            return dal.GetDealerName(StrWhere);
        }
        /// <summary>
        /// 得到一级客户ID和一级客户名称通过登录人名称
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDealerByUserName(string StrWhere)
        {
            return dal.GetDealerByUserName(StrWhere);
        }
        /// <summary>
        /// 获取指定供应商所供应的一级客户集合
        /// </summary>
        /// <param name="SupplierID">供应商编号</param>
        /// <returns></returns>
        public DataTable GetDealerNameBySupplierID(string SupplierID)
        {
            return dal.GetDealerNameBySupplierID(SupplierID);
        }
        /// <summary>
        /// 部门经理审核新增一级客户
        /// </summary>
        /// <param name="examState"></param>
        /// <param name="UserID"></param>
        /// <param name="StrWhere"></param>
        public void ExamNewdealer(int examState, int UserID, string StrWhere)
        {
            dal.ExamNewdealer(examState, UserID, StrWhere);
        }
        /// <summary>
        /// 区域VM经理审核新增一级客户
        /// </summary>
        /// <param name="examstate"></param>
        /// <param name="UserID"></param>
        /// <param name="StrWhere"></param>
        public void VMExamNewDealer(int examState, int UserID, string StrWhere)
        {
            dal.VMExamNewDealer(examState, UserID, StrWhere);
        }
        #endregion  成员方法
    }
}

