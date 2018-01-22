using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���ShopLevel ��ժҪ˵����
	/// </summary>
	public class ShopLevel
	{
		private readonly LN.DAL.ShopLevel dal=new LN.DAL.ShopLevel();
		public ShopLevel()
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
		public bool Exists(int LevelID)
		{
			return dal.Exists(LevelID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.ShopLevel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.ShopLevel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int LevelID)
		{
			
			dal.Delete(LevelID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.ShopLevel GetModel(int LevelID)
		{
			
			return dal.GetModel(LevelID);
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
		public List<LN.Model.ShopLevel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.ShopLevel> modelList = new List<LN.Model.ShopLevel>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.ShopLevel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.ShopLevel();
					if(ds.Tables[0].Rows[n]["LevelID"].ToString()!="")
					{
						model.LevelID=int.Parse(ds.Tables[0].Rows[n]["LevelID"].ToString());
					}
					model.ShopLevelName=ds.Tables[0].Rows[n]["ShopLevel"].ToString();
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

