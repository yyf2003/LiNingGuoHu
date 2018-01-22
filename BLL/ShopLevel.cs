using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类ShopLevel 的摘要说明。
	/// </summary>
	public class ShopLevel
	{
		private readonly LN.DAL.ShopLevel dal=new LN.DAL.ShopLevel();
		public ShopLevel()
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
		public bool Exists(int LevelID)
		{
			return dal.Exists(LevelID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.ShopLevel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ShopLevel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int LevelID)
		{
			
			dal.Delete(LevelID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ShopLevel GetModel(int LevelID)
		{
			
			return dal.GetModel(LevelID);
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
		public List<LN.Model.ShopLevel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.ShopLevel> modelList = new List<LN.Model.ShopLevel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.ShopLevel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.ShopLevel();
					if(ds.Tables[0].Rows[n]["LevelID"].ToString()!="")
					{
						model.LevelID=int.Parse(ds.Tables[0].Rows[n]["LevelID"].ToString());
					}
					model.ShopLevelName=ds.Tables[0].Rows[n]["ShopLevel"].ToString();
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

