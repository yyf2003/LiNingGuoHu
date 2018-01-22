using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���SupplierSetupPrice ��ժҪ˵����
	/// </summary>
	public class SupplierSetupPrice
	{
		private readonly LN.DAL.SupplierSetupPrice dal=new LN.DAL.SupplierSetupPrice();
		public SupplierSetupPrice()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.SupplierSetupPrice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.SupplierSetupPrice model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			
			dal.Delete(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.SupplierSetupPrice GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}


		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LN.Model.SupplierSetupPrice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LN.Model.SupplierSetupPrice> DataTableToList(DataTable dt)
		{
			List<LN.Model.SupplierSetupPrice> modelList = new List<LN.Model.SupplierSetupPrice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.SupplierSetupPrice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.SupplierSetupPrice();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["supplierID"].ToString()!="")
					{
						model.supplierID=int.Parse(dt.Rows[n]["supplierID"].ToString());
					}
					if(dt.Rows[n]["setupMoney"].ToString()!="")
					{
						model.setupMoney=decimal.Parse(dt.Rows[n]["setupMoney"].ToString());
					}
					if(dt.Rows[n]["SysTime"].ToString()!="")
					{
						model.SysTime=DateTime.Parse(dt.Rows[n]["SysTime"].ToString());
					}
					if(dt.Rows[n]["SubmitUserID"].ToString()!="")
					{
						model.SubmitUserID=int.Parse(dt.Rows[n]["SubmitUserID"].ToString());
					}
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

