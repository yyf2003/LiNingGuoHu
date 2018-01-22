using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类ComplainContent 的摘要说明。
	/// </summary>
	public class ComplainContent
	{
		private readonly LN.DAL.ComplainContent dal=new LN.DAL.ComplainContent();
		public ComplainContent()
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
		public bool Exists(int cID)
		{
			return dal.Exists(cID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.ComplainContent model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ComplainContent model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int cID)
		{
			
			dal.Delete(cID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ComplainContent GetModel(int cID)
		{
			
			return dal.GetModel(cID);
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
		public List<LN.Model.ComplainContent> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.ComplainContent> modelList = new List<LN.Model.ComplainContent>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.ComplainContent model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.ComplainContent();
					if(ds.Tables[0].Rows[n]["cID"].ToString()!="")
					{
						model.cID=int.Parse(ds.Tables[0].Rows[n]["cID"].ToString());
					}
					model.cInfo=ds.Tables[0].Rows[n]["cInfo"].ToString();
					if(ds.Tables[0].Rows[n]["tID"].ToString()!="")
					{
						model.tID=int.Parse(ds.Tables[0].Rows[n]["tID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["userID"].ToString()!="")
					{
						model.userID=int.Parse(ds.Tables[0].Rows[n]["userID"].ToString());
					}
					model.acceptUserID=ds.Tables[0].Rows[n]["acceptUserID"].ToString();
					if(ds.Tables[0].Rows[n]["acceptNumber"].ToString()!="")
					{
						model.acceptNumber=int.Parse(ds.Tables[0].Rows[n]["acceptNumber"].ToString());
					}
					model.AttachmentInfo=ds.Tables[0].Rows[n]["AttachmentInfo"].ToString();
					if(ds.Tables[0].Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[n]["CreateTime"].ToString());
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

