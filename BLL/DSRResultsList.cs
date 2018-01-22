using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���DSRResultsList ��ժҪ˵����
	/// </summary>
	public class DSRResultsList
	{
		private readonly LN.DAL.DSRResultsList dal=new LN.DAL.DSRResultsList();
		public DSRResultsList()
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
		public int  Add(LN.Model.DSRResultsList model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.DSRResultsList model)
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
		public LN.Model.DSRResultsList GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

        ///// <summary>
        ///// �õ�һ������ʵ�壬�ӻ����С�
        ///// </summary>
        //public LN.Model.DSRResultsList GetModelByCache(int ID)
        //{
			
        //    string CacheKey = "DSRResultsListModel-" + ID;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (LN.Model.DSRResultsList)objModel;
        //}

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
		public List<LN.Model.DSRResultsList> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.DSRResultsList> modelList = new List<LN.Model.DSRResultsList>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.DSRResultsList model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.DSRResultsList();
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					model.DataID=ds.Tables[0].Rows[n]["DataID"].ToString();
					if(ds.Tables[0].Rows[n]["CheckRulesID"].ToString()!="")
					{
						model.CheckRulesID=int.Parse(ds.Tables[0].Rows[n]["CheckRulesID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CheckResults"].ToString()!="")
					{
						model.CheckResults=int.Parse(ds.Tables[0].Rows[n]["CheckResults"].ToString());
					}
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

