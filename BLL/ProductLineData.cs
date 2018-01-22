using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类ProductLineData 的摘要说明。
	/// </summary>
	public class ProductLineData
	{
		private readonly LN.DAL.ProductLineData dal=new LN.DAL.ProductLineData();
		public ProductLineData()
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
		public bool Exists(int ProductLineID)
		{
			return dal.Exists(ProductLineID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.ProductLineData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ProductLineData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductLineID)
		{
			
			dal.Delete(ProductLineID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ProductLineData GetModel(int ProductLineID)
		{
			
			return dal.GetModel(ProductLineID);
		}

	    /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<LN.Model.ProductLineData> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataTable GetListPageByWhere(LN.Model.PageModel model, out int TotalNumber)
		{
            return dal.GetListPageByWhere(model, out TotalNumber);
		}
        /// <summary>
        /// 得到相应发起POP的故事包类型
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataTable getPOPProductTypelist(string POPID)
        {
            return dal.getPOPProductTypelist(POPID);
        }

        /// <summary>
        /// 得到相应发起POP的故事包类型
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataTable getPOPProductTypelist(string POPID, string SeatName)
        {
            return dal.getPOPProductTypelist(POPID, SeatName);
        }

           /// <summary>
        /// 得到相应发起POP的故事包
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataTable GetPOPproductLineByTypeID(string POPID, int typeid)
        {
            return dal.GetPOPproductLineByTypeID(POPID,typeid);
        }

           /// <summary>
        /// 得到所有产品系列的名称 不包括重复的
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDistinctLine(string StrWhere)
        {
            return dal.GetDistinctLine(StrWhere);
        }
		#endregion  成员方法
	}
}

