using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;

namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类tb_FOSPOP 的摘要说明。
	/// </summary>
	public class tb_FOSPOP
	{
		private readonly LN.DAL.tb_FOSPOP dal=new LN.DAL.tb_FOSPOP();

		public tb_FOSPOP(){}

		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.tb_FOSPOP model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(LN.Model.tb_FOSPOP model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public int Delete(int FOS_ID)
		{
            return dal.Delete(FOS_ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public LN.Model.tb_FOSPOP GetModel(string FOS_POPSeat)
		{
            return dal.GetModel(FOS_POPSeat);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public IList<LN.Model.tb_FOSPOP> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

		#endregion  成员方法
	}
}

