using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类SupplierInfo 的摘要说明。
	/// </summary>
	public class SupplierInfo
	{
		private readonly LN.DAL.SupplierInfo dal=new LN.DAL.SupplierInfo();
		public SupplierInfo()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.SupplierInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.SupplierInfo model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int SupplierID)
		{
			
			dal.Delete(SupplierID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.SupplierInfo GetModel(int SupplierID)
		{
			
			return dal.GetModel(SupplierID);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<LN.Model.SupplierInfo> GetList(string strWhere)
		{
            return dal.GetList(strWhere);
		}
            /// <summary>
        /// 放弃一级客户
        /// </summary>
        /// <param name="supplierID"></param>
        /// <param name="beizhu"></param>
        public void GiveUpSup(int supplierID, string beizhu)
        {
            dal.GiveUpSup(supplierID,beizhu);
        }

        /// <summary>
        /// 获取指定用户所属一级客户的编号和用户的权限
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns>所属一级客户的编号和用户的权限</returns>
        public IList<int> GetSupplierID(string UserID)
        {
            return dal.GetSupplierID(UserID);
        }

        /// <summary>
        /// 获取指定用户的供应商编号和最新POP发起ID
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns>返回POPID，SupplierID</returns>
        public IList<string> GetPOPIDAndSIDByUserID(int userid)
        {
            return dal.GetPOPIDAndSIDByUserID(userid);
        }

        /// <summary>
        /// 根据供应商负责人的用户名获取供应商Id  add by mhj 2012.2.5
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetSupplierIdByUserName(string userName)
        {
            return dal.GetSupplierIdByUserName(userName);
        }

		#endregion  成员方法
	}
}

