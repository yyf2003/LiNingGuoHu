using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类POPStage 的摘要说明。
	/// </summary>
	public class POPStage
	{
		private readonly LN.DAL.POPStage dal=new LN.DAL.POPStage();
		public POPStage()
		{}
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
		public bool Exists(int StageID)
		{
			return dal.Exists(StageID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.POPStage model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.POPStage model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int StageID)
		{
			
			dal.Delete(StageID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPStage GetModel(int StageID)
		{
			
			return dal.GetModel(StageID);
		}

        ///// <summary>
        ///// 得到一个对象实体，从缓存中。
        ///// </summary>
        //public LN.Model.POPStage GetModelByCache(int StageID)
        //{
			
        //    string CacheKey = "POPStageModel-" + StageID;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(StageID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (LN.Model.POPStage)objModel;
        //}

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
		public List<LN.Model.POPStage> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.POPStage> modelList = new List<LN.Model.POPStage>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.POPStage model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.POPStage();
					if(ds.Tables[0].Rows[n]["StageID"].ToString()!="")
					{
						model.StageID=int.Parse(ds.Tables[0].Rows[n]["StageID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["SupplierID"].ToString()!="")
					{
						model.SupplierID=int.Parse(ds.Tables[0].Rows[n]["SupplierID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POPID"].ToString()!="")
					{
						model.POPID=int.Parse(ds.Tables[0].Rows[n]["POPID"].ToString());
					}
					model.POPMaterial=ds.Tables[0].Rows[n]["POPMaterial"].ToString();
					if(ds.Tables[0].Rows[n]["POPprice"].ToString()!="")
					{
						model.POPprice=decimal.Parse(ds.Tables[0].Rows[n]["POPprice"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ExamUserID"].ToString()!="")
					{
						model.ExamUserID=int.Parse(ds.Tables[0].Rows[n]["ExamUserID"].ToString());
					}
					model.ExamDate=ds.Tables[0].Rows[n]["ExamDate"].ToString();
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

		#endregion  成员方法
	}
}

