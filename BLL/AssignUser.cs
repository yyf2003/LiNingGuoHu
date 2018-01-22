using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���AssignUser ��ժҪ˵����
	/// </summary>
	public class AssignUser
	{
		private readonly LN.DAL.AssignUser dal=new LN.DAL.AssignUser();
		public AssignUser()
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.AssignUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.AssignUser model)
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
		public LN.Model.AssignUser GetModel(int ID)
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
		/// ��������б�
		/// </summary>
		public List<LN.Model.AssignUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.AssignUser> modelList = new List<LN.Model.AssignUser>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.AssignUser model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.AssignUser();
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["UpmanagerID"].ToString()!="")
					{
						model.UpmanagerID=int.Parse(ds.Tables[0].Rows[n]["UpmanagerID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ManagedID"].ToString()!="")
					{
						model.ManagedID=int.Parse(ds.Tables[0].Rows[n]["ManagedID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ManagedRole"].ToString()!="")
					{
						model.ManagedRole=int.Parse(ds.Tables[0].Rows[n]["ManagedRole"].ToString());
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

