using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���POPPrice ��ժҪ˵����
	/// </summary>
	public class POPPrice
	{
		private readonly LN.DAL.POPPrice dal=new LN.DAL.POPPrice();
		public POPPrice()
		{}
		#region  ��Ա����

		/// <summary>
        /// �������ݣ����ӣ��޸ģ�
		/// </summary>
        public int Operate(List<string> strSql)
		{
            return dal.Operate(strSql);
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
		public LN.Model.POPPrice GetModel(int PriceID)
		{
			
			return dal.GetModel(PriceID);
		}


		/// <summary>
		/// ��������б�
		/// </summary>
		public IList<LN.Model.POPPrice> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// ������Ӧ�̼۸����
        /// </summary>
        /// <param name="list"></param>
        public void ExamPrice(List<string> list)
        {
            dal.ExamPrice(list);
        }
		
        /// <summary>
        /// ָ���û��Ƿ�����POP������Ҫ�ύ���ϱ���
        /// </summary>
        /// <param name="userid">�û����</param>
        /// <returns>����POPID��SupplierID</returns>
        public IList<string> IsSubmitPrice(int userid)
        {
            return dal.IsSubmitPrice(userid);
        }

        /// <summary>
        /// ָ���û��Ƿ�����POP������Ҫ�ύ���ϱ���
        /// </summary>
        /// <param name="userid">�û����</param>
        /// <returns>����POPID</returns>
        public string IsSetMPrice(int userid)
        {
            return dal.IsSetMPrice(userid);
        }
        /// <summary>
        /// �õ�ĳ��Ҫ�����Ĳ��ϱ���
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public DataSet GetExamPriceList(int supplierID)
        {
            return dal.GetExamPriceList(supplierID);
        }

		#endregion  ��Ա����
	}
}

