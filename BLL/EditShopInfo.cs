using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���EditShopInfo ��ժҪ˵����
	/// </summary>
	public class EditShopInfo
	{
		private readonly LN.DAL.EditShopInfo dal=new LN.DAL.EditShopInfo();
		public EditShopInfo()
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
		public int  Add(LN.Model.EditShopInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.EditShopInfo model)
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
		public LN.Model.EditShopInfo GetModel(int ID)
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
		public List<LN.Model.EditShopInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LN.Model.EditShopInfo> DataTableToList(DataTable dt)
		{
			List<LN.Model.EditShopInfo> modelList = new List<LN.Model.EditShopInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.EditShopInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.EditShopInfo();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["ShopID"].ToString()!="")
					{
						model.ShopID=int.Parse(dt.Rows[n]["ShopID"].ToString());
					}
					model.PosID=dt.Rows[n]["PosID"].ToString();
					model.Shopname=dt.Rows[n]["Shopname"].ToString();
					model.ShopAddress=dt.Rows[n]["ShopAddress"].ToString();
					model.ShopOpenDate=dt.Rows[n]["ShopOpenDate"].ToString();
					model.ShopCloseDate=dt.Rows[n]["ShopCloseDate"].ToString();
					if(dt.Rows[n]["CloseUserID"].ToString()!="")
					{
						model.CloseUserID=int.Parse(dt.Rows[n]["CloseUserID"].ToString());
					}
					if(dt.Rows[n]["ProvinceID"].ToString()!="")
					{
						model.ProvinceID=int.Parse(dt.Rows[n]["ProvinceID"].ToString());
					}
					if(dt.Rows[n]["CityID"].ToString()!="")
					{
						model.CityID=int.Parse(dt.Rows[n]["CityID"].ToString());
					}
					if(dt.Rows[n]["TownID"].ToString()!="")
					{
						model.TownID=int.Parse(dt.Rows[n]["TownID"].ToString());
					}
					if(dt.Rows[n]["ShopLevelID"].ToString()!="")
					{
						model.ShopLevelID=int.Parse(dt.Rows[n]["ShopLevelID"].ToString());
					}
					if(dt.Rows[n]["SaleTypeID"].ToString()!="")
					{
						model.SaleTypeID=int.Parse(dt.Rows[n]["SaleTypeID"].ToString());
					}
					model.LinkMan=dt.Rows[n]["LinkMan"].ToString();
					model.LinkPhone=dt.Rows[n]["LinkPhone"].ToString();
					model.ShopMaster=dt.Rows[n]["ShopMaster"].ToString();
					model.ShopMasterPhone=dt.Rows[n]["ShopMasterPhone"].ToString();
					model.Email=dt.Rows[n]["Email"].ToString();
					model.PostAddress=dt.Rows[n]["PostAddress"].ToString();
					model.PostCode=dt.Rows[n]["PostCode"].ToString();
					model.FaxNumber=dt.Rows[n]["FaxNumber"].ToString();
					if(dt.Rows[n]["Boolinstall"].ToString()!="")
					{
						model.Boolinstall=int.Parse(dt.Rows[n]["Boolinstall"].ToString());
					}
					model.DealerID=dt.Rows[n]["DealerID"].ToString();
					model.FXID=dt.Rows[n]["FXID"].ToString();
					model.CustomerGroupID=dt.Rows[n]["CustomerGroupID"].ToString();
					model.CustomerGroupName=dt.Rows[n]["CustomerGroupName"].ToString();
					if(dt.Rows[n]["ShopState"].ToString()!="")
					{
						model.ShopState=int.Parse(dt.Rows[n]["ShopState"].ToString());
					}
					if(dt.Rows[n]["ExamState"].ToString()!="")
					{
						model.ExamState=int.Parse(dt.Rows[n]["ExamState"].ToString());
					}
					model.VMMaster=dt.Rows[n]["VMMaster"].ToString();
					model.VMMasterPhone=dt.Rows[n]["VMMasterPhone"].ToString();
					model.DSRMaster=dt.Rows[n]["DSRMaster"].ToString();
					model.DSRMasterPhone=dt.Rows[n]["DSRMasterPhone"].ToString();
					if(dt.Rows[n]["ShopArea"].ToString()!="")
					{
						model.ShopArea=decimal.Parse(dt.Rows[n]["ShopArea"].ToString());
					}
					if(dt.Rows[n]["ShopVI"].ToString()!="")
					{
						model.ShopVI=int.Parse(dt.Rows[n]["ShopVI"].ToString());
					}
					if(dt.Rows[n]["ShopType"].ToString()!="")
					{
						model.ShopType=int.Parse(dt.Rows[n]["ShopType"].ToString());
					}
					model.ShopPhone=dt.Rows[n]["ShopPhone"].ToString();
					if(dt.Rows[n]["areaid"].ToString()!="")
					{
						model.areaid=int.Parse(dt.Rows[n]["areaid"].ToString());
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
        /// ���²�������
        /// </summary>
        /// <param name="model"></param>
        public int UpdateSub(LN.Model.EditShopInfo model)
        {
            return dal.UpdateSub(model);
        }

              /// <summary>
        /// �����޸ĵ��̵����״̬
        /// </summary>
        /// <param name="StrWhere"></param>
        public void UpdateExamState(int examState, string IDList)
        {
            dal.UpdateExamState(examState, IDList);
        }

          /// <summary>
        /// ʡ��VM���ĵ��̵����״̬
        /// </summary>
        /// <param name="examState"></param>
        /// <param name="StrWhere"></param>
        public void VMUpdateExamState(int examState, string UserID, string IDList)
        {
            dal.VMUpdateExamState(examState, UserID, IDList);
        }

		/// <summary>
        /// ��ȡ���̵����״̬
        /// </summary>
        /// <param name="ShopID">���̱��</param>
        public DataTable GetExamState(string ShopID)
        {
            return dal.GetExamState(ShopID);
        }

		#endregion  ��Ա����
	}
}

