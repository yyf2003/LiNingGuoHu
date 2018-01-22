using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���ProductLineData ��ժҪ˵����
	/// </summary>
	public class ProductLineData
	{
		private readonly LN.DAL.ProductLineData dal=new LN.DAL.ProductLineData();
		public ProductLineData()
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
		public bool Exists(int ProductLineID)
		{
			return dal.Exists(ProductLineID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.ProductLineData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.ProductLineData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ProductLineID)
		{
			
			dal.Delete(ProductLineID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.ProductLineData GetModel(int ProductLineID)
		{
			
			return dal.GetModel(ProductLineID);
		}

	    /// <summary>
        /// ��������б�
        /// </summary>
        public List<LN.Model.ProductLineData> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

		/// <summary>
		/// ��������б�
		/// </summary>
        public DataTable GetListPageByWhere(LN.Model.PageModel model, out int TotalNumber)
		{
            return dal.GetListPageByWhere(model, out TotalNumber);
		}
        /// <summary>
        /// �õ���Ӧ����POP�Ĺ��°�����
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataTable getPOPProductTypelist(string POPID)
        {
            return dal.getPOPProductTypelist(POPID);
        }

        /// <summary>
        /// �õ���Ӧ����POP�Ĺ��°�����
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataTable getPOPProductTypelist(string POPID, string SeatName)
        {
            return dal.getPOPProductTypelist(POPID, SeatName);
        }

           /// <summary>
        /// �õ���Ӧ����POP�Ĺ��°�
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public DataTable GetPOPproductLineByTypeID(string POPID, int typeid)
        {
            return dal.GetPOPproductLineByTypeID(POPID,typeid);
        }

           /// <summary>
        /// �õ����в�Ʒϵ�е����� �������ظ���
        /// </summary>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataTable GetDistinctLine(string StrWhere)
        {
            return dal.GetDistinctLine(StrWhere);
        }
		#endregion  ��Ա����
	}
}

