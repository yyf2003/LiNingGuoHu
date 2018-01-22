using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类POPPrice 的摘要说明。
	/// </summary>
	public class POPPrice
	{
		private readonly LN.DAL.POPPrice dal=new LN.DAL.POPPrice();
		public POPPrice()
		{}
		#region  成员方法

		/// <summary>
        /// 操作数据（增加，修改）
		/// </summary>
        public int Operate(List<string> strSql)
		{
            return dal.Operate(strSql);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PriceID)
		{
			
			dal.Delete(PriceID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.POPPrice GetModel(int PriceID)
		{
			
			return dal.GetModel(PriceID);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<LN.Model.POPPrice> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 审批供应商价格操作
        /// </summary>
        /// <param name="list"></param>
        public void ExamPrice(List<string> list)
        {
            dal.ExamPrice(list);
        }
		
        /// <summary>
        /// 指定用户是否有新POP发起，需要提交材料报价
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns>返回POPID，SupplierID</returns>
        public IList<string> IsSubmitPrice(int userid)
        {
            return dal.IsSubmitPrice(userid);
        }

        /// <summary>
        /// 指定用户是否有新POP发起，需要提交材料报价
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns>返回POPID</returns>
        public string IsSetMPrice(int userid)
        {
            return dal.IsSetMPrice(userid);
        }
        /// <summary>
        /// 得到某期要审批的材料报价
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataSet GetExamPriceList(int supplierID)
        {
            return dal.GetExamPriceList(supplierID);
        }

		#endregion  成员方法
	}
}

