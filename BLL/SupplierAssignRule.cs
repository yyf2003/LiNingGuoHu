using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���SupplierAssignRule ��ժҪ˵����
	/// </summary>
	public class SupplierAssignRule
	{
		private readonly LN.DAL.SupplierAssignRule dal=new LN.DAL.SupplierAssignRule();
		public SupplierAssignRule()
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
		public bool Exists(int AssignRuleID)
		{
			return dal.Exists(AssignRuleID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.SupplierAssignRule model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.SupplierAssignRule model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int AssignRuleID)
		{
			
			dal.Delete(AssignRuleID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.SupplierAssignRule GetModel(int AssignRuleID)
		{
			
			return dal.GetModel(AssignRuleID);
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
		public List<LN.Model.SupplierAssignRule> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.SupplierAssignRule> modelList = new List<LN.Model.SupplierAssignRule>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.SupplierAssignRule model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.SupplierAssignRule();
					if(ds.Tables[0].Rows[n]["AssignRuleID"].ToString()!="")
					{
						model.AssignRuleID=int.Parse(ds.Tables[0].Rows[n]["AssignRuleID"].ToString());
					}
					model.AssignRule=ds.Tables[0].Rows[n]["AssignRule"].ToString();
					model.Remarks=ds.Tables[0].Rows[n]["Remarks"].ToString();
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

