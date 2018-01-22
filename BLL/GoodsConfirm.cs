using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类GoodsConfirm 的摘要说明。
	/// </summary>
	public class GoodsConfirm
	{
		private readonly LN.DAL.GoodsConfirm dal=new LN.DAL.GoodsConfirm();
		public GoodsConfirm()
		{}
		#region  成员方法

		/// <summary>
		/// 修改数据
		/// </summary>
        public int Operate(LN.Model.GoodsConfirm model)
		{
			return dal.Operate(model);
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
		public LN.Model.GoodsConfirm GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		#endregion  成员方法
	}
}

