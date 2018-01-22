using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���POPMateriaData ��ժҪ˵����
	/// </summary>
	public class POPMateriaData
	{
		private readonly LN.DAL.POPMateriaData dal=new LN.DAL.POPMateriaData();
		public POPMateriaData()
		{}
		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
        public int Add(string MateriaPro, string UserID, string cltype)
		{
            return dal.Add(MateriaPro, UserID, cltype);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Update(LN.Model.POPMateriaData model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int MateriaID)
		{
			
			dal.Delete(MateriaID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.POPMateriaData GetModel(int MateriaID)
		{
			
			return dal.GetModel(MateriaID);
		}

        public DataTable GetTable(string strWhere)
        {
            return dal.GetTable(strWhere);
        }

		/// <summary>
		/// ��������б�
		/// </summary>
        public List<LN.Model.POPMateriaData> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��ò������������б�
		/// </summary>
        public List<LN.Model.POPMateriaData> GetMateriaList(string strWhere)
        {
            return dal.GetMateriaList(strWhere);
        }

		/// <summary>
		/// ��������б�
		/// </summary>
        public List<LN.Model.POPMateriaData> GetAllList()
		{
			return GetList("");
		}

        /// <summary>
        /// �������AJAX��ҳ�б�
        /// </summary>
        /// <param name="model">��ҳʵ��</param>
        /// <returns>���ػ�ȡ�����б���</returns>
        public DataTable GetMateriaListPageByID(LN.Model.PageModel model, out int TotalNumber)
        {
            return dal.GetMateriaListPageByID(model,out TotalNumber);
        }

        /// <summary>
        /// �õ�ָ���û����ڹ�Ӧ�����ڲ��ϱ����嵥
        /// </summary>
        /// <param name="userID">�û����</param>
        /// <returns>���ز��ϱ����嵥�б�</returns>
        public DataTable GetMaterialPriceByUserID(string suppilerid)
        {
            return dal.GetMaterialPriceByUserID(suppilerid); 
        }

        /// <summary>
        /// �޸�ָ�����ϵ�״̬(ʹ�� �� ����)
        /// </summary>
        /// <param name="mID">���ϱ��</param>
        /// <param name="isDelete">״̬</param>
        /// <returns>���ؽ��</returns>
        public int IsDelete(int mID, int isDelete)
        {
            return dal.IsDelete(mID,isDelete);
        }
             /// <summary>
        /// ���ݵ����Ƿ�֧�ְ�װ�õ���Ӧ�Ĳ����б�
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public DataTable GetMaterialByshopID(string shopid)
        {
            return dal.GetMaterialByshopID(shopid);
        }
        public DataTable GetMaterialListData(string IsDelete)
        {
            return dal.GetMaterialListData(IsDelete);
        }
		#endregion  ��Ա����
	}
}

