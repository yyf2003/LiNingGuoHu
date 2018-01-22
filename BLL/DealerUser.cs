using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类DealerUser 的摘要说明。
	/// </summary>
	public class DealerUser
	{
		private readonly LN.DAL.DealerUser dal=new LN.DAL.DealerUser();
		public DealerUser()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.DealerUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.DealerUser model)
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
		public LN.Model.DealerUser GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
        public IList<LN.Model.DealerUser> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 通过用户编号获取一级客户号
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns>返回一级客户号</returns>
        public DataTable GetDealerIdByUserID(int userid)
        {
            return dal.GetDealerIdByUserID(userid);
        }

		#endregion  成员方法
	}
}

