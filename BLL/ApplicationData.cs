using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类ApplicationData 的摘要说明。
	/// </summary>
	public class ApplicationData
	{
		private readonly LN.DAL.ApplicationData dal=new LN.DAL.ApplicationData();
		public ApplicationData()
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.ApplicationData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ApplicationData model)
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
		public LN.Model.ApplicationData GetModel(int ID)
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
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LN.Model.ApplicationData> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LN.Model.ApplicationData> DataTableToList(DataTable dt)
		{
			List<LN.Model.ApplicationData> modelList = new List<LN.Model.ApplicationData>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.ApplicationData model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.ApplicationData();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["ShopID"].ToString()!="")
					{
						model.ShopID=int.Parse(dt.Rows[n]["ShopID"].ToString());
					}
					model.POSCode=dt.Rows[n]["POSCode"].ToString();
					model.POPSeatNum=dt.Rows[n]["POPSeatNum"].ToString();
					model.SeatDesc=dt.Rows[n]["SeatDesc"].ToString();
					if(dt.Rows[n]["POPHeight"].ToString()!="")
					{
						model.POPHeight=decimal.Parse(dt.Rows[n]["POPHeight"].ToString());
					}
					if(dt.Rows[n]["POPWith"].ToString()!="")
					{
						model.POPWith=decimal.Parse(dt.Rows[n]["POPWith"].ToString());
					}
					if(dt.Rows[n]["POPArea"].ToString()!="")
					{
						model.POPArea=decimal.Parse(dt.Rows[n]["POPArea"].ToString());
					}
					model.POPMaterial=dt.Rows[n]["POPMaterial"].ToString();
					if(dt.Rows[n]["ProductLineID"].ToString()!="")
					{
						model.ProductLineID=int.Parse(dt.Rows[n]["ProductLineID"].ToString());
					}
					model.Sexarea=dt.Rows[n]["Sexarea"].ToString();
					if(dt.Rows[n]["TwoSided"].ToString()!="")
					{
						model.TwoSided=int.Parse(dt.Rows[n]["TwoSided"].ToString());
					}
					if(dt.Rows[n]["Glass"].ToString()!="")
					{
						model.Glass=int.Parse(dt.Rows[n]["Glass"].ToString());
					}
					if(dt.Rows[n]["PlatformWith"].ToString()!="")
					{
						model.PlatformWith=decimal.Parse(dt.Rows[n]["PlatformWith"].ToString());
					}
					if(dt.Rows[n]["PlatformHeight"].ToString()!="")
					{
						model.PlatformHeight=decimal.Parse(dt.Rows[n]["PlatformHeight"].ToString());
					}
					if(dt.Rows[n]["PlatformLong"].ToString()!="")
					{
						model.PlatformLong=decimal.Parse(dt.Rows[n]["PlatformLong"].ToString());
					}
					if(dt.Rows[n]["ApplyUserID"].ToString()!="")
					{
						model.ApplyUserID=int.Parse(dt.Rows[n]["ApplyUserID"].ToString());
					}
					model.ApplyType=dt.Rows[n]["ApplyType"].ToString();
					model.ApplyDesc=dt.Rows[n]["ApplyDesc"].ToString();
					model.ApplyDate=dt.Rows[n]["ApplyDate"].ToString();
					model.PhotoPath=dt.Rows[n]["PhotoPath"].ToString();
					if(dt.Rows[n]["AreaVMExamState"].ToString()!="")
					{
						model.AreaVMExamState=int.Parse(dt.Rows[n]["AreaVMExamState"].ToString());
					}
					model.AreaVMExamDesc=dt.Rows[n]["AreaVMExamDesc"].ToString();
					if(dt.Rows[n]["AreaVMExamUseID"].ToString()!="")
					{
						model.AreaVMExamUseID=int.Parse(dt.Rows[n]["AreaVMExamUseID"].ToString());
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
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

