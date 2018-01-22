using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类SupplierSetupPrice 的摘要说明。
	/// </summary>
	public class SupplierSetupPrice
	{
		private readonly LN.DAL.SupplierSetupPrice dal=new LN.DAL.SupplierSetupPrice();
		public SupplierSetupPrice()
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
		public int  Add(LN.Model.SupplierSetupPrice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.SupplierSetupPrice model)
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
		public LN.Model.SupplierSetupPrice GetModel(int ID)
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
		public List<LN.Model.SupplierSetupPrice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LN.Model.SupplierSetupPrice> DataTableToList(DataTable dt)
		{
			List<LN.Model.SupplierSetupPrice> modelList = new List<LN.Model.SupplierSetupPrice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.SupplierSetupPrice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.SupplierSetupPrice();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["supplierID"].ToString()!="")
					{
						model.supplierID=int.Parse(dt.Rows[n]["supplierID"].ToString());
					}
					if(dt.Rows[n]["setupMoney"].ToString()!="")
					{
						model.setupMoney=decimal.Parse(dt.Rows[n]["setupMoney"].ToString());
					}
					if(dt.Rows[n]["SysTime"].ToString()!="")
					{
						model.SysTime=DateTime.Parse(dt.Rows[n]["SysTime"].ToString());
					}
					if(dt.Rows[n]["SubmitUserID"].ToString()!="")
					{
						model.SubmitUserID=int.Parse(dt.Rows[n]["SubmitUserID"].ToString());
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

