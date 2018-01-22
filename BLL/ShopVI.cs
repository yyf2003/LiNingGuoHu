using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���ShopVI ��ժҪ˵����
	/// </summary>
	public class ShopVI
	{
		private readonly LN.DAL.ShopVI dal=new LN.DAL.ShopVI();
		public ShopVI()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ShopVIID)
		{
			return dal.Exists(ShopVIID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.ShopVI model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.ShopVI model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ShopVIID)
		{
			
			dal.Delete(ShopVIID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.ShopVI GetModel(int ShopVIID)
		{
			
			return dal.GetModel(ShopVIID);
		}

	

		/// <summary>
		/// ��������б�
		/// </summary>
        public List<LN.Model.ShopVI> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
        public List<LN.Model.ShopVI> GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public List<LN.Model.ShopVI> GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

