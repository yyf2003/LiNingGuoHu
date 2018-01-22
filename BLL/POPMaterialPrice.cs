using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
using System.Collections;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类POPMaterialPrice 的摘要说明。
	/// </summary>
	public class POPMaterialPrice
	{
		private readonly LN.DAL.POPMaterialPrice dal=new LN.DAL.POPMaterialPrice();
		public POPMaterialPrice()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PriceID)
		{
			return dal.Exists(PriceID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.POPMaterialPrice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.POPMaterialPrice model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PriceID)
		{
			
			dal.Delete(PriceID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPMaterialPrice GetModel(int PriceID)
		{
			
			return dal.GetModel(PriceID);
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
		public List<LN.Model.POPMaterialPrice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<LN.Model.POPMaterialPrice> DataTableToList(DataTable dt)
		{
			List<LN.Model.POPMaterialPrice> modelList = new List<LN.Model.POPMaterialPrice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.POPMaterialPrice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.POPMaterialPrice();
					if(dt.Rows[n]["PriceID"].ToString()!="")
					{
						model.PriceID=int.Parse(dt.Rows[n]["PriceID"].ToString());
					}
					if(dt.Rows[n]["SupplierID"].ToString()!="")
					{
						model.SupplierID=int.Parse(dt.Rows[n]["SupplierID"].ToString());
					}
                    if (dt.Rows[n]["MateriaID"].ToString() != "")
					{
                        model.MateriaID = int.Parse(dt.Rows[n]["MateriaID"].ToString());
					}
					if(dt.Rows[n]["POPprice"].ToString()!="")
					{
						model.POPprice=decimal.Parse(dt.Rows[n]["POPprice"].ToString());
					}
					if(dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["SysTime"].ToString()!="")
					{
						model.SysTime=DateTime.Parse(dt.Rows[n]["SysTime"].ToString());
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
        /// 更新供应商材料价格
        /// </summary>
        /// <param name="htlist"></param>
        public void UpdatePrice_supplier(List<Hashtable> htlist)
        {
            dal.UpdatePrice_supplier(htlist);
        }
           /// <summary>
        /// 更新供应商材料价格---整体修改
        /// </summary>
        /// <param name="htlist"></param>
        public void UpdatePrice_all(List<Hashtable> htlist)
        {
            dal.UpdatePrice_all(htlist);
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

