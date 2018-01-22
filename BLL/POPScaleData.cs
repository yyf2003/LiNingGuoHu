using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类POPScaleData 的摘要说明。
	/// </summary>
	public class POPScaleData
	{
		private readonly LN.DAL.POPScaleData dal=new LN.DAL.POPScaleData();
		public POPScaleData()
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
		public bool Exists(int PhotoScaleID)
		{
			return dal.Exists(PhotoScaleID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.POPScaleData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.POPScaleData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PhotoScaleID)
		{
			
			dal.Delete(PhotoScaleID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPScaleData GetModel(int PhotoScaleID)
		{
			
			return dal.GetModel(PhotoScaleID);
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
		public List<LN.Model.POPScaleData> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.POPScaleData> modelList = new List<LN.Model.POPScaleData>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.POPScaleData model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.POPScaleData();
					if(ds.Tables[0].Rows[n]["PhotoScaleID"].ToString()!="")
					{
						model.PhotoScaleID=int.Parse(ds.Tables[0].Rows[n]["PhotoScaleID"].ToString());
					}
					model.PhotoScale=ds.Tables[0].Rows[n]["PhotoScale"].ToString();
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

