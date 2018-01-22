using System;
using System.Data;
using System.Collections.Generic;

using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���POPChangeSet ��ժҪ˵����
	/// </summary>
	public class POPChangeSet
	{
		private readonly LN.DAL.POPChangeSet dal=new LN.DAL.POPChangeSet();
		public POPChangeSet()
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
		public int  Add(LN.Model.POPChangeSet model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.POPChangeSet model)
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
		public LN.Model.POPChangeSet GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

 
		/// <summary>
		/// ��������б�
		/// </summary>
        public List<LN.Model.POPChangeSet> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		

		/// <summary>
		/// ��������б�
		/// </summary>
        public List<LN.Model.POPChangeSet> GetAllList()
		{
			return GetList("");
		}
        /// <summary>
        /// ��Ʒ��������
        /// </summary>
        /// <param name="sqlstr"></param>
        public void CitySet(string POPID, string CatenaProID, string sqlstr)
        {
            dal.CitySet(POPID, CatenaProID,sqlstr);
        }
              	/// <summary>
		/// ��������б�
		/// </summary>
        public DataTable Getview_List(string strWhere)
        {
            return dal.Getview_List(strWhere);
        }
          /// <summary>
        /// ��������б�
        /// </summary>
        public DataTable GetPOPprice_List(string strWhere)
        {
            return dal.GetPOPprice_List(strWhere);
        }

        /// <summary>
        /// ��ȡָ������������ķ���ID
        /// </summary>
        /// <param name="ShopID">���̱��</param>
        /// <returns>����ָ�����̲���ķ���ID</returns>
        public string GetPOPIDByShopID(string ShopID)
        {
            return dal.GetPOPIDByShopID(ShopID);
        }


         /// <summary>
        /// �������̼���pop���� add  by mhj 2012.06.04
        /// </summary>
        /// <param name="strShopid"></param>
        /// <returns></returns>
        public int JoinPopLanuch(string strShopid)
        {
            return dal.JoinPopLanuch(strShopid);
        }

        /// <summary>
        /// �������̼���pop���� add  by mhj 2015.05.10
        /// </summary>
        /// <param name="strPosId"></param>
        /// <returns></returns>
        public int JoinPopLanuchByPosId(string strPosId)
        {
            return dal.JoinPopLanuchByPosId(strPosId);
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

