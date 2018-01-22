using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类AssignUser 的摘要说明。
	/// </summary>
	public class AssignUser
	{
		private readonly LN.DAL.AssignUser dal=new LN.DAL.AssignUser();
		public AssignUser()
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
		public int  Add(LN.Model.AssignUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.AssignUser model)
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
		public LN.Model.AssignUser GetModel(int ID)
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
		/// 获得数据列表
		/// </summary>
		public List<LN.Model.AssignUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.AssignUser> modelList = new List<LN.Model.AssignUser>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.AssignUser model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.AssignUser();
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["UpmanagerID"].ToString()!="")
					{
						model.UpmanagerID=int.Parse(ds.Tables[0].Rows[n]["UpmanagerID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ManagedID"].ToString()!="")
					{
						model.ManagedID=int.Parse(ds.Tables[0].Rows[n]["ManagedID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ManagedRole"].ToString()!="")
					{
						model.ManagedRole=int.Parse(ds.Tables[0].Rows[n]["ManagedRole"].ToString());
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

