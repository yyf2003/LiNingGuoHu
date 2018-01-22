using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类ComplainType 的摘要说明。
	/// </summary>
	public class ComplainType
	{
		private readonly LN.DAL.ComplainType dal=new LN.DAL.ComplainType();
		public ComplainType()
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
		public bool Exists(int tID)
		{
			return dal.Exists(tID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.ComplainType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ComplainType model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int tID)
		{
			
			dal.Delete(tID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ComplainType GetModel(int tID)
		{
			
			return dal.GetModel(tID);
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
		public List<LN.Model.ComplainType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.ComplainType> modelList = new List<LN.Model.ComplainType>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.ComplainType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.ComplainType();
					if(ds.Tables[0].Rows[n]["tID"].ToString()!="")
					{
						model.tID=int.Parse(ds.Tables[0].Rows[n]["tID"].ToString());
					}
					model.tName=ds.Tables[0].Rows[n]["tName"].ToString();
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

