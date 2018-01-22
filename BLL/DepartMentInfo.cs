using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���DepartMentInfo ��ժҪ˵����
	/// </summary>
	public class DepartMentInfo
	{
		private readonly LN.DAL.DepartMentInfo dal=new LN.DAL.DepartMentInfo();
		public DepartMentInfo()
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
		public int  Add(LN.Model.DepartMentInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.DepartMentInfo model)
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
		public LN.Model.DepartMentInfo GetModel(int ID)
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
		public List<LN.Model.DepartMentInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LN.Model.DepartMentInfo> DataTableToList(DataTable dt)
		{
			List<LN.Model.DepartMentInfo> modelList = new List<LN.Model.DepartMentInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.DepartMentInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.DepartMentInfo();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					model.department=dt.Rows[n]["department"].ToString();
					model.Department_Master=dt.Rows[n]["Department_Master"].ToString();
					model.department_MasterPhone=dt.Rows[n]["department_MasterPhone"].ToString();
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


        public void NewUpdate(LN.Model.DepartMentInfo model)
        {
            dal.NewUpdate(model);
        }

        public void ClearUserData(string userName)
        {
            dal.ClearUserData(userName);
        }
		#endregion  ��Ա����
	}
}

