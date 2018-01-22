using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类CityData 的摘要说明。
	/// </summary>
	public class CityData
	{
		private readonly LN.DAL.CityData dal=new LN.DAL.CityData();
		public CityData()
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
		public bool Exists(int CItyID)
		{
			return dal.Exists(CItyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.CityData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.CityData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CItyID)
		{
			
			dal.Delete(CItyID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.CityData GetModel(int CItyID)
		{
			
			return dal.GetModel(CItyID);
		}



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.CityData> GetList(string strWhere)
        {
			return dal.GetList(strWhere);
		}

         /// <summary>
        /// 根据省份得到城市简单信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetCityList(string strWhere)
        {
            return dal.GetCityList(strWhere);
        }

		#endregion  成员方法
	}
}

