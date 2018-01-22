using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类POPReprotDamage 的摘要说明。
    /// </summary>
    public class POPReprotDamage
    {
        private readonly LN.DAL.POPReprotDamage dal = new LN.DAL.POPReprotDamage();
        public POPReprotDamage()
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
        public int Add(LN.Model.POPReprotDamage model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.POPReprotDamage model)
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
        /// VM检查报损坏
        /// </summary>
        /// <param name="UserID">VM UserID</param>
        /// <param name="VMDesc">描述</param>
        /// <param name="date">检查日期</param>
        public void VMCheckReprotDamage(int UserID, string VMDesc, string date, int ID)
        {
            dal.VMCheckReprotDamage(UserID, VMDesc, date, ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.POPReprotDamage GetModel(int ID)
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
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.POPReprotDamage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.POPReprotDamage> modelList = new List<LN.Model.POPReprotDamage>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.POPReprotDamage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.POPReprotDamage();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ShopID"].ToString() != "")
                    {
                        model.ShopID = int.Parse(ds.Tables[0].Rows[n]["ShopID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["SupplierID"].ToString() != "")
                    {
                        model.SupplierID = int.Parse(ds.Tables[0].Rows[n]["SupplierID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UpUserID"].ToString() != "")
                    {
                        model.UpUserID = int.Parse(ds.Tables[0].Rows[n]["UpUserID"].ToString());
                    }
                    model.UpPOPDate = ds.Tables[0].Rows[n]["UpPOPDate"].ToString();
                    model.PhotoPath = ds.Tables[0].Rows[n]["PhotoPath"].ToString();
                    model.ShopDesc = ds.Tables[0].Rows[n]["ShopDesc"].ToString();
                    if (ds.Tables[0].Rows[n]["DSRState"].ToString() != "")
                    {
                        model.DSRState = int.Parse(ds.Tables[0].Rows[n]["DSRState"].ToString());
                    }
                    model.DSRDesc = ds.Tables[0].Rows[n]["DSRDesc"].ToString();

                    model.DSRDate = ds.Tables[0].Rows[n]["DSRDate"].ToString();

                    if (ds.Tables[0].Rows[n]["VMState"].ToString() != "")
                    {
                        model.VMState = int.Parse(ds.Tables[0].Rows[n]["VMState"].ToString());
                    }
                    model.VMDate = ds.Tables[0].Rows[n]["VMDate"].ToString();
                    model.VMDesc = ds.Tables[0].Rows[n]["VMDesc"].ToString();
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
        /// 得到POP报损数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetPopReportDamageData(string strWhere)
        {
            return dal.GetPopReportDamageData(strWhere);
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

