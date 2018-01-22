using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类AreaData 的摘要说明。
	/// </summary>
	public class AreaData
	{
		private readonly LN.DAL.AreaData dal=new LN.DAL.AreaData();
		public AreaData()
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
		public bool Exists(int AreaID)
		{
			return dal.Exists(AreaID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.AreaData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.AreaData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int AreaID)
		{
			
			dal.Delete(AreaID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.AreaData GetModel(int AreaID)
		{
			
			return dal.GetModel(AreaID);
		}



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.AreaData> GetList(string strWhere)
        {
			return dal.GetList(strWhere);
		}

		#endregion  成员方法
	}
}

