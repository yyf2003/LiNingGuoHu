using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类ErrLog 的摘要说明。
	/// </summary>
	public class ErrLog
	{
		private readonly LN.DAL.ErrLog dal=new LN.DAL.ErrLog();
		public ErrLog()
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
		public int  Add(LN.Model.ErrLog model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ErrLog model)
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
		public LN.Model.ErrLog GetModel(int ID)
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
		public List<LN.Model.ErrLog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.ErrLog> modelList = new List<LN.Model.ErrLog>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.ErrLog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.ErrLog();
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					model.ErrID=ds.Tables[0].Rows[n]["ErrID"].ToString();
					model.ErrDec=ds.Tables[0].Rows[n]["ErrDec"].ToString();
					if(ds.Tables[0].Rows[n]["ErrTime"].ToString()!="")
					{
						model.ErrTime=DateTime.Parse(ds.Tables[0].Rows[n]["ErrTime"].ToString());
					}
					model.ErrPage=ds.Tables[0].Rows[n]["ErrPage"].ToString();
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

