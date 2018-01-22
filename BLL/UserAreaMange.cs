using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类UserAreaMange 的摘要说明。
    /// </summary>
    public class UserAreaMange
    {
        private readonly LN.DAL.UserAreaMange dal = new LN.DAL.UserAreaMange();
        public UserAreaMange()
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
        public int Add(LN.Model.UserAreaMange model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.UserAreaMange model)
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
        /// 删除用户的数据
        /// </summary>
        /// <param name="UserID"></param>
        public void DeleteUserData(int UserID)
        {
            dal.DeleteUserData(UserID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.UserAreaMange GetModel(int ID)
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
        public List<LN.Model.UserAreaMange> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.UserAreaMange> modelList = new List<LN.Model.UserAreaMange>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.UserAreaMange model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.UserAreaMange();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(ds.Tables[0].Rows[n]["UserID"].ToString());
                    }
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
                    if (ds.Tables[0].Rows[n]["TownID"].ToString() != "")
                    {
                        model.TownID = int.Parse(ds.Tables[0].Rows[n]["TownID"].ToString());
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
        /// 得到分配的区域信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginArea(int UID)
        {
            return dal.GetUserAssginArea(UID);
        }

        /// <summary>
        /// 得到分配的城市信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginCity(int UID)
        {
            return dal.GetUserAssginCity(UID);
        }

        /// <summary>
        /// 得到分配的省份信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginProvice(int UID)
        {
            return dal.GetUserAssginProvice(UID);
        }
          /// <summary>
        /// 得到分配的城镇信息
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        public DataSet GetUserAssginTown(int UID)
        {
            return dal.GetUserAssginTown(UID);
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

