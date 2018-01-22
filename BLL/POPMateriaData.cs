using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类POPMateriaData 的摘要说明。
	/// </summary>
	public class POPMateriaData
	{
		private readonly LN.DAL.POPMateriaData dal=new LN.DAL.POPMateriaData();
		public POPMateriaData()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(string MateriaPro, string UserID, string cltype)
		{
            return dal.Add(MateriaPro, UserID, cltype);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(LN.Model.POPMateriaData model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int MateriaID)
		{
			
			dal.Delete(MateriaID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPMateriaData GetModel(int MateriaID)
		{
			
			return dal.GetModel(MateriaID);
		}

        public DataTable GetTable(string strWhere)
        {
            return dal.GetTable(strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<LN.Model.POPMateriaData> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得材料名称数据列表
		/// </summary>
        public List<LN.Model.POPMateriaData> GetMateriaList(string strWhere)
        {
            return dal.GetMateriaList(strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<LN.Model.POPMateriaData> GetAllList()
		{
			return GetList("");
		}

        /// <summary>
        /// 获得数据AJAX分页列表
        /// </summary>
        /// <param name="model">分页实体</param>
        /// <returns>返回获取店铺列表集合</returns>
        public DataTable GetMateriaListPageByID(LN.Model.PageModel model, out int TotalNumber)
        {
            return dal.GetMateriaListPageByID(model,out TotalNumber);
        }

        /// <summary>
        /// 得到指定用户所在供应商上期材料报价清单
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <returns>返回材料报价清单列表</returns>
        public DataTable GetMaterialPriceByUserID(string suppilerid)
        {
            return dal.GetMaterialPriceByUserID(suppilerid); 
        }

        /// <summary>
        /// 修改指定材料的状态(使用 或 弃用)
        /// </summary>
        /// <param name="mID">材料编号</param>
        /// <param name="isDelete">状态</param>
        /// <returns>返回结果</returns>
        public int IsDelete(int mID, int isDelete)
        {
            return dal.IsDelete(mID,isDelete);
        }
             /// <summary>
        /// 跟据店铺是否支持安装得到相应的材料列表
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public DataTable GetMaterialByshopID(string shopid)
        {
            return dal.GetMaterialByshopID(shopid);
        }
        public DataTable GetMaterialListData(string IsDelete)
        {
            return dal.GetMaterialListData(IsDelete);
        }
		#endregion  成员方法
	}
}

