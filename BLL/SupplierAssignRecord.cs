using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类AssignRecord 的摘要说明。
	/// </summary>
	public class SupplierAssignRecord
	{
		private readonly LN.DAL.SupplierAssignRecord dal=new LN.DAL.SupplierAssignRecord();
		public SupplierAssignRecord()
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            return dal.Exists(strWhere);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.SupplierAssignRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.SupplierAssignRecord model)
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
		public LN.Model.SupplierAssignRecord GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

	  /// <summary>
      /// 
      /// </summary>
      /// <param name="strWhere"></param>
      /// <returns></returns>
        public string GetSuplierIDbyArea(string strWhere)
        {
            return dal.GetSuplierIDbyArea(strWhere);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetSuplierIDListbyArea(string AreaID)
        {
            return dal.GetSuplierIDListbyArea(AreaID);
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
		public List<LN.Model.SupplierAssignRecord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.SupplierAssignRecord> modelList = new List<LN.Model.SupplierAssignRecord>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.SupplierAssignRecord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.SupplierAssignRecord();
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["SupplierID"].ToString()!="")
					{
						model.SupplierID=int.Parse(ds.Tables[0].Rows[n]["SupplierID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AssignRuleID"].ToString()!="")
					{
						model.AssignRuleID=int.Parse(ds.Tables[0].Rows[n]["AssignRuleID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AssignProID"].ToString()!="")
					{
						model.AssignProID=int.Parse(ds.Tables[0].Rows[n]["AssignProID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AssignCityID"].ToString()!="")
					{
						model.AssignCityID=int.Parse(ds.Tables[0].Rows[n]["AssignCityID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AssignShopID"].ToString()!="")
					{
						model.AssignShopID=int.Parse(ds.Tables[0].Rows[n]["AssignShopID"].ToString());
					}
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
        /// 根据分配的城市 将所在城市的店铺ID 放到 SupplierAssignRecord 表中
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="cityIDlist"></param>
        /// <returns></returns>
        public bool allotshop(string gid,string PosIDlist,string dept, string areaIDlist,string Prolist)
        {
            return dal.allotshop(gid,PosIDlist,dept, areaIDlist, Prolist);
        }
		/// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回获取店铺列表集合</returns>
        public DataTable GetAssignRecordByID(LN.Model.PageModel model, out int TotalNumber)
        {
            return dal.GetAssignRecordByID(model,out TotalNumber);
        }

             /// <summary>
        /// 根据店铺得到供应商信息
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public DataTable GetSpplierAssignRecordWithShopID(int ShopID)
        {
            return dal.GetSpplierAssignRecordWithShopID(ShopID);
        }
           /// <summary>
        /// 根据供应商得到管理的店铺数据数量
        /// </summary>
        /// <param name="Supplierid"></param>
        /// <returns></returns>
        public int GetShopData(int Supplierid)
        {
            return dal.GetShopData(Supplierid);
        }
             /// <summary>
        /// 从视图中得到数据。 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getdatafromView(string strWhere)
        {
            return dal.getdatafromView(strWhere);
        }
        /// <summary>
        /// 得到相应供应商所负责的省区名称
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataTable GetSupplierArea(int supplierID)
        {
            return dal.GetSupplierArea(supplierID);
        }
        /// <summary>
        /// 得到相应供应商所负责的省份名称
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataTable GetSupplierPro(int supplierID)
        {
            return dal.GetSupplierPro(supplierID);
        }

                /// <summary>
        /// 根据供应商的ID得到供应商所有负责的区域的POP信息
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataTable Getsupplier_popinfo(int supplierID)
        {
            return dal.Getsupplier_popinfo(supplierID);
        }


        public DataTable GetSuplierByProvinceId(int provinceid)
        {
            return dal.GetSuplierByProvinceId(provinceid);
        }
		#endregion  成员方法
	}
}

