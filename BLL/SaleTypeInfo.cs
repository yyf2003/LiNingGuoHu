using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类SaleTypeInfo 的摘要说明。
	/// </summary>
	public class SaleTypeInfo
	{
		private readonly LN.DAL.SaleTypeInfo dal=new LN.DAL.SaleTypeInfo();
		public SaleTypeInfo()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SaleTypeID)
		{
			return dal.Exists(SaleTypeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.SaleTypeInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.SaleTypeInfo model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SaleTypeID)
		{
			
			dal.Delete(SaleTypeID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.SaleTypeInfo GetModel(int SaleTypeID)
		{
			
			return dal.GetModel(SaleTypeID);
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
		public List<LN.Model.SaleTypeInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.SaleTypeInfo> modelList = new List<LN.Model.SaleTypeInfo>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.SaleTypeInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.SaleTypeInfo();
					if(ds.Tables[0].Rows[n]["SaleTypeID"].ToString()!="")
					{
						model.SaleTypeID=int.Parse(ds.Tables[0].Rows[n]["SaleTypeID"].ToString());
					}
					model.SaleType=ds.Tables[0].Rows[n]["SaleType"].ToString();
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

