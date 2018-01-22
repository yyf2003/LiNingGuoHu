using System;
using System.Data;
using System.Collections.Generic;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类AreaCityLevel 的摘要说明。
	/// </summary>
	public class AreaCityLevel
	{
		private readonly LN.DAL.AreaCityLevel dal=new LN.DAL.AreaCityLevel();
		public AreaCityLevel()
		{}
		#region  成员方法


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.AreaCityLevel GetModel(int ACL_Id)
		{
			
			return dal.GetModel(ACL_Id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public IList<LN.Model.AreaCityLevel> GetList(string strWhere)
		{
            return dal.GetList(strWhere);
		}

		#endregion  成员方法
	}
}

