using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���POPLaunch ��ժҪ˵����
	/// </summary>
	public class POPLaunch
	{
		private readonly LN.DAL.POPLaunch dal=new LN.DAL.POPLaunch();
		public POPLaunch()
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
		public int  Add(LN.Model.POPLaunch model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.POPLaunch model)
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
		public LN.Model.POPLaunch GetModel(string popID)
		{

            return dal.GetModel(popID);
		}

 
		/// <summary>
		/// ��������б�
		/// </summary>
		public IList<LN.Model.POPLaunch> GetList(string strWhere)
        {
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// �õ�����pop���漰���Ĺ��°�
        /// </summary>
        /// <param name="popid"></param>
        /// <returns></returns>
        public string GetProline(string popid)
        {
            return dal.GetProline(popid);
        }

        /// <summary>
        /// ������ɵĲ���
        /// </summary>
        /// <param name="step"></param>
        /// <param name="POPID"></param>
        public void Updatesteps(int step, string POPID)
        {
            dal.Updatesteps(step,POPID);
        }

           /// <summary>
        /// �õ�����POP��ɵĲ���
        /// </summary>
        /// <param name="POPID"></param>
        /// <returns></returns>
        public int getsetps(string POPID)
        {
            return dal.getsetps(POPID);
        }
        /// <summary>
        /// �õ�ȫ���ģУϣУɣ�
        /// </summary>
        /// <returns></returns>
        public List<string> GetPOPID()
        {
            return dal.GetPOPID();
        }

        /// <summary>
        /// �õ�ȫ���ģУϣУɣ�
        /// </summary>
        /// <returns></returns>
        public IList<LN.Model.POPLaunch> GetPOPIDList()
        {
            return dal.GetPOPIDList();
        }

        /// <summary>
        /// �õ����µģУϣУɣ�
        /// </summary>
        /// <returns></returns>
        public DataTable GetNewPOPID()
        {
            return dal.GetNewPOPID();
        }

        /// <summary>
        /// pop ���� ���յ���
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet POPAnalysis(Hashtable ht, string Procedurename, out int totalnum)
        {
            return dal.POPAnalysis(ht,Procedurename,out totalnum);
        }
             /// <summary>
        /// ���ݲ�Ʒ�������Ʒϵ�н��з���
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet POPAnalysisByPro(Hashtable ht)
        {
            return dal.POPAnalysisByPro(ht);
        }
            /// <summary>
        /// ���Ϻ͹��°����� �õ�ÿ��������������POP
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="totalnum"></param>
        /// <returns></returns>
        public DataTable EveryShopPOP(Hashtable ht, out int totalnum)
        {
            return dal.EveryShopPOP(ht,out totalnum);
        }
        /// <summary>
        /// �鿴��һ��POP�Ƿ����
        /// </summary>
        /// <returns></returns>
        public string GetLastEndDate()
        {
            return dal.GetLastEndDate();
        }

        /// <summary>
        /// �õ����·����POP
        /// </summary>
        public LN.Model.POPLaunch GetNewestModel()
        {
            return dal.GetNewestModel();
        }
        /// <summary>
        /// �õ����µ�POPID
        /// </summary>
        /// <returns></returns>
        public string GetLastPOPID()
        {
            return dal.GetLastPOPID();
        }
             /// <summary>
        /// �õ�ÿ�ڷ���POP�������������
        /// </summary>
        /// <param name="POPID">pop����ID</param>
        /// <param name="sid">��Ӧ��ID</param>
        /// <returns></returns>
        public DataTable GetTotalPOPList(string POPID, string sid,string prolist)
        {
            return dal.GetTotalPOPList(POPID, sid, prolist);
        }
              /// <summary>
        /// �õ�ÿ�η���popÿ�����̵�pop�������
        /// </summary>
        /// <param name="POPID"></param>
        /// <param name="sid"></param>
        /// <param name="prolist"></param>
        /// <returns></returns>
        public DataTable GetPOPlaunchshopPOPlist(string POPID, string sid, string prolist, int pageindex, int pagesize, out int TotalNumber)
        {
            return dal.GetPOPlaunchshopPOPlist(POPID, sid, prolist, pageindex, pagesize,out TotalNumber);
        }
              /// <summary>
        /// �����Ҫ���� ����б��� 
        /// </summary>
        /// <param name="POPID"></param>
        /// <param name="userID"></param>
        public void SetPOPprice(string POPID, string userID)
        {
            dal.SetPOPprice(POPID, userID);
        }
        /// <summary>
        /// ɾ��Ϊ������ɵ�POP
        /// </summary>
        /// <param name="popid"></param>
        public void delpoplaunch(string popid)
        {
            dal.delpoplaunch(popid);
        }
		#endregion  ��Ա����
	}
}

