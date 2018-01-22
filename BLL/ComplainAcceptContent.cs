using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类ComplainAcceptContent 的摘要说明。
	/// </summary>
	public class ComplainAcceptContent
	{
		private readonly LN.DAL.ComplainAcceptContent dal=new LN.DAL.ComplainAcceptContent();
		public ComplainAcceptContent()
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
		public bool Exists(int aID)
		{
			return dal.Exists(aID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.ComplainAcceptContent model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ComplainAcceptContent model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int aID)
		{
			
			dal.Delete(aID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ComplainAcceptContent GetModel(int aID)
		{
			
			return dal.GetModel(aID);
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
		public List<LN.Model.ComplainAcceptContent> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.ComplainAcceptContent> modelList = new List<LN.Model.ComplainAcceptContent>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.ComplainAcceptContent model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.ComplainAcceptContent();
					if(ds.Tables[0].Rows[n]["aID"].ToString()!="")
					{
						model.aID=int.Parse(ds.Tables[0].Rows[n]["aID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["cID"].ToString()!="")
					{
						model.cID=int.Parse(ds.Tables[0].Rows[n]["cID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["acceptUserID"].ToString()!="")
					{
						model.acceptUserID=int.Parse(ds.Tables[0].Rows[n]["acceptUserID"].ToString());
					}
					model.aInfo=ds.Tables[0].Rows[n]["aInfo"].ToString();
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

