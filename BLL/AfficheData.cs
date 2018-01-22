using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
    /// <summary>
    /// 业务逻辑类AfficheData 的摘要说明。
    /// </summary>
    public class AfficheData
    {
        private readonly LN.DAL.AfficheData dal = new LN.DAL.AfficheData();
        public AfficheData()
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
        /// 更新点击率
        /// </summary>
        /// <param name="ID"></param>
        public void UpdateClick(int ID)
        {
            dal.UpdateClick(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(LN.Model.AfficheData model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(LN.Model.AfficheData model)
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
        public LN.Model.AfficheData GetModel(int ID)
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
        public List<LN.Model.AfficheData> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<LN.Model.AfficheData> modelList = new List<LN.Model.AfficheData>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                LN.Model.AfficheData model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new LN.Model.AfficheData();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.UserID = ds.Tables[0].Rows[n]["UserID"].ToString();
                    model.TypeID = ds.Tables[0].Rows[n]["TypeID"].ToString();
                    model.Title = ds.Tables[0].Rows[n]["Title"].ToString();
                    model.Main = ds.Tables[0].Rows[n]["Main"].ToString();
                    if (ds.Tables[0].Rows[n]["Click"].ToString() != "")
                    {
                        model.Click = int.Parse(ds.Tables[0].Rows[n]["Click"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["IsScroll"].ToString() != "")
                    {
                        model.IsScroll = int.Parse(ds.Tables[0].Rows[n]["IsScroll"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["IsDel"].ToString() != "")
                    {
                        model.IsDel = int.Parse(ds.Tables[0].Rows[n]["IsDel"].ToString());
                    }
                    model.FileUrl = ds.Tables[0].Rows[n]["FileUrl"].ToString();
                    model.Time = ds.Tables[0].Rows[n]["Time"].ToString();
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
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

           /// <summary>
        /// 设置前台滚动
        /// </summary>
        public void SetScroll(int ID)
        {
            dal.SetScroll(ID);
        }

          /// <summary>
        /// 取消前台滚动
        /// </summary>
        public void DelScroll(int ID)
        {
            dal.DelScroll(ID);
        }

        /// <summary>
        /// 得到分页页数
        /// </summary>
        /// <returns></returns>
        public int GetPageNumWithTypeID(string typeid)
        {
            return dal.GetPageNumWithTypeID(typeid);
        }

        /// <summary>
        /// 根据页数返回DataTable
        /// </summary>
        /// <param name="pageNum">页数</param>
        /// <param name="typeid">类别</param>
        /// <returns></returns>
        public DataTable GetPageWithNumWithTypeID(int pageNum, string typeid)
        {
            return dal.GetPageWithNumWithTypeID(pageNum, typeid);
        }
          /// <summary>
        /// 获得数据列表前6条
        /// </summary>
        public DataSet GetTop6List(string strWhere)
        {
            return dal.GetTop6List(strWhere);
        }

            /// <summary>
        /// 获得最新前６条滚动数据
        /// </summary>
        public DataSet GetTop6ScrollList()
        {
            return dal.GetTop6ScrollList();
        }

        #endregion  成员方法
    }
}

