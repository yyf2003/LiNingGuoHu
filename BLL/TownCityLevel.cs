using System;
using System.Data;
using System.Collections.Generic;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类TownCityLevel 的摘要说明。
	/// </summary>
	public class TownCityLevel
	{
		private readonly LN.DAL.TownCityLevel dal=new LN.DAL.TownCityLevel();
		public TownCityLevel()
		{}
		#region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LN.Model.TownCityLevel GetModel(int TCL_Id)
        {

            return dal.GetModel(TCL_Id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public IList<LN.Model.TownCityLevel> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

		#endregion  成员方法
	}
}

