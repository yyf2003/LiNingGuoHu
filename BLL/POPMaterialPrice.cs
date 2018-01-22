using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
using System.Collections;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���POPMaterialPrice ��ժҪ˵����
	/// </summary>
	public class POPMaterialPrice
	{
		private readonly LN.DAL.POPMaterialPrice dal=new LN.DAL.POPMaterialPrice();
		public POPMaterialPrice()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int PriceID)
		{
			return dal.Exists(PriceID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.POPMaterialPrice model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.POPMaterialPrice model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PriceID)
		{
			
			dal.Delete(PriceID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.POPMaterialPrice GetModel(int PriceID)
		{
			
			return dal.GetModel(PriceID);
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
		public List<LN.Model.POPMaterialPrice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<LN.Model.POPMaterialPrice> DataTableToList(DataTable dt)
		{
			List<LN.Model.POPMaterialPrice> modelList = new List<LN.Model.POPMaterialPrice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				LN.Model.POPMaterialPrice model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new LN.Model.POPMaterialPrice();
					if(dt.Rows[n]["PriceID"].ToString()!="")
					{
						model.PriceID=int.Parse(dt.Rows[n]["PriceID"].ToString());
					}
					if(dt.Rows[n]["SupplierID"].ToString()!="")
					{
						model.SupplierID=int.Parse(dt.Rows[n]["SupplierID"].ToString());
					}
                    if (dt.Rows[n]["MateriaID"].ToString() != "")
					{
                        model.MateriaID = int.Parse(dt.Rows[n]["MateriaID"].ToString());
					}
					if(dt.Rows[n]["POPprice"].ToString()!="")
					{
						model.POPprice=decimal.Parse(dt.Rows[n]["POPprice"].ToString());
					}
					if(dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["SysTime"].ToString()!="")
					{
						model.SysTime=DateTime.Parse(dt.Rows[n]["SysTime"].ToString());
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
        /// ���¹�Ӧ�̲��ϼ۸�
        /// </summary>
        /// <param name="htlist"></param>
        public void UpdatePrice_supplier(List<Hashtable> htlist)
        {
            dal.UpdatePrice_supplier(htlist);
        }
           /// <summary>
        /// ���¹�Ӧ�̲��ϼ۸�---�����޸�
        /// </summary>
        /// <param name="htlist"></param>
        public void UpdatePrice_all(List<Hashtable> htlist)
        {
            dal.UpdatePrice_all(htlist);
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

