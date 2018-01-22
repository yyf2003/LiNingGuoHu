using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���ComplainAcceptContent ��ժҪ˵����
	/// </summary>
	public class ComplainAcceptContent
	{
		private readonly LN.DAL.ComplainAcceptContent dal=new LN.DAL.ComplainAcceptContent();
		public ComplainAcceptContent()
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
		public bool Exists(int aID)
		{
			return dal.Exists(aID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.ComplainAcceptContent model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.ComplainAcceptContent model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int aID)
		{
			
			dal.Delete(aID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.ComplainAcceptContent GetModel(int aID)
		{
			
			return dal.GetModel(aID);
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
		public List<LN.Model.ComplainAcceptContent> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.ComplainAcceptContent> modelList = new List<LN.Model.ComplainAcceptContent>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.ComplainAcceptContent model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.ComplainAcceptContent();
					if(ds.Tables[0].Rows[n]["aID"].ToString()!="")
					{
						model.aID=int.Parse(ds.Tables[0].Rows[n]["aID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["cID"].ToString()!="")
					{
						model.cID=int.Parse(ds.Tables[0].Rows[n]["cID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["acceptUserID"].ToString()!="")
					{
						model.acceptUserID=int.Parse(ds.Tables[0].Rows[n]["acceptUserID"].ToString());
					}
					model.aInfo=ds.Tables[0].Rows[n]["aInfo"].ToString();
					model.AttachmentInfo=ds.Tables[0].Rows[n]["AttachmentInfo"].ToString();
					if(ds.Tables[0].Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[n]["CreateTime"].ToString());
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

