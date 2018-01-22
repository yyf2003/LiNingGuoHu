using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���POPStage ��ժҪ˵����
	/// </summary>
	public class POPStage
	{
		private readonly LN.DAL.POPStage dal=new LN.DAL.POPStage();
		public POPStage()
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
		public bool Exists(int StageID)
		{
			return dal.Exists(StageID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.POPStage model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.POPStage model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int StageID)
		{
			
			dal.Delete(StageID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.POPStage GetModel(int StageID)
		{
			
			return dal.GetModel(StageID);
		}

        ///// <summary>
        ///// �õ�һ������ʵ�壬�ӻ����С�
        ///// </summary>
        //public LN.Model.POPStage GetModelByCache(int StageID)
        //{
			
        //    string CacheKey = "POPStageModel-" + StageID;
        //    object objModel = LTP.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(StageID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch{}
        //    }
        //    return (LN.Model.POPStage)objModel;
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
		public List<LN.Model.POPStage> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.POPStage> modelList = new List<LN.Model.POPStage>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.POPStage model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.POPStage();
					if(ds.Tables[0].Rows[n]["StageID"].ToString()!="")
					{
						model.StageID=int.Parse(ds.Tables[0].Rows[n]["StageID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["SupplierID"].ToString()!="")
					{
						model.SupplierID=int.Parse(ds.Tables[0].Rows[n]["SupplierID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POPID"].ToString()!="")
					{
						model.POPID=int.Parse(ds.Tables[0].Rows[n]["POPID"].ToString());
					}
					model.POPMaterial=ds.Tables[0].Rows[n]["POPMaterial"].ToString();
					if(ds.Tables[0].Rows[n]["POPprice"].ToString()!="")
					{
						model.POPprice=decimal.Parse(ds.Tables[0].Rows[n]["POPprice"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ExamUserID"].ToString()!="")
					{
						model.ExamUserID=int.Parse(ds.Tables[0].Rows[n]["ExamUserID"].ToString());
					}
					model.ExamDate=ds.Tables[0].Rows[n]["ExamDate"].ToString();
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

