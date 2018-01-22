using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类supplier_POPIDsetupPrice 的摘要说明。
	/// </summary>
	public class supplier_POPIDsetupPrice
	{
		private readonly LN.DAL.supplier_POPIDsetupPrice dal=new LN.DAL.supplier_POPIDsetupPrice();
		public supplier_POPIDsetupPrice()
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
		public int  Add(LN.Model.supplier_POPIDsetupPrice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.supplier_POPIDsetupPrice model)
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
		public LN.Model.supplier_POPIDsetupPrice GetModel(int ID)
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
		public List<LN.Model.supplier_POPIDsetupPrice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LN.Model.supplier_POPIDsetupPrice> DataTableToList(DataTable dt)
		{
			List<LN.Model.supplier_POPIDsetupPrice> modelList = new List<LN.Model.supplier_POPIDsetupPrice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.supplier_POPIDsetupPrice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.supplier_POPIDsetupPrice();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.POPID=dt.Rows[n]["POPID"].ToString();
					if(dt.Rows[n]["supplierID"].ToString()!="")
					{
						model.supplierID=int.Parse(dt.Rows[n]["supplierID"].ToString());
					}
					if(dt.Rows[n]["setupMoney"].ToString()!="")
					{
						model.setupMoney=decimal.Parse(dt.Rows[n]["setupMoney"].ToString());
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

