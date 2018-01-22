using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类PhysicalCompanyData 的摘要说明。
	/// </summary>
	public class PhysicalCompanyData
	{
		private readonly LN.DAL.PhysicalCompanyData dal=new LN.DAL.PhysicalCompanyData();
		public PhysicalCompanyData()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.PhysicalCompanyData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(int id,string name,string photo)
		{
			return dal.Update(id,name,photo);
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
		public LN.Model.PhysicalCompanyData GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public IList<LN.Model.PhysicalCompanyData> GetList(string strWhere)
		{
            return dal.GetList(strWhere);
		}

		#endregion  成员方法
	}
}

