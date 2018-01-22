using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类SupplierAssignRule 的摘要说明。
	/// </summary>
	public class SupplierAssignRule
	{
		private readonly LN.DAL.SupplierAssignRule dal=new LN.DAL.SupplierAssignRule();
		public SupplierAssignRule()
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
		public bool Exists(int AssignRuleID)
		{
			return dal.Exists(AssignRuleID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.SupplierAssignRule model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.SupplierAssignRule model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AssignRuleID)
		{
			
			dal.Delete(AssignRuleID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.SupplierAssignRule GetModel(int AssignRuleID)
		{
			
			return dal.GetModel(AssignRuleID);
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
		public List<LN.Model.SupplierAssignRule> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.SupplierAssignRule> modelList = new List<LN.Model.SupplierAssignRule>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.SupplierAssignRule model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.SupplierAssignRule();
					if(ds.Tables[0].Rows[n]["AssignRuleID"].ToString()!="")
					{
						model.AssignRuleID=int.Parse(ds.Tables[0].Rows[n]["AssignRuleID"].ToString());
					}
					model.AssignRule=ds.Tables[0].Rows[n]["AssignRule"].ToString();
					model.Remarks=ds.Tables[0].Rows[n]["Remarks"].ToString();
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

