using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���POPScaleData ��ժҪ˵����
	/// </summary>
	public class POPScaleData
	{
		private readonly LN.DAL.POPScaleData dal=new LN.DAL.POPScaleData();
		public POPScaleData()
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
		public bool Exists(int PhotoScaleID)
		{
			return dal.Exists(PhotoScaleID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.POPScaleData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.POPScaleData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PhotoScaleID)
		{
			
			dal.Delete(PhotoScaleID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.POPScaleData GetModel(int PhotoScaleID)
		{
			
			return dal.GetModel(PhotoScaleID);
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
		public List<LN.Model.POPScaleData> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.POPScaleData> modelList = new List<LN.Model.POPScaleData>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.POPScaleData model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.POPScaleData();
					if(ds.Tables[0].Rows[n]["PhotoScaleID"].ToString()!="")
					{
						model.PhotoScaleID=int.Parse(ds.Tables[0].Rows[n]["PhotoScaleID"].ToString());
					}
					model.PhotoScale=ds.Tables[0].Rows[n]["PhotoScale"].ToString();
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

