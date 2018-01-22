using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类ProvinceData 的摘要说明。
	/// </summary>
	public class ProvinceData
	{
		private readonly LN.DAL.ProvinceData dal=new LN.DAL.ProvinceData();
		public ProvinceData()
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
		public bool Exists(int ProvinceID)
		{
			return dal.Exists(ProvinceID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(LN.Model.ProvinceData model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ProvinceData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProvinceID)
		{
			
			dal.Delete(ProvinceID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ProvinceData GetModel(int ProvinceID)
		{
			
			return dal.GetModel(ProvinceID);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.ProvinceData> GetList(string strWhere)
        {
			return dal.GetList(strWhere);
		}

		#endregion  成员方法
	}
}

