using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// 业务逻辑类ShopVI 的摘要说明。
	/// </summary>
	public class ShopVI
	{
		private readonly LN.DAL.ShopVI dal=new LN.DAL.ShopVI();
		public ShopVI()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ShopVIID)
		{
			return dal.Exists(ShopVIID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(LN.Model.ShopVI model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LN.Model.ShopVI model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ShopVIID)
		{
			
			dal.Delete(ShopVIID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LN.Model.ShopVI GetModel(int ShopVIID)
		{
			
			return dal.GetModel(ShopVIID);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<LN.Model.ShopVI> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public List<LN.Model.ShopVI> GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<LN.Model.ShopVI> GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

