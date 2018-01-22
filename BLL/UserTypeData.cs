using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类UserTypeData 的摘要说明。
	/// </summary>
	public class UserTypeData
	{
		private readonly LN.DAL.UserTypeData dal=new LN.DAL.UserTypeData();
		public UserTypeData()
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
		public int  Add(LN.Model.UserTypeData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.UserTypeData model)
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
		public LN.Model.UserTypeData GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.UserTypeData> GetList(string strWhere)
        {
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获取指定用户的权限
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <returns></returns>
        public int GetUserType(string UserID)
        {
            return dal.GetUserType(UserID);
        }

		#endregion  成员方法
	}
}

