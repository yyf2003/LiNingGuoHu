using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���AssignRecord ��ժҪ˵����
	/// </summary>
	public class SupplierAssignRecord
	{
		private readonly LN.DAL.SupplierAssignRecord dal=new LN.DAL.SupplierAssignRecord();
		public SupplierAssignRecord()
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
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string strWhere)
        {
            return dal.Exists(strWhere);
        }
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.SupplierAssignRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.SupplierAssignRecord model)
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
		public LN.Model.SupplierAssignRecord GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

	  /// <summary>
      /// 
      /// </summary>
      /// <param name="strWhere"></param>
      /// <returns></returns>
        public string GetSuplierIDbyArea(string strWhere)
        {
            return dal.GetSuplierIDbyArea(strWhere);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetSuplierIDListbyArea(string AreaID)
        {
            return dal.GetSuplierIDListbyArea(AreaID);
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
		public List<LN.Model.SupplierAssignRecord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<LN.Model.SupplierAssignRecord> modelList = new List<LN.Model.SupplierAssignRecord>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.SupplierAssignRecord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.SupplierAssignRecord();
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["SupplierID"].ToString()!="")
					{
						model.SupplierID=int.Parse(ds.Tables[0].Rows[n]["SupplierID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AssignRuleID"].ToString()!="")
					{
						model.AssignRuleID=int.Parse(ds.Tables[0].Rows[n]["AssignRuleID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AssignProID"].ToString()!="")
					{
						model.AssignProID=int.Parse(ds.Tables[0].Rows[n]["AssignProID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AssignCityID"].ToString()!="")
					{
						model.AssignCityID=int.Parse(ds.Tables[0].Rows[n]["AssignCityID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AssignShopID"].ToString()!="")
					{
						model.AssignShopID=int.Parse(ds.Tables[0].Rows[n]["AssignShopID"].ToString());
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
        /// ���ݷ���ĳ��� �����ڳ��еĵ���ID �ŵ� SupplierAssignRecord ����
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="cityIDlist"></param>
        /// <returns></returns>
        public bool allotshop(string gid,string PosIDlist,string dept, string areaIDlist,string Prolist)
        {
            return dal.allotshop(gid,PosIDlist,dept, areaIDlist, Prolist);
        }
		/// <summary>
        /// ��������б�
        /// </summary>
        /// <param name="model">��ҳʵ��</param>
        /// <returns>���ػ�ȡ�����б���</returns>
        public DataTable GetAssignRecordByID(LN.Model.PageModel model, out int TotalNumber)
        {
            return dal.GetAssignRecordByID(model,out TotalNumber);
        }

             /// <summary>
        /// ���ݵ��̵õ���Ӧ����Ϣ
        /// </summary>
        /// <param name="ShopID"></param>
        /// <returns></returns>
        public DataTable GetSpplierAssignRecordWithShopID(int ShopID)
        {
            return dal.GetSpplierAssignRecordWithShopID(ShopID);
        }
           /// <summary>
        /// ���ݹ�Ӧ�̵õ�����ĵ�����������
        /// </summary>
        /// <param name="Supplierid"></param>
        /// <returns></returns>
        public int GetShopData(int Supplierid)
        {
            return dal.GetShopData(Supplierid);
        }
             /// <summary>
        /// ����ͼ�еõ����ݡ� 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getdatafromView(string strWhere)
        {
            return dal.getdatafromView(strWhere);
        }
        /// <summary>
        /// �õ���Ӧ��Ӧ���������ʡ������
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataTable GetSupplierArea(int supplierID)
        {
            return dal.GetSupplierArea(supplierID);
        }
        /// <summary>
        /// �õ���Ӧ��Ӧ���������ʡ������
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataTable GetSupplierPro(int supplierID)
        {
            return dal.GetSupplierPro(supplierID);
        }

                /// <summary>
        /// ���ݹ�Ӧ�̵�ID�õ���Ӧ�����и���������POP��Ϣ
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataTable Getsupplier_popinfo(int supplierID)
        {
            return dal.Getsupplier_popinfo(supplierID);
        }


        public DataTable GetSuplierByProvinceId(int provinceid)
        {
            return dal.GetSuplierByProvinceId(provinceid);
        }
		#endregion  ��Ա����
	}
}

