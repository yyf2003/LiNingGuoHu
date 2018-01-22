using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���ApplicationData ��ժҪ˵����
	/// </summary>
	public class ApplicationData
	{
		private readonly LN.DAL.ApplicationData dal=new LN.DAL.ApplicationData();
		public ApplicationData()
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
		public int  Add(LN.Model.ApplicationData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.ApplicationData model)
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
		public LN.Model.ApplicationData GetModel(int ID)
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
		public List<LN.Model.ApplicationData> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LN.Model.ApplicationData> DataTableToList(DataTable dt)
		{
			List<LN.Model.ApplicationData> modelList = new List<LN.Model.ApplicationData>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.ApplicationData model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.ApplicationData();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["ShopID"].ToString()!="")
					{
						model.ShopID=int.Parse(dt.Rows[n]["ShopID"].ToString());
					}
					model.POSCode=dt.Rows[n]["POSCode"].ToString();
					model.POPSeatNum=dt.Rows[n]["POPSeatNum"].ToString();
					model.SeatDesc=dt.Rows[n]["SeatDesc"].ToString();
					if(dt.Rows[n]["POPHeight"].ToString()!="")
					{
						model.POPHeight=decimal.Parse(dt.Rows[n]["POPHeight"].ToString());
					}
					if(dt.Rows[n]["POPWith"].ToString()!="")
					{
						model.POPWith=decimal.Parse(dt.Rows[n]["POPWith"].ToString());
					}
					if(dt.Rows[n]["POPArea"].ToString()!="")
					{
						model.POPArea=decimal.Parse(dt.Rows[n]["POPArea"].ToString());
					}
					model.POPMaterial=dt.Rows[n]["POPMaterial"].ToString();
					if(dt.Rows[n]["ProductLineID"].ToString()!="")
					{
						model.ProductLineID=int.Parse(dt.Rows[n]["ProductLineID"].ToString());
					}
					model.Sexarea=dt.Rows[n]["Sexarea"].ToString();
					if(dt.Rows[n]["TwoSided"].ToString()!="")
					{
						model.TwoSided=int.Parse(dt.Rows[n]["TwoSided"].ToString());
					}
					if(dt.Rows[n]["Glass"].ToString()!="")
					{
						model.Glass=int.Parse(dt.Rows[n]["Glass"].ToString());
					}
					if(dt.Rows[n]["PlatformWith"].ToString()!="")
					{
						model.PlatformWith=decimal.Parse(dt.Rows[n]["PlatformWith"].ToString());
					}
					if(dt.Rows[n]["PlatformHeight"].ToString()!="")
					{
						model.PlatformHeight=decimal.Parse(dt.Rows[n]["PlatformHeight"].ToString());
					}
					if(dt.Rows[n]["PlatformLong"].ToString()!="")
					{
						model.PlatformLong=decimal.Parse(dt.Rows[n]["PlatformLong"].ToString());
					}
					if(dt.Rows[n]["ApplyUserID"].ToString()!="")
					{
						model.ApplyUserID=int.Parse(dt.Rows[n]["ApplyUserID"].ToString());
					}
					model.ApplyType=dt.Rows[n]["ApplyType"].ToString();
					model.ApplyDesc=dt.Rows[n]["ApplyDesc"].ToString();
					model.ApplyDate=dt.Rows[n]["ApplyDate"].ToString();
					model.PhotoPath=dt.Rows[n]["PhotoPath"].ToString();
					if(dt.Rows[n]["AreaVMExamState"].ToString()!="")
					{
						model.AreaVMExamState=int.Parse(dt.Rows[n]["AreaVMExamState"].ToString());
					}
					model.AreaVMExamDesc=dt.Rows[n]["AreaVMExamDesc"].ToString();
					if(dt.Rows[n]["AreaVMExamUseID"].ToString()!="")
					{
						model.AreaVMExamUseID=int.Parse(dt.Rows[n]["AreaVMExamUseID"].ToString());
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

