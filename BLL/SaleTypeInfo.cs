using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���SaleTypeInfo ��ժҪ˵����
	/// </summary>
	public class SaleTypeInfo
	{
		private readonly LN.DAL.SaleTypeInfo dal=new LN.DAL.SaleTypeInfo();
		public SaleTypeInfo()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int SaleTypeID)
		{
			return dal.Exists(SaleTypeID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.SaleTypeInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.SaleTypeInfo model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int SaleTypeID)
		{
			
			dal.Delete(SaleTypeID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.SaleTypeInfo GetModel(int SaleTypeID)
		{
			
			return dal.GetModel(SaleTypeID);
		}

	 

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LN.Model.SaleTypeInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.SaleTypeInfo> modelList = new List<LN.Model.SaleTypeInfo>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.SaleTypeInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.SaleTypeInfo();
					if(ds.Tables[0].Rows[n]["SaleTypeID"].ToString()!="")
					{
						model.SaleTypeID=int.Parse(ds.Tables[0].Rows[n]["SaleTypeID"].ToString());
					}
					model.SaleType=ds.Tables[0].Rows[n]["SaleType"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
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

