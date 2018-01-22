using System;
using System.Data;
using System.Collections.Generic;
using LN.Model;
namespace LN.BLL
{
	/// <summary>
	/// ҵ���߼���CityData ��ժҪ˵����
	/// </summary>
	public class CityData
	{
		private readonly LN.DAL.CityData dal=new LN.DAL.CityData();
		public CityData()
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
		public bool Exists(int CItyID)
		{
			return dal.Exists(CItyID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LN.Model.CityData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(LN.Model.CityData model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CItyID)
		{
			
			dal.Delete(CItyID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public LN.Model.CityData GetModel(int CItyID)
		{
			
			return dal.GetModel(CItyID);
		}



        /// <summary>
        /// ��������б�
        /// </summary>
        public IList<LN.Model.CityData> GetList(string strWhere)
        {
			return dal.GetList(strWhere);
		}

         /// <summary>
        /// ����ʡ�ݵõ����м���Ϣ
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetCityList(string strWhere)
        {
            return dal.GetCityList(strWhere);
        }

		#endregion  ��Ա����
	}
}

