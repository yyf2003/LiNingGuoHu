using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类NewAddPOP 的摘要说明。
	/// </summary>
	public class NewAddPOP
	{
		private readonly LN.DAL.NewAddPOP dal=new LN.DAL.NewAddPOP();
		public NewAddPOP()
		{}
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
		public int  Add(LN.Model.NewAddPOP model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.NewAddPOP model)
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
		public LN.Model.NewAddPOP GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

        ///// <summary>
        ///// 得到一个对象实体，从缓存中。
        ///// </summary>
        //public LN.Model.NewAddPOP GetModelByCache(int ID)
        //{
			
        //    string CacheKey = "NewAddPOPModel-" + ID;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (LN.Model.NewAddPOP)objModel;
        //}

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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LN.Model.NewAddPOP> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LN.Model.NewAddPOP> DataTableToList(DataTable dt)
		{
			List<LN.Model.NewAddPOP> modelList = new List<LN.Model.NewAddPOP>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.NewAddPOP model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.NewAddPOP();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["shopid"].ToString()!="")
					{
						model.shopid=int.Parse(dt.Rows[n]["shopid"].ToString());
					}
					model.POPID=dt.Rows[n]["POPID"].ToString();
					if(dt.Rows[n]["POPinfoID"].ToString()!="")
					{
						model.POPinfoID=int.Parse(dt.Rows[n]["POPinfoID"].ToString());
					}
					if(dt.Rows[n]["imageID"].ToString()!="")
					{
						model.imageID=int.Parse(dt.Rows[n]["imageID"].ToString());
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
        /// 得到新增POP的订单
        /// </summary>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        public DataTable GetNewList(string strwhere)
        {
            return dal.GetNewList(strwhere);
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

