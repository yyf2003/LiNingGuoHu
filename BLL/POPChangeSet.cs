using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类POPChangeSet 的摘要说明。
	/// </summary>
	public class POPChangeSet
	{
		private readonly LN.DAL.POPChangeSet dal=new LN.DAL.POPChangeSet();
		public POPChangeSet()
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
		public int  Add(LN.Model.POPChangeSet model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.POPChangeSet model)
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
		public LN.Model.POPChangeSet GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

 
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<LN.Model.POPChangeSet> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<LN.Model.POPChangeSet> GetAllList()
		{
			return GetList("");
		}
        /// <summary>
        /// 产品更换区域
        /// </summary>
        /// <param name="sqlstr"></param>
        public void CitySet(string POPID, string CatenaProID, string sqlstr)
        {
            dal.CitySet(POPID, CatenaProID,sqlstr);
        }
              	/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataTable Getview_List(string strWhere)
        {
            return dal.Getview_List(strWhere);
        }
          /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetPOPprice_List(string strWhere)
        {
            return dal.GetPOPprice_List(strWhere);
        }

        /// <summary>
        /// 获取指定店铺所参与的发起ID
        /// </summary>
        /// <param name="ShopID">店铺编号</param>
        /// <returns>返回指定店铺参与的发起ID</returns>
        public string GetPOPIDByShopID(string ShopID)
        {
            return dal.GetPOPIDByShopID(ShopID);
        }


         /// <summary>
        /// 单个店铺加入pop发起 add  by mhj 2012.06.04
        /// </summary>
        /// <param name="strShopid"></param>
        /// <returns></returns>
        public int JoinPopLanuch(string strShopid)
        {
            return dal.JoinPopLanuch(strShopid);
        }

        /// <summary>
        /// 单个店铺加入pop发起 add  by mhj 2015.05.10
        /// </summary>
        /// <param name="strPosId"></param>
        /// <returns></returns>
        public int JoinPopLanuchByPosId(string strPosId)
        {
            return dal.JoinPopLanuchByPosId(strPosId);
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

