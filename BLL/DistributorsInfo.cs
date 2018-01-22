using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类DistributorsInfo 的摘要说明。
    /// </summary>
    public class DistributorsInfo
    {
        private readonly LN.DAL.DistributorsInfo dal = new LN.DAL.DistributorsInfo();
        public DistributorsInfo()
        { }
        #region  成员方法
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
        public int Add(LN.Model.DistributorsInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.DistributorsInfo model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string FXID)
        {
            return dal.Delete(FXID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.DistributorsInfo GetModel(string FXID)
        {

            return dal.GetModel(FXID);
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
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.DistributorsInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.DistributorsInfo> DataTableToList(DataTable dt)
        {
            List<LN.Model.DistributorsInfo> modelList = new List<LN.Model.DistributorsInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.DistributorsInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.DistributorsInfo();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.FXID = dt.Rows[n]["FXID"].ToString();
                    model.FXName = dt.Rows[n]["FXName"].ToString();
                    model.FXContactor = dt.Rows[n]["FXContactor"].ToString();
                    model.FXPhone = dt.Rows[n]["FXPhone"].ToString();
                    model.FXtel = dt.Rows[n]["FXtel"].ToString();
                    model.DealerID = dt.Rows[n]["DealerID"].ToString();
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
        /// 根据城市的id获取直属客户的列表
        /// </summary>
        /// <param name="CityID"></param>
        public DataTable GetFXinfolistBy(string CityID)
        {
            return dal.GetFXinfolistBy(CityID);
        }

        /// <summary>
        /// 根据城市的id获取直属客户的列表
        /// </summary>
        /// <param name="CityID"></param>
        public DataTable GetFXinfolistsBy(string DealerID)
        {
            return dal.GetFXinfolistsBy(DealerID);
        }

        /// <summary>
        /// 根据条件得到直属客户的ID和直属客户名字
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetIDName(string strWhere)
        {
            return dal.GetIDName(strWhere);
        }

        /// <summary>
        /// 获取指定用户是否是直属客户
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>返回直属客户编号</returns>
        public string GetFXIdByUserID(string UserID)
        {
            return dal.GetFXIdByUserID(UserID);
        }

        /// <summary>
        /// 获得数据AJAX分页列表
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回获取直属客户列表集合</returns>
        public DataTable GetListPageByWhere(LN.Model.PageModel model, out int TotalNumber)
        {
            return dal.GetListPageByWhere(model, out TotalNumber);
        }
        /// <summary>
        /// 根据FXID得到一个直属客户的详细信息
        /// </summary>
        /// <param name="FXID"></param>
        /// <returns></returns>
        public DataTable GetOneFX(string FXID)
        {
            return dal.GetOneFX(FXID);
        }

        /// <summary>
        ///  得到要审批的直属客户
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetFXinfolist(string strwhere)
        {
            return dal.GetFXinfolist(strwhere);
        }
        /// <summary>
        /// 部门经理审核直属客户的所从属的一级客户
        /// </summary>
        /// <param name="examState"></param>
        /// <param name="userID"></param>
        /// <param name="Strwhere"></param>
        public void ExamFXofDealer(string examState, string userID, string Strwhere)
        {
            dal.ExamFXofDealer(examState, userID, Strwhere);
        }
        /// <summary>
        /// 省区VM审核直属客户的所从属的一级客户
        /// </summary>
        /// <param name="VMexamState"></param>
        /// <param name="UserID"></param>
        /// <param name="Strwhere"></param>
        public void VMExamFXofDealer(string VMexamState, string UserID, string Strwhere)
        {
            dal.VMExamFXofDealer(VMexamState, UserID, Strwhere);
        }
        #endregion  成员方法
    }
}

