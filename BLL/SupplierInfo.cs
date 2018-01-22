using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���SupplierInfo ��ժҪ˵����
	/// </summary>
	public class SupplierInfo
	{
		private readonly LN.DAL.SupplierInfo dal=new LN.DAL.SupplierInfo();
		public SupplierInfo()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.SupplierInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.SupplierInfo model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int SupplierID)
		{
			
			dal.Delete(SupplierID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.SupplierInfo GetModel(int SupplierID)
		{
			
			return dal.GetModel(SupplierID);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public IList<LN.Model.SupplierInfo> GetList(string strWhere)
		{
            return dal.GetList(strWhere);
		}
            /// <summary>
        /// ����һ���ͻ�
        /// </summary>
        /// <param name="supplierID"></param>
        /// <param name="beizhu"></param>
        public void GiveUpSup(int supplierID, string beizhu)
        {
            dal.GiveUpSup(supplierID,beizhu);
        }

        /// <summary>
        /// ��ȡָ���û�����һ���ͻ��ı�ź��û���Ȩ��
        /// </summary>
        /// <param name="UserID">�û����</param>
        /// <returns>����һ���ͻ��ı�ź��û���Ȩ��</returns>
        public IList<int> GetSupplierID(string UserID)
        {
            return dal.GetSupplierID(UserID);
        }

        /// <summary>
        /// ��ȡָ���û��Ĺ�Ӧ�̱�ź�����POP����ID
        /// </summary>
        /// <param name="userid">�û����</param>
        /// <returns>����POPID��SupplierID</returns>
        public IList<string> GetPOPIDAndSIDByUserID(int userid)
        {
            return dal.GetPOPIDAndSIDByUserID(userid);
        }

        /// <summary>
        /// ���ݹ�Ӧ�̸����˵��û�����ȡ��Ӧ��Id  add by mhj 2012.2.5
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetSupplierIdByUserName(string userName)
        {
            return dal.GetSupplierIdByUserName(userName);
        }

		#endregion  ��Ա����
	}
}

