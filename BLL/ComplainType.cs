using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���ComplainType ��ժҪ˵����
	/// </summary>
	public class ComplainType
	{
		private readonly LN.DAL.ComplainType dal=new LN.DAL.ComplainType();
		public ComplainType()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int tID)
		{
			return dal.Exists(tID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.ComplainType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.ComplainType model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int tID)
		{
			
			dal.Delete(tID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.ComplainType GetModel(int tID)
		{
			
			return dal.GetModel(tID);
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
		public List<LN.Model.ComplainType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.ComplainType> modelList = new List<LN.Model.ComplainType>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.ComplainType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.ComplainType();
					if(ds.Tables[0].Rows[n]["tID"].ToString()!="")
					{
						model.tID=int.Parse(ds.Tables[0].Rows[n]["tID"].ToString());
					}
					model.tName=ds.Tables[0].Rows[n]["tName"].ToString();
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

