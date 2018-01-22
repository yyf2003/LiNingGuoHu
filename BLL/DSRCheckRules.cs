using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类DSRCheckRules 的摘要说明。
	/// </summary>
	public class DSRCheckRules
	{
		private readonly LN.DAL.DSRCheckRules dal=new LN.DAL.DSRCheckRules();
		public DSRCheckRules()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RulesID)
		{
			return dal.Exists(RulesID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.DSRCheckRules model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.DSRCheckRules model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int RulesID)
		{
			
			dal.Delete(RulesID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.DSRCheckRules GetModel(int RulesID)
		{
			
			return dal.GetModel(RulesID);
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
		public List<LN.Model.DSRCheckRules> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.DSRCheckRules> modelList = new List<LN.Model.DSRCheckRules>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.DSRCheckRules model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.DSRCheckRules();
					if(ds.Tables[0].Rows[n]["RulesID"].ToString()!="")
					{
						model.RulesID=int.Parse(ds.Tables[0].Rows[n]["RulesID"].ToString());
					}
					model.DSRCheckType=ds.Tables[0].Rows[n]["DSRCheckType"].ToString();
					model.DSRRules=ds.Tables[0].Rows[n]["DSRRules"].ToString();
					if(ds.Tables[0].Rows[n]["RulesState"].ToString()!="")
					{
						model.RulesState=int.Parse(ds.Tables[0].Rows[n]["RulesState"].ToString());
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

